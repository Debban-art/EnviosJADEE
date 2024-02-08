using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
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

        private void btnAñadir_Click_1(object sender, EventArgs e)
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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMarcas(), this);
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmVehículos(), this);
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmCategorías(), this);
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new DetallePerfil(), this);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
        }
    }
}
