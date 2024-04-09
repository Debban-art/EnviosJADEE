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
    internal class RepartidoresService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<GetVehiculoModelCMB> GetVehiculos()
        {
            parametros = new ArrayList();
            List<GetVehiculoModelCMB> lista = new List<GetVehiculoModelCMB>();
            try
            {
                DataSet ds = dac.Fill("GetVehiculosCMB", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetVehiculoModelCMB
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Vehiculo"].ToString(),
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        public List<GetRepartidorModel> GetRepartidores()
        {

            parametros = new ArrayList();
            List<GetRepartidorModel> lista = new List<GetRepartidorModel>();
            try
            {
                DataSet ds = dac.Fill("GetRepartidores", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetRepartidorModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         Matricula = dataRow["Matricula"].ToString(),
                                         ClaveRepartidor = dataRow["Clave"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         UsuarioRegistra = int.Parse(dataRow["UsuarioRegistra"].ToString()),
                                         Estatus = dataRow["Estatus"].ToString()
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }

        public int InsertRepartidor(InsertRepartidorModel repartidor)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = repartidor.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pIdVehiculo", SqlDbType = System.Data.SqlDbType.Int, Value = repartidor.IdVehiculo });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("InsertRepartidor", parametros);
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

        public int UpdateRepartidor(GetRepartidorModel repartidor)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = repartidor.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombreRepartidor", SqlDbType = System.Data.SqlDbType.VarChar, Value = repartidor.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pMatriculaVehiculo", SqlDbType = System.Data.SqlDbType.VarChar, Value = repartidor.Matricula });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = repartidor.Estatus == "activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("UpdateRepartidor", parametros);
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

        public void DeleteRepartidor(int id)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("DeleteRepartidor", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
