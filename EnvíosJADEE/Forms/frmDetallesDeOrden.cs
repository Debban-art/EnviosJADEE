using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmDetallesDeOrden : Form
    {
        DetallesDeOrdenService detallesDeOrdenService = new DetallesDeOrdenService();
        Label lblRepartidores = new Label();
        ComboBox cmbRepartidores = new ComboBox();
        public frmDetallesDeOrden()
        {
            InitializeComponent();
        }

        private void frmDetallesDeOrden_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);
            cmbEstatus.DataSource = detallesDeOrdenService.GetEstatusOrden();
            cmbEstatus.DisplayMember = "NombreEstatusOrden";
            cmbEstatus.ValueMember = "Id";

            btnCambiar.Location = new Point(cmbEstatus.Right + 4, cmbEstatus.Top);
            btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbEstatus.Top);

            lblRepartidores.Location = new System.Drawing.Point(cmbEstatus.Right + 5, lblEstatus.Top);
            lblRepartidores.Font = new Font("Yu Gothic UI", 12);
            lblRepartidores.Text = "Repartidor";

            cmbRepartidores.Location = new System.Drawing.Point(cmbEstatus.Right + 5, cmbEstatus.Top);
            cmbRepartidores.Size = new System.Drawing.Size(cmbEstatus.Width, cmbEstatus.Height);
            RepartidoresService repartidoresService = new RepartidoresService();
            cmbRepartidores.DataSource = repartidoresService.GetRepartidores();
            cmbRepartidores.DisplayMember = "Nombre";
            cmbRepartidores.ValueMember = "Id";
            cmbRepartidores.Size = cmbEstatus.Size;
            cmbRepartidores.Font = cmbEstatus.Font;
            cmbRepartidores.BackColor = cmbEstatus.BackColor;
            gpbDatosEnvio.Controls.Add(lblRepartidores);
            gpbDatosEnvio.Controls.Add(cmbRepartidores);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string ClaveOrden = txtClave.Text;

            #region dgvOrden
            DetallesEnvíoModel detallesEnvío = detallesDeOrdenService.GetDetallesOrden(ClaveOrden)[0];
            cmbEstatus.SelectedItem = detallesEnvío.EstatusDeOrden.ToString(); //Arreglar
            txtNombreEmisor.Text = detallesEnvío.NombreEmisor.ToString();
            txtCostoTotal.Text = detallesEnvío.CostoTotal.ToString();
            txtPeso.Text = detallesEnvío.Peso.ToString(); 
            txtFechaSalida.Text = detallesEnvío.FechaSalida.ToString();
            txtFechaEntrega.Text = detallesEnvío.FechaEntrega.ToString();
            txtMarca.Text = detallesEnvío.Marca.ToString();
            txtModelo.Text = detallesEnvío.Modelo.ToString();
            txtMatrícula.Text = detallesEnvío.Matricula.ToString();

            txtCodigoPostal.Text = detallesEnvío.CodigoPostal.ToString();
            txtCalle.Text = detallesEnvío.Calle;
            txtNoCasa.Text = detallesEnvío.NoCasa;
            txtNombreDestinatario.Text = detallesEnvío.NombreDestinatario;
            txtApellidoPatDestinatario.Text = detallesEnvío.ApellidoPatDestinatario;
            txtApellidoMatDestinatario.Text = detallesEnvío.ApellidoMatDestinatario;
            txtTelefonoDestinatario.Text = detallesEnvío.ApellidoPatDestinatario;
            #endregion

            #region dgvProductos
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = detallesDeOrdenService.GetProductosPorOrden(ClaveOrden);
            #endregion

        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden == "Enviado")
            {
                btnCambiar.Location = new Point(cmbRepartidores.Right + 10, cmbRepartidores.Top);
                btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbRepartidores.Top);

                lblRepartidores.Visible = true;
                cmbRepartidores.Visible = true;
            }
            else
            {
                lblRepartidores.Visible = false;
                cmbRepartidores.Visible = false;
                btnCambiar.Location = new Point(cmbEstatus.Right + 4, cmbEstatus.Top);
                btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbEstatus.Top);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            RegistroEnvioService registroEnvioService = new RegistroEnvioService();
            string ClaveOrden = txtClave.Text;
            int IdNuevoEstatus = int.Parse(cmbEstatus.SelectedValue.ToString());
            int IdRepartidor = int.Parse(cmbRepartidores.SelectedValue.ToString());

            registroEnvioService.UpdateEstatusOrden(IdNuevoEstatus, ClaveOrden, IdRepartidor);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
