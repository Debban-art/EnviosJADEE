using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            MarcasService service = new MarcasService();
            dgvMarcas.DataSource = service.GetMarcas();

            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.Columns[0].ReadOnly = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvMarcas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarcasService service = new MarcasService();
            MarcaModel Marcas = new MarcaModel();
            var row = dgvMarcas.Rows[e.RowIndex];

            Marcas.Id = int.Parse(row.Cells[0].Value.ToString());
            Marcas.marca = row.Cells[1].Value.ToString();
            Marcas.estatus = row.Cells[2].Value.ToString();
            service.UpdateMarcas(Marcas);

            dgvMarcas.DataSource = null;

            dgvMarcas.DataSource = service.GetMarcas();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MarcaModel Marca = new MarcaModel();
                Marca.marca = txtMarca.Text;
                MarcasService service = new MarcasService();
                service.InsertMarcas(Marca);

                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = service.GetMarcas();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            txtMarca.Focus();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

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
            ChangePages.ChangeWindow(new frmDetallePerfil(), this);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMedios(), this);
        }
    }
}
