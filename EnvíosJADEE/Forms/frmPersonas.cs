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
    public partial class frmPersonas : Form
    {
        public frmPersonas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtDirección.Text = "";


            txtNombre.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0 || txtApPaterno.Text.Trim().Length == 0 || txtApMaterno.Text.Trim().Length == 0 || txtDirección.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PersonaModel persona = new PersonaModel();
                persona.Nombre = txtNombre.Text;
                persona.ApellidoPaterno = txtApPaterno.Text;
                persona.ApellidoMaterno= txtApMaterno.Text;
                persona.Dirección = txtDirección.Text;

                UsuarioModel usuario= new UsuarioModel();
                usuario.IdPerfil = int.Parse(cmbPerfiles.SelectedValue.ToString());

                PersonaUsuarioService service = new PersonaUsuarioService();
                service.InsertPersonaUsuario(persona, usuario);

                dgvPersonas.DataSource = null;
                dgvPersonas.DataSource = service.GetPersonasUsuario();



            }
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";

            PersonaUsuarioService personaService = new PersonaUsuarioService();
            dgvPersonas.DataSource = personaService.GetPersonasUsuario();
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.Columns[0].ReadOnly= true;
            dgvPersonas.Columns[4].ReadOnly = true;
            dgvPersonas.Columns[7].ReadOnly = true;
            dgvPersonas.Columns[9].ReadOnly = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvPersonas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            PersonaUsuarioService service = new PersonaUsuarioService();
            PersonaModel persona = new PersonaModel();
            var row = dgvPersonas.Rows[e.RowIndex];

            persona.Id = int.Parse(row.Cells[0].Value.ToString());
            persona.Nombre = row.Cells[1].Value.ToString();
            persona.ApellidoPaterno = row.Cells[2].Value.ToString();
            persona.ApellidoMaterno = row.Cells[3].Value.ToString();
            persona.Dirección = row.Cells[5].Value.ToString();
            persona.Estatus = row.Cells[8].Value.ToString();
            service.UpdatePersonasUsuario(persona);
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = service.GetPersonasUsuario();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
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

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmDetallePerfil(), this);
            
        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
