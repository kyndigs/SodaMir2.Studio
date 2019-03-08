using SodaMir2.ImageLibrary;
using SodaMir2.Studio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SodaMir2.Studio
{
    public partial class ImagePreviewDocument : DockContent
    {
        public SodaImage CurrentImage { get; set; }
        public int CurrentImageIndex { get; set; }
        public ImageProperties CurrentProperties { get; set; }
        public bool FirstOpenComplete { get; set; }

        private MainForm _parentForm { get; set; }

        public ImagePreviewDocument()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        public void Initialize(MainForm parent)
        {
            _parentForm = parent;
        }

        public void ChangeImageInterpolation(InterpolationMode mode)
        {
            Bitmap newimage = new Bitmap(selectedPicturePreviewBox.Image.Width, selectedPicturePreviewBox.Image.Height);

            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newimage))
            {
                g.InterpolationMode = mode;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.DrawImage(CurrentImage.Image, new Rectangle(0, 0, newimage.Width, newimage.Height));
            }

            selectedPicturePreviewBox.Image = newimage;
        }

        public void ZoomImage(double value)
        {
            if (selectedPicturePreviewBox.Image != null)
            {
                var image = selectedPicturePreviewBox.Image;

                var newimage = selectedPicturePreviewBox.Image = selectedPicturePreviewBox.Image;
                var newSize = new Size((int)(newimage.Width * Convert.ToDouble(value)), (int)(newimage.Height * Convert.ToDouble(value)));
                var bmp = new Bitmap(newimage, newSize);

                selectedPicturePreviewBox.Image = bmp;
            }
        }

        public void UpdateImage(double zoom, InterpolationMode mode)
        {
            ZoomImage(zoom);
            ChangeImageInterpolation(mode);
        }

        public void RefreshImage(ImageGrid grid)
        {
            var img = grid.GetSelectImage(CurrentImageIndex);

            if (img.Image != null)
            {
                selectedPicturePreviewBox.Image = grid.GetBitmapImage();
                CurrentImage = grid.GetSelectImage();
                CurrentImageIndex = grid.SelectedIndex;
            }
            else
            {
                selectedPicturePreviewBox.Image = null;
                CurrentImage = null;
                CurrentImageIndex = 0;
            }
        }

        public void SetImage(ImageGrid grid)
        {
            var img = grid.GetSelectImage();

            if (img.Image != null)
            {
                selectedPicturePreviewBox.Image = grid.GetBitmapImage();
                CurrentImage = grid.GetSelectImage();
                CurrentImageIndex = grid.SelectedIndex;
            }
            else
            {
                selectedPicturePreviewBox.Image = null;
                CurrentImage = null;
                CurrentImageIndex = 0;
            }
        }

        private void SelectedPicturePreviewBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPicturePreviewBox.Image != null)
            {
                var pt = new Point(selectedPicturePreviewBox.Width / 2 - selectedPicturePreviewBox.Image.Width / 2, selectedPicturePreviewBox.Height / 2 - selectedPicturePreviewBox.Image.Height / 2);

                var x = e.X - pt.X;
                var y = e.Y - pt.Y;
                _parentForm.UpdateCoords(x, y);
            }
        }
    }
}
