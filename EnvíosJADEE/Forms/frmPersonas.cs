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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmPersonas : Form
    {
        PersonaUsuarioService personaService = new PersonaUsuarioService();
        public frmPersonas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtDireccion.Text = "";


            txtNombre.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
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
                InsertPersonaModel persona = new InsertPersonaModel();
                persona.Nombre = txtNombre.Text.Trim();
                persona.ApellidoPaterno = txtApPaterno.Text.Trim();
                persona.ApellidoMaterno = txtApMaterno.Text.Trim();
                persona.Dirección = txtDireccion.Text.Trim();

                UsuarioModel usuario = new UsuarioModel();
                usuario.IdPerfil = int.Parse(cmbPerfiles.SelectedValue.ToString());

                int resultado = personaService.InsertPersonaUsuario(persona, usuario);

                if (resultado == 1)
                {
                    MessageBox.Show("Cuenta añadida con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPersonas.DataSource = null;
                    dgvPersonas.DataSource = personaService.GetPersonasUsuario();
                    dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPersonas.Columns[0].ReadOnly = true;
                    dgvPersonas.Columns[4].ReadOnly = true;
                    dgvPersonas.Columns[7].ReadOnly = true;
                    dgvPersonas.Columns[9].ReadOnly = true;
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

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";


            dgvPersonas.DataSource = personaService.GetPersonasUsuario();
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.Columns[0].ReadOnly= true;
            dgvPersonas.Columns[4].ReadOnly = true;
            dgvPersonas.Columns[8].ReadOnly = true;
        }

        private void dgvPersonas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvPersonas.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    InsertPersonaModel persona = new InsertPersonaModel();
                    PerfilService perfilService = new PerfilService();
                    var row = dgvPersonas.Rows[e.RowIndex];

                    if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Trim() == "" || row.Cells[2].Value == null || row.Cells[2].Value.ToString().Trim() == "" ||row.Cells[3].Value == null || row.Cells[3].Value.ToString().Trim() == "" || row.Cells[5].Value == null || row.Cells[5].Value.ToString().Trim() == "" || row.Cells[6].Value == null || row.Cells[6].Value.ToString().Trim() == "" || row.Cells[7].Value == null || row.Cells[7].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[2].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[3].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[5].Value.ToString().Trim(), @"[!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[6].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[7].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[2].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[3].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[6].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success)
                    {
                        MessageBox.Show("Favor de ingresar un solo nombre/apellido por campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[7].Value.ToString().ToLower().Trim() != "activo" && row.Cells[7].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!perfilService.GetLowerPerfiles().Contains(row.Cells[6].Value.ToString().ToLower().Trim()))
                    {
                        MessageBox.Show("Ingrese un perfil válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //else
                    //{
                    //    persona.Id = int.Parse(row.Cells[0].Value.ToString());
                    //    persona.Nombre = row.Cells[1].Value.ToString();
                    //    persona.ApellidoPaterno = row.Cells[2].Value.ToString();
                    //    persona.ApellidoMaterno = row.Cells[3].Value.ToString();
                    //    persona.Dirección = row.Cells[5].Value.ToString();
                    //    persona.Estatus = row.Cells[8].Value.ToString();
                    //    personaService.UpdatePersonasUsuario(persona);

                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvPersonas.DataSource = null;
                dgvPersonas.DataSource = personaService.GetPersonasUsuario();
                return;
            }));


        }

        private void dgvPersonas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        { 
            if (e.ColumnIndex == 0 || e.ColumnIndex == 4 || e.ColumnIndex == 8)
            {
                e.Cancel = true;
            }
        }
    }
}
