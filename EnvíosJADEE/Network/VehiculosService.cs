using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TestLeoniWF;
using EnvíosJADEE.Clases;
namespace EnvíosJADEE.Network
{
    internal class VehiculosService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<GetVehiculoModel> GetVehiculos()
        {
            parametros = new ArrayList();
            List<GetVehiculoModel> lista = new List<GetVehiculoModel>();

            try
            {
                DataSet ds = dac.Fill("SelectVehiculos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new GetVehiculoModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Tipo = dataRow["Tipo"].ToString(),
                                         Marca = dataRow["Marca"].ToString(),
                                         Matricula = dataRow["Matricula"].ToString(),
                                         Modelo = dataRow["Modelo"].ToString(),
                                         NoSerie = int.Parse(dataRow["NoSerie"].ToString()),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaModificación = dataRow["FechaModificacion"].ToString(),
                                         Usuario = int.Parse(dataRow["Usuario"].ToString())
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public int InsertVehiculo(InsertVehiculoModel Vehiculo)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Vehiculo.matricula });
            parametros.Add(new SqlParameter { ParameterName = "@pIdMarca", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.idMarca });
            parametros.Add(new SqlParameter { ParameterName = "@pModelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Vehiculo.modelo });
            parametros.Add(new SqlParameter { ParameterName = "@pNoSerie", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.NoSerie });
            parametros.Add(new SqlParameter { ParameterName = "@pIdTipo", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.idTipo });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                DataSet ds = dac.Fill("InsertVehiculos", parametros);
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


        public int UpdateVehiculo(GetVehiculoModel vehiculo)
        {
            int resultado = 3;
            List<int> lista = new List<int>();

            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.Matricula });
            parametros.Add(new SqlParameter { ParameterName = "@pModelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.Modelo });
            parametros.Add(new SqlParameter { ParameterName = "@pMarca", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.Marca });
            parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.Tipo });
            parametros.Add(new SqlParameter { ParameterName = "@pNoSerie", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.NoSerie });
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.Estatus == "activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });


            try
            {
                DataSet ds = dac.Fill("UpdateVehiculos", parametros);
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

        public void DeleteVehiculo(int id)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("DeleteVehiculo", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




