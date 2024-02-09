using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class ModulosPorPerfilService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<ModuloModel> GetModulosPorPerfil(int idPerfil)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdPerfil", SqlDbType = System.Data.SqlDbType.Int, Value = idPerfil });

            List<ModuloModel> lista = new List<ModuloModel>();

            try
            {
                DataSet ds = dac.Fill("GetModulosPorPerfil", parametros);
                if (ds.Tables.Count> 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new ModuloModel
                                     {
                                         Id = int.Parse(dataRow["IdModulo"].ToString()),
                                         Nombre = dataRow["Modulo.Nombre"].ToString(),
                                         IdCategoria = int.Parse(dataRow["IdCategoria"].ToString())
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
            return lista;
        }

        public List<CategoríaModel> GetCategoriaPorModulo(int idCategoria)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdCategoria", SqlDbType = System.Data.SqlDbType.Int, Value = idCategoria });

            List<CategoríaModel> lista = new List<CategoríaModel>();

            try
            {
                DataSet ds = dac.Fill("GetCategoriasPorModulo", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new CategoríaModel
                                     {
                                         Nombre = dataRow["Categoria"].ToString(),
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
