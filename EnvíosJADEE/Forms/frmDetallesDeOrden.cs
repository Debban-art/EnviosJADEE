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
            btnCambiar.Location = new Point(cmbEstatus.Left, cmbEstatus.Bottom + 4);
            btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbEstatus.Bottom + 4);
            lblRepartidores.Location = new System.Drawing.Point(cmbEstatus.Left, cmbEstatus.Bottom + 5);
            lblRepartidores.Font = new Font("Yu Gothic UI", 12);
            lblRepartidores.Text = "Repartidor";

            cmbRepartidores.Location = new System.Drawing.Point(lblRepartidores.Left, lblRepartidores.Bottom + 5);
            cmbRepartidores.Size = new System.Drawing.Size(cmbEstatus.Width, cmbEstatus.Height);
            RepartidoresService repartidoresService = new RepartidoresService();
            cmbRepartidores.DataSource = repartidoresService.GetRepartidores();
            cmbRepartidores.DisplayMember = "Nombre";
            cmbRepartidores.ValueMember = "Id";
            cmbRepartidores.Size = cmbEstatus.Size;
            cmbRepartidores.Font = cmbEstatus.Font;
            cmbRepartidores.BackColor = cmbEstatus.BackColor;
            Controls.Add(lblRepartidores);
            Controls.Add(cmbRepartidores);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string ClaveOrden = txtClave.Text;

            #region dgvOrden
            dgvOrden.DataSource = null;
            dgvOrden.DataSource = detallesDeOrdenService.GetDetallesOrden(ClaveOrden);
            dgvOrden.Columns[26].ReadOnly = false;
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
                btnCambiar.Location = new Point(cmbRepartidores.Left, cmbRepartidores.Bottom + 10);
                btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbRepartidores.Bottom + 10);

                lblRepartidores.Visible = true;
                cmbRepartidores.Visible = true;
            }
            else
            {
                lblRepartidores.Visible = false;
                cmbRepartidores.Visible = false;
                btnCambiar.Location = new Point(cmbEstatus.Left, cmbEstatus.Bottom + 4);
                btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbEstatus.Bottom + 4);
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
    }
}
