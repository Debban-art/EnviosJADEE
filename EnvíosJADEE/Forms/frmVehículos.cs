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
    }
}
