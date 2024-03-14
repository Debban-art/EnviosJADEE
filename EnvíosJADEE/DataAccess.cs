 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;

namespace TestLeoniWF
{
    public class DataAcces
    {
        SqlConnection SqlCon;

        public DataAcces()
        {
            SqlCon = new SqlConnection();
        }

        public string ObtenerConexion()
        {
            //var appSettings = ConfigurationManager.AppSettings;
            //string result = appSettings["Estacion"] ?? "Not Found";
            //return System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            return "Data Source=104.254.247.128; Initial Catalog=EnviosJADEE_Debbany; User Id=sa;password=ABC1238f47!;";

        }

        private void AbrirConexion()
        {
            if (!(this.SqlCon.State == ConnectionState.Open))
            {
                SqlCon.ConnectionString = ObtenerConexion();
                SqlCon.Open();
            }
        }

        private void CerrarConexion()
        {
            if (this.SqlCon.State == ConnectionState.Open)
            {
                SqlCon.Close();
            }
        }

        public void ExecuteNonQuery(string procedimiento, ArrayList parametros)
        {
            try
            {
                AbrirConexion();
                SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
                mComando.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }
                mComando.CommandTimeout = 10000;
                mComando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                CerrarConexion();
                throw e;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public DataSet Fill(string procedimiento, ArrayList parametros)
        {
            DataSet mDataSet = new DataSet();

            try
            {
                AbrirConexion();
                SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
                SqlDataAdapter mDataAdapter = new SqlDataAdapter(mComando);

                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandTimeout = 600;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }

                mDataAdapter.Fill(mDataSet);
                return mDataSet;
            }
            catch (Exception e)
            {
                CerrarConexion();
                throw e;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
