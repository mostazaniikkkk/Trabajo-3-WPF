using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCliente
    {
        //para traer datos de listaCliente a agregarCliente
        public static List<string> names = new List<string>();
        //para traer datos sql
        public static List<string> baseCliente = new List<string>();

        //lista modelo
        static List<ModeloCliente> cliente = new List<ModeloCliente>();
        public static List<ModeloCliente> _cliente { get { return cliente; } }

        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        static ModeloCliente instancia;
        private ModeloCliente() { }

        public static ModeloCliente Singleton
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ModeloCliente();
                }
                return instancia;
            }
        }
    }
}