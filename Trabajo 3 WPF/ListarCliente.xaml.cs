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
    /// Lógica de interacción para ListarCliente.xaml
    /// </summary>
    public partial class ListarCliente : Window
    {
        public ListarCliente()
        {
            InitializeComponent();
            comboEmpresa.Items.Add("Seleccionar.");
            comboEmpresa.Items.Add("SPA.");
            comboEmpresa.Items.Add("EIRL.");
            comboEmpresa.Items.Add("Limitada.");
            comboEmpresa.Items.Add("Sociedad Anónima.");
            comboEmpresa.SelectedIndex = 0;

            comboActividad.Items.Add("Seleccionar.");
            comboActividad.Items.Add("Agropecuaria.");
            comboActividad.Items.Add("Minería.");
            comboActividad.Items.Add("Manufactura.");
            comboActividad.Items.Add("Comercio.");
            comboActividad.Items.Add("Hotelería.");
            comboActividad.Items.Add("Alimentos.");
            comboActividad.Items.Add("Transporte.");
            comboActividad.Items.Add("Servicios.");
            comboActividad.SelectedIndex = 0;
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
                ListarClienteGeneral.Background = _ib;

                row0.Background = Brushes.Black;
                btnExit.Background = Brushes.Gray;
                lblWindow.Foreground = Brushes.LightGray;

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
                ListarClienteGeneral.Background = _ib;

                row0.Background = Brushes.LightSteelBlue;
                btnExit.Background = Brushes.LightSteelBlue;
                lblWindow.Foreground = Brushes.Black;
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

        private void tablaListarCliente_Initialized(object sender, EventArgs e)
        {
            
            tablaListarCliente.ItemsSource = ControladorCliente.TodosDatosClientes();
            
        }

        private void checkRut_Click(object sender, RoutedEventArgs e)
        {
            if (checkRut.IsChecked.Value)
            {
                lblRut.Visibility = Visibility.Visible;
                txtRut.Visibility = Visibility.Visible;
            }
            if (!checkRut.IsChecked.Value)
            {
                lblRut.Visibility = Visibility.Collapsed;
                txtRut.Visibility = Visibility.Collapsed;
            }
        }

        private void checkEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmpresa.IsChecked.Value)
            {
                lblEmpresa.Visibility = Visibility.Visible;
                comboEmpresa.Visibility = Visibility.Visible;
            }
            if (!checkEmpresa.IsChecked.Value)
            {
                lblEmpresa.Visibility = Visibility.Collapsed;
                comboEmpresa.Visibility = Visibility.Collapsed;
            }
        }

        private void checkActividad_Click(object sender, RoutedEventArgs e)
        {
            if (checkActividad.IsChecked.Value)
            {
                lblActividad.Visibility = Visibility.Visible;
                comboActividad.Visibility = Visibility.Visible;
            }
            if (!checkActividad.IsChecked.Value)
            {
                lblActividad.Visibility = Visibility.Collapsed;
                comboActividad.Visibility = Visibility.Collapsed;
            }
        }

        private void tablaListarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {   if(checkRut.IsChecked.Value||checkEmpresa.IsChecked.Value|| checkActividad.IsChecked.Value)
                {
                    ModeloCliente._cliente.Clear();
                    if (checkRut.IsChecked.Value)
                    {
                        if (checkEmpresa.IsChecked.Value)
                        {
                            if (checkActividad.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(txtRut.Text, comboEmpresa.SelectedItem.ToString(), comboActividad.SelectedItem.ToString());
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(txtRut.Text, comboEmpresa.SelectedItem.ToString(), "");
                            break;
                        }
                        if (checkActividad.IsChecked.Value)
                        {
                            if (checkEmpresa.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(txtRut.Text, comboActividad.SelectedItem.ToString(), comboEmpresa.SelectedItem.ToString());
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(txtRut.Text, comboEmpresa.SelectedItem.ToString(), "");
                            break;
                        }
                        tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(txtRut.Text, "", "");
                        break;
                    }

                    if (checkEmpresa.IsChecked.Value)
                    {
                        if (checkRut.IsChecked.Value)
                        {
                            if (checkActividad.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboEmpresa.SelectedItem.ToString(), txtRut.Text, comboActividad.SelectedItem.ToString());
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboEmpresa.SelectedItem.ToString(), txtRut.Text, "");
                            break;
                        }
                        if (checkActividad.IsChecked.Value)
                        {
                            if (checkRut.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboEmpresa.SelectedItem.ToString(), comboActividad.SelectedItem.ToString(), txtRut.Text);
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboEmpresa.SelectedItem.ToString(), comboActividad.SelectedItem.ToString(), "");
                            break;
                        }
                        tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboEmpresa.SelectedItem.ToString(), "", "");
                        break;
                    }

                    if (checkActividad.IsChecked.Value)
                    {
                        if (checkEmpresa.IsChecked.Value)
                        {
                            if (checkRut.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboActividad.SelectedItem.ToString(), comboEmpresa.SelectedItem.ToString(), txtRut.Text);
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboActividad.SelectedItem.ToString(), comboEmpresa.SelectedItem.ToString(), "");
                            break;
                        }
                        if (checkRut.IsChecked.Value)
                        {
                            if (checkEmpresa.IsChecked.Value)
                            {
                                tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboActividad.SelectedItem.ToString(), txtRut.Text, comboEmpresa.SelectedItem.ToString());
                                break;
                            }
                            tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboActividad.SelectedItem.ToString(), txtRut.Text, "");
                            break;
                        }
                        tablaListarCliente.ItemsSource = ControladorCliente.OrderByListarCliente(comboActividad.SelectedItem.ToString(), "", "");
                        break;
                    }
                    break;
                }
                break;
            } while (true);
            
        }
    }
}
