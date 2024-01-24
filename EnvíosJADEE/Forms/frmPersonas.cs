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


            }
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }
    }
}
