﻿using EnvíosJADEE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLeoniWF;
using EnvíosJADEE.Clases;

namespace EnvíosJADEE.Network
{
    internal class PerfilService
    {
            
        private DataAcces dac = new DataAcces();
        private ArrayList parametros = new ArrayList();
        public string InsertPerfil(PerfilModel Perfil)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Perfil.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("InsertPerfil", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Correcto";
        }

        public List<PerfilModel> GetPerfiles()
        {
            parametros = new ArrayList();
            List<PerfilModel> lista = new List<PerfilModel>();
            //parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });                                                                                                                                                                                                                                              
            try
            {
                DataSet ds = dac.Fill("GetPerfiles", parametros);
                if (ds.Tables.Count > 0)
                {
                    lista = ds.Tables[0].AsEnumerable()
                                     .Select(dataRow => new PerfilModel
                                     {
                                         Id = int.Parse(dataRow["Id"].ToString()),
                                         Nombre = dataRow["Nombre"].ToString(),
                                         Estatus = dataRow["Estatus"].ToString(),
                                         FechaRegistro = dataRow["FechaRegistro"].ToString(),
                                         Usuario = int.Parse(dataRow["UsuarioRegistra"].ToString())

                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;

        }
        public void UpdatePerfil(PerfilModel Perfil)
        {
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.Int, Value = Perfil.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Perfil.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = Perfil.Estatus == "Activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = System.Data.SqlDbType.Int, Value = SesionClass.IdUsuario });

            try
            {
                dac.ExecuteNonQuery("UpdatePerfiles", parametros);
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
