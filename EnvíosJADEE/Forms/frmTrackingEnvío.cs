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
    public partial class frmTrackingEnvío : Form
    {
        TrackingService trackingService = new TrackingService();

        public frmTrackingEnvío()
        {
            InitializeComponent();
        }

        private void frmTrackingEnvío_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);
            

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(txtClaveDeOrden.Text.Trim() == "")
            {
                MessageBox.Show("Debes de ingresar una clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Clave = txtClaveDeOrden.Text;
                string EstatusDeOrden = trackingService.GetEstatusOrden(Clave);
                if (EstatusDeOrden.Trim() == "")
                {

                    MessageBox.Show("Clave de orden inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lblEstatusDeOrden.Text = EstatusDeOrden;
                    dgvBitácora.Visible = true;
                    dgvBitácora.DataSource = null;
                    dgvBitácora.DataSource = trackingService.GetRegistrosPorClave(Clave);
                    if (EstatusDeOrden == "Entregado")
                    {
                        lblFecha.Text = "Fecha de entrega:  ";
                    }
                    else
                    {
                        lblFecha.Text = "Fecha estimada de entrega: ";
                    }
                    lblFecha.Text += trackingService.GetFechaEntrega(Clave);

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClaveDeOrden.Text = null;
            txtClaveDeOrden.Focus();

            lblEstatusDeOrden.Text = null;
            lblFecha.Text = null;

            dgvBitácora.DataSource = null;
        }

    }
}
