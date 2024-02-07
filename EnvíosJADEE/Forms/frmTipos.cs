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
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtTipo.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TipoModel Tipo = new TipoModel();
                Tipo.Tipo = txtTipo.Text;
                TipoService service = new TipoService();
                service.InsertTipo(Tipo);

                dgvTipos.DataSource = null;
                dgvTipos.DataSource = service.GetTipos();

            }
        }

        private void frmTipos_Load(object sender, EventArgs e)
        {
            TipoService service = new TipoService();
            dgvTipos.DataSource = service.GetTipos();
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.Columns[0].ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTipo.Text = "";
            txtTipo.Focus();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }
    }
}
