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
    public partial class frmVehículos : Form
    {
        public frmVehículos()
        {
            InitializeComponent();
        }

        private void frmVehículos_Load(object sender, EventArgs e)
        {
            VehiculosService service = new VehiculosService();
            dgvVehiculos.DataSource = service.GetVehiculos();

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
                Vehiculo.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());
                Vehiculo.IdTipo = int.Parse(cmbTipo.SelectedValue.ToString());
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

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVehiculos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            VehiculosService service = new VehiculosService();
            VehiculoModel vehiculo = new VehiculoModel();
            var row = dgvVehiculos.Rows[e.RowIndex];

            vehiculo.IdTipo = int.Parse(row.Cells[0].Value.ToString());
            vehiculo.matricula = row.Cells[1].Value.ToString();
            vehiculo.modelo = row.Cells[3].Value.ToString();
            vehiculo.IdMarca = int.Parse(row.Cells[2].Value.ToString());
            vehiculo.NoSerie = int.Parse(row.Cells[4].Value.ToString()); 
            service.UpdateVehiculo(vehiculo);
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = service.GetVehiculos();
        }
    }
}



  