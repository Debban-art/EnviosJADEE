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


        public string  GetEstatusOrden(string Clave)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = System.Data.SqlDbType.VarChar, Value = Clave });

            string Estatus = "";
            try
            {
                DataSet ds = dac.Fill("GetEstatusDeOrdenByClave", parametros);

                if (ds.Tables.Count > 0)
                {
                    Estatus = ds.Tables[0].Columns[0].ToString();
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
