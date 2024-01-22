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
            txtUsuario.Text = "";

            cmbModulo.Focus();
        }

        private void frmDetallePerfil_Load(object sender, EventArgs e)
        {
            DetallePerfilService service = new DetallePerfilService();

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DetallePerfilModel detallePerfil = new DetallePerfilModel();
                detallePerfil.IdModulo = int.Parse(cmbModulo.SelectedValue.ToString());
                detallePerfil.IdPerfil = int.Parse(cmbPerfil.SelectedValue.ToString());
                detallePerfil.Usuario = int.Parse(txtUsuario.Text);

                DetallePerfilService detallePerfilService = new DetallePerfilService();
                detallePerfilService.InsertDetallePerfil(detallePerfil);

                dgvDetallePerfil.DataSource = null;
                dgvDetallePerfil.DataSource = detallePerfilService.GetDetallePerfil();
            }

        }
    }
}
