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
    internal class DetallesDeOrdenService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<EstatusDeOrdenModel> GetEstatusOrden()
        {
            parametros = new ArrayList();
            List<EstatusDeOrdenModel> lista = new List<EstatusDeOrdenModel>();
            try
            {
                DataSet ds = dac.Fill("GetEstatusDeOrden", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new EstatusDeOrdenModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         NombreEstatusOrden = dataRow["NombreEstatus"].ToString()

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public List<DetallesEnvíoModel> GetDetallesOrden(string ClaveOrden)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = System.Data.SqlDbType.VarChar, Value = ClaveOrden });
            List<DetallesEnvíoModel> lista = new List<DetallesEnvíoModel>();
            try
            {
                DataSet ds = dac.Fill("GetOrdenByClave", parametros);
                if(ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                      .Select(dataRow => new DetallesEnvíoModel
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
                          NombreRepartidor = dataRow["NombreRepartidor"].ToString(),
                          ClaveRepartidor = dataRow["ClaveRepartidor"].ToString(),
                          Marca = dataRow["MarcaVehiculo"].ToString(),
                          Modelo = dataRow["Modelo"].ToString(),
                          Matricula = dataRow["Matricula"].ToString(),
                          FechaSalida = dataRow["FechaSalida"].ToString(),
                          FechaEntrega = dataRow["FechaEntrega"].ToString(),
                          EstatusDeOrden = dataRow["EstatusDeOrden"].ToString(),
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
