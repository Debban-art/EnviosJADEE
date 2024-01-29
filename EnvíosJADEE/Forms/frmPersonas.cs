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
            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";

            PersonaUsuarioService personaService = new PersonaUsuarioService();
            dgvPersonas.DataSource = personaService.GetPersonasUsuario();
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            persona.Estatus = row.Cells[6].Value.ToString();
            service.UpdatePersonasUsuario(persona);
            dgvPersonas.DataSource = null;
            CategoriasService Categoriaservice = new CategoriasService();
            dgvPersonas.DataSource = Categoriaservice.GetCategorias();
        }
    }
}
