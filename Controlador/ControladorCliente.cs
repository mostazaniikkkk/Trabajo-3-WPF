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
        public static void CargarDatosAsociados(string rut)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "SELECT RazonSocial, NombreContacto, MailContacto, Direccion, Telefono FROM dbo.Cliente WHERE RutCliente = @rut";
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
                        //ModeloCliente.baseCliente.Add(ModeloCliente.Singleton.ToString());
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
        public static List<ModeloCliente> OrderByListarCliente(string order1, string order2, string order3)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);

                do
                {
                    if (order1 == "RutCliente" || order1 == "IdTipoEmpresa" || order1 == "IdActividadEmpresa")
                    {
                        if(order2 == "RutCliente" || order2 == "IdTipoEmpresa" || order2 == "IdActividadEmpresa")
                        {
                            if(order3 == "RutCliente" || order3 == "IdTipoEmpresa" || order3 == "IdActividadEmpresa")
                            {
                                command.CommandText = "SELECT * FROM dbo.Cliente ORDER BY @order1, @order2, @order3";
                                command.Parameters.AddWithValue("@order1", order1);
                                command.Parameters.AddWithValue("@order2", order2);
                                command.Parameters.AddWithValue("@order3", order3);
                                break;
                            }
                            command.CommandText = "SELECT * FROM dbo.Cliente ORDER BY @order1, @order2";
                            command.Parameters.AddWithValue("@order1", order1);
                            command.Parameters.AddWithValue("@order2", order2);
                            break;
                        }
                        command.CommandText = "SELECT * FROM dbo.Cliente ORDER BY @order1";
                        command.Parameters.AddWithValue("@order1", order1);
                        break;
                    }
                } while (true);

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ModeloCliente.Singleton.RutCliente = row["RutCliente"].ToString();
                        ModeloCliente.Singleton.RazonSocial = row["RazonSocial"].ToString();
                        ModeloCliente.Singleton.NombreContacto = row["NombreContacto"].ToString();
                        ModeloCliente.Singleton.MailContacto = row["MailContacto"].ToString();
                        ModeloCliente.Singleton.Direccion = row["Direccion"].ToString();
                        ModeloCliente.Singleton.Telefono = row["Telefono"].ToString();
                        ModeloCliente._cliente.Add(ModeloCliente.Singleton);
                    }
                    return ModeloCliente._cliente;
                }
                catch
                {
                    throw;
                }
            }
        }

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
