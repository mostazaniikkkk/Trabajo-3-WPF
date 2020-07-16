using Controlador;
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
    /// Lógica de interacción para AgregarContrato.xaml
    /// </summary>
    public partial class AgregarContrato : Window
    {
        public AgregarContrato()
        {
            InitializeComponent();
            comboEvento.Items.Add("Seleccionar");
            comboEvento.Items.Add("Coffee Break");
            comboEvento.Items.Add("Cocktail");
            comboEvento.Items.Add("Cenas");
            comboEvento.SelectedIndex = 0;

            comboModalidad.Items.Add("Seleccionar");
            comboModalidad.SelectedIndex = 0;
            comboModalidad.IsEnabled = false;

            GenerarComboFechaHoraInicio();
            comboFechaHoraInicio.SelectedIndex = 0;
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
                Window3.Background = _ib;

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
                Window3.Background = _ib;

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

        private void btnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            if(txtFechaTermino.Text!=""&&txtRutCliente.Text!=""&&comboEvento.SelectedIndex>0&&comboModalidad.SelectedIndex>0
            &&comboFechaHoraInicio.SelectedItem.ToString()!=""&&txtAsistentes.Text!=""&&txtPersonalAdicional.Text!=""
             && txtObservaciones.Text != "")
            {
                #region convertirDatos
                string data = ControladorContrato.GenerarNumeroContrato(20);
                string convertirData1 = data.Remove(4, 1);
                string convertirData2 = convertirData1.Remove(6, 1);
                string convertirData3 = convertirData2.Remove(8, 1);
                string convertirData4 = convertirData3.Remove(10, 1);
                string convertirData5 = convertirData4.Remove(12);
                Console.WriteLine(convertirData5);
                //string convertirFechaInt16 = convertirFechaInt13.Remove(12, 1);


                string fechaHoraInicio = data;
                //string txtFechaHoraInicioData = txtFechaHoraInicio.Text;
                //4 - 7 - 10 - 13 - 16
                //A entero txtNumeroContrato
                string convertirFechaInt4 = fechaHoraInicio.Remove(4, 1);
                string convertirFechaInt7 = convertirFechaInt4.Remove(6, 1);
                string convertirFechaInt10 = convertirFechaInt7.Remove(8, 1);
                string convertirFechaInt13 = convertirFechaInt10.Remove(8);
                //string convertirFechaInt16 = convertirFechaInt13.Remove(12, 1);
                //a entero fechaHorainicio
                //string convertirFechaInt4x = txtFechaHoraInicioData.Remove(2, 1);
                //string convertirFechaInt7x = convertirFechaInt4x.Remove(4, 1);
                //string convertirFechaInt13x = convertirFechaInt10x.Remove(10, 1);
                //string convertirFechaInt16x = convertirFechaInt13x.Remove(12, 1);
                //Console.WriteLine("Convirtiendo a entero quitando caracteres:"+convertirFechaInt13);
                //nroContrato int
                List<string> fechaAlReves = new List<string>();
                for (int i = convertirFechaInt13.Length; i > 0; i--)
                {
                    fechaAlReves.Add(convertirFechaInt13[i - 1].ToString());
                }
                long fechaIntNroContrato = long.Parse(fechaAlReves[1] + fechaAlReves[0] + fechaAlReves[3] + fechaAlReves[2] + fechaAlReves[5] + fechaAlReves[4] + fechaAlReves[7] +
                fechaAlReves[6]);
                //Hora inicio int
                //long fechaHoraInicioInt = long.Parse(convertirFechaInt7x);

                string txtFechaTerminoData = txtFechaTermino.Text;
                string convertirFechaInt4x1 = txtFechaTerminoData.Remove(2, 1);
                string convertirFechaInt7x1 = convertirFechaInt4x1.Remove(4, 1);
                long fechaTerminoInt = long.Parse(convertirFechaInt7x1);
                #endregion

                if (fechaIntNroContrato > fechaTerminoInt)
                {
                    Console.WriteLine(false);
                    dialogFechaTerminoInvalida.IsEnabled = true;
                    dialogFechaTerminoInvalida.IsOpen = true;
                }
                else
                {
                    Console.WriteLine(true);
                    txtFechaTermino.Text = txtFechaTerminoData;
                }

                #region CoffeeBreak
                if (comboModalidad.SelectedItem.ToString() == "Light Break")
                {
                    string comboFechaHoraInicioCut = comboFechaHoraInicio.SelectedItem.ToString().Remove(2);
                    int agregarHoras = int.Parse(comboFechaHoraInicioCut) + 2;
                    
                    if (agregarHoras > 24)
                    {
                        int resto = agregarHoras - 24;
                        txtFechaHoraTermino.Text ="0" + resto + ":00";
                    }
                    else
                    {
                        txtFechaHoraTermino.Text = agregarHoras + ":00";
                    }
                    if (agregarHoras < 10)
                    {
                        txtFechaHoraTermino.Text = "0" + agregarHoras + ":00";
                    }
                }
                if (comboModalidad.SelectedItem.ToString() == "Journal Break")
                {

                    string comboFechaHoraInicioCut = comboFechaHoraInicio.SelectedItem.ToString().Remove(2);
                    int agregarHoras = int.Parse(comboFechaHoraInicioCut) + 4;

                    if (agregarHoras > 24)
                    {
                        int resto = agregarHoras - 24;
                        txtFechaHoraTermino.Text = "0" + resto + ":00";
                    }
                    else
                    {
                        txtFechaHoraTermino.Text = agregarHoras + ":00";
                    }
                    if (agregarHoras < 10)
                    {
                        txtFechaHoraTermino.Text = "0" + agregarHoras + ":00";
                    }
                }
                if (comboModalidad.SelectedItem.ToString() == "Day Break")
                {

                    string comboFechaHoraInicioCut = comboFechaHoraInicio.SelectedItem.ToString().Remove(2);
                    int agregarHoras = int.Parse(comboFechaHoraInicioCut) + 8;
                    
                    if (agregarHoras > 24)
                    {
                        int resto = agregarHoras - 24;
                        txtFechaHoraTermino.Text = "0" + resto + ":00";
                    }
                    else
                    {
                        txtFechaHoraTermino.Text = agregarHoras + ":00";
                    }
                    if (agregarHoras < 10)
                    {
                        txtFechaHoraTermino.Text = "0" + agregarHoras + ":00";
                    }
                }
                #endregion

                if (comboModalidad.SelectedItem.ToString() == "Quick Cocktail")
                {

                    string comboFechaHoraInicioCut = comboFechaHoraInicio.SelectedItem.ToString().Remove(2);
                    int agregarHoras = int.Parse(comboFechaHoraInicioCut);
                    if (agregarHoras < 10)
                    {
                        txtFechaHoraTermino.Text ="0" + agregarHoras + ":30";
                    }
                    else
                    {
                        txtFechaHoraTermino.Text = agregarHoras + ":30";
                    }
                }
                if (comboModalidad.SelectedItem.ToString() == "Ambient Cocktail")
                {
                    string comboFechaHoraInicioCut = comboFechaHoraInicio.SelectedItem.ToString().Remove(2);
                    int agregarHoras = int.Parse(comboFechaHoraInicioCut) + 1;
                    
                    if (agregarHoras > 24)
                    {
                        int resto = agregarHoras - 24;
                        txtFechaHoraTermino.Text = "0" + resto + ":00";
                    }
                    else
                    {
                        txtFechaHoraTermino.Text = agregarHoras + ":00";
                    }
                    if (agregarHoras < 10)
                    {
                        txtFechaHoraTermino.Text = "0" + agregarHoras + ":00";
                    }
                }

                if (comboModalidad.SelectedItem.ToString()=="Light Break"|| comboModalidad.SelectedItem.ToString() == "Journal Break"||
                comboModalidad.SelectedItem.ToString() == "Day Break")
                {
                    try
                    {
                        if(comboEvento.SelectedIndex == 1)
                        {
                            string valorContrato = ControladorContrato.CalcularValorContratoCoffee(comboModalidad.SelectedItem.ToString(), int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)).ToString();
                            txtValorTotalContrato.Text = valorContrato;
                            txtNumeroContrato.Text = convertirData5;
                        }
                        
                    }
                    catch
                    {
                        dialogAsistenteNotNumero.IsEnabled = true;
                        dialogAsistenteNotNumero.IsOpen = true;
                    }   
                }
                if(comboModalidad.SelectedItem.ToString() == "Quick Cocktail" || comboModalidad.SelectedItem.ToString() == "Ambient Cocktail")
                {
                    try
                    {
                        if (comboEvento.SelectedIndex == 2)
                        {
                            string valorContrato = ControladorContrato.CalcularValorContratoCocktail(comboModalidad.SelectedItem.ToString(), int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)).ToString();
                            txtValorTotalContrato.Text = valorContrato;
                            txtNumeroContrato.Text = convertirData5;
                        }
                    }
                    catch
                    {
                        dialogAsistenteNotNumero.IsEnabled = true;
                        dialogAsistenteNotNumero.IsOpen = true;
                    }
                    
                }
                if (comboModalidad.SelectedItem.ToString() == "Ejecutiva" || comboModalidad.SelectedItem.ToString() == "Celebración")
                {
                    try
                    {
                        if (comboEvento.SelectedIndex == 3)
                        {
                            string valorContrato = ControladorContrato.CalcularValorContratoCena(comboModalidad.SelectedItem.ToString(), int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)).ToString();
                            txtValorTotalContrato.Text = valorContrato;
                            txtNumeroContrato.Text = convertirData5;
                        }
                    }
                    catch
                    {
                        dialogAsistenteNotNumero.IsEnabled = true;
                        dialogAsistenteNotNumero.IsOpen = true;
                    }
                    
                }
                try
                {
                    if (ControladorContrato.RetornarSiRutExisteContrato(txtRutCliente.Text))
                    {
                        if (comboModalidad.SelectedItem.ToString() == "Light Break")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CB001",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " +comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Journal Break")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CB002",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Day Break")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CB003",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " +textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Quick Cocktail")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CO001",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Ambient Cocktail")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CO002",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Ejecutiva")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CE001",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        if (comboModalidad.SelectedItem.ToString() == "Celebración")
                        {
                            string textTermino = txtFechaHoraTermino.Text;
                            ControladorContrato.AgregarContratoBaseDatos(txtNumeroContrato.Text, txtFechaCreacion.Text, txtFechaTermino.Text, txtRutCliente.Text, "CE002",
                                 comboEvento.SelectedIndex * 10, txtFechaTermino.Text + " " + comboFechaHoraInicio.SelectedItem.ToString(), txtFechaTermino.Text + " " + textTermino, int.Parse(txtAsistentes.Text), int.Parse(txtPersonalAdicional.Text)
                                 , true, int.Parse(txtValorTotalContrato.Text), txtObservaciones.Text);
                        }
                        dialogAgregarContrato.IsEnabled = true;
                        dialogAgregarContrato.IsOpen = true;
                    }
                    else
                    {
                        dialogRutNoEncontrado.IsEnabled = true;
                        dialogRutNoEncontrado.IsOpen = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    dialogAgregarContratoError.IsEnabled = true;
                    dialogAgregarContratoError.IsOpen = true;
                }

            }
            else
            {
                dialogNoDataError.IsEnabled = true;
                dialogNoDataError.IsOpen = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialogFechaHoraInvalida.IsEnabled = false;
            dialogFechaHoraInvalida.IsOpen = false;
            comboFechaHoraInicio.SelectedIndex = 0;
        }

        private void comboEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblCosas.Content = "";
            gridVariables.Margin = new Thickness(54,140,0,0);
            checkVegetariana.Visibility = Visibility.Collapsed;
            checkAmbientacionBasica.Visibility = Visibility.Collapsed;
            checkAmbientacionPersonalizada.Visibility = Visibility.Collapsed;
            checkMusica.Visibility = Visibility.Collapsed;

            comboFechaHoraInicio.Items.Clear();
            txtFechaHoraTermino.Text = "";

            GenerarComboFechaHoraInicio();
            comboFechaHoraInicio.SelectedIndex = 0;
            comboFechaHoraInicio.IsEnabled = true;
            comboModalidad.IsEnabled = true;
            comboModalidad.Items.Clear();

            comboModalidad.Items.Add("Seleccionar");
            comboModalidad.SelectedIndex = 0;
            if(comboEvento.SelectedIndex == 1)
            {
                comboModalidad.Items.Add("Light Break");
                comboModalidad.Items.Add("Journal Break");
                comboModalidad.Items.Add("Day Break");
                lblCosas.Content = "Alimentación:";
                checkVegetariana.Visibility = Visibility.Visible;
                gridVariables.Margin = new Thickness(54, 190, 0, 0);
            }
            if (comboEvento.SelectedIndex == 2)
            {
                comboModalidad.Items.Add("Quick Cocktail");
                comboModalidad.Items.Add("Ambient Cocktail");
                lblCosas.Content = "Ambientación:";
                checkAmbientacionBasica.Visibility = Visibility.Visible;
                checkAmbientacionPersonalizada.Visibility = Visibility.Visible;
                checkMusica.Visibility = Visibility.Visible;
                gridVariables.Margin = new Thickness(54, 190, 0, 0);
            }
            if (comboEvento.SelectedIndex == 3)
            {
                comboModalidad.Items.Add("Ejecutiva");
                comboModalidad.Items.Add("Celebración");
                comboFechaHoraInicio.Items.Clear();
                comboFechaHoraInicio.Items.Add("Todo el día");
                comboFechaHoraInicio.SelectedIndex = 0;
                txtFechaHoraTermino.Text = "Todo el día";
                comboFechaHoraInicio.IsEnabled = false;
                lblCosas.Content = "Ambientación:";
                checkAmbientacionBasica.Visibility = Visibility.Visible;
                checkAmbientacionPersonalizada.Visibility = Visibility.Visible;
                gridVariables.Margin = new Thickness(54, 190, 0, 0);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dialogNoDataError.IsEnabled = false;
            dialogNoDataError.IsOpen = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dialogFechaTerminoInvalida.IsEnabled = false;
            dialogFechaTerminoInvalida.IsOpen = false;
            txtFechaTermino.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dialogAsistenteNotNumero.IsEnabled = false;
            dialogAsistenteNotNumero.IsOpen = false;
        }

        //Genera los items dentro del combobox para fechahorainicio
        private void GenerarComboFechaHoraInicio()
        {
            comboFechaHoraInicio.Items.Add("Seleccionar");
            for(int i = 1; i < 25; i++)
            {
                if (i.ToString().Length > 1)
                {
                    comboFechaHoraInicio.Items.Add(i + ":00");
                }
                if (i.ToString().Length == 1)
                {
                    comboFechaHoraInicio.Items.Add("0" + i + ":00");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dialogAgregarContrato.IsEnabled = false;
            dialogAgregarContrato.IsOpen = false;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            dialogAgregarContratoError.IsEnabled = false;
            dialogAgregarContratoError.IsOpen = false;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            dialogRutNoEncontrado.IsEnabled = false;
            dialogRutNoEncontrado.IsOpen = false;
        }

        private void btnBuscarListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            ListarContratoEmergente listar = new ListarContratoEmergente();
            if (btnAltoContraste.Background == Brushes.Gray)
            {
                listar.btnAltoContraste_Click(null, null);
            }
            if (ControladorContrato.isFilasTablaContrato())
            {
                listar.Show();
                this.Close();
            }
            else
            {
                dialogIsData.IsEnabled = true;
                dialogIsData.IsOpen = true;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            dialogIsData.IsEnabled = false;
            dialogIsData.IsOpen = false;
        }
    }
}
