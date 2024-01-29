using EnvíosJADEE.Forms;
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

namespace EnvíosJADEE
{
    public partial class frmLogin : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void chkContraseñaVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContraseñaVisible.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            LoginService login = new LoginService();
            if (login.Login(txtUsuario.Text, txtContraseña.Text))
            {
                frmHome frmHome = new frmHome();
                frmHome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña inválido", "Credenciales inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lnklblCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonas frmPersonas = new frmPersonas();
            frmPersonas.Show();
            this.Hide();
        }
    }
}
