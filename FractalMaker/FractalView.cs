using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace FractalMaker
{
     // on hérite de ObservableObject, ça nous permet d'avoir la méthode Set
    public class FractalView : ObservableObject
    {
        private double x0;

        public double X0
        {
            get { return x0; }
            set
            {
                Set(ref x0, value);
            }
        }
        // champ, donnée membre
        private double x1;

        // propriété
        public double X1
        {
            get { return x1; }
            set
            {
                // écrit dans x1 et émet un événement 
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
    }
}
