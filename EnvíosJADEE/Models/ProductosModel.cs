using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class ProductosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int IdCategoria { get; set; }

        public string Categoria { get; set;}

        public float Precio { get; set; }

        public float Peso { get; set; }

        public int UsuarioRegistra { get; set; }

        public string FechaRegistro { get; set; }

        public string Estatus { get; set; }
    }
}
