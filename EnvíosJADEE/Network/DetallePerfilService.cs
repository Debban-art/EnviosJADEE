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

namespace EnvíosJADEE.Network
{
    internal class DetallePerfilService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public string InsertDetallePerfil(DetallePerfilModel detallePerfil)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = System.Data.SqlDbType.Int, Value = detallePerfil.IdModulo });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = detallePerfil.IdPerfil });

            try
            {
                dac.ExecuteNonQuery("InsertDetallePerfil", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<DetallePerfilModel> GetDetallePerfil()
        {
            parametros = new ArrayList();
            List<DetallePerfilModel> lista = new List<DetallePerfilModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetDetallesPerfiles", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new DetallePerfilModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         IdModulo = int.Parse(dataRow["IdModulo"].ToString()),
                                         Modulo = dataRow["Modulo"].ToString(),
                                         IdPerfil = int.Parse(dataRow["IdPerfil"].ToString()),
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
    }
}
