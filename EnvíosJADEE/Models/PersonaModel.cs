using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class InsertPersonaModel
    {
        public int Id { get; set; }
		public string Nombre { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string NombreUsuario { get; set; }
		public string Dirección { get; set; }
        public int IdPerfil { get; set; }
        public string Estatus { get; set; }
		public string FechaRegistro { get; set; } 
    }

    internal class GetPersonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public string Dirección { get; set; }
        public string Perfil { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int Usuario { get; set; }
    }

}
