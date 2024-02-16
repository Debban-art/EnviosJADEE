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
    internal class ProductosService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public List<ProductosModel> GetProductos()
        {
            parametros = new ArrayList();
            List<ProductosModel> lista = new List<ProductosModel>();
            try
            {
                DataSet ds = dac.Fill("GetProductos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new ProductosModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["NombreProducto"].ToString(),
                                         IdCategoria = int.Parse(dataRow["IdCategoria"].ToString()),
                                         Categoria = dataRow["Categoria"].ToString(),
                                         Precio = float.Parse(dataRow["Precio"].ToString()),
                                         Peso = float.Parse(dataRow["Peso"].ToString()),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         UsuarioRegistra = int.Parse(dataRow["UsuarioRegistra"].ToString())

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
