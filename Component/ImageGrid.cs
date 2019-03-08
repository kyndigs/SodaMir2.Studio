using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SodaMir2.ImageLibrary;
using System.IO;

namespace SodaMir2.Studio.Component
{
    public partial class ImageGrid : Panel
    {
        public SodaImageLibrary ImageLibrary;

        private int _cellHorizontalCount { get; set; }
        private int _cellVerticalCount { get; set; }


        public int SelectedIndex = 0;
        public bool HideMissing = false;
        public string LibraryName = "";

        public int CellWidth
        {
            get; set;
        }
        public int CellHeight { get; set; }
        public int SelectedColorAlpha { get; set; }
        public Color SelectedColor { get; set; }

        public ImageGrid()
        {
            InitializeComponent();
            HorizontalScroll.Maximum = 0;
            AutoScroll = true;
            AutoScrollMinSize = new Size(464, 592);
            ResizeRedraw = true;
            DoubleBuffered = true;
            VerticalScroll.SmallChange = 64;
            VerticalScroll.LargeChange = 64;
            CellHeight = 64;
            CellWidth = 64;
        }

        public void LoadImageLibrary(string filename)
        {
            try
            {
                var lib = new SodaImageLibrary(filename);

                if (ImageLibrary != null)
                {
                    foreach (var img in ImageLibrary.Images)
                    {
                        img.FreeImages();
                    }
                }

                LibraryName = Path.GetFileName(filename);
                ImageLibrary = lib;
                Refresh();
            }
            catch (Exception)
            {
                throw new ArgumentException("There was an exception loading the library");
            }
        }

        public Image GetBitmapImage()
        {
            return ImageLibrary.GetCachedBitmapImage(SelectedIndex);
        }

        public SodaImage GetSelectImage(int index)
        {
            return ImageLibrary.Images[index];
        }

        public SodaImage GetSelectImage()
        {
            return ImageLibrary.Images[SelectedIndex];
        }

        public void SetSelectedIndex(int index)
        {
            if (index <= ImageLibrary.Images.Count - 1)
            {
                SelectedIndex = index;
            }

            this.Refresh();
        }

        public static Size ResizeKeepAspect(Size CurrentDimensions, int maxWidth, int maxHeight)
        {
            int newHeight = CurrentDimensions.Height;
            int newWidth = CurrentDimensions.Width;
            if (maxWidth > 0 && newWidth > maxWidth) //WidthResize
            {
                Decimal divider = Math.Abs((Decimal)newWidth / (Decimal)maxWidth);
                newWidth = maxWidth;
                newHeight = (int)Math.Round((Decimal)(newHeight / divider));
            }
            if (maxHeight > 0 && newHeight > maxHeight) //HeightResize
            {
                Decimal divider = Math.Abs((Decimal)newHeight / (Decimal)maxHeight);
                newHeight = maxHeight;
                newWidth = (int)Math.Round((Decimal)(newWidth / divider));
            }

            return new Size(newWidth, newHeight);
        }

        public void ScrollToIndex(int index)
        {
            //var row = (_cellHorizontalCount / CellHeight) * index;
            //this.VerticalScroll.Value = row * index;
            //this.Refresh();
        }

        protected override void OnClick(EventArgs e)
        {
            var row = ((this.VerticalScroll.Value) + this.PointToClient(Cursor.Position).Y) / CellHeight;
            var column = this.PointToClient(Cursor.Position).X / CellWidth;
            var index = column + row * _cellHorizontalCount;

            if (index <= ImageLibrary.Images.Count - 1)
                SelectedIndex = index;

            this.Refresh();
            base.OnClick(e);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            var DrawStart = (this.VerticalScroll.Value / CellHeight);

            this.VerticalScroll.Value = DrawStart * CellHeight;
            this.Refresh();
            base.OnScroll(se);
        }


        private int DrawStart { get; set; }

        public void Repaint(PaintEventArgs pe)
        {
            pe.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            Graphics g = pe.Graphics;

            if (ImageLibrary != null)
            {
                _cellHorizontalCount = Width / CellWidth;
                _cellVerticalCount = Height / CellHeight;

                int numOfCells = ImageLibrary.Images.Count - 1;

                var rows = numOfCells / _cellHorizontalCount + 3;
                this.AutoScrollMinSize = new Size(464, (rows * CellHeight) + CellHeight);

                DrawStart = (this.VerticalScroll.Value / CellHeight);

                this.VerticalScroll.Value = DrawStart * CellHeight;

                if (DrawStart < 0)
                    DrawStart = 0;

                var startIndex = (DrawStart * _cellHorizontalCount);


                if (startIndex < 0)
                    startIndex = 0;

                var endIndex = startIndex + (_cellVerticalCount * _cellHorizontalCount);

                if (endIndex > numOfCells)
                    endIndex = numOfCells + 1;

                int row = 0;
                int col = 0;

                for (var i = 0; i < endIndex; i++)
                {
                    var item = ImageLibrary.Images[i];

                    if (item.Size != 0)
                    {
                        if (i >= startIndex)
                        {
                            var img = ImageLibrary.GetCachedBitmapImage(i, false);

                            if (img != null)
                            {
                                if (img.Height >= CellHeight || img.Width >= CellWidth)
                                {
                                    var newsize = ResizeKeepAspect(img.Size, CellWidth - 2, CellHeight - 2);
                                    g.DrawImage(img, 0 + (CellWidth * col) + ((CellWidth / 2) - newsize.Width / 2), 0 + (CellHeight * row) + ((CellHeight/2) - newsize.Height / 2), newsize.Width, newsize.Height);
                                }
                                else
                                {
                                    g.DrawImage(img, 0 + (CellWidth * col) + ((CellWidth / 2) - img.Width / 2), 0 + (CellHeight * row) + ((CellHeight / 2) - img.Height / 2), img.Width, img.Height);
                                }

                                img.Dispose();
                            }
                        }
                        else
                        {
                            ImageLibrary.Images[i].FreeImages();
                        }
                    }

                    if (i >= startIndex)
                    {
                        String drawString = i.ToString();

                        Font drawFont = new Font("Arial", 10);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        PointF drawPoint = new PointF(0 + (CellWidth * col) + (CellWidth / 2) - (int)(g.MeasureString(i.ToString(), drawFont).Width / 2), 0 + (CellHeight * row) + (CellHeight - 14));
                        g.DrawString(drawString, drawFont, drawBrush, drawPoint);

                        Pen p = new Pen(Color.Black);
                        g.DrawRectangle(p, new Rectangle(0 + (CellWidth * col), 0 + (CellHeight * row), CellWidth, CellHeight));
                    }

                    if (i == SelectedIndex)
                    {
                        var selectedBrushOverlay = new SolidBrush(Color.FromArgb(SelectedColorAlpha, SelectedColor.R, SelectedColor.G, SelectedColor.B));
                        g.FillRectangle(selectedBrushOverlay, new Rectangle(0 + (CellWidth * col), 0 + (CellWidth * row), CellWidth, CellHeight));
                    }

                    if (col == _cellHorizontalCount - 1)
                    {
                        col = 0;
                        row++;
                    }
                    else
                    {
                        col++;
                    }
                }
            }
            else
            {
                String drawString = "No Library Loaded";

                Font drawFont = new Font("Arial", 18);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                PointF drawPoint = new PointF((this.Width / 2) - (g.MeasureString(drawString, drawFont).Width / 2), (this.Height / 2) - (g.MeasureString(drawString, drawFont).Height / 2));
                g.DrawString(drawString, drawFont, drawBrush, drawPoint);
            }

            //base.OnPaint(pe);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Repaint(pe);
        }
    }
}
