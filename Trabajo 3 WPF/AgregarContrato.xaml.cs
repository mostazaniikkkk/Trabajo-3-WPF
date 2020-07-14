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
            &&txtFechaHoraInicio.Text!=""&&txtAsistentes.Text!=""&&txtPersonalAdicional.Text!=""
            && txtRealizado.Text != "" && txtValorTotalContrato.Text != "" && txtObservaciones.Text != "")
            {
                #region convertirDatos
                string data = ControladorContrato.GenerarNumeroContrato(20);
                string convertirData1 = data.Remove(4, 1);
                string convertirData2 = convertirData1.Remove(6, 1);
                string convertirData3 = convertirData2.Remove(8, 1);
                string convertirData4 = convertirData3.Remove(10, 1);
                string convertirData5 = convertirData4.Remove(12, 1);
                Console.WriteLine(convertirData5);
                //string convertirFechaInt16 = convertirFechaInt13.Remove(12, 1);


                string fechaHoraInicio = data;
                string txtFechaHoraInicioData = txtFechaHoraInicio.Text;
                //4 - 7 - 10 - 13 - 16
                //A entero txtNumeroContrato
                string convertirFechaInt4 = fechaHoraInicio.Remove(4, 1);
                string convertirFechaInt7 = convertirFechaInt4.Remove(6, 1);
                string convertirFechaInt10 = convertirFechaInt7.Remove(8, 1);
                string convertirFechaInt13 = convertirFechaInt10.Remove(8);
                //string convertirFechaInt16 = convertirFechaInt13.Remove(12, 1);
                //a entero fechaHorainicio
                string convertirFechaInt4x = txtFechaHoraInicioData.Remove(2, 1);
                string convertirFechaInt7x = convertirFechaInt4x.Remove(4, 1);
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
                //Console.WriteLine("A entero:" + fechaIntNroContrato);
                //Hora inicio int
                long fechaHoraInicioInt = long.Parse(convertirFechaInt7x);
                // Console.WriteLine("A entero 1:" + fechaHoraInicioInt);

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

                if (fechaIntNroContrato > fechaHoraInicioInt)
                {
                    Console.WriteLine(false);
                    dialogFechaHoraInvalida.IsEnabled = true;
                    dialogFechaHoraInvalida.IsOpen = true;

                }
                else
                {
                    Console.WriteLine(true);
                    txtFechaHoraTermino.Text = txtFechaHoraInicio.Text;
                }

                if(comboModalidad.SelectedItem.ToString()=="Light Break"|| comboModalidad.SelectedItem.ToString() == "Journal Break"||
                comboModalidad.SelectedItem.ToString() == "Day Break")
                {
                    try
                    {
                        ControladorContrato.CalcularValorContrato(comboModalidad.SelectedItem.ToString(), int.Parse(txtAsistentes.Text));
                        txtNumeroContrato.Text = convertirData5;
                    }
                    catch
                    {
                        dialogAsistenteNotNumero.IsEnabled = true;
                        dialogAsistenteNotNumero.IsOpen = true;
                    }   
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
            txtFechaHoraInicio.Text = "";
        }

        private void comboEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboModalidad.IsEnabled = true;
            comboModalidad.Items.Clear();

            comboModalidad.Items.Add("Seleccionar");
            comboModalidad.SelectedIndex = 0;
            if(comboEvento.SelectedIndex == 1)
            {
                comboModalidad.Items.Add("Light Break");
                comboModalidad.Items.Add("Journal Break");
                comboModalidad.Items.Add("Day Break");
            }
            if (comboEvento.SelectedIndex == 2)
            {
                comboModalidad.Items.Add("Quick Cocktail");
                comboModalidad.Items.Add("Ambient Cocktail");
            }
            if (comboEvento.SelectedIndex == 3)
            {
                comboModalidad.Items.Add("Ejecutiva");
                comboModalidad.Items.Add("Celebración");
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
    }
}
