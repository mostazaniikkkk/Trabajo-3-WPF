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
using System.Windows.Shapes;

namespace Trabajo_3_WPF
{
    /// <summary>
    /// Lógica de interacción para ListarContrato.xaml
    /// </summary>
    public partial class ListarContrato : Window
    {
        public ListarContrato()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnExit.Background = Brushes.Salmon;
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnExit.Background = Brushes.LightSteelBlue;
            if (btnAltoContraste.Background == Brushes.Gray)
            {
                btnExit.Background = Brushes.Gray;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void btnAltoContraste_Click(object sender, RoutedEventArgs e)
        {
            if (btnAltoContraste.Background == Brushes.LightSteelBlue)
            {
                btnVolver.Background = Brushes.Gray;
                btnAltoContraste.Background = Brushes.Gray;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri("pack://application:,,,/Assets/Imagenes/BG01.png");
                bitmap.EndInit();

                ImageBrush _ib = new ImageBrush();
                _ib.ImageSource = bitmap;
                Window4.Background = _ib;

                row0.Background = Brushes.Black;
                btnExit.Background = Brushes.Gray;

            }
            else
            {
                btnVolver.Background = Brushes.LightSteelBlue;
                btnAltoContraste.Background = Brushes.LightSteelBlue;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri("pack://application:,,,/Assets/Imagenes/BG00.png");
                bitmap.EndInit();

                ImageBrush _ib = new ImageBrush();
                _ib.ImageSource = bitmap;
                Window4.Background = _ib;

                row0.Background = Brushes.LightSteelBlue;
                btnExit.Background = Brushes.LightSteelBlue;

            }
        }

        private void btnVolver_MouseEnter(object sender, MouseEventArgs e)
        {
            btnVolver.Background = Brushes.LightGreen;
        }

        private void btnVolver_MouseLeave(object sender, MouseEventArgs e)
        {
            btnVolver.Background = Brushes.LightSteelBlue;
            if (btnAltoContraste.Background == Brushes.Gray)
            {
                btnVolver.Background = Brushes.Gray;
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            if (btnAltoContraste.Background == Brushes.Gray)
            {
                main.btnAltoContraste_Click(null, null);
            }
            main.Show();
            this.Close();
        }
    }
}
