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
    }
}
