using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmRegistroEnvío : Form
    {
        public frmRegistroEnvío()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbIdCliente.SelectedIndex = 0;
            cmbIdEstatusOrden.SelectedIndex = 0;
            cmbIdProducto.SelectedIndex = 0;
            txtCostoTotal.Text = "";
            txtPeso.Text = "";
            txtFechaSalida.Text = "";
            txtFechaEntrega.Text = "";
            txtPais.Text = "";
            txtEstado.Text = "";
            txtCiudad.Text = "";
            txtCodigoPostal.Text = "";
            txtDomicilio.Text = "";
            txtCalle.Text = "";
            txtNoCasa.Text = "";

            cmbIdCliente.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtCostoTotal.Text.Trim().Length == 0 || txtPeso.Text.Trim().Length == 0 || txtFechaSalida.Text.Trim().Length == 0 || txtFechaEntrega.Text.Trim().Length == 0
                || txtPais.Text.Trim().Length == 0 || txtEstado.Text.Trim().Length == 0 || txtCiudad.Text.Trim().Length == 0 || txtCodigoPostal.Text.Trim().Length == 0
                || txtDomicilio.Text.Trim().Length == 0 || txtCalle.Text.Trim().Length == 0 || txtNoCasa.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RegistroEnvioModel envio = new RegistroEnvioModel();
                envio.CostoTotal = float.Parse(txtCostoTotal.ToString());
                envio.Peso = float.Parse(txtPeso.ToString());
                envio.FechaSalida = txtFechaSalida.Text;
                envio.FechaEntrega = txtFechaEntrega.Text;
                envio.Pais = txtPais.Text;
                envio.Estado = txtEstado.Text;
                envio.Ciudad = txtCiudad.Text;
                envio.CodigoPostal = txtCodigoPostal.Text;
                envio.Domicilio = txtDomicilio.Text;
                envio.Calle = txtCalle.Text;
                envio.NoCasa = txtNoCasa.Text;
                envio.IdCliente = int.Parse(cmbIdCliente.SelectedValue.ToString());
                envio.IdEstatusOrden = int.Parse(envio.IdEstatusOrden.ToString());
                envio.IdProducto = int.Parse(envio.IdProducto.ToString());



                RegistroEnvioService service = new RegistroEnvioService();
<<<<<<< HEAD
                //service.InsertRegistroEnvio(envio);
=======
                service.InsertOrdenes(envio);
>>>>>>> 4f7d10d22dde6f91b37aedd050de1898833dbaee

                dgvRegistroEnvio.DataSource = null;
                //dgvRegistroEnvio.DataSource = service.GetRegistroEnvio();



            }
        }

        private void dgvRegistroEnvio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRegistroEnvio_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RegistroEnvioService service = new RegistroEnvioService();
            RegistroEnvioModel envio = new RegistroEnvioModel();
            var row = dgvRegistroEnvio.Rows[e.RowIndex];

            envio.IdCliente = int.Parse(row.Cells[1].Value.ToString());
            envio.IdProducto = int.Parse(row.Cells[2].Value.ToString());
            envio.IdEstatusOrden = int.Parse(row.Cells[3].Value.ToString());
            envio.CostoTotal = float.Parse(row.Cells[4].Value.ToString());
            envio.Peso = float.Parse(row.Cells[5].Value.ToString());
            envio.FechaSalida = row.Cells[6].Value.ToString();
            envio.FechaEntrega = row.Cells[7].Value.ToString();
            envio.Pais = row.Cells[8].Value.ToString();
            envio.Estado = row.Cells[9].Value.ToString();
            envio.Ciudad = row.Cells[10].Value.ToString();
            envio.CodigoPostal = row.Cells[11].Value.ToString();
            envio.Domicilio = row.Cells[12].Value.ToString();
            envio.Calle = row.Cells[13].Value.ToString();
            envio.NoCasa = row.Cells[14].Value.ToString();



            envio.UpdateRegistroEnvio(Ordenes);
            dgvRegistroEnvio.DataSource = null;
            RegistroEnvioService RegistroEnvioService = new RegistroEnvioService();
            dgvRegistroEnvio.DataSource = service.GetRegistroEnvio();
        }

        private void frmRegistroEnvío_Load(object sender, EventArgs e)
        {

        }
    }
}
