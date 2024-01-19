using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class DetallePerfilModel
    {
        public int Id { get; set; }
        public int IdModulo { get; set; }
        public string Modulo { get; set; }
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int Usuario { get; set; }
    }
}
