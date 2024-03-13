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
using System.Text.RegularExpressions;

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
            else if (Regex.Match(txtNombre.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtApPaterno.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtApMaterno.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtDireccion.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
            {
                MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Regex.Match(txtNombre.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(txtApPaterno.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(txtApMaterno.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success)
            {
                MessageBox.Show("Favor de ingresar un solo nombre/apellido por campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PersonaModel persona = new PersonaModel();
                persona.Nombre = txtNombre.Text.Trim();
                persona.ApellidoPaterno = txtApPaterno.Text.Trim();
                persona.ApellidoMaterno = txtApMaterno.Text.Trim();
                persona.Dirección = txtDireccion.Text.Trim();

                UsuarioModel usuario = new UsuarioModel();
                usuario.IdPerfil = int.Parse(cmbPerfiles.SelectedValue.ToString());

                PersonaUsuarioService service = new PersonaUsuarioService();
                int resultado = service.InsertPersonaUsuario(persona, usuario);

                if (resultado == 1)
                {
                    MessageBox.Show("Cuenta creada con éxito, seras redirigido a la pantalla de inicio", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginService login = new LoginService();
                    login.Login(txtNombre.Text.Substring(0, 1) + txtApPaterno.Text, "123456789");
                    frmHome frmHome = new frmHome();
                    frmHome.Show();
                    this.Hide();
                }
                else if (resultado == 0)
                {
                    MessageBox.Show("El usuario ya existe, trata de iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Algo salió mal, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmCrearCuenta_Load(object sender, EventArgs e)
        {
            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";
        }

        private void lnklblIniciarSesión_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePages.ChangeWindow(new frmLogin(), this);
        }
    }
}
