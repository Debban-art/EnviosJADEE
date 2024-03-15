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
    public partial class frmPerfiles : Form
    {
        PerfilService perfilService = new PerfilService();
        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

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
            try
            {
                if (txtNombre.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se puede dejar el campo en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtNombre.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PerfilModel perfilModel = new PerfilModel();
                    perfilModel.Nombre = txtNombre.Text;


                    int resultado = perfilService.InsertPerfil(perfilModel);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Perfil añadido exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("El perfil ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dgvPerfiles.DataSource = null;
            dgvPerfiles.DataSource = perfilService.GetPerfiles();

        }

        private void dgvPerfiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            perfilService = new PerfilService();
            PerfilModel Perfil = new PerfilModel();
            var row = dgvPerfiles.Rows[e.RowIndex];

            Perfil.Id = int.Parse(row.Cells[0].Value.ToString());
            Perfil.Nombre = row.Cells[1].Value.ToString();
            Perfil.Estatus = row.Cells[2].Value.ToString();
            perfilService.UpdatePerfil(Perfil);

            dgvPerfiles.DataSource = null;
           
            dgvPerfiles.DataSource = perfilService.GetPerfiles();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmDetallePerfil(), this);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
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
    }
}
