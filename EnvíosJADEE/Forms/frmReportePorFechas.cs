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
using DocumentFormat.OpenXml.Spreadsheet;
using iText.Layout.Font;

namespace EnvíosJADEE.Forms
{
    public partial class frmReportePorFechas : Form
    {
        FiltrarOrdenesService filtrarOrdenes = new FiltrarOrdenesService();
        DateTime FechaInicial;
        DateTime FechaFinal;
        public frmReportePorFechas()
        {
            InitializeComponent();
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FechaInicial = dtpFechaInicial.Value;
            FechaFinal = dtpFechaFinal.Value;

            dgvOrdenesPorFecha.DataSource = null;
            dgvOrdenesPorFecha.DataSource = filtrarOrdenes.GetOrdenesFiltradaFecha(FechaInicial, FechaFinal);

            btnExportarExcel.Visible = true;
        }

        private void frmReportePorFechas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Ordenes del {dtpFechaInicial.Value.Date.ToString("dd-MM-yyyy")} a {dtpFechaFinal.Value.Date.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(filtrarOrdenes.GetOrdenesFiltradaFecha(FechaInicial, FechaFinal));

                foreach(var row in tablaDeRegistros.Rows())
                {
                    var EstatusDeOrden = row.Cell(24).Value.ToString();

                    if (EstatusDeOrden == "Cancelado")
                    {
                        row.Style.Fill.SetBackgroundColor(XLColor.Red);
                    };
                }

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "AA2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = $"Registro de órdenes del {dtpFechaInicial.Value.Date.ToString("dd-MM-yyyy")} al {dtpFechaFinal.Value.Date.ToString("dd-MM-yyyy")}";
                var rangoTituloTabla = workSheet.Range("A3", "AA4");
                rangoTituloTabla.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 54, 96, 146)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);

                var sumaRow = tablaDeRegistros.Row(tablaDeRegistros.RowCount() + 1);
                sumaRow.Cell(4).FormulaA1 = "=SUMAR.SI([EstatusDeOrden];\"<>Cancelado\";[CostoTotal])";      

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
