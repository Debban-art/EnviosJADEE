using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvíosJADEE.Models
{
    internal class DetallesEnvíoModel
    {
        public int Id { get; set; }

        public string Clave { get; set; }

        public string NombreEmisor { get; set; }

        public float CostoTotal { get; set; }

        public float Peso { get; set; }
        public int CodigoPostal { get; set; }
        public string NoCasa { get; set; }
        public string Calle { get; set; }
        public int IdColonia { get; set; }
        public int IdMunicipio { get; set; }
        public int IdEstado { get; set; }
        public int IdPais { get; set; }
        public string NombreDestinatario { get; set; }
        public string ApellidoPatDestinatario { get; set; }
        public string ApellidoMatDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }

        public int IdRepartidor { get; set; }
        public string ClaveRepartidor { get; set;  }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public string FechaSalida { get; set; }

        public string FechaEntrega { get; set; }

        public int IdEstatusDeOrden { get; set; }

        public int UsuarioRegistra { get; set; }

        public string FechaRegistro { get; set; }

        public string Estatus { get; set; }

    }
}
