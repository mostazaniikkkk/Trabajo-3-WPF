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
    /// Lógica de interacción para ListarClienteEmergente.xaml
    /// </summary>
    public partial class ListarClienteEmergente : Window
    {
        public ListarClienteEmergente()
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
                btnAltoContraste.Background = Brushes.Gray;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri("pack://application:,,,/Assets/Imagenes/BG01.png");
                bitmap.EndInit();

                ImageBrush _ib = new ImageBrush();
                _ib.ImageSource = bitmap;
                ListarClienteTemporal.Background = _ib;

                row0.Background = Brushes.Black;
                btnExit.Background = Brushes.Gray;
                lblWindow.Foreground = Brushes.LightGray;

            }
            else
            {
                btnAltoContraste.Background = Brushes.LightSteelBlue;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri("pack://application:,,,/Assets/Imagenes/BG00.png");
                bitmap.EndInit();

                ImageBrush _ib = new ImageBrush();
                _ib.ImageSource = bitmap;
                ListarClienteTemporal.Background = _ib;

                row0.Background = Brushes.LightSteelBlue;
                btnExit.Background = Brushes.LightSteelBlue;
                lblWindow.Foreground = Brushes.Black;
            }
        }

        private void tablaListarCliente_Initialized(object sender, EventArgs e)
        {
            tablaListarCliente.ItemsSource = ControladorCliente.TodosDatosClientes();
            if (ModeloCliente._cliente.Count() > 1)
            {
                ModeloCliente._cliente.RemoveAt(1);
            }

        }

        private void tablaListarCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            var selected = grid.SelectedItems;

            foreach (var item in selected)
            {
                var cliente = item as ModeloCliente;
                ModeloCliente.names.Add(cliente.RutCliente);
                ModeloCliente.names.Add(cliente.RazonSocial);
                ModeloCliente.names.Add(cliente.NombreContacto);
                ModeloCliente.names.Add(cliente.MailContacto);
                ModeloCliente.names.Add(cliente.Direccion);
                ModeloCliente.names.Add(cliente.Telefono);
            }
            
            AgregarCliente aCliente = new AgregarCliente();
            aCliente.txtRut.Text = ModeloCliente.names[0].ToString();
            aCliente.txtRazonSocial.Text = ModeloCliente.names[1].ToString();
            aCliente.txtNombreContacto.Text = ModeloCliente.names[2].ToString();
            aCliente.txtMailContacto.Text = ModeloCliente.names[3].ToString();
            aCliente.txtDireccion.Text = ModeloCliente.names[4].ToString();
            aCliente.txtTelefono.Text = ModeloCliente.names[5].ToString();

            ModeloCliente.names.Clear();

            if(btnAltoContraste.Background == Brushes.Gray)
            {
                aCliente.btnAltoContraste_Click(null, null);
            }

            aCliente.Show();
            this.Close();
        }
    }
}
