using BumpKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    double y = y0 + (y1 - y0) * j / (height - 1);
                    // double y
                    int iteration = GetIterationFromPoint(x, y);
                    //iteration = i;
                    // TODO : afficher dans écran
                    //        mettre dans fichier
                    float value =  ((float)iteration)/255F;
                    Drawable.DrawPixel(i, j, Color.FromScRgb( a : 1.0F, r: 0, g: value, b: 0 ));
                }
            }
        }

        // retourne un nombre < 256
        public int GetIterationFromPoint(double ca, double cb)
        {
            double za = 0;
            double zb = 0;
            double za1 = 0;
            double zb1 = 0;
            int i = 0;
            while (   i <255){
               za1 = ( za * za)- (zb * zb )+ ca;
               zb1 = (2 * za * zb ) + cb;
               za = za1;
               zb = zb1;               
              if (za * za + zb * zb >= 4 )
                  break; 
               i++;
            }

            //System.Diagnostics.Debug.WriteLine( $"{i}");
            return i;
        }
    }
}
