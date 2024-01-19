using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class VehiculoModel
    {
        public int id { get; set; }

        public int idTipo {  get; set; }
        public string tipo { get; set; }
        public string matricula { get; set; }

        public int idMarca { get; set; }

        public string marca { get; set; }
        public string modelo { get; set; }

        public int NoSerie { get; set; }

        public string FechaRegistro { get; set; }
       

        public string estatus { get; set; }


    }
}
