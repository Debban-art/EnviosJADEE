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
            //Llamar el insertModulo
            ModulosService moduloService = new ModulosService();
            ModuloModel modulo = new ModuloModel();

            modulo.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
            modulo.Nombre = txtNombre.Text;
            modulo.Usuario = int.Parse(txtUsuario.Text);

            moduloService.InsertModulos(modulo);

            //Refresh la tabla de modulos
            dgvModulos.DataSource = null;
            dgvModulos.DataSource = moduloService.GetModulos();

        }
    }
}
