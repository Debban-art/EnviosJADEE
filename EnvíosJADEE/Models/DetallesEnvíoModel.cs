using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class DetallesEnvíoModel
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public int IdEstatusOrden { get; set; }
        public int IdMueble { get; set; }
        public string FechaSalida { get; set; }
        public string FechaEntrega { get; set; }
        public int Estatus { get; set; }
    }
}
