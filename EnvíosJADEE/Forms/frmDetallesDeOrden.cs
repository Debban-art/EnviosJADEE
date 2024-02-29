using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private PdfDocument document;
        private PdfPage currentPage;
        private PdfGraphics graphics;
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
            btnImprimir.Visible = true;
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

            if (IdNuevoEstatus != detallesEnvío.IdEstatusDeOrden)
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
        private void LoadColonias(int idMunicipio, int idColonia)
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
            txtTelefonoDestinatario.Text = detallesEnvío.TelefonoDestinatario;
            #endregion

            #region dgvProductos
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = detallesDeOrdenService.GetProductosPorOrden(ClaveOrden);
            #endregion
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            #region fonts
            PdfFont fontTitle1 = new PdfStandardFont(PdfFontFamily.Helvetica, 28, PdfFontStyle.Bold);
            PdfFont fontTitle2 = new PdfStandardFont(PdfFontFamily.Helvetica, 24, PdfFontStyle.Bold);
            PdfFont fontTitle3 = new PdfStandardFont(PdfFontFamily.Helvetica, 22, PdfFontStyle.Italic);
            PdfFont fontText = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Regular);
            PdfFont fontTextBold = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            #endregion

            #region spacing
            float titleSpacing = 10;
            float textSpacing = 5;
            #endregion

            using (PdfDocument document = new PdfDocument())
            {

                AddContentToPages(document);

                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentosPath, $"Datos de la orden {txtClave.Text}.pdf");
                document.Save(filePath);
                MessageBox.Show("Documento PDF generado con éxito.");

                // Calcular el tamaño y la posición de la imagen
                float imageWidth = page.GetClientSize().Width; // Ancho de la página
                float imageHeight = 100; // Altura de la imagen
                float imageX = 0; // Posición X de la imagen (centrada)
                float imageY = page.GetClientSize().Height - imageHeight; // Posición Y de la imagen (en la parte superior)

                // Cargar la imagen desde un archivo

                

                float yOffset = icon.Height + 5;

                // Draw the text with sequential vertical titleSpacing.
                graphics.DrawString("Datos de la orden", fontTitle1, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTitle1.Height + titleSpacing;

                #region Datos generales de la orden
                graphics.DrawString("Clave:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtClave.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Nombre del emisor:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtNombreEmisor.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Costo total:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtCostoTotal.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Peso total:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtPeso.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;
                #endregion

                #region Datos del destinatario
                graphics.DrawString("Datos del destinatario", fontTitle2, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTitle2.Height + titleSpacing;

                graphics.DrawString("Nombre completo:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtNombreDestinatario.Text} {txtApellidoPatDestinatario.Text} {txtApellidoMatDestinatario.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Teléfono:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtTelefonoDestinatario.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Dirección:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtCalle.Text}, {txtNoCasa.Text}, {((ColoniaModel)cmbColonia.SelectedItem).Nombre.ToString()}, {txtCodigoPostal.Text}, {((MunicipioModel)cmbMunicipio.SelectedItem).Nombre.ToString()}, {((EstadosModel)cmbEstado.SelectedItem).Nombre.ToString()}, {((PaisModels)cmbPaís.SelectedItem).Nombre.ToString()}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;
                #endregion

                #region Productos
                graphics.DrawString("Productos", fontTitle2, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTitle2.Height + titleSpacing;
                #endregion


                #region Datos del envío
                graphics.DrawString("Datos del envío", fontTitle2, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTitle2.Height + titleSpacing;

                graphics.DrawString("Estatus:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Fecha de salida:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtFechaSalida.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                graphics.DrawString("Fecha de entrega:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontTextBold.Height + textSpacing;
                graphics.DrawString($"{txtFechaEntrega.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                yOffset += fontText.Height + textSpacing;

                if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden != "Pendiente")
                {
                    #region datos del repartidor
                    graphics.DrawString("Datos del repartidor", fontTitle3, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTitle3.Height + titleSpacing;

                    graphics.DrawString("Nombre del repartidor:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTextBold.Height + textSpacing;
                    graphics.DrawString($"{((RepartidorModel)cmbRepartidores.SelectedItem).Nombre}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontText.Height + textSpacing;

                    graphics.DrawString("Clave del repartidor:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTextBold.Height + textSpacing;
                    graphics.DrawString($"{txtClaveRepartidor.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontText.Height + textSpacing;
                    #endregion

                    #region datos del vehiculo
                    graphics.DrawString("Datos del vehículo", fontTitle3, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTitle3.Height + titleSpacing;

                    graphics.DrawString("Marca del vehiculo:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTextBold.Height + textSpacing;
                    graphics.DrawString($"{txtMarca.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontText.Height + textSpacing;

                    graphics.DrawString("Modelo del vehiculo:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTextBold.Height + textSpacing;
                    graphics.DrawString($"{txtModelo.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontText.Height + textSpacing;

                    graphics.DrawString("Matrícula del vehículo:", fontTextBold, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontTextBold.Height + textSpacing;
                    graphics.DrawString($"{txtMatrícula.Text}", fontText, PdfBrushes.Black, new PointF(0, yOffset));
                    yOffset += fontText.Height + textSpacing;
                    #endregion
                }

                #endregion


                //Save the document.
                //document.Save($"Reporte de la orden {txtClave}.pdf");




            }
        }

        private void AddContentToPages(PdfDocument document)
        {
            float yOffset = 0;
            float imageHeight = 100;
            bool newPageNeeded = false;

            PdfBitmap icon = new PdfBitmap("C:\\Users\\Lab-A\\Documents\\GitHub\\EnviosJADEE\\EnvíosJADEE\\Resources\\package_122391.png");
            page.Graphics.DrawImage(icon, 0, 0);
        }

        
    }
}
