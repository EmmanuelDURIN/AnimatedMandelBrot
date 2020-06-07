using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel { FractalView = new FractalView { X0 = -2, X1 = 2, Y0 = -2, Y1 = 2 } };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            this.Loaded += MainWindow_Loaded;
            // On s'abonne aux dépl. de la souris sur l'image :
            fractalImage.MouseMove += FractalImage_MouseMove;

            // On s'abonne aux click de la souris sur l'image :
            fractalImage.MouseLeftButtonDown += FractalImage_MouseLeftButtonDown;

        }

        private void FractalImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void FractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(fractalImage);
            viewModel.X = pos.X;
            viewModel.Y = pos.Y;
            // ANAIS : convertir {x,y} ecran en Coordonnées fractales avec une fonction
            //  en ecrivant une fonction dans ...
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // AnimationBuilder.MakeAnimatedGif();
            viewModel.Calculate();
        }
    }
}
