using ClosedXML.Excel;
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
using System.IO;

namespace EnvíosJADEE.Forms
{
    public partial class frmTrackingEnvío : Form
    {
        TrackingService trackingService = new TrackingService();

        public frmTrackingEnvío()
        {
            InitializeComponent();
        }

        private void frmTrackingEnvío_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);
            

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(txtClaveDeOrden.Text.Trim() == "")
            {
                MessageBox.Show("Debes de ingresar una clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Clave = txtClaveDeOrden.Text;
                string EstatusDeOrden = trackingService.GetEstatusOrden(Clave);
                if (EstatusDeOrden.Trim() == "")
                {

                    MessageBox.Show("Clave de orden inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lblEstatusDeOrden.Text = EstatusDeOrden;
                    dgvBitácora.Visible = true;
                    btnExportarExcel.Visible = true;
                    btnExportarExcel.Enabled = true;
                    dgvBitácora.DataSource = null;
                    dgvBitácora.DataSource = trackingService.GetRegistrosPorClave(Clave);
                    if (EstatusDeOrden == "Entregado")
                    {
                        lblFecha.Text = "Fecha de entrega:  ";
                    }
                    else
                    {
                        lblFecha.Text = "Fecha estimada de entrega: ";
                    }
                    lblFecha.Text += trackingService.GetFechaEntrega(Clave);

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClaveDeOrden.Text = null;
            txtClaveDeOrden.Focus();
            btnExportarExcel.Visible=false;
            btnExportarExcel.Enabled=false;

            lblEstatusDeOrden.Text = null;
            lblFecha.Text = null;

            dgvBitácora.DataSource = null;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Tracking de envio de la orden {txtClaveDeOrden.Text} {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(trackingService.GetRegistrosPorClave(txtClaveDeOrden.Text));

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "C2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = "Tracking";
                var rangoTituloTabla = workSheet.Range("A3", "C4");
                rangoTituloTabla.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 54, 96, 146)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);

                workSheet.Columns().AdjustToContents();

                workBook.SaveAs(filePath);

                MessageBox.Show("Excel creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
