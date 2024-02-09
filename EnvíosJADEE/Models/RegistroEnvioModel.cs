using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class RegistroEnvioModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public int IdProducto { get; set; } 

        public int IdEstatusOrden { get; set; }

        public float CostoTotal { get; set; }

        public float Peso { get; set; }

        public string FechaSalida { get; set; }

        public string FechaEntrega { get; set; }

        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Ciudad { get; set; }

        public string CodigoPostal { get; set; }

        public string Domicilio { get; set; }

        public string Calle { get; set; }

        public string NoCasa { get; set; }

        public int Estatus { get; set; }
    }
}
