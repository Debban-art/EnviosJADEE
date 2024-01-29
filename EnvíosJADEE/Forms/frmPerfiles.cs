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
            dgvPerfiles.Columns[0].ReadOnly=true;
            dgvPerfiles.Columns[3].ReadOnly=true;
            dgvPerfiles.Columns[4].ReadOnly=true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtNombre.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PerfilModel perfilModel = new PerfilModel();
                perfilModel.Nombre = txtNombre.Text;

                PerfilService perfilService = new PerfilService();
                perfilService.InsertPerfil(perfilModel);

                dgvPerfiles.DataSource = null;
                dgvPerfiles.DataSource = perfilService.GetPerfiles();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvPerfiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PerfilService service = new PerfilService();
           PerfilModel Perfil = new PerfilModel();
            var row = dgvPerfiles.Rows[e.RowIndex];

           Perfil.Id = int.Parse(row.Cells[0].Value.ToString());
           Perfil.Nombre = row.Cells[1].Value.ToString();
           Perfil.Estatus = row.Cells[2].Value.ToString();
            service.UpdatePerfil(Perfil);

            dgvPerfiles.DataSource = null;
           
            dgvPerfiles.DataSource = service.GetPerfiles();
        }
    }
}
