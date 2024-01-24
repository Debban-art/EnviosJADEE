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
    internal class LoginService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public bool Login(string Usuario, string Contraseña)
        {
            parametros = new ArrayList();
            List<UsuarioModel> lista = new List<UsuarioModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = Usuario});
            parametros.Add(new SqlParameter { ParameterName = "@pContraseña", SqlDbType = System.Data.SqlDbType.VarChar, Value = Contraseña});
            try
            {
                DataSet ds = dac.Fill("SPLogin", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new UsuarioModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         NombreUsuario = dataRow["NombreUsuario"].ToString()
                                     }).ToList();
                    if (lista[0].Id == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
