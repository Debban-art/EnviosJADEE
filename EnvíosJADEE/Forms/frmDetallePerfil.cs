using EnvíosJADEE.Clases;
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
    public partial class frmDetallePerfil : Form
    {
        public frmDetallePerfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbModulo.SelectedIndex = 0;
            cmbPerfil.SelectedIndex = 0;

            cmbModulo.Focus();
        }

        private void frmDetallePerfil_Load(object sender, EventArgs e)
        {
            DetallePerfilService service = new DetallePerfilService();
            MenuBuilder.BuildMenu(this);

            dgvDetallePerfil.DataSource = service.GetDetallePerfil();
            dgvDetallePerfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ModulosService modulosService = new ModulosService(); 
            PerfilService perfilService = new PerfilService();

            cmbModulo.DataSource = modulosService.GetModulos();
            cmbModulo.DisplayMember = "Nombre";
            cmbModulo.ValueMember = "Id";

            cmbPerfil.DataSource = perfilService.GetPerfiles();
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "Id";

            dgvDetallePerfil.Columns[0].ReadOnly = true;
            dgvDetallePerfil.Columns[2].ReadOnly = true;
            dgvDetallePerfil.Columns[4].ReadOnly = true;
            dgvDetallePerfil.Columns[6].ReadOnly = true;
            dgvDetallePerfil.Columns[7].ReadOnly = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DetallePerfilModel detallePerfil = new DetallePerfilModel();
            detallePerfil.IdModulo = int.Parse(cmbModulo.SelectedValue.ToString());
            detallePerfil.IdPerfil = int.Parse(cmbPerfil.SelectedValue.ToString());

            DetallePerfilService detallePerfilService = new DetallePerfilService();
            detallePerfilService.InsertDetallePerfil(detallePerfil);

            dgvDetallePerfil.DataSource = null;
            dgvDetallePerfil.DataSource = detallePerfilService.GetDetallePerfil();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();

        }

        private void dgvDetallePerfil_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DetallePerfilService service = new DetallePerfilService();
            DetallePerfilModel DetallePerfil = new DetallePerfilModel();
            var row = dgvDetallePerfil.Rows[e.RowIndex];

            DetallePerfil.Id = int.Parse(row.Cells[0].Value.ToString());
            DetallePerfil.IdModulo = int.Parse(row.Cells[1].Value.ToString());
            DetallePerfil.IdPerfil = int.Parse(row.Cells[3].Value.ToString());
            DetallePerfil.Estatus = row.Cells[5].Value.ToString();
            service.UpdateDetallePerfil(DetallePerfil);

            dgvDetallePerfil.DataSource = null;
            dgvDetallePerfil.DataSource = service.GetDetallePerfil();
        }

        private void dgvDetallePerfil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }
        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMedios(), this);
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

        private void modulosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }

        private void perfilToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
        }
    }
}
