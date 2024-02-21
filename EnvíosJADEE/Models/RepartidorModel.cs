using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class RepartidorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdVehiculo { get; set; }
        public string ClaveRepartidor { get; set; } 
        public string FechaRegistro { get; set; }
        public int UsuarioRegistra { get; set; }
        public string Estatus { get; set; }

    }
}
