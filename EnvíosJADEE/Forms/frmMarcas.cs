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
    public partial class frmMarcas : Form
    {
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            MarcasService service = new MarcasService();
            dgvMarcas.DataSource = service.GetMarcas();

            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.Columns[0].ReadOnly = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void dgvMarcas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarcasService service = new MarcasService();
            MarcaModel Marcas = new MarcaModel();
            var row = dgvMarcas.Rows[e.RowIndex];

            Marcas.Id = int.Parse(row.Cells[0].Value.ToString());
            Marcas.marca = row.Cells[1].Value.ToString();
            Marcas.estatus = row.Cells[2].Value.ToString();
            service.UpdateMarcas(Marcas);

            dgvMarcas.DataSource = null;

            dgvMarcas.DataSource = service.GetMarcas();
        }
    }
}
