using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalMaker
{
    public class MainViewModel : ObservableObject, IDrawable
    {
        const int Width = 1000;
        const int Height = 1000;
        public MainViewModel()
        {
            sourceBitmap = new WriteableBitmap(
                  Width,
                  Height,
                  96,
                  96,
                  PixelFormats.Bgr32,
                  palette: null);

        }

        private double x0;

        public double X0
        {
            get { return x0; }
            set
            {
                Set(ref x0, value);
            }
        }
        private double x1;

        public double X1
        {
            get { return x1; }
            set
            {
                Set(ref x1, value);
            }
        }
        private double y0;

        public double Y0
        {
            get { return y0; }
            set
            {
                Set(ref y0, value);
            }
        }
        private double y1;

        public double Y1
        {
            get { return y1; }
            set
            {
                Set(ref y1, value);
            }
        }
        private WriteableBitmap sourceBitmap;

        public WriteableBitmap SourceBitmap
        {
            get { return sourceBitmap; }
            set { sourceBitmap = value; }
        }

        public void DrawPixel(int column, int row, Color color)
        {
            try
            {
                // Reserve the back buffer for updates.
                sourceBitmap.Lock();
                unsafe
                {
                    // Get a pointer to the back buffer.
                    IntPtr pBackBuffer = sourceBitmap.BackBuffer;

                    // Find the address of the pixel to draw.
                    pBackBuffer += row * sourceBitmap.BackBufferStride;
                    pBackBuffer += column * 4;

                    // Compute the pixel's color.
                    int color_data = color.R << 16; // R
                    color_data |= color.G << 8;   // G
                    color_data |= color.B << 0;   // B

                    // Assign the color data to the pixel.
                    *((int*)pBackBuffer) = color_data;
                }

                // Specify the area of the bitmap that changed.
                sourceBitmap.AddDirtyRect(new Int32Rect(column, row, 1, 1));
            }
            finally
            {
                // Release the back buffer and make it available for display.
                sourceBitmap.Unlock();
            }
        }

        internal void Calculate()
        {
            var mandelbrotCalculator = new MandelbrotCalculator();
            mandelbrotCalculator.Drawable = this;
            mandelbrotCalculator.CalculateImage(Width, Height, X0, X1, Y0, Y1);
        }
    }
}
