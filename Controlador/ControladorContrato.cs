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
            using(SqlConnection connection = new SqlConnection(connectionString))
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

        public static void CalcularValorContrato(string tipo, int asistentes)
        {
            if (tipo == "Light Break")
            {
                
                try
                {
                    if (asistentes > 0 && asistentes <= 20)
                    {
                        int valorTotalEvento = 3 + 3;
                    }
                    if (asistentes> 20 && asistentes <= 50)
                    {
                        int valorTotalEvento = 3 + 5;
                    }
                    if (asistentes > 50)
                    {
                        int resto = asistentes - 50;
                        int contadorUF = 0;
                        for (int i = 1; i < resto; i++)
                        {
                            if (resto % i == 0)
                            {
                                contadorUF += 2;
                            }

                        }
                        int valorTotalEvento = 3 + (5 + contadorUF);
                        Console.WriteLine("valor total evento 50+ :" + contadorUF);
                    }
                }
                catch
                {
                    throw;                    
                }
            }
        }
    }
}
