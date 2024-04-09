namespace EnvíosJADEE.Models
{
    internal class InsertVehiculoModel
    {
        public int id { get; set; }

        public int idTipo { get; set; }
        public string matricula { get; set; }

        public int idMarca { get; set; }
        public string modelo { get; set; }

        public int NoSerie { get; set; }

    }

    internal class GetVehiculoModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NoSerie { get; set; }
        public string Estatus { get; set; }
        public string FechaModificación { get; set; }

        public int Usuario { get; set; }
    }

    internal class GetVehiculoModelCMB
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
