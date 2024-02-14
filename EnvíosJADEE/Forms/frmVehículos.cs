using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmVehículos : Form
    {
        public frmVehículos()
        {
            InitializeComponent();
        }

        private void frmVehículos_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            VehiculosService service = new VehiculosService();
            dgvVehiculos.DataSource = service.GetVehiculos();
            dgvVehiculos.Columns[0].ReadOnly = true;
            dgvVehiculos.Columns[2].ReadOnly = true;
            dgvVehiculos.Columns[5].ReadOnly = true;
            dgvVehiculos.Columns[8].ReadOnly = true;

            MarcasService marcasService = new MarcasService();
            cmbMarca.DataSource = marcasService.GetMarcas();
            cmbMarca.DisplayMember = "marca";
            cmbMarca.ValueMember = "Id";

            TipoService tipoService = new TipoService();
            cmbTipo.DataSource = tipoService.GetTipos();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "Id";

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Close();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtModelo.Text.Trim().Length == 0 || txtMatrícula.Text.Trim().Length == 0 || txtNoId.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                VehiculoModel Vehiculo = new VehiculoModel();
                Vehiculo.modelo = txtModelo.Text;
                Vehiculo.matricula = txtMatrícula.Text;
                Vehiculo.idMarca = int.Parse(cmbMarca.SelectedValue.ToString());
                Vehiculo.idTipo = int.Parse(cmbTipo.SelectedValue.ToString());
                Vehiculo.NoSerie = int.Parse(txtNoId.Text.Trim());



                VehiculosService service = new VehiculosService();
                service.InsertVehiculo(Vehiculo);

                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource = service.GetVehiculos();



            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


            txtModelo.Text = "";
            txtMatrícula.Text = "";
            txtNoId.Text = "";



            txtModelo.Focus();

        }

        private void dgvVehiculos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            VehiculosService service = new VehiculosService();
            VehiculoModel vehiculo = new VehiculoModel();
            var row = dgvVehiculos.Rows[e.RowIndex];

            vehiculo.id = int.Parse(row.Cells[0].Value.ToString());
            vehiculo.idTipo = int.Parse(row.Cells[1].Value.ToString());
            vehiculo.matricula = row.Cells[3].Value.ToString();
            vehiculo.modelo = row.Cells[6].Value.ToString();
            vehiculo.idMarca = int.Parse(row.Cells[4].Value.ToString());
            vehiculo.NoSerie = int.Parse(row.Cells[7].Value.ToString());
            vehiculo.estatus = row.Cells[9].Value.ToString();
            service.UpdateVehiculo(vehiculo);

            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = service.GetVehiculos();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmCategorías(), this);
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
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
    }
}



