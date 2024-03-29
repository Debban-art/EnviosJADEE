﻿using EnvíosJADEE.Models;
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
    internal class TipoService
    {
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();

        public string InsertTipo(TipoModel Tipo)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Tipo.Tipo });

            try
            {
                dac.ExecuteNonQuery("InsertTipo", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<TipoModel> GetTipos()
        {
            parametros = new ArrayList();
            List<TipoModel> lista = new List<TipoModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetTipos", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new TipoModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Tipo = dataRow["Nombre"].ToString(),
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
