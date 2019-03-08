
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SodaMir2.Studio.Component
{
    public class WILImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int PlacementX { get; set; }
        public int PlacementY { get; set; }
        public int ShadowX { get; set; }
        public int ShadowY { get; set; }
        public int Size { get; set; }

        public long ImageTime { get; set; }

        public Image Image { get; set; }

        private int convert16bitTo32bit(int color)
        {
            byte red = (byte)((color & 0xf800) >> 8);
            byte green = (byte)((color & 0x07e0) >> 3);
            byte blue = (byte)((color & 0x001f) << 3);

            return ((red << 0x10) | (green << 0x8) | blue) | (255 << 24);
        }

        private int WidthBytes(int bit, int width)
        {
            return (((width * bit) + 31) >> 5) * 4;
        }

        public unsafe void CreateTexture(BinaryReader reader)
        {
            if (Width == 0 || Height == 0) return;

            var img = new Bitmap(Width, Height);
            var MaskImage = new Bitmap(1, 1);

            BitmapData data = img.LockBits(new System.Drawing.Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte[] bytes = new byte[0];
            byte[] maskbytes = new byte[0];

            MemoryStream output;

            byte Compressed = reader.ReadByte();
            reader.ReadBytes(5);


            var input = new MemoryStream(reader.ReadBytes(Size - 6));

            output = new MemoryStream();
            byte[] buffer = new byte[10];

            DeflateStream decompress = new DeflateStream(input, CompressionMode.Decompress);

            int len;
            //try
            //{
            while ((len = decompress.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            //}
            //catch (Exception ex)
            //{
            //    var stop = true;
            //}

            bytes = output.ToArray();
            decompress.Close();
            output.Close();
            input.Close();

            int index = 0;
            int* scan0 = (int*)data.Scan0;
            {
                for (int y = Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        scan0[y * Width + x] = convert16bitTo32bit(bytes[index++] + (bytes[index++] << 8));
                    }

                    if (Width % 4 > 0)
                        index += WidthBytes(16, Width) - (Width * 2);
                }
            }

            img.UnlockBits(data);

            Image = img;
        }
    }

    public class WILHeader
    {
        public string Title { get; set; }
        public int ImageCount { get; set; }
        public int ColorCount { get; set; }
        public int Type { get; set; }
        public int Version { get; set; }
        public int Palette { get; set; }
    }

    public class WilLibrary
    {
        public WILHeader Header = new WILHeader();
        public List<int> WilIndex;
        public WILImage[] Images;

        private BinaryReader wilBinaryReader;
        private FileStream wilFileStream;

        private string WilFilePath;
        private string WixFilePath;

        public long MemoryCheckTime;

        public WilLibrary(string wilFilePath)
        {
            WilFilePath = wilFilePath;
            WixFilePath = Path.ChangeExtension(wilFilePath, ".wix");

            MemoryCheckTime = Environment.TickCount;

            try
            {
                if (File.Exists(WilFilePath) && File.Exists(WixFilePath))
                {
                    var wilImageInfo = new WILImage();

                    wilFileStream = new FileStream(WilFilePath, FileMode.Open, FileAccess.Read);
                    wilBinaryReader = new BinaryReader(wilFileStream);

                    LoadWilHeader();

                    LoadIndexFile(wilFilePath);

                    Images = new WILImage[WilIndex.Count];
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void LoadWilHeader()
        {
            wilFileStream.Seek(0, SeekOrigin.Begin);

            Header.Title = System.Text.Encoding.UTF8.GetString(wilBinaryReader.ReadBytes(44));
            Header.ImageCount = wilBinaryReader.ReadInt32();
            Header.ColorCount = wilBinaryReader.ReadInt32();
            Header.Version = wilBinaryReader.ReadInt32();
            Header.Palette = wilBinaryReader.ReadInt32();
        }

        private void LoadIndexFile(string wilFilePath)
        {
            WilIndex = new List<int>();

            FileStream stream = null;

            try
            {
                stream = new FileStream(Path.ChangeExtension(wilFilePath, ".wix"), FileMode.Open, FileAccess.Read);
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new BinaryReader(stream))
                {
                    reader.ReadBytes(52);

                    stream = null;

                    while (reader.BaseStream.Position <= reader.BaseStream.Length - 4)
                    {
                        WilIndex.Add(reader.ReadInt32());
                    }
                }
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        public byte[] DecompressImageStream(Stream compressedStream)
        {
            var decompressedImageStream = new MemoryStream();

            compressedStream.Seek(2, SeekOrigin.Begin);

            using (var compressor = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                compressor.CopyTo(decompressedImageStream);
                compressor.Close();
                return decompressedImageStream.ToArray();
            }
        }

        public Bitmap ConvertArrayToImage(byte[] bitmapArray, int width, int height)
        {
            var convertedImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var convertedImageData = convertedImage.LockBits(new System.Drawing.Rectangle(0, 0, convertedImage.Width, convertedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(bitmapArray, 0, convertedImageData.Scan0, bitmapArray.Length);

            convertedImage.UnlockBits(convertedImageData);

            return convertedImage;
        }

        public void LoadWilImage(int imageIndex)
        {
            try
            {
                wilFileStream.Position = WilIndex[imageIndex];

                var newWilImage = new WILImage();

                newWilImage.Width = wilBinaryReader.ReadInt16();
                newWilImage.Height = wilBinaryReader.ReadInt16();
                newWilImage.PlacementX = wilBinaryReader.ReadInt16();
                newWilImage.PlacementY = wilBinaryReader.ReadInt16();

                if (newWilImage.Width == 4 && newWilImage.Height == 1)
                    return;

                newWilImage.Size = newWilImage.Width * newWilImage.Height;

                var dno = wilBinaryReader.ReadInt16();
                var dno2 = wilBinaryReader.ReadInt16();

                newWilImage.Size = wilBinaryReader.ReadInt32();

                var compressedImageStream = new MemoryStream(newWilImage.Size);
                var decompressedImageStream = DecompressImageStream(compressedImageStream);

                newWilImage.ImageTime = Environment.TickCount;

                newWilImage.CreateTexture(wilBinaryReader);

                Images[imageIndex] = newWilImage;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public Image GetCachedImage(int index)
        {
            if (Images != null && index >= 0 && index <= Images.Length)
            {
                if (Images[index] == null)
                {
                    wilFileStream.Position = WilIndex[index];
                    Images[index] = new WILImage();
                }

                if (Images[index].Image == null)
                {
                    LoadWilImage(index);

                    Images[index].ImageTime = Environment.TickCount;

                    return Images[index].Image;
                }
                else
                {
                    Images[index].ImageTime = Environment.TickCount;
                    return Images[index].Image;
                }
            }

            return null;
        }

        public Image GetCachedImage(int index, ref int posx, ref int posy)
        {
            if (Images != null && index >= 0 && index <= Images.Length)
            {
                if (Environment.TickCount - MemoryCheckTime > 10000)
                {
                    MemoryCheckTime = Environment.TickCount;
                    FreeOldImageMemory();
                }

                if (Images[index] == null)
                {
                    wilFileStream.Position = WilIndex[index];
                    Images[index] = new WILImage();
                }

                if (Images[index].Image == null)
                {
                    LoadWilImage(index);

                    posx = Images[index].PlacementX;
                    posy = Images[index].PlacementY;

                    Images[index].ImageTime = Environment.TickCount;

                    return Images[index].Image;
                }
                else
                {
                    posx = Images[index].PlacementX;
                    posy = Images[index].PlacementY;

                    Images[index].ImageTime = Environment.TickCount;

                    return Images[index].Image;
                }
            }

            return null;
        }

        public void FreeOldImageMemory()
        {
            for (int i = 0; i <= Images.Length - 1; i++)
            {
                if (Images[i] != null)
                {
                    if (Environment.TickCount - Images[i].ImageTime > 30000)
                    {
                        Images[i] = null;
                    }
                }
            }
        }
    }
}