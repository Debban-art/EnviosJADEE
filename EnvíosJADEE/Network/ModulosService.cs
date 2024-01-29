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
        public string InsertModulos(ModuloModel Modulos)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdCategoria", SqlDbType = System.Data.SqlDbType.Int, Value = Modulos.IdCategoria });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Modulos.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("InsertModulos", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<ModuloModel> GetModulos()
        {
            parametros = new ArrayList();
            List<ModuloModel> lista = new List<ModuloModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetModulos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new ModuloModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         IdCategoria = int.Parse(dataRow["IdCategoria"].ToString()),
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

        public void UpdateModulos(ModuloModel modulo)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = modulo.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = modulo.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pIdCategoria", SqlDbType = System.Data.SqlDbType.Int, Value = modulo.IdCategoria });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });
            parametros.Add(new SqlParameter { ParameterName = "@pCategoria", SqlDbType = System.Data.SqlDbType.VarChar, Value = modulo.Categoria });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = modulo.Estatus == "Activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });


            try
            {
                dac.ExecuteNonQuery("UpdateModulos", parametros);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

    }
}
