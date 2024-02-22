using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class FiltrarOrdenesService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public List<DetallesOrdenFiltradoModel> GetOrdenesFiltradaFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = System.Data.SqlDbType.Date, Value = FechaInicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.Date, Value = FechaFinal });
            List<DetallesOrdenFiltradoModel> lista = new List<DetallesOrdenFiltradoModel>();
            try
            {
                DataSet ds = dac.Fill("FiltrarOrdenesFecha", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                      .Select(dataRow => new DetallesOrdenFiltradoModel
                      {
                          Id = int.Parse(dataRow["Id"].ToString()),
                          Clave = dataRow["Clave"].ToString(),
                          NombreEmisor = dataRow["NombreEmisor"].ToString(),
                          CostoTotal = float.Parse(dataRow["Costototal"].ToString()),
                          Peso = float.Parse(dataRow["Peso"].ToString()),
                          CodigoPostal = int.Parse(dataRow["CodigoPostal"].ToString()),
                          NoCasa = dataRow["NoCasa"].ToString(),
                          Calle = dataRow["Calle"].ToString(),
                          Colonia = dataRow["Colonia"].ToString(),
                          Municipio = dataRow["Municipio"].ToString(),
                          Estado = dataRow["Estado"].ToString(),
                          Pais = dataRow["Pais"].ToString(),
                          NombreDestinatario = dataRow["NombreDestinatario"].ToString(),
                          ApellidoPatDestinatario = dataRow["ApellidoPatDestinatario"].ToString(),
                          ApellidoMatDestinatario = dataRow["ApellidoMatDestinatario"].ToString(),
                          TelefonoDestinatario = dataRow["TelefonoDestinatario"].ToString(),
                          Repartidor = dataRow["Repartidor"].ToString(),
                          ClaveRepartidor = dataRow["ClaveRepartidor"].ToString(),
                          Marca = dataRow["MarcaVehiculo"].ToString(),
                          Modelo = dataRow["Modelo"].ToString(),
                          Matricula = dataRow["Matricula"].ToString(),
                          FechaSalida = dataRow["FechaSalida"].ToString(),
                          FechaEntrega = dataRow["FechaEntrega"].ToString(),
                          EstatusDeOrden =dataRow["EstatusDeOrden"].ToString(),
                          FechaRegistro = dataRow["FechaRegistro"].ToString(),
                          UsuarioRegistra = int.Parse(dataRow["UsuarioRegistra"].ToString()),
                          Estatus = dataRow["Estatus"].ToString()
                      }).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
    }
    
}
