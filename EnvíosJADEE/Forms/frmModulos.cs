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
    public partial class frmModulos : Form
    {
        public frmModulos()
        {
            InitializeComponent();
        }

        private void frmModulos_Load(object sender, EventArgs e)
        {
            //Mostrar en la dgv la tabla de modulos
            ModulosService service = new ModulosService();
            dgvModulos.DataSource = service.GetModulos();
            dgvModulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Mostrar en la cmb todas las categorías disponibles
            CategoriasService categoriasService = new CategoriasService();
            cmbCategoria.DataSource = categoriasService.GetCategorias();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Llamar el insertModulo
                ModulosService moduloService = new ModulosService();
                ModuloModel modulo = new ModuloModel();

                modulo.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                modulo.Nombre = txtNombre.Text;

                moduloService.InsertModulos(modulo);

                //Refresh la tabla de modulos
                dgvModulos.DataSource = null;
                dgvModulos.DataSource = moduloService.GetModulos();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbCategoria.SelectedIndex = 0;
            txtNombre.Text = "";

            cmbCategoria.Focus();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }
    }
}
