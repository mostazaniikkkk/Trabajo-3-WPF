using Controlador;
using Modelo;
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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class AgregarCliente : Window
    { 
        public AgregarCliente()
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
                Window1.Background = _ib;

                row0.Background = Brushes.Black;
                btnExit.Background = Brushes.Gray;

                lblWindow.Foreground = Brushes.LightGray;
                lblRut.Foreground = Brushes.LightGray;
                lblRazonSocial.Foreground = Brushes.LightGray;
                lblNombreContacto.Foreground = Brushes.LightGray;
                lblMailContacto.Foreground = Brushes.LightGray;
                lblDireccion.Foreground = Brushes.LightGray;
                lblTelefono.Foreground = Brushes.LightGray;

                txtRut.Foreground = Brushes.LightGray;
                txtRazonSocial.Foreground = Brushes.LightGray;
                txtNombreContacto.Foreground = Brushes.LightGray;
                txtMailContacto.Foreground = Brushes.LightGray;
                txtDireccion.Foreground = Brushes.LightGray;
                txtTelefono.Foreground = Brushes.LightGray;
                btnCargarDatosAsociados.Background = Brushes.Gray;

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
                Window1.Background = _ib;

                row0.Background = Brushes.LightSteelBlue;
                btnExit.Background = Brushes.LightSteelBlue;

                lblWindow.Foreground = Brushes.Black;
                lblRut.Foreground = Brushes.Black;
                lblRazonSocial.Foreground = Brushes.Black;
                lblNombreContacto.Foreground = Brushes.Black;
                lblMailContacto.Foreground = Brushes.Black;
                lblDireccion.Foreground = Brushes.Black;
                lblTelefono.Foreground = Brushes.Black;

                txtRut.Foreground = Brushes.Black;
                txtRazonSocial.Foreground = Brushes.Black;
                txtNombreContacto.Foreground = Brushes.Black;
                txtMailContacto.Foreground = Brushes.Black;
                txtDireccion.Foreground = Brushes.Black;
                txtTelefono.Foreground = Brushes.Black;
                btnCargarDatosAsociados.Background = Brushes.LightBlue;

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

        private void btnCargarDatosAsociados_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text != "")
            {

                ControladorCliente.CargarDatosAsociados(txtRut.Text);
                try
                {
                    txtRazonSocial.Text = ModeloCliente.baseCliente[0];
                    txtNombreContacto.Text = ModeloCliente.baseCliente[1];
                    txtMailContacto.Text = ModeloCliente.baseCliente[2];
                    txtDireccion.Text = ModeloCliente.baseCliente[3];
                    txtTelefono.Text = ModeloCliente.baseCliente[4];
                    ModeloCliente.baseCliente.Clear();
                }
                catch (Exception)
                {
                    dialog.IsOpen = true;
                    dialog.IsEnabled = true;
                    /*MessageBoxResult result = MessageBox.Show("No se encontraron datos asociados...");
                    Console.WriteLine(result);*/
                    txtRazonSocial.Text = "";
                    txtNombreContacto.Text = "";
                    txtMailContacto.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog.IsOpen = false;
            dialog.IsEnabled = false;
        }

        private void btnBuscarListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            ListarCliente listar = new ListarCliente();
            if (btnAltoContraste.Background == Brushes.Gray)
            {
                listar.btnAltoContraste_Click(null, null);
            }
            listar.Show();
            this.Close();
        }
    }
}
