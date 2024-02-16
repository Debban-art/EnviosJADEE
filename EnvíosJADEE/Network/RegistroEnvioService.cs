using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class RegistroEnvioService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();


        public List<RegistroEnvioModel> GetRegistroEnvios()
        {
            parametros = new ArrayList();
            List<RegistroEnvioModel> lista = new List<RegistroEnvioModel>();
            try
            {
                DataSet ds = dac.Fill("GetOrdenes", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new RegistroEnvioModel
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
                                         FechaSalida = dataRow["FechaSalida"].ToString(),
                                         FechaEntrega = dataRow["FechaEntrega"].ToString(),
                                         EstatusDeOrden = dataRow["EstatusDeOrden"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         UsuarioRegistra = int.Parse(dataRow["UsuarioRegistra"].ToString())

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        public string InsertOrdenes(OrdenModel orden)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pCostototal", SqlDbType = System.Data.SqlDbType.Decimal, Value = orden.CostoTotal });
            parametros.Add(new SqlParameter { ParameterName = "@pPeso", SqlDbType = System.Data.SqlDbType.Decimal, Value = orden.Peso });
            parametros.Add(new SqlParameter { ParameterName = "@pNombreEmisor", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.NombreEmisor });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPais", SqlDbType = System.Data.SqlDbType.Int, Value = orden.IdPais });
            parametros.Add(new SqlParameter { ParameterName = "@pIdEstado", SqlDbType = System.Data.SqlDbType.Int, Value = orden.IdEstado });
            parametros.Add(new SqlParameter { ParameterName = "@pIdMunicipio", SqlDbType = System.Data.SqlDbType.Int, Value = orden.IdMunicipio });
            parametros.Add(new SqlParameter { ParameterName = "@pIdColonia", SqlDbType = System.Data.SqlDbType.Int, Value = orden.idColonia });
            parametros.Add(new SqlParameter { ParameterName = "@pCalle", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.Calle });
            parametros.Add(new SqlParameter { ParameterName = "@pNoCasa", SqlDbType = System.Data.SqlDbType.Int, Value = orden.NoCasa });
            parametros.Add(new SqlParameter { ParameterName = "@pCodigoPostal", SqlDbType = System.Data.SqlDbType.Int, Value = orden.CodigoPostal });
            parametros.Add(new SqlParameter { ParameterName = "@pNombreDestinatario", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.NombreDestinatario });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoPatDestinatario", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.ApellidoPatDestinatario });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoMatDestinatario", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.ApellidoMatDestinatario });
            parametros.Add(new SqlParameter { ParameterName = "@pTelefonoDestinatario", SqlDbType = System.Data.SqlDbType.VarChar, Value = orden.TelefonoDestinatario });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("InsertOrdenes", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }


        public List<ProductosModel> GetProductoById(int IdProducto)
        {
            parametros = new ArrayList();
            List<ProductosModel> lista = new List<ProductosModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdProducto", SqlDbType = System.Data.SqlDbType.Int, Value = IdProducto });
            try
            {
                DataSet ds = dac.Fill("GetProductoById", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                        .Select(dataRow => new ProductosModel
                                        {
                                            Id = int.Parse(dataRow["Id"].ToString()),
                                            Nombre = dataRow["NombreProducto"].ToString(),
                                            IdCategoria = int.Parse(dataRow["IdCategoria"].ToString()),
                                            Precio = float.Parse(dataRow["Precio"].ToString()),
                                            Peso = float.Parse(dataRow["Peso"].ToString())
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
