﻿using System;
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
using Modelo;
using Controlador;

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
            comboEvento.Items.Add("Seleccionar");
            comboEvento.Items.Add("Coffee Break");
            comboEvento.Items.Add("Cocktail");
            comboEvento.Items.Add("Cenas");
            comboEvento.SelectedIndex = 0;

            comboModalidad.Items.Add("Seleccionar");
            comboModalidad.Items.Add("Light Break");
            comboModalidad.Items.Add("Journal Break");
            comboModalidad.Items.Add("Day Break");
            comboModalidad.Items.Add("Quick Cocktail");
            comboModalidad.Items.Add("Ambient Cocktail");
            comboModalidad.Items.Add("Ejecutiva");
            comboModalidad.Items.Add("Celebración");
            comboModalidad.SelectedIndex = 0;
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
                ListarContratoGeneral.Background = _ib;

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
                ListarContratoGeneral.Background = _ib;

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
            ModeloContrato._contrato.Clear();
            tablaListarContrato.ItemsSource = null;
            tablaListarContrato.ItemsSource = ControladorContrato.TodosDatosContrato();
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
                lblTipoEvento.Visibility = Visibility.Visible;
                comboEvento.Visibility = Visibility.Visible;
            }
            if (!checkEmpresa.IsChecked.Value)
            {
                lblTipoEvento.Visibility = Visibility.Collapsed;
                comboEvento.Visibility = Visibility.Collapsed;
            }
        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!checkRut.IsChecked.Value && !checkEmpresa.IsChecked.Value && !checkModalidad.IsChecked.Value && !checkNroContrato.IsChecked.Value)
                {
                    ModeloContrato._contrato.Clear();
                    tablaListarContrato.ItemsSource = null;
                    tablaListarContrato.ItemsSource = ControladorContrato.TodosDatosContrato();
                    break;
                }
                if (checkRut.IsChecked.Value || checkEmpresa.IsChecked.Value || checkModalidad.IsChecked.Value || checkNroContrato.IsChecked.Value)
                {
                    ModeloContrato._contrato.Clear();
                    tablaListarContrato.ItemsSource = null;
                    if (checkRut.IsChecked.Value && checkEmpresa.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarRutEventoListarContrato(txtRut.Text, comboEvento.SelectedItem.ToString());
                        break;
                    }
                    if (checkRut.IsChecked.Value && checkModalidad.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarRutModalidadListarContrato(txtRut.Text, comboModalidad.SelectedIndex);
                        break;
                    }
                    if (checkRut.IsChecked.Value && checkEmpresa.IsChecked.Value && checkModalidad.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarTodosListarContrato(txtRut.Text, comboEvento.SelectedItem.ToString(), comboModalidad.SelectedIndex);
                        break;
                    }
                    if (checkModalidad.IsChecked.Value && checkEmpresa.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarModalidadEventoListarContrato(comboEvento.SelectedItem.ToString(), comboModalidad.SelectedIndex);
                        break;
                    }
                    if (checkRut.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarRutListarContrato(txtRut.Text);
                        break;
                    }
                    if (checkEmpresa.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarEventoListarContrato(comboEvento.SelectedItem.ToString());
                        break;
                    }
                    if (checkModalidad.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarModalidadListarContrato(comboModalidad.SelectedIndex);
                        break;
                    }
                    if (checkNroContrato.IsChecked.Value)
                    {
                        tablaListarContrato.ItemsSource = ControladorContrato.FiltrarNroContratoListarContrato(txtNroContrato.Text);
                        break;
                    }
                }

                break;
            } while (true);
        }

        private void checkModalidad_Click(object sender, RoutedEventArgs e)
        {
            if (checkModalidad.IsChecked.Value)
            {
                lblModalidad.Visibility = Visibility.Visible;
                comboModalidad.Visibility = Visibility.Visible;
            }
            if (!checkModalidad.IsChecked.Value)
            {
                lblModalidad.Visibility = Visibility.Collapsed;
                comboModalidad.Visibility = Visibility.Collapsed;
            }
        }

        private void nroContrato_Click_1(object sender, RoutedEventArgs e)
        {
            if (checkNroContrato.IsChecked.Value)
            {
                lblNroContrato.Visibility = Visibility.Visible;
                txtNroContrato.Visibility = Visibility.Visible;
            }
            if (!checkNroContrato.IsChecked.Value)
            {
                lblNroContrato.Visibility = Visibility.Collapsed;
                txtNroContrato.Visibility = Visibility.Collapsed;
            }
        }
    }
}
