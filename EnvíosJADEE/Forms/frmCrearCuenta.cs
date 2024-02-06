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
    public partial class frmCrearCuenta : Form
    {
        public frmCrearCuenta()
        {
            InitializeComponent();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0 || txtApPaterno.Text.Trim().Length == 0 || txtApMaterno.Text.Trim().Length == 0 || txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PersonaModel persona = new PersonaModel();
                persona.Nombre = txtNombre.Text;
                persona.ApellidoPaterno = txtApPaterno.Text;
                persona.ApellidoMaterno = txtApMaterno.Text;
                persona.Dirección = txtDireccion.Text;

                UsuarioModel usuario = new UsuarioModel();
                usuario.IdPerfil = int.Parse(cmbPerfiles.SelectedValue.ToString());

                PersonaUsuarioService service = new PersonaUsuarioService();
                service.InsertPersonaUsuario(persona, usuario);

                LoginService login = new LoginService();
                login.Login(txtNombre.Text.Substring(0,1)+txtApPaterno.Text, "123456789");
                frmHome frmHome = new frmHome();
                frmHome.Show();
                this.Hide();
            }
        }

        private void frmCrearCuenta_Load(object sender, EventArgs e)
        {
            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";
        }
    }
}
