using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class PersonaModel
    {
        public int Id { get; set; }
		public string Nombre { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string Dirección { get; set; }
		public string Estatus { get; set; }
		public string FechaRegistro { get; set; }
		public int UsuarioRegistra { get; set; } 
    }
}
