using BumpKit;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Media;

namespace FractalMaker
{
    public class MandelbrotCalculator
    {
        public IDrawable Drawable { get; set; }

        public void CalculateImage(int width, int height, double x0, double x1, double y0, double y1)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double x = x0 + (x1 - x0) * i / (width - 1);
                    double y = 0.0;
                    // double y
                    int iteration = GetIterationFromPoint(x, y);
                    iteration = i;
                    // TODO : afficher dans écran
                    //        mettre dans fichier
                    Drawable.DrawPixel(i, j, Color.FromRgb((byte)iteration, (byte)iteration, (byte)iteration));
                }
            }
        }
        public int GetIterationFromPoint(double x, double y)
        {

            Complex c = new Complex(x, y);
            Complex currentZ = new Complex(0, 0);

            Complex nextZ = currentZ * currentZ + c;
            currentZ = nextZ;


            return 0;
        }

    }
}
