﻿using EnvíosJADEE.Models;
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
    internal class DetallesDeOrdenService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public List<EstatusDeOrdenModel> GetEstatusOrden(DetallesEnvíoModel detallesEnvío)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdEstatusActual", SqlDbType = System.Data.SqlDbType.Int, Value = detallesEnvío.IdEstatusDeOrden });
            List<EstatusDeOrdenModel> lista = new List<EstatusDeOrdenModel>();
            try
            {
                DataSet ds = dac.Fill("GetEstatusDeOrden", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new EstatusDeOrdenModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         NombreEstatusOrden = dataRow["NombreEstatus"].ToString()

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public List<DetallesEnvíoModel> GetDetallesOrden(string ClaveOrden)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = System.Data.SqlDbType.VarChar, Value = ClaveOrden });
            List<DetallesEnvíoModel> lista = new List<DetallesEnvíoModel>();
            try
            {
                DataSet ds = dac.Fill("GetOrdenByClave", parametros);
                if(ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                      .Select(dataRow => new DetallesEnvíoModel
                      {
                          Id = int.Parse(dataRow["Id"].ToString()),
                          Clave = dataRow["Clave"].ToString(),
                          NombreEmisor = dataRow["NombreEmisor"].ToString(),
                          CostoTotal = float.Parse(dataRow["Costototal"].ToString()),
                          Peso = float.Parse(dataRow["Peso"].ToString()),
                          CodigoPostal = int.Parse(dataRow["CodigoPostal"].ToString()),
                          NoCasa = dataRow["NoCasa"].ToString(),
                          Calle = dataRow["Calle"].ToString(),
                          IdColonia = int.Parse(dataRow["IdColonia"].ToString()),
                          IdMunicipio = int.Parse(dataRow["IdMunicipio"].ToString()),
                          IdEstado = int.Parse(dataRow["IdEstado"].ToString()),
                          IdPais = int.Parse(dataRow["IdPais"].ToString()),
                          NombreDestinatario = dataRow["NombreDestinatario"].ToString(),
                          ApellidoPatDestinatario = dataRow["ApellidoPatDestinatario"].ToString(),
                          ApellidoMatDestinatario = dataRow["ApellidoMatDestinatario"].ToString(),
                          TelefonoDestinatario = dataRow["TelefonoDestinatario"].ToString(),
                          IdRepartidor = int.Parse(dataRow["IdRepartidor"].ToString()),
                          ClaveRepartidor = dataRow["ClaveRepartidor"].ToString(),
                          Marca = dataRow["MarcaVehiculo"].ToString(),
                          Modelo = dataRow["Modelo"].ToString(),
                          Matricula = dataRow["Matricula"].ToString(),
                          FechaSalida = dataRow["FechaSalida"].ToString(),
                          FechaEntrega = dataRow["FechaEntrega"].ToString(),
                          IdEstatusDeOrden = int.Parse(dataRow["IdEstatusDeOrden"].ToString()),
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

        public List<ProductosPorOrdenModel> GetProductosPorOrden(string ClaveOrden)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = SqlDbType.VarChar, Value = ClaveOrden });
            List<ProductosPorOrdenModel> lista = new List<ProductosPorOrdenModel>();
            try
            {
                DataSet ds = dac.Fill("GetProductosByOrden", parametros);
                if(ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new ProductosPorOrdenModel
                        {
                            IdOrden = int.Parse(dataRow["Id"].ToString()),
                            Clave = dataRow["Clave"].ToString(),
                            Producto = dataRow["NombreProducto"].ToString(),
                            Cantidad = int.Parse((dataRow["Cantidad"].ToString()))
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
