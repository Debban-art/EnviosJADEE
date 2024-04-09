using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class InsertRepartidorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdVehiculo { get; set; }
        public int UsuarioRegistra { get; set; }
    }

    internal class GetRepartidorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string ClaveRepartidor { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int UsuarioRegistra { get; set; }

    }
}
