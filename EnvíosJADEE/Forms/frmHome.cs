using EnvíosJADEE.Clases;
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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehículos frmVehículos = new frmVehículos();
            frmVehículos.Show();

            this.Hide();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas = new frmMarcas();
            frmMarcas.Show();

            this.Hide();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorías frmCategorías = new frmCategorías();
            frmCategorías.Show();

            this.Hide();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModulos frmModulos = new frmModulos();
            frmModulos.Show();

            this.Hide();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPerfiles frmPerfiles = new frmPerfiles();
            frmPerfiles.Show();

            this.Hide();
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetallePerfil frmDetalle= new frmDetallePerfil();
            frmDetalle.Show();

            this.Hide();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonas frmPersonas = new frmPersonas();
            frmPersonas.Show();

            this.Hide();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = SesionClass.NombreUsuario;
        }
    }
}
