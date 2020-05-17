using BumpKit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FractalMaker
{
    public class MandelbrotCalculator
    {
        // plus tard
        public  void CalculateImage(int width, int height, double x0, double x1 )
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double x = x0 +(x1-x0) *i /(width-1);
                    // double y
                     int iteration = GetIterationFromPoint( x,  y);
                     // TODO : afficher dans écran
                     //        mettre dans fichier
                }
            }


        }
        public  int GetIterationFromPoint(double x, double y)
        {

            Complex c = new Complex(x,y);
            Complex currentZ = new Complex(0,0);
            
            Complex nextZ = currentZ*currentZ +c;
            currentZ = nextZ;


            return ;
        }
       
    }
}
