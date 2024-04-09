using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class MarcasService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public int InsertMarcas(MarcaModel Marca)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Marca.Marca });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });


            try
            {
                DataSet ds = dac.Fill("InsertMarcas", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable().Select(dataRow => int.Parse(dataRow["resultado"].ToString())).ToList();
                    resultado = lista[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }


        public List<MarcaModel> GetMarcas()
        {
            parametros = new ArrayList();
            List<MarcaModel> lista = new List<MarcaModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetMarcas", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new MarcaModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Marca = dataRow["Nombre"].ToString(),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaModificación = dataRow["FechaModificación"].ToString(),
                                         Usuario = int.Parse(dataRow["Usuario"].ToString())

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public int UpdateMarcas(MarcaModel Marcas)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = Marcas.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Marcas.Marca });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = Marcas.Estatus == "activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });


            try
            {
                DataSet ds = dac.Fill("UpdateMarcas", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable().Select(dataRow => int.Parse(dataRow["resultado"].ToString())).ToList();
                    resultado = lista[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public void DeleteMarca(int id)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("DeleteMarca", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
