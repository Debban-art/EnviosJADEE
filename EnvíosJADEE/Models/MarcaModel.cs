using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class MarcaModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }

        public string Estatus { get; set; }
        public string FechaModificación { get; set; }
        public int Usuario { get; set; }
    }
}
