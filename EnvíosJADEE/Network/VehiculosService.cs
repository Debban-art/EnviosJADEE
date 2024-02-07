using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class VehiculosService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<VehiculoModel> GetVehiculos()
        {
            parametros = new ArrayList();
            List <VehiculoModel> lista = new List<VehiculoModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("SelectVehiculos", parametros);
                if (ds.Tables.Count > 0 )
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
    }
}
