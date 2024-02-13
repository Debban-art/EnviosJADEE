using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;

namespace EnvíosJADEE.Network
{
    internal class RegistroEnvioService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public string InsertOrdenes(RegistroEnvioModel Ordenes)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdCliente", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.IdCliente });
            parametros.Add(new SqlParameter { ParameterName = "@pIdProducto", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.IdProducto });
            parametros.Add(new SqlParameter { ParameterName = "@pIdEstatusOrden", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.IdEstatusOrden });
            parametros.Add(new SqlParameter { ParameterName = "@pCostoTotal", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.CostoTotal });
            parametros.Add(new SqlParameter { ParameterName = "@pPeso", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.Peso });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaSalida", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.FechaSalida });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaEntrega", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.FechaEntrega });
            parametros.Add(new SqlParameter { ParameterName = "@pPais", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.Pais });
            parametros.Add(new SqlParameter { ParameterName = "@pEstado", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.Estado });
            parametros.Add(new SqlParameter { ParameterName = "@pCiudad", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.Ciudad });
            parametros.Add(new SqlParameter { ParameterName = "@pCodigoPostal", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.CodigoPostal });
            parametros.Add(new SqlParameter { ParameterName = "@pDomicilio", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.Domicilio });
            parametros.Add(new SqlParameter { ParameterName = "@pCalle", SqlDbType = System.Data.SqlDbType.Int, Value = Ordenes.Calle });
            parametros.Add(new SqlParameter { ParameterName = "@pNoCasa", SqlDbType = System.Data.SqlDbType.VarChar, Value = Ordenes.NoCasa });

            try
            {
                dac.ExecuteNonQuery("InsertRegistroEnvio", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }
    }
}
