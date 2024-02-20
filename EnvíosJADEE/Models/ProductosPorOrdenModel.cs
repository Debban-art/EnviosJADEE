using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class ProductosPorOrdenModel
    {
        public int IdOrden { get; set; }
        public string Clave { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
