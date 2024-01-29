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
 
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CategoríaModel categoría = new CategoríaModel();
                categoría.Nombre = txtNombre.Text;
                CategoriasService service = new CategoriasService();
                service.InsertCategorías(categoría);

                dgvCategorías.DataSource = null;
                CategoriasService Categoriaservice = new CategoriasService();
                dgvCategorías.DataSource = Categoriaservice.GetCategorias();
            }

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
            txtNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvCategorías_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvCategorías_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CategoriasService service= new CategoriasService();
            CategoríaModel categoría = new CategoríaModel();
            var row = dgvCategorías.Rows[e.RowIndex];

            categoría.Id = int.Parse(row.Cells[0].Value.ToString());
            categoría.Nombre = row.Cells[1].Value.ToString();
            categoría.Estatus = row.Cells[2].Value.ToString();
            service.UpdateCategorías(categoría);
            dgvCategorías.DataSource = null;
            CategoriasService Categoriaservice = new CategoriasService();
            dgvCategorías.DataSource = Categoriaservice.GetCategorias();
        }
    }
}
