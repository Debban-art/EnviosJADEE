using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public List<RepartidorModel> GetRepartidores()
        {

            parametros = new ArrayList();
            List<RepartidorModel> lista = new List<RepartidorModel>();
            try
            {
                DataSet ds = dac.Fill("GetRepartidores", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new RepartidorModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         IdVehiculo = int.Parse(dataRow["IdVehiculo"].ToString()),
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
    }
}
