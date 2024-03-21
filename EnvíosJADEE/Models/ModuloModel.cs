using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Models
{
    internal class GetModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
         public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int Usuario { get; set; }
    }

    internal class InsertModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public int Usuario { get; set; }
    }
}
