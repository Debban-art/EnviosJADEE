using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmDetallesDeOrden : Form
    {
        //todo list
        //Agregar funcionalidades cancelar
        //Hacer readOnly a todos excepto estatus, repartidor.
        //Cargar en automático de nuevo al cambiar estatus
        DetallesDeOrdenService detallesDeOrdenService = new DetallesDeOrdenService();
        DireccionesService direccionesService = new DireccionesService();
        TrackingService trackingService = new TrackingService();
        Label lblRepartidores = new Label();
        ComboBox cmbRepartidores = new ComboBox();
        public frmDetallesDeOrden()
        {
            InitializeComponent();
        }

        private void frmDetallesDeOrden_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            btnCancelar.Location = new Point(btnMostrar.Right + 10, btnMostrar.Top);


            btnCambiar.Location = new Point(cmbEstatus.Right + 4, cmbEstatus.Top);

            lblRepartidores.Location = new System.Drawing.Point(cmbEstatus.Right + 5, lblEstatus.Top);
            lblRepartidores.Font = new Font("Yu Gothic UI", 12);
            lblRepartidores.Text = "Repartidor";

            cmbRepartidores.Location = new System.Drawing.Point(cmbEstatus.Right + 5, cmbEstatus.Top);
            cmbRepartidores.Size = new System.Drawing.Size(cmbEstatus.Width, cmbEstatus.Height);
            RepartidoresService repartidoresService = new RepartidoresService();
            cmbRepartidores.DataSource = repartidoresService.GetRepartidores();
            cmbRepartidores.DisplayMember = "Nombre";
            cmbRepartidores.ValueMember = "Id";
            cmbRepartidores.Size = cmbEstatus.Size;
            cmbRepartidores.Font = cmbEstatus.Font;
            cmbRepartidores.BackColor = cmbEstatus.BackColor;

            lblClaveRepartidor.Location = new Point(cmbRepartidores.Right + 5, lblRepartidores.Top);

            txtClaveRepartidor.Location = new Point(cmbRepartidores.Right + 5, cmbRepartidores.Top);

            gpbDatosEnvio.Controls.Add(lblRepartidores);
            gpbDatosEnvio.Controls.Add(cmbRepartidores);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {


            btnActualizarEstatus.Visible = true;
            btnActualizarEstatus.Location = new Point(btnMostrar.Right + 10, btnMostrar.Top);
            btnCancelar.Location = new Point(btnActualizarEstatus.Right + 10, btnActualizarEstatus.Top);

            LoadData();

        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden == "Enviado")
            {
                btnCambiar.Location = new Point(cmbRepartidores.Right + 10, cmbRepartidores.Top);

                lblRepartidores.Visible = true;

                cmbRepartidores.Visible = true;
                cmbRepartidores.Enabled = true;

                lblClaveRepartidor.Visible = false;
                txtClaveRepartidor.Visible = false;
            }
            else if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden != "Pendiente")
            {
                btnCambiar.Location = new Point(txtClaveRepartidor.Right + 10, cmbRepartidores.Top);

                lblRepartidores.Visible = true;

                cmbRepartidores.Visible = true;
                cmbRepartidores.Enabled = false;

                lblClaveRepartidor.Visible = true;
                txtClaveRepartidor.Visible = true;
            }
            else
            {
                lblRepartidores.Visible = false;
                cmbRepartidores.Visible = false;
                cmbRepartidores.Enabled = false;
                lblClaveRepartidor.Visible = false;
                txtClaveRepartidor.Visible = false;
                btnCambiar.Location = new Point(cmbEstatus.Right + 4, cmbEstatus.Top);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            RegistroEnvioService registroEnvioService = new RegistroEnvioService();
            string ClaveOrden = txtClave.Text;
            DetallesEnvíoModel detallesEnvío = detallesDeOrdenService.GetDetallesOrden(ClaveOrden)[0];

            int IdNuevoEstatus = int.Parse(cmbEstatus.SelectedValue.ToString());
            int IdRepartidor = int.Parse(cmbRepartidores.SelectedValue.ToString());

            if ( IdNuevoEstatus != detallesEnvío.IdEstatusDeOrden)
            {
                registroEnvioService.UpdateEstatusOrden(IdNuevoEstatus, ClaveOrden, IdRepartidor);

                TrackingModel nuevoRegistro = new TrackingModel();
                nuevoRegistro.ClaveOrden = ClaveOrden;

                if (IdNuevoEstatus == 2)
                {
                    nuevoRegistro.CambioRegistrado = "El paquete ha salido de la estación ";
                }
                else if (IdNuevoEstatus == 3)
                {
                    nuevoRegistro.CambioRegistrado = "El paquete está en camino a su entrega";
                }
                else if (IdNuevoEstatus == 4)
                {
                    nuevoRegistro.CambioRegistrado = "El paquete ha sido entregado";
                }
                else
                {
                    nuevoRegistro.CambioRegistrado = "El paquete ha sido cancelado";
                }

                trackingService.InsertNuevoRegistro(nuevoRegistro);
            }

            LoadData();
        }

        private void LoadEstados(int idPais, int idEstado)
        {
            cmbEstado.DataSource = null;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";
            cmbEstado.DataSource = direccionesService.GetEstados(idPais);
            cmbEstado.SelectedValue = idEstado;
        }

        private void LoadMunicipios(int idEstado, int idMunicipio)
        {
            cmbMunicipio.DataSource = null;
            cmbMunicipio.DisplayMember = "Nombre";
            cmbMunicipio.ValueMember = "Id";
            cmbMunicipio.DataSource = direccionesService.GetMunicipios(idEstado);
            cmbMunicipio.SelectedValue = idMunicipio;
        }
        private void LoadColonias (int idMunicipio, int idColonia)
        {
            cmbColonia.DataSource = null;
            cmbColonia.DisplayMember = "Nombre";
            cmbColonia.ValueMember = "Id";
            cmbColonia.DataSource = direccionesService.GetColonias(idMunicipio);
            cmbColonia.SelectedValue = idColonia;
        }

        private void gpbDatosEnvio_Enter(object sender, EventArgs e)
        {

        }

        private void btnActualizarEstatus_Click(object sender, EventArgs e)
        {
            cmbEstatus.Enabled = true;
            btnCambiar.Visible = true;

        }

        private void LoadData()
        {
            string ClaveOrden = txtClave.Text;
            #region dgvOrden
            DetallesEnvíoModel detallesEnvío = detallesDeOrdenService.GetDetallesOrden(ClaveOrden)[0];
            cmbEstatus.DataSource = detallesDeOrdenService.GetEstatusOrden(detallesEnvío);
            cmbEstatus.DisplayMember = "NombreEstatusOrden";
            cmbEstatus.ValueMember = "Id";
            cmbEstatus.SelectedValue = detallesEnvío.IdEstatusDeOrden; 

            cmbRepartidores.SelectedValue = detallesEnvío.IdRepartidor;
            txtClaveRepartidor.Text = detallesEnvío.ClaveRepartidor;

            cmbEstatus.Enabled = false;
            cmbRepartidores.Enabled = false;
            txtClaveRepartidor.Enabled = false;
            btnCambiar.Visible = false;

            if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden != "Pendiente")
            {
                btnCambiar.Location = new Point(txtClaveRepartidor.Right + 10, cmbRepartidores.Top);

                lblRepartidores.Visible = true;
                cmbRepartidores.Visible = true;
                lblClaveRepartidor.Visible = true;
                txtClaveRepartidor.Visible = true;
            }
            else
            {
                lblRepartidores.Visible = false;
                cmbRepartidores.Visible = false;
                lblClaveRepartidor.Visible = false;
                txtClaveRepartidor.Visible = false;
                btnCambiar.Location = new Point(cmbEstatus.Right + 4, cmbEstatus.Top);
            }



            txtNombreEmisor.Text = detallesEnvío.NombreEmisor.ToString();
            txtCostoTotal.Text = detallesEnvío.CostoTotal.ToString();
            txtPeso.Text = detallesEnvío.Peso.ToString();
            txtFechaSalida.Text = detallesEnvío.FechaSalida.ToString();
            txtFechaEntrega.Text = detallesEnvío.FechaEntrega.ToString();
            txtMarca.Text = detallesEnvío.Marca.ToString();
            txtModelo.Text = detallesEnvío.Modelo.ToString();
            txtMatrícula.Text = detallesEnvío.Matricula.ToString();


            cmbPaís.DataSource = direccionesService.GetPais();
            cmbPaís.ValueMember = "Id";
            cmbPaís.DisplayMember = "Nombre";
            cmbPaís.SelectedValue = detallesEnvío.IdPais;

            LoadEstados(detallesEnvío.IdPais, detallesEnvío.IdEstado);
            LoadMunicipios(detallesEnvío.IdEstado, detallesEnvío.IdMunicipio);
            LoadColonias(detallesEnvío.IdMunicipio, detallesEnvío.IdColonia);

            txtCodigoPostal.Text = detallesEnvío.CodigoPostal.ToString();
            txtCalle.Text = detallesEnvío.Calle;
            txtNoCasa.Text = detallesEnvío.NoCasa;
            txtNombreDestinatario.Text = detallesEnvío.NombreDestinatario;
            txtApellidoPatDestinatario.Text = detallesEnvío.ApellidoPatDestinatario;
            txtApellidoMatDestinatario.Text = detallesEnvío.ApellidoMatDestinatario;
            txtTelefonoDestinatario.Text = detallesEnvío.ApellidoPatDestinatario;
            #endregion

            #region dgvProductos
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = detallesDeOrdenService.GetProductosPorOrden(ClaveOrden);
            #endregion
        }
    }
}
