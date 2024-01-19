using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class CategoríaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int Usuario { get; set; }
    }
}
