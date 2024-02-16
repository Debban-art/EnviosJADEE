using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmEnvíos : Form
    {
        RegistroEnvioService ordenesService = new RegistroEnvioService();
        ProductosService productosService = new ProductosService();
        DireccionesService direccionesService = new DireccionesService();

        Dictionary<ProductosModel, int> ProductosTemporales = new Dictionary<ProductosModel, int>();
        //crear una lista temporal para los productos
        public frmEnvíos()
        {
            InitializeComponent();
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

            cmbEstado.DataSource = direccionesService.GetEstados(int.Parse(cmbPaís.SelectedValue.ToString()));
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";

            cmbMunicipio.DataSource = direccionesService.GetMunicipios(int.Parse(cmbEstado.SelectedValue.ToString()));
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "Id";

            cmbColonia.DataSource = direccionesService.GetColonias(int.Parse(cmbMunicipio.SelectedValue.ToString()));
            cmbColonia.DisplayMember = "Nombre";
            cmbColonia.ValueMember = "Id";
            #endregion

            txtCostoTotal.ReadOnly = true;
            txtPeso.ReadOnly = true;



            dgvOrdenes.DataSource = ordenesService.GetRegistroEnvios();


        }






        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //cmbIdCliente.SelectedIndex = 0;
            //cmbIdEstatusOrden.SelectedIndex = 0;
            //cmbIdProducto.SelectedIndex = 0;
            //txtCostoTotal.Text = "";
            //txtPeso.Text = "";
            //txtFechaSalida.Text = "";
            //txtFechaEntrega.Text = "";
            //txtPais.Text = "";
            //txtEstado.Text = "";
            //txtCiudad.Text = "";
            //txtCodigoPostal.Text = "";
            //txtDomicilio.Text = "";
            //txtCalle.Text = "";
            //txtNoCasa.Text = "";

            //cmbIdCliente.Focus();

            //Se reinicia la lista
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //if (txtCostoTotal.Text.Trim().Length == 0 || txtPeso.Text.Trim().Length == 0 || txtFechaSalida.Text.Trim().Length == 0 || txtFechaEntrega.Text.Trim().Length == 0
            //    || txtPais.Text.Trim().Length == 0 || txtEstado.Text.Trim().Length == 0 || txtCiudad.Text.Trim().Length == 0 || txtCodigoPostal.Text.Trim().Length == 0
            //    || txtDomicilio.Text.Trim().Length == 0 || txtCalle.Text.Trim().Length == 0 || txtNoCasa.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    RegistroEnvioModel envio = new RegistroEnvioModel();
            //    envio.CostoTotal = float.Parse(txtCostoTotal.ToString());
            //    envio.Peso = float.Parse(txtPeso.ToString());
            //    envio.FechaSalida = txtFechaSalida.Text;
            //    envio.FechaEntrega = txtFechaEntrega.Text;
            //    envio.Pais = txtPais.Text;
            //    envio.Estado = txtEstado.Text;
            //    envio.Ciudad = txtCiudad.Text;
            //    envio.CodigoPostal = txtCodigoPostal.Text;
            //    envio.Domicilio = txtDomicilio.Text;
            //    envio.Calle = txtCalle.Text;
            //    envio.NoCasa = txtNoCasa.Text;
            //    envio.IdCliente = int.Parse(cmbIdCliente.SelectedValue.ToString());
            //    envio.IdEstatusOrden = int.Parse(envio.IdEstatusOrden.ToString());
            //    envio.IdProducto = int.Parse(envio.IdProducto.ToString());



            //    RegistroEnvioService service = new RegistroEnvioService();
            //    //service.InsertRegistroEnvio(envio);

            //    service.InsertOrdenes(envio);


            //    dgvOrdenes.DataSource = null;
            //    //dgvRegistroEnvio.DataSource = service.GetRegistroEnvio();



            //}

            //
        }

        private void dgvRegistroEnvio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRegistroEnvio_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //RegistroEnvioService service = new RegistroEnvioService();
            //RegistroEnvioModel envio = new RegistroEnvioModel();
            //var row = dgvOrdenes.Rows[e.RowIndex];

            //envio.IdCliente = int.Parse(row.Cells[1].Value.ToString());
            //envio.IdProducto = int.Parse(row.Cells[2].Value.ToString());
            //envio.IdEstatusOrden = int.Parse(row.Cells[3].Value.ToString());
            //envio.CostoTotal = float.Parse(row.Cells[4].Value.ToString());
            //envio.Peso = float.Parse(row.Cells[5].Value.ToString());
            //envio.FechaSalida = row.Cells[6].Value.ToString();
            //envio.FechaEntrega = row.Cells[7].Value.ToString();
            //envio.Pais = row.Cells[8].Value.ToString();
            //envio.Estado = row.Cells[9].Value.ToString();
            //envio.Ciudad = row.Cells[10].Value.ToString();
            //envio.CodigoPostal = row.Cells[11].Value.ToString();
            //envio.Domicilio = row.Cells[12].Value.ToString();
            //envio.Calle = row.Cells[13].Value.ToString();
            //envio.NoCasa = row.Cells[14].Value.ToString();



            ////envio.UpdateRegistroEnvio(Ordenes);
            //dgvOrdenes.DataSource = null;
            //RegistroEnvioService RegistroEnvioService = new RegistroEnvioService();
            ////dgvRegistroEnvio.DataSource = service.GetRegistroEnvio();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(cmbProducto.SelectedValue.ToString());
            
            ProductosModel producto = ordenesService.GetProductoById(idProducto)[0];
            if (!ProductosTemporales.ContainsKey(producto)){
                ProductosTemporales.Add(producto, 1);
            }
            else
            {
                ProductosTemporales[producto]++;
            }

            float costoTotal = 0;
            float pesoTotal = 0;
            foreach (ProductosModel productoModel in ProductosTemporales.Keys)
            {
                costoTotal += productoModel.Precio;
                pesoTotal += productoModel.Peso;
            }

            txtCostoTotal.Text = costoTotal.ToString();
            txtPeso.Text = pesoTotal.ToString();
        }

        private void btnAñadir_Click_1(object sender, EventArgs e)
        {
            if (txtNombreEmisor.Text.Trim().Length == 0 || txtApellidoPatDestinatario.Text.Trim().Length == 0 || txtApellidoMatDestinatario.Text.Trim().Length == 0 || txtNombreDestinatario.Text.Trim().Length == 0 || txtCodigoPostal.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvOrdenes.DataSource = ordenesService.GetRegistroEnvios(); // Suponiendo que GetOrdenes() devuelve las órdenes desde la base de datos
                }
                else
                {
                    MessageBox.Show("Error al insertar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
