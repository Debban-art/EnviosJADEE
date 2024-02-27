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
    internal class TrackingService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public string InsertNuevoRegistro(TrackingModel Registro)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClaveOrden", SqlDbType = System.Data.SqlDbType.VarChar, Value = Registro.ClaveOrden });
            parametros.Add(new SqlParameter { ParameterName = "@pCambioRegistrado", SqlDbType = System.Data.SqlDbType.VarChar, Value = Registro.CambioRegistrado});

            try
            {
                dac.ExecuteNonQuery("InsertCambioEnvío", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<TrackingModel> GetRegistrosPorClave(string Clave)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClaveOrden", SqlDbType = SqlDbType.VarChar, Value = Clave });
            List<TrackingModel> lista = new List<TrackingModel>();
            try
            {
                DataSet ds = dac.Fill("GetBitacoraEnvio", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new TrackingModel
                                     {
                                         ClaveOrden = dataRow["ClaveOrden"].ToString(),
                                         CambioRegistrado = dataRow["CambioRegistrado"].ToString(),
                                         FechaCambio = dataRow["FechaCambio"].ToString(),
                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    

            }
            return lista;
        }

        public string GetFechaEntrega(string Clave)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClaveOrden", SqlDbType = SqlDbType.VarChar, Value = Clave });
            string FechaEntrega = "";
            try
            {
                DataSet ds = dac.Fill("GetFechaEntrega", parametros);
                if (ds.Tables.Count > 0)
                {
                    FechaEntrega = ds.Tables[0].Rows[0]["FechaEntrega"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return FechaEntrega;
        }


        public string  GetEstatusOrden(string Clave)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = System.Data.SqlDbType.VarChar, Value = Clave });

            string Estatus = "";
            try
            {
                DataSet ds = dac.Fill("GetEstatusDeOrdenByClave", parametros);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Estatus = ds.Tables[0].Rows[0]["NombreEstatus"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
    }
}
