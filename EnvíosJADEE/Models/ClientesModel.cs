using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class ClientesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string País { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Domicilio { get;set; }
        public string Calle { get;set; }
        public string NoCasa { get;set; }
        public int Estatus { get; set; }


    }
}
