using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Contexts;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Windows.Forms;
using iText.Layout.Properties;
using iText.IO;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Xml.Linq;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using ZXing;

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
            #region filepath
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Reporte {txtClave.Text}.pdf");
            #endregion

            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document doc = new Document(pdf, iText.Kernel.Geom.PageSize.LETTER);
            try
            {
                ImageData imageFile = ImageDataFactory.Create("C:\\Users\\Lab-A\\Documents\\GitHub\\EnviosJADEE\\EnvíosJADEE\\Resources\\package_122391.png");

                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(imageFile).Scale(0.25f, 0.25f).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                doc.Add(logo);

                Paragraph header = new Paragraph("Detalles de orden").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetBold();
                doc.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                doc.Add(ls);


                #region Generar codigo de barras
                BarcodeWriter barcode = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128
                };

                Bitmap barcodeBitmap = barcode.Write(txtClave.Text);
                #endregion

                #region Datos generales de la orden
                Paragraph contenido = new Paragraph();
                contenido.Add(new Text("Clave:\n").SetBold());
                using (MemoryStream ms = new MemoryStream())
                {
                    barcodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] barcodeBytes = ms.ToArray();

                    iText.Layout.Element.Image barcodeImage = new iText.Layout.Element.Image(ImageDataFactory.Create(barcodeBytes)).Scale(0.5f,0.5f);
                    contenido.Add(barcodeImage);
                    contenido.Add("\n");
                }
                contenido.Add(new Text("Nombre del emisor:\n").SetBold());
                contenido.Add($"{txtNombreEmisor.Text}\n");
                contenido.Add(new Text("Costo total:\n").SetBold());
                contenido.Add($"{txtCostoTotal.Text}\n");
                contenido.Add(new Text("Peso total:\n").SetBold());
                contenido.Add($"{txtPeso.Text}\n");

                doc.Add(contenido);

                #endregion

                #region Datos del destinatario
                header = new Paragraph("Datos del destinatario").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18);
                doc.Add(header);
                doc.Add(ls);

                contenido = new Paragraph();
                contenido.Add(new Text("Nombre completo:\n").SetBold());
                contenido.Add($"{txtNombreDestinatario.Text} {txtApellidoPatDestinatario.Text} {txtApellidoMatDestinatario.Text}\n");
                contenido.Add(new Text("Teléfono:\n").SetBold());
                contenido.Add($"{txtTelefonoDestinatario.Text}\n");
                contenido.Add(new Text("Dirección:\n").SetBold());
                contenido.Add($"{txtCalle.Text}, {txtNoCasa.Text}, {((ColoniaModel)cmbColonia.SelectedItem).Nombre.ToString()}, {txtCodigoPostal.Text}, {((MunicipioModel)cmbMunicipio.SelectedItem).Nombre.ToString()}, {((EstadosModel)cmbEstado.SelectedItem).Nombre.ToString()}, {((PaisModels)cmbPaís.SelectedItem).Nombre.ToString()}\n");

                doc.Add(contenido);
                #endregion

                #region Productos
                header = new Paragraph("Productos").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18);
                doc.Add(header);
                doc.Add(ls);

                Table productos = new Table(3);

                productos.AddHeaderCell("Clave");
                productos.AddHeaderCell("Nombre");
                productos.AddHeaderCell("Cantidad");

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    productos.AddCell(row.Cells["Clave"].Value.ToString());
                    productos.AddCell(row.Cells["Producto"].Value.ToString());
                    productos.AddCell(row.Cells["Cantidad"].Value.ToString());
                }

                productos.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                doc.Add(new Paragraph("\n"));
                doc.Add(productos);
                doc.Add(new Paragraph("\n"));
                #endregion

                #region Datos del Envío
                header = new Paragraph("Datos de envío").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18);
                doc.Add(header);
                doc.Add(ls);
                contenido = new Paragraph();
                contenido.Add(new Text("Estatus de envío:\n").SetBold());
                contenido.Add($"{((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden}\n");
                contenido.Add(new Text("Fecha de salida:\n").SetBold());
                contenido.Add($"{txtFechaSalida.Text}\n");
                contenido.Add(new Text("Fecha de entrega:\n").SetBold());
                contenido.Add($"{txtFechaSalida.Text}\n");

                doc.Add(contenido);

                if (((EstatusDeOrdenModel)cmbEstatus.SelectedItem).NombreEstatusOrden != "Pendiente")
                {
                    #region datos del repartidor

                    header = new Paragraph("Datos del repartidor").SetFontSize(16).SetItalic();
                    doc.Add(header);


                    contenido = new Paragraph();
                    contenido.Add(new Text("Nombre:\n").SetBold());
                    contenido.Add($"{((RepartidorModel)cmbRepartidores.SelectedItem).Nombre}\n");

                    contenido.Add(new Text("Clave de repartidor\n").SetBold());
                    contenido.Add($"{txtClaveRepartidor.Text}");

                    doc.Add(contenido);

                    #endregion

                    #region datos del vehiculo
                    header = new Paragraph("Datos del vehiculo").SetItalic().SetFontSize(16);
                    doc.Add(header);

                    contenido = new Paragraph();
                    contenido.Add(new Text("Marca del vehiculo:\n").SetBold());
                    contenido.Add($"{txtMarca.Text}\n");
                    contenido.Add(new Text("Modelo del vehiculo:\n").SetBold());
                    contenido.Add($"{txtModelo.Text}\n");
                    contenido.Add(new Text("Matrícula del vehículo:\n").SetBold());
                    contenido.Add($"{txtMatrícula.Text}\n");

                    doc.Add(contenido);
                    #endregion
                }
                #endregion

                MessageBox.Show("PDF creado correctamente en: " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}

       
