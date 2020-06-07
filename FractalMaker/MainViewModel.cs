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

        private FractalView fractalView = new FractalView { };

        public FractalView FractalView
        {
            get { return fractalView; }
            set
            {
                Set(ref fractalView, value);
            }
        }
        // champ, donnée membre
        private double x;

        // propriété
        public double X
        {
            get { return x; }
            set
            {
                // écrit dans x1 et émet un événement 
                Set(ref x, value);
            }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set
            {
                Set(ref y, value);
            }
        }

        private double zoom = 2;

        public double Zoom
        {
            get { return zoom; }
            set
            {
                Set(ref zoom, value);
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
            mandelbrotCalculator.CalculateImage(Width, Height, fractalView.X0, fractalView.X1, fractalView.Y0, fractalView.Y1);
        }
    }
}
