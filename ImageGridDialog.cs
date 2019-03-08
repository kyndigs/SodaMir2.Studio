using SodaMir2.Studio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodaMir2.Studio
{
    public partial class ImageGridDialog : ToolWindow
    {
        public MainForm ParentForm { get; set; }

        public ImageGridDialog()
        {
            InitializeComponent();
        }

        public void InitializeImageGrid(string filename)
        {
            imageGrid1.LoadImageLibrary(filename);
        }
        
        public ImageGrid GetImageGrid()
        {
            return imageGrid1;
        }

        public Image ExportImage()
        {
            if (imageGrid1.ImageLibrary.Images[imageGrid1.SelectedIndex].Image != null)
            {
                var image = imageGrid1.ImageLibrary.GetCachedBitmapImage(imageGrid1.SelectedIndex);

                if (image != null)
                {
                    return image;
                }
            }

            return null;
        }

        private void imageGrid1_Click(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                ParentForm.UpdateImagePreview();
            }
            else
            {
                ParentForm.CreateImagePreview(imageGrid1.SelectedIndex);
                ParentForm.UpdateImagePreview();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            imageGrid1.Repaint(pe);
        }

        private void ImageGridDialog_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
