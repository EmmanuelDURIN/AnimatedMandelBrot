using BumpKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace FractalMaker
{
    public class AnimationBuilder
    {
        public static void MakeAnimatedGif()
        {
            //var image = Image.FromFile("");
            using (FileStream gif = File.OpenWrite("mandelbrot1.gif"))
            {
                using (var encoder = new GifEncoder(gif))
                {
                    for (int phase = 0; phase < 10; phase += 10)
                    {
                        Bitmap image = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        //image.Palette = new ColorPalette { Flags}
                        using (var context = image.CreateUnsafeContext())
                        {
                            for (var x = 0; x < context.Width; x++)
                                for (var y = 0; y < context.Height; y++)
                                {
                                    //var pixel = context.GetRawPixel(x, y);
                                    //var average = Convert.ToByte((pixel.Red + pixel.Green + pixel.Blue) / 3d);
                                    byte average = (byte)((x + phase) * 255 / context.Width);
                                    byte alpha = 255;
                                    context.SetPixel(x, y, alpha, average, average, average);
                                }
                        }
                        encoder.AddFrame(image);
                    }
                }
                //using (var binaryWriter = new BinaryWriter(gif))
                //{
                //    byte[] colorTable = Enumerable.Range(0, 768).Select(i => (byte)(i / 3)).ToArray();
                //    WriteColorTable(binaryWriter, colorTable);
                //}

            }
        }
        static void WriteColorTable(BinaryWriter Writer, byte[] colorTable)
        {
            Writer.Seek(13, SeekOrigin.Begin); // Locating the image color table
            Writer.Write(colorTable, 0, colorTable.Length);
        }
    }
}
