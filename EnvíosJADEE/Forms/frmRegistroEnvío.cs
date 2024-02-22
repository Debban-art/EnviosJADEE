using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EnvíosJADEE.Forms
{
    public partial class frmEnvíos : Form
    {
        #region variables
        RegistroEnvioService ordenesService = new RegistroEnvioService();
        ProductosService productosService = new ProductosService();
        TrackingService trackingService = new TrackingService();
        DireccionesService direccionesService = new DireccionesService();

        float costoTotal = 0;
        float pesoTotal = 0;

        Dictionary<int, int> ProductosTemporales = new Dictionary<int, int>();
        #endregion

        public frmEnvíos()
        {
            InitializeComponent();

            cmbPaís.SelectedIndexChanged += CmbPais_SelectedIndexChanged;
            cmbEstado.SelectedIndexChanged += CmbEstado_SelectedIndexChanged;
        }
        private void frmRegistroEnvío_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            #region combo boxs
            cmbProducto.DataSource = productosService.GetProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";

            cmbPaís.DataSource = direccionesService.GetPais();
            cmbPaís.DisplayMember = "Nombre";
            cmbPaís.ValueMember = "Id";
            #endregion

            txtCostoTotal.ReadOnly = true;
            txtPeso.ReadOnly = true;
            dgvOrdenes.DataSource = ordenesService.GetRegistroEnvios();
            dgvOrdenes.Columns[0].ReadOnly = true;
            dgvOrdenes.Columns[1].ReadOnly = true;
            dgvOrdenes.Columns[2].ReadOnly = true;
            dgvOrdenes.Columns[3].ReadOnly = true;
            dgvOrdenes.Columns[4].ReadOnly = true;
            dgvOrdenes.Columns[5].ReadOnly = true;
            dgvOrdenes.Columns[6].ReadOnly = true;
            dgvOrdenes.Columns[7].ReadOnly = true;
            dgvOrdenes.Columns[8].ReadOnly = true;
            dgvOrdenes.Columns[9].ReadOnly = true;
            dgvOrdenes.Columns[10].ReadOnly = true;
            dgvOrdenes.Columns[11].ReadOnly = true;
            dgvOrdenes.Columns[12].ReadOnly = true;
            dgvOrdenes.Columns[13].ReadOnly = true;
            dgvOrdenes.Columns[14].ReadOnly = true;
            dgvOrdenes.Columns[15].ReadOnly = true;
            dgvOrdenes.Columns[16].ReadOnly = true;
            dgvOrdenes.Columns[17].ReadOnly = true;
            dgvOrdenes.Columns[18].ReadOnly = true;
            dgvOrdenes.Columns[19].ReadOnly = true;
            dgvOrdenes.Columns[20].ReadOnly = true;
            dgvOrdenes.Columns[21].ReadOnly = false;
        }


        #region Sección de productos
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(cmbProducto.SelectedValue.ToString());


            if (!ProductosTemporales.ContainsKey(idProducto))
            {
                ProductosTemporales.Add(idProducto, 1);

            }
            else
            {
                ProductosTemporales[idProducto]++;
            }

            ProductosModel producto = ordenesService.GetProductoById(idProducto)[0];
            costoTotal += producto.Precio;
            pesoTotal += producto.Peso;

            txtCostoTotal.Text = costoTotal.ToString();
            txtPeso.Text = pesoTotal.ToString();
        }
        #endregion

        #region sección de dirección
        private void CmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int paisId = ((PaisModels)cmbPaís.SelectedItem).Id;

            cmbEstado.DataSource = null;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";
            cmbEstado.DataSource = direccionesService.GetEstados(paisId);

        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedItem != null)
            {
                int estadoId = ((EstadosModel)cmbEstado.SelectedItem).Id;

                cmbMunicipio.DataSource = null;
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "Id";
                cmbMunicipio.DataSource = direccionesService.GetMunicipios(estadoId);

            }
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipio.SelectedItem != null)
            {
                int municipioId = ((MunicipioModel)cmbMunicipio.SelectedItem).Id;
                cmbColonia.DataSource = null;
                cmbColonia.DisplayMember = "Nombre";
                cmbColonia.ValueMember = "Id";
                cmbColonia.DataSource = direccionesService.GetColonias(municipioId);

                txtCodigoPostal.Text = ((ColoniaModel)cmbColonia.SelectedItem).CodigoPostal.ToString();
            }

        }

        private void txtCodigoPostal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigoPostal.Text.Trim() != "")
                {
                    int CodigoPostal = int.Parse(txtCodigoPostal.Text);

                    DirecciónModel dirección = direccionesService.GetDireccionPorCodigoPostal(CodigoPostal)[0];

                    if (dirección != null)
                    {
                        cmbPaís.SelectedValue = dirección.IdPais;
                        cmbEstado.SelectedValue = dirección.IdEstado;
                        cmbMunicipio.SelectedValue = dirección.IdMunicipio;
                    }
                }

            }
        }
        #endregion

        #region sección botones
        private void btnAñadir_Click_1(object sender, EventArgs e)
        {
            if (txtNombreEmisor.Text.Trim() == "" || txtApellidoPatDestinatario.Text.Trim() == "" || txtApellidoMatDestinatario.Text.Trim() == "" || txtNombreDestinatario.Text.Trim() == "" || txtCodigoPostal.Text.Trim() == "" || txtCalle.Text.Trim() == "" || txtTelefonoDestinatario.Text.Trim() == "" || txtNoCasa.Text.Trim() == "")
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtCostoTotal.Text.Trim() == "" || txtPeso.Text.Trim() == "")
            {
                MessageBox.Show("Añade al menos un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!ValidarTelefono(txtTelefonoDestinatario.Text))
            {
                MessageBox.Show("Número de teléfono inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OrdenModel orden = new OrdenModel();
                orden.CostoTotal = float.Parse(txtCostoTotal.Text);
                orden.Peso = float.Parse(txtPeso.Text);
                orden.NombreEmisor = txtNombreEmisor.Text;
                orden.IdPais = int.Parse(cmbPaís.SelectedValue.ToString());
                orden.IdEstado = int.Parse(cmbEstado.SelectedValue.ToString());
                orden.IdMunicipio = int.Parse(cmbMunicipio.SelectedValue.ToString());
                orden.idColonia = int.Parse(cmbColonia.SelectedValue.ToString());
                orden.Calle = txtCalle.Text;
                orden.NoCasa = int.Parse(txtNoCasa.Text);
                orden.CodigoPostal = int.Parse(txtCodigoPostal.Text);
                orden.NombreDestinatario = txtNombreDestinatario.Text;
                orden.ApellidoPatDestinatario = txtApellidoPatDestinatario.Text;
                orden.ApellidoMatDestinatario = txtApellidoMatDestinatario.Text;
                orden.TelefonoDestinatario = txtTelefonoDestinatario.Text;


                string resultado = ordenesService.InsertOrdenes(orden);

                if (resultado == "Correcto")
                {
                    MessageBox.Show("Orden insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvOrdenes.DataSource = null;
                    dgvOrdenes.DataSource = ordenesService.GetRegistroEnvios();

                    int filaUltimoModelo = dgvOrdenes.Rows.Count - 1;
                    string clave = dgvOrdenes.Rows[filaUltimoModelo].Cells["Clave"].Value.ToString();

                    foreach (int id in ProductosTemporales.Keys)
                    {
                        ordenesService.InsertDetallesOrdenes(id, ProductosTemporales[id]);
                    }

                    costoTotal = 0;
                    pesoTotal = 0;

                    TrackingModel NuevoRegistro = new TrackingModel();
                    NuevoRegistro.ClaveOrden = clave;
                    NuevoRegistro.CambioRegistrado = "El paquete está siendo preparado para su envío";

                    trackingService.InsertNuevoRegistro(NuevoRegistro);
                }
                else
                {
                    MessageBox.Show("Error al insertar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            txtNombreEmisor.Text = "";
            cmbProducto.SelectedIndex = 0;
            ProductosTemporales = new Dictionary<int, int>();
            costoTotal = 0;
            pesoTotal = 0;
            txtCostoTotal.Text = "";
            txtPeso.Text = "";
            txtCalle.Text = "";
            txtNoCasa.Text = "";
            txtNombreDestinatario.Text = "";
            txtApellidoPatDestinatario.Text = "";
            txtApellidoMatDestinatario.Text = "";
            txtTelefonoDestinatario.Text = "";
        }
        #endregion

        private void dgvOrdenes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvOrdenes.Rows[e.RowIndex];

            string Estatus = row.Cells["Estatus"].Value.ToString();
            int IdOrden = int.Parse(row.Cells["Id"].Value.ToString());
            ordenesService.UpdateActEstatusRegistroEnvios(Estatus, IdOrden);
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = ordenesService.GetRegistroEnvios();
        }

        private bool ValidarTelefono(string numero)
        {
            string patron = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(numero, patron);
        }

        private void gpbDatosDestinatario_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
