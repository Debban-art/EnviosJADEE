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
    public partial class frmPerfiles : Form
    {
        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            PerfilService perfilService = new PerfilService();
            dgvPerfiles.DataSource = perfilService.GetPerfiles();
            dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtUsuarioRegistra.Text = "";
            txtNombre.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            PerfilModel perfilModel = new PerfilModel();
            perfilModel.Nombre = txtNombre.Text;
            perfilModel.Usuario = int.Parse(txtUsuarioRegistra.Text);

            PerfilService perfilService = new PerfilService();
            perfilService.InsertPerfil(perfilModel);

            dgvPerfiles.DataSource = null;
            dgvPerfiles.DataSource = perfilService.GetPerfiles();
        }
    }
}
