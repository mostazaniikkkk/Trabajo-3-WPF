using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorContrato
    {
        static string connectionString = @"Server=DESKTOP-3FLS338; Database=OnBreak; Trusted_Connection=True;";

        public static bool RetornarExisteRutContrato(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT RutCliente FROM dbo.Contrato WHERE RutCliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                try
                {
                    Console.WriteLine(dt.Rows[0].ToString());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string GenerarNumeroContrato(int type)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select convert(varchar, getdate(), @type)", connection);
                command.Parameters.AddWithValue("@type", type);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    return dt.Rows[0][0].ToString();
                }
                catch
                {
                    throw;
                }
            }
        }

        public static double CalcularValorContratoCoffee(string tipo, int asistentes, int personalAdicional)
        {
            double valorTotal = 0;
            do
            {
                if (tipo == "Light Break")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 2;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 3.5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 3.5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            double valorTotalEvento = 3 + 3 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            double valorTotalEvento = 3 + 5 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            int resto = asistentes - 50;
                            int contadorUF = 0;
                            for (int i = 1; i < resto+1; i++)
                            {
                                if (resto % i == 0)
                                {
                                    contadorUF += 2;
                                }

                            }
                            double valorTotalEvento = 3 + (5 + contadorUF) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
                if (tipo == "Journal Break")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 2;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 3.5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 3.5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            double valorTotalEvento = 8 + 3 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            double valorTotalEvento = 8 + 5 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            int resto = asistentes - 50;
                            int contadorUF = 0;
                            for (int i = 1; i < resto+1; i++)
                            {
                                if (resto % i == 0)
                                {
                                    contadorUF += 2;
                                }

                            }
                            double valorTotalEvento = 8 + (5 + contadorUF) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
                if (tipo == "Day Break")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 2;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 3.5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 3.5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            double valorTotalEvento = 12 + 3 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            double valorTotalEvento = 12 + 5 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            int resto = asistentes - 50;
                            int contadorUF = 0;
                            for (int i = 1; i < resto+1; i++)
                            {
                                if (resto % i == 0)
                                {
                                    contadorUF += 2;
                                }

                            }
                            double valorTotalEvento = 12 + (5 + contadorUF) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
            } while (true);
            return valorTotal;
        }
        public static double CalcularValorContratoCocktail(string tipo, int asistentes, int personalAdicional)
        {
            double valorTotal = 0;
            do
            {
                Console.WriteLine("Hola");
                if (tipo == "Quick Cocktail")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 2;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 3.5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 3.5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            Console.WriteLine("ENTRA<20");
                            double valorTotalEvento = 6 + 4 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            Console.WriteLine("ENTRA<50");
                            double valorTotalEvento = 6 + 6 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            Console.WriteLine("ENTRA>50!");
                            int resto = asistentes - 50;
                            int contadorUF = 0;
                            for (int i = 1; i < resto+1; i++)
                            {
                                if (i %20 == 0)
                                {
                                    contadorUF += 2;
                                }
                            }
                            double valorTotalEvento = 6 + (5 + contadorUF) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
                if (tipo == "Ambient Cocktail")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 2;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 3.5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 3.5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            double valorTotalEvento = 10 + 3 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            double valorTotalEvento = 10 + 5 + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            int resto = asistentes - 50;
                            int contadorUF = 0;
                            for (int i = 1; i < resto+1; i++)
                            {
                                if (i % 20 == 0)
                                {
                                    contadorUF += 2;
                                }

                            }
                            double valorTotalEvento = 10 + (5 + contadorUF) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
            } while (true);
            return valorTotal;
        }

        public static double CalcularValorContratoCena(string tipo, int asistentes, int personalAdicional)
        {
            double valorTotal = 0;
            do
            {
                if (tipo == "Ejecutiva")
                {
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 4;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            Console.WriteLine("ENTRA<20");
                            double valorTotalEvento = 25 + (asistentes*1.5) + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            Console.WriteLine("ENTRA<50");
                            double valorTotalEvento = 25 + (asistentes * 1.2) + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            Console.WriteLine("ENTRA>50!");
                            
                            double valorTotalEvento = 25 + (asistentes * 1) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
                if (tipo == "Celebración")
                {
                    Console.WriteLine("celebración entra");
                    try
                    {
                        double ufPersonal = 0;
                        if (personalAdicional == 2)
                        {
                            ufPersonal = 3;
                        }
                        if (personalAdicional == 3)
                        {
                            ufPersonal = 4;
                        }
                        if (personalAdicional == 4)
                        {
                            ufPersonal = 5;
                        }
                        if (personalAdicional > 4)
                        {
                            int ufAdicional = personalAdicional - 4;
                            ufPersonal = (ufAdicional * 0.5) + 5;
                        }

                        //Cambio de calculo a asistentes
                        if (asistentes > 0 && asistentes <= 20)
                        {
                            Console.WriteLine("ENTRA<20");
                            double valorTotalEvento = 35 + (asistentes * 1.5) + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 20 && asistentes <= 50)
                        {
                            Console.WriteLine("ENTRA<50");
                            double valorTotalEvento = 35 + (asistentes * 1.2) + ufPersonal;
                            valorTotal = valorTotalEvento;
                            break;
                        }
                        if (asistentes > 50)
                        {
                            Console.WriteLine("ENTRA>50!");

                            double valorTotalEvento = 35 + (asistentes * 1) + ufPersonal;
                            Console.WriteLine("valor total evento 50+ :" + valorTotalEvento);
                            valorTotal = valorTotalEvento;
                            break;
                        }

                    }
                    catch
                    {
                        throw;
                    }
                }
            } while (true);
            return valorTotal;
        }
    }
}
