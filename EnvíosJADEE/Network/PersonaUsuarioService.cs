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
        public string InsertPersonaUsuario(PersonaModel persona, UsuarioModel usuario)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Dirección });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = usuario.IdPerfil});
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("InsertPersonaUsuario", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }
        public List<PersonaModel> GetPersonasUsuario()
        {
            parametros = new ArrayList();
            List<PersonaModel> lista = new List<PersonaModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetPersonasUsuario", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new PersonaModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         ApellidoPaterno = dataRow["ApellidoPaterno"].ToString(),
                                         ApellidoMaterno = dataRow["ApellidoMaterno"].ToString(),
                                         NombreUsuario = dataRow["NombreUsuario"].ToString(),
                                         Dirección = dataRow["Direccion"].ToString(),
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

        public void UpdatePersonasUsuario(PersonaModel persona)
        {
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = persona.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApellidoMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApellidoMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Dirección });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = persona.Estatus == "Activo" ? 1 : 0 });
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
