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
            dgvOrden.DataSource = null;
            dgvOrden.DataSource = detallesDeOrdenService.GetDetallesOrden(ClaveOrden);
        }
    }
}
