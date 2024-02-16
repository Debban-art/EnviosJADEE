using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class OrdenModel
    {
        public int Id { get; set; }
        public string Clave { get; }
        public string NombreEmisor { get; set; }

        public float CostoTotal { get; set; }

        public float Peso { get; set; }

        public string NombreDestinatario { get; set; }
        public string ApellidoPatDestinatario { get; set; }
        public string ApellidoMatDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }
        
        public int IdPais { get; set; }

        public int IdEstado { get; set; }

        public int IdMunicipio { get; set; }

        public int CodigoPostal { get; set; }

        public int idColonia { get; set; }

        public string Calle { get; set; }

        public int NoCasa { get; set; }

        public string FechaSalida { get; set; }

        public string FechaEntrega { get; set; }

        public string Estatus { get; set; }

    }
}
