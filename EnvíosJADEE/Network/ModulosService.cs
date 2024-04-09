using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;
using EnvíosJADEE.Clases;

namespace EnvíosJADEE.Network
{
    internal class ModulosService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public int InsertModulos(InsertModuloModel Modulos)
        {
            List<int> lista = new List<int>();
            int resultado = 3;
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pIdCategoria", SqlDbType = System.Data.SqlDbType.Int, Value = Modulos.IdCategoria });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Modulos.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("InsertModulos", parametros);
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

        public List<GetModuloModel> GetModulos()
        {
            parametros = new ArrayList();
            List<GetModuloModel> lista = new List<GetModuloModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetModulos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetModuloModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         Categoria = dataRow["Categoria"].ToString(),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         Usuario = int.Parse(dataRow["UsuarioRegistra"].ToString())

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public int UpdateModulos(GetModuloModel modulo)
        { 
            List<int> lista = new List<int>();
            int resultado = 3;
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = modulo.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = modulo.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pCategoria", SqlDbType = System.Data.SqlDbType.VarChar, Value = modulo.Categoria });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = modulo.Estatus == "Activo" ? 1 : 0 });
            


            try
            {
                DataSet ds = dac.Fill("UpdateModulos", parametros);
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

        public void DeleteModulos(int id)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("DeleteModulo", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
