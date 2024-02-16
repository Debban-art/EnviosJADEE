using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class ColoniaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Asentamiento { get; set;
        }
        public int CodigoPostal { get; set;}

        public int IdMunicipio { get; set;}
    }

}
