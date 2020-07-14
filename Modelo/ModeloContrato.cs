using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ModeloContrato
    {
        public string NroContrato { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaTermino { get; set; }
        public string RutCliente { get; set; }
        public int IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string FechaHorainicio { get; set; }
        public string FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }

        public ModeloContrato(){ }

    }
}
