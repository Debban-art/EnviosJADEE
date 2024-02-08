using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class VehiculosService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public string InsertVehiculo(VehiculoModel Vehiculo)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Vehiculo.matricula });
            parametros.Add(new SqlParameter { ParameterName = "@pIdMarca", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.idMarca });
            parametros.Add(new SqlParameter { ParameterName = "@pModelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Vehiculo.modelo });
            parametros.Add(new SqlParameter { ParameterName = "@pNoSerie", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.NoSerie });
            parametros.Add(new SqlParameter { ParameterName = "@pIdTipo", SqlDbType = System.Data.SqlDbType.Int, Value = Vehiculo.idTipo });


            try
            {
                dac.ExecuteNonQuery("InsertVehiculoS", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<VehiculoModel> GetVehiculos()


        {
            parametros = new ArrayList();
            List<VehiculoModel> lista = new List<VehiculoModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("SelectVehiculos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new VehiculoModel
                                     {
                                         id = int.Parse(dataRow["Id"].ToString()),
                                         idTipo = int.Parse(dataRow["IdTipo"].ToString()),
                                         tipo = dataRow["Tipo"].ToString(),
                                         matricula = dataRow["Matricula"].ToString(),
                                         idMarca = int.Parse(dataRow["IdMarca"].ToString()),
                                         marca = dataRow["Marca"].ToString(),
                                         modelo = dataRow["Modelo"].ToString(),
                                         NoSerie = int.Parse(dataRow["NoSerie"].ToString()),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         estatus = dataRow["Estatus"].ToString()



                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }
        public void UpdateVehiculo(VehiculoModel vehiculo)
        {
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.matricula });
            parametros.Add(new SqlParameter { ParameterName = "@pIdMarca", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.idMarca });
            parametros.Add(new SqlParameter { ParameterName = "@pModelo", SqlDbType = System.Data.SqlDbType.VarChar, Value = vehiculo.modelo });
            parametros.Add(new SqlParameter { ParameterName = "@pNoSerie", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.NoSerie });
            parametros.Add(new SqlParameter { ParameterName = "@pIdTipo", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.idTipo });
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.id });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = vehiculo.estatus == "Activo" ? 1 : 0 });

            try
            {
                dac.ExecuteNonQuery("UpdateVehiculos", parametros);
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




