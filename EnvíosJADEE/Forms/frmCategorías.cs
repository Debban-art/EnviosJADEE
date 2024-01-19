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
    public partial class frmCategorías : Form
    {
        public frmCategorías()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            CategoríaModel categoría = new CategoríaModel();
            categoría.Nombre = txtNombre.Text;
            categoría.Usuario = int.Parse(txtUsuario.Text);
            CategoriasService service= new CategoriasService();
            service.InsertCategorías(categoría);

            dgvCategorías.DataSource = null;
            CategoriasService Categoriaservice = new CategoriasService();
            dgvCategorías.DataSource = Categoriaservice.GetCategorias();
            dgvCategorías.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmCategorías_Load(object sender, EventArgs e)
        {
            CategoriasService service = new CategoriasService();
            dgvCategorías.DataSource= service.GetCategorias();
            dgvCategorías.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }
    }
}
