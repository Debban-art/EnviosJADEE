using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmDetallesDeOrden : Form
    {
        DetallesDeOrdenService detallesDeOrdenService = new DetallesDeOrdenService();
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
            Label lblRepartidores = new Label();
            ComboBox cmbRepartidores = new ComboBox();

            if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden == "Enviado")
            {


                lblRepartidores.Location = new System.Drawing.Point(cmbEstatus.Left, cmbEstatus.Bottom + 5);
                lblRepartidores.Font = new Font("Yu Gothic UI", 12);
                lblRepartidores.Text = "Repartidor";

                cmbRepartidores.Location = new System.Drawing.Point(lblRepartidores.Left, lblRepartidores.Bottom + 5);
                cmbRepartidores.Size = new System.Drawing.Size(cmbEstatus.Width, cmbEstatus.Height);
                cmbRepartidores.Items.AddRange(new object[] { "Opción 1", "Opción 2", "Opción 3" });

                btnCambiar.Location = new Point(cmbRepartidores.Left, cmbRepartidores.Bottom + 4);
                btnCancelar.Location = new Point(btnCambiar.Right + 4, cmbRepartidores.Bottom + 4);

                // Agrega el ComboBox dinámico al formulario
                Controls.Add(lblRepartidores);
                Controls.Add(cmbRepartidores);
            }
            else
            {
                // Elimina el ComboBox y el Label relacionados con los repartidores si existen
                if (cmbRepartidores != null)
                {
                    Controls.Remove(cmbRepartidores);
                    cmbRepartidores.Dispose();
                    cmbRepartidores = null;
                }

                if (lblRepartidores != null)
                {
                    Controls.Remove(lblRepartidores);
                    lblRepartidores.Dispose();
                    lblRepartidores = null;
                }
            }
        }
    }
}
