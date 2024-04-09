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

        public string Clave { get; set; }

        public string NombreEmisor { get; set; }

        public float CostoTotal { get; set; }

        public float Peso { get; set; }
        public int CodigoPostal { get; set; }
        public string NoCasa { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string NombreDestinatario { get; set; }
        public string ApellidoPatDestinatario { get; set; }
        public string ApellidoMatDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }
        public string FechaSalida { get; set; }

        public string FechaEntrega { get; set; }

        public string EstatusDeOrden { get; set; }

        public string Estatus { get; set; }

        public string FechaRegistro { get; set; }
        public int UsuarioRegistra { get; set; }


    }
}
