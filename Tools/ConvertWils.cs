using ImageMagick;
using SodaMir2.ImageLibrary;
using SodaMir2.Studio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodaMir2.Studio.Tools
{
    public partial class ConvertWils : Form
    {
        public ConvertWils()
        {
            InitializeComponent();
        }

        WilLibrary SelectedWil { get; set; }
        int SelectedIndex { get; set; }

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            var wilcount = 0;
            long wilsize = 0;

            var slibcount = 0;
            long slibsize = 0;

            foreach (var file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
            {
                if (Path.GetExtension(file) == ".wil")
                {
                    wilcount++;
                    var fileinfo = new FileInfo(file);
                    wilsize = wilsize + fileinfo.Length;
                }

                if (Path.GetExtension(file) == ".slib")
                {
                    slibcount++;
                    var fileinfo = new FileInfo(file);
                    slibsize = slibsize + fileinfo.Length;
                }
            }

            label3.Text = wilcount.ToString();
            label5.Text = FormatBytes(wilsize);

            label8.Text = slibcount.ToString();
            label6.Text = FormatBytes(slibsize);

            //SetSourcePath();
        }

        public void SetSourcePath()
        {

            var wilcount = 0;
            long wilsize = 0;

            var slibcount = 0;
            long slibsize = 0;

            foreach (var file in Directory.GetFiles(textBox1.Text))
            {
                if (Path.GetExtension(file) == ".wil")
                {
                    wilcount++;
                    var fileinfo = new FileInfo(file);
                    wilsize = wilsize + fileinfo.Length;
                }

                if (Path.GetExtension(file) == ".slib")
                {
                    slibcount++;
                    var fileinfo = new FileInfo(file);
                    slibsize = slibsize + fileinfo.Length;
                }
            }

            label3.Text = wilcount.ToString();
            label5.Text = FormatBytes(wilsize);

            label8.Text = slibcount.ToString();
            label6.Text = FormatBytes(slibsize);
        }

        SodaImageLibrary ConvertedWil;
        int ConvertedWilSelectedIndex;

        public Image ConvertArrayToImage(byte[] bitmapArray, int width, int height)
        {
            var convertedImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var convertedImageData = convertedImage.LockBits(new System.Drawing.Rectangle(0, 0, convertedImage.Width, convertedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(bitmapArray, 0, convertedImageData.Scan0, bitmapArray.Length);

            convertedImage.UnlockBits(convertedImageData);

            return convertedImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Maximum = Convert.ToInt32(label3.Text);
                progressBar1.Enabled = true;
                backgroundWorker1.RunWorkerAsync(new List<object>() { textBox1.Text, textBox2.Text });
            }
            catch (Exception ex)
            {
                var stop = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        public int Get8BitColor(Color originalColor)
        {
            int red = ((originalColor.R * 8) / 256);
            int green = ((originalColor.G * 8) / 256);
            int blue = ((originalColor.B * 4) / 256);

            int eightBitColor = ((red << 5) | (green << 2) | blue);

            return eightBitColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            folderBrowserDialog1.ShowDialog();
            ConvertWilTask(openFileDialog1.FileName, folderBrowserDialog1.SelectedPath);
        }

        public static List<Color> ColorList = new List<Color>();

        public void ConvertWilTask(string file, string dest)
        {
            SelectedWil = new WilLibrary(file);

            var countimg = SelectedWil.Images.Count();
            SelectedWil = null;

            var title = Path.GetFileNameWithoutExtension(file);

            SodaImageLibrary lib = new SodaImageLibrary(title + ".slib");

            WilLibrary wil = new WilLibrary(file);

            for (int i = 0; i < countimg - 1; i++)
            {
                var wilimg = wil.GetCachedImage(i);

                if (wilimg != null)
                {
                    var image = new SodaImage();
                    image.Height = wil.Images[i].Height;
                    image.Width = wil.Images[i].Width;
                    image.PlacementX = wil.Images[i].PlacementX;
                    image.PlacementY = wil.Images[i].PlacementY;

                    using (var img = new MagickImage((Bitmap)wilimg))
                    {
                    tryagain:
                        try
                        {
                            img.Transparent(MagickColors.Black);
                            var newimg = img.ToBitmap();
                            image.Image = newimg;
                        }
                        catch (Exception ex)
                        {
                            var stop = true;
                            goto tryagain;
                        }
                    }

                    lib.Images.Add(image);
                }
                else
                {
                    var image = new SodaImage();
                    image.Height = 0;
                    image.Width = 0;
                    image.PlacementX = 0;
                    image.PlacementY = 0;
                    image.Image = null;

                    lib.Images.Add(image);
                }
            }

            lib.WriteToBinaryFile(dest + "\\" + title + ".slib", lib, false);

            foreach (var img in lib.Images)
                img.FreeImages();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var count = 1;
            List<object> args = e.Argument as List<object>;
            var source = args[0].ToString();
            var dest = args[1].ToString();
            foreach (var file in System.IO.Directory.GetFiles(source))
            {

                if (Path.GetExtension(file) == ".wil")
                {

                }

                backgroundWorker1.ReportProgress(count, file);
                count++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            label11.Text = "Converting " + e.ProgressPercentage + " of " + Convert.ToInt32(label3.Text);

            var slibcount = 0;
            long slibsize = 0;

            foreach (var file in Directory.GetFiles(textBox2.Text))
            {
                if (Path.GetExtension(file) == ".slib")
                {
                    slibcount++;
                    var fileinfo = new FileInfo(file);
                    slibsize = slibsize + fileinfo.Length;
                }
            }

            label8.Text = slibcount.ToString();
            label6.Text = FormatBytes(slibsize);
        }

        private void WilConvertForm_Load(object sender, EventArgs e)
        {

        }
    }
}
