using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorCliente
    {
        static string connectionString = @"Server=DESKTOP-3FLS338; Database=OnBreak; Trusted_Connection=True;";

        /*Lo que hace este método es cargar todos los datos asociados al rut, pasando el rut como parámetro
        y llenando la lista en modelo cliente con los datos dentro de la BD si los encuentra.*/

        public static bool RetornarSiExisteRutContrato(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT RutCliente FROM dbo.Contrato WHERE RutCliente = @rut", connection);

                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    Console.WriteLine(dt.Rows[0][0].ToString());
                    if (dt.Rows[0][0] != null)
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        
        public static void CargarDatosAsociados(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT RazonSocial, NombreContacto, MailContacto, Direccion, Telefono, IdActividadEmpresa, IdTipoEmpresa FROM dbo.Cliente WHERE RutCliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);
                //cuenta los items dentro de la lista para decir en qué posición guardará el dato.
                try
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        ModeloCliente.baseCliente.Add(row["RazonSocial"].ToString());
                        ModeloCliente.baseCliente.Add(row["NombreContacto"].ToString());
                        ModeloCliente.baseCliente.Add(row["MailContacto"].ToString());
                        ModeloCliente.baseCliente.Add(row["Direccion"].ToString());
                        ModeloCliente.baseCliente.Add(row["Telefono"].ToString());
                        ModeloCliente.baseCliente.Add(row["IdActividadEmpresa"].ToString());
                        ModeloCliente.baseCliente.Add(row["IdTipoEmpresa"].ToString());
                    }
                }
                catch
                {
                    throw;
                }  
            }
        }

        public static List<ModeloCliente> TodosDatosClientes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT * FROM dbo.Cliente";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);
                //cuenta los items dentro de la lista para decir en qué posición guardará el dato.
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static void AgregarCliente(string rut, string razonSocial, string nombreContacto, string mailContacto, string direccion, string telefono, string empresa, int actividad)
        {
            int id = 0;
            do
            {
                if (empresa == "SPA")
                {
                    id = 10;
                }
                if (empresa == "EIRL")
                {
                    id = 20;
                }
                if (empresa == "Limitada")
                {
                    id = 30;
                }
                if (empresa == "Sociedad Anónima")
                {
                    id = 40;
                }
                break;
            } while (true);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "INSERT INTO dbo.Cliente(RutCliente, RazonSocial, NombreContacto, MailContacto, Direccion, Telefono, IdActividadEmpresa, IdTipoEmpresa) VALUES (@rut, @razonSocial, @nombreContacto, @mailContacto, @direccion, @telefono, @actividad, @empresa)";
                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@razonSocial", razonSocial);
                command.Parameters.AddWithValue("@nombreContacto", nombreContacto);
                command.Parameters.AddWithValue("@mailContacto", mailContacto);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@actividad", actividad);
                command.Parameters.AddWithValue("@empresa", id);
                

                //Abrir conexión y ejecutar query
                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

                connection.Close();
            }
        }

        /*Elimina el cliente y todos los datos asociados, debido a que no tiene un contrato asociado*/
        public static void EliminarClienteAsociado(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "DELETE FROM dbo.Cliente WHERE RutCliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                //Abrir conexión y ejecutar query
                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected);
                }
                catch (Exception)
                {
                    throw;
                }

                connection.Close();
            }
        }

        //Retorna true si es que se encuentran datos asociados al cliente
        public static bool isMoreDataCliente(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT RutCliente FROM dbo.Cliente WHERE RutCliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    Console.WriteLine(dt.Rows[0][0].ToString());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //Devuelve si hay filas dentro de la tabla cliente en la base de datos
        public static bool isFilasTablaCliente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT COUNT(*) FROM dbo.Cliente";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if(int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    Console.WriteLine(dt.Rows[0][0].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*Ordena dataGrid de listarCliente según el orden especificado por el cliente 
        en la ventana*/

        #region filtradoDeListarCliente

        public static List<ModeloCliente> FiltrarRutListarCliente(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE RutCliente = @rut";
                command.Parameters.AddWithValue("@rut", rut);
                  

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarEmpresaListarCliente(string empresa)
        {
            int id = 0;
            do
            {
                if (empresa == "SPA")
                {
                    id = 10;
                }
                if (empresa == "EIRL")
                {
                    id = 20;
                }
                if (empresa == "Limitada")
                {
                    id = 30;
                }
                if (empresa == "Sociedad Anónima")
                {
                    id = 40;
                }
                break;
            } while (true);
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE IdTipoEmpresa = @empresa";
                command.Parameters.AddWithValue("@empresa", id);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarActividadListarCliente(int actividad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE IdActividadEmpresa = @actividad";
                command.Parameters.AddWithValue("@actividad", actividad);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarTodosListarCliente(string rut, string empresa, int actividad)
        {
            int id = 0;
            do
            {
                if (empresa == "SPA")
                {
                    id = 10;
                }
                if (empresa == "EIRL")
                {
                    id = 20;
                }
                if (empresa == "Limitada")
                {
                    id = 30;
                }
                if (empresa == "Sociedad Anónima")
                {
                    id = 40;
                }
                break;
            } while (true);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE IdActividadEmpresa = @actividad AND RutCliente = @rut AND IdTipoEmpresa = @empresa";
                command.Parameters.AddWithValue("@actividad", actividad);
                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@empresa", id);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarRutEmpresaListarCliente(string rut, string empresa)
        {
            int id = 0;
            do
            {
                if (empresa == "SPA")
                {
                    id = 10;
                }
                if (empresa == "EIRL")
                {
                    id = 20;
                }
                if (empresa == "Limitada")
                {
                    id = 30;
                }
                if (empresa == "Sociedad Anónima")
                {
                    id = 40;
                }
                break;
            } while (true);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE RutCliente = @rut AND IdTipoEmpresa = @empresa";
                command.Parameters.AddWithValue("@rut", rut);
                command.Parameters.AddWithValue("@empresa", id);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarActividadEmpresaListarCliente(string empresa, int actividad)
        {
            int id = 0;
            do
            {
                if (empresa == "SPA")
                {
                    id = 10;
                }
                if (empresa == "EIRL")
                {
                    id = 20;
                }
                if (empresa == "Limitada")
                {
                    id = 30;
                }
                if (empresa == "Sociedad Anónima")
                {
                    id = 40;
                }
                break;
            } while (true);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE IdActividadEmpresa = @actividad AND IdTipoEmpresa = @empresa";
                command.Parameters.AddWithValue("@actividad", actividad);
                command.Parameters.AddWithValue("@empresa", id);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<ModeloCliente> FiltrarRutActividadListarCliente(string rut, int actividad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                command.CommandText = "SELECT * FROM dbo.Cliente WHERE IdActividadEmpresa = @actividad AND RutCliente = @rut";
                command.Parameters.AddWithValue("@actividad", actividad);
                command.Parameters.AddWithValue("@rut", rut);


                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente modelo = new ModeloCliente();
                        modelo.RutCliente = row["RutCliente"].ToString();
                        modelo.RazonSocial = row["RazonSocial"].ToString();
                        modelo.NombreContacto = row["NombreContacto"].ToString();
                        modelo.MailContacto = row["MailContacto"].ToString();
                        modelo.Direccion = row["Direccion"].ToString();
                        modelo.Telefono = row["Telefono"].ToString();
                        modelo.IdActividadEmpresa = int.Parse(row["IdActividadEmpresa"].ToString());
                        modelo.IdTipoEmpresa = int.Parse(row["IdTipoEmpresa"].ToString());
                        ModeloCliente._cliente.Add(modelo);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

        #endregion

        /*Devuelve las filas que tiene la tabla cliente*/
        public static int FilasTablaCliente()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT COUNT(*) FROM dbo.Cliente";

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    Console.WriteLine(dt.Rows[0][0].ToString());

                    return int.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
