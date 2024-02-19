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
    internal class DireccionesService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public List<PaisModels> GetPais()
        {
            parametros = new ArrayList();
            List<PaisModels> lista = new List<PaisModels>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetPaises", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new PaisModels
                                     {
                                         Id = int.Parse(dataRow["id"].ToString()),
                                         Nombre = dataRow["nombre"].ToString(),
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public List<EstadosModel> GetEstados(int IdPais)
        {
            parametros = new ArrayList();
            List<EstadosModel> lista = new List<EstadosModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdPais", SqlDbType = System.Data.SqlDbType.Int, Value = IdPais });
            try
            {
                DataSet ds = dac.Fill("GetEstados", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new EstadosModel
                                     {
                                         Id = int.Parse(dataRow["id"].ToString()),
                                         Nombre = dataRow["nombre"].ToString(),
                                         IdPais = int.Parse(dataRow["pais"].ToString()),
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public List<MunicipioModel> GetMunicipios(int IdEstado)
        {
            parametros = new ArrayList();
            List<MunicipioModel> lista = new List<MunicipioModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdEstado", SqlDbType = System.Data.SqlDbType.Int, Value = IdEstado });
            try
            {
                DataSet ds = dac.Fill("GetMunicipios", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new MunicipioModel
                                     {
                                         Id = int.Parse(dataRow["id"].ToString()),
                                         Nombre = dataRow["nombre"].ToString(),
                                         IdEstado = int.Parse(dataRow["estado"].ToString()),
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public List<ColoniaModel> GetColonias (int IdMunicipio)
        {
            parametros = new ArrayList();
            List<ColoniaModel> lista = new List<ColoniaModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdMunicipio", SqlDbType = System.Data.SqlDbType.Int, Value = IdMunicipio });
            try
            {
                DataSet ds = dac.Fill("GetColonias", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new ColoniaModel
                                     {
                                         Id = int.Parse(dataRow["id"].ToString()),
                                         Nombre = dataRow["nombre"].ToString(),
                                         IdMunicipio = int.Parse(dataRow["municipio"].ToString()),
                                         CodigoPostal = int.Parse(dataRow["codigo_postal"].ToString()),
                                         Asentamiento = dataRow["asentamiento"].ToString()
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public List<DirecciónModel> GetDireccionPorCodigoPostal(int CodigoPostal)
        {
            parametros = new ArrayList();
            List<DirecciónModel> lista = new List<DirecciónModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pCodigoPostal", SqlDbType = SqlDbType.Int, Value = CodigoPostal});
            try
            {
                DataSet ds = dac.Fill("GetDirecciónByCodigoPostal", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(DataRow => new DirecciónModel
                                     {
                                         IdPais = int.Parse(DataRow["IdPais"].ToString()),
                                         IdEstado = int.Parse(DataRow["IdEstado"].ToString()),
                                         IdMunicipio = int.Parse(DataRow["IdMunicipio"].ToString())
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            return lista;
        }
    }
}
