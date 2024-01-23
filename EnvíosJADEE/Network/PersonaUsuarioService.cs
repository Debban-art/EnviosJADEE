using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
            parametros.Add(new SqlParameter { ParameterName = "pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Dirección });
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = usuario.IdPerfil});

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
    }
}
