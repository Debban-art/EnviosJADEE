using EnvíosJADEE.Clases;
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
    internal class PersonaUsuarioService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public int InsertPersonaUsuario(InsertPersonaModel persona, UsuarioModel usuario)
        {
            int resultado = 3;
            List<int> lista = new List<int>();
            parametros = new ArrayList();
            
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Dirección });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = usuario.IdPerfil});
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("InsertPersonaUsuario", parametros);
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
        public List<GetPersonaModel> GetPersonasUsuario()
        {
            parametros = new ArrayList();
            List<GetPersonaModel> lista = new List<GetPersonaModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetPersonasUsuario", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetPersonaModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         ApellidoPaterno = dataRow["ApellidoPaterno"].ToString(),
                                         ApellidoMaterno = dataRow["ApellidoMaterno"].ToString(),
                                         NombreUsuario = dataRow["NombreUsuario"].ToString(),
                                         Dirección = dataRow["Direccion"].ToString(),
                                         Perfil = dataRow["Perfil"].ToString(),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public void UpdatePersonasUsuario(GetPersonaModel persona)
        {
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = persona.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Dirección });
            parametros.Add(new SqlParameter { ParameterName = "@pPerfil", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Perfil});
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = persona.Estatus == "activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("UpdatePersonasUsuarios", parametros);
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
