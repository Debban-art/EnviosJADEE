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
    internal class DetallePerfilService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public int InsertDetallePerfil(InsertDetallePerfilModel detallePerfil)
        {
            int resultado = 3;
            List<int> lista = new List<int>();
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = System.Data.SqlDbType.Int, Value = detallePerfil.IdModulo });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = detallePerfil.IdPerfil });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("InsertDetallePerfil", parametros);
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

        public List<GetDetallePerfilModel> GetDetallePerfil()
        {
            parametros = new ArrayList();
            List<GetDetallePerfilModel> lista = new List<GetDetallePerfilModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetDetallesPerfiles", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetDetallePerfilModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Modulo = dataRow["Modulo"].ToString(),
                                         Perfil = dataRow["Perfil"].ToString(),
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

        public int UpdateDetallePerfil(GetDetallePerfilModel DetallePerfil)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = DetallePerfil.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pModulo", SqlDbType = System.Data.SqlDbType.VarChar, Value = DetallePerfil.Modulo });
            parametros.Add(new SqlParameter { ParameterName = "@pPerfil", SqlDbType = System.Data.SqlDbType.VarChar, Value = DetallePerfil.Perfil });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = DetallePerfil.Estatus == "activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("UpdateDetallePerfil", parametros);
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

        public void DeleteDetallePerfil (int id)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("DeleteDetallePerfil", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
