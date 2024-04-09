using ClosedXML.Excel;
using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
namespace EnvíosJADEE.Forms
{
    public partial class frmMarcas : Form
    {
        MarcasService service = new MarcasService();
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            MarcasService service = new MarcasService();
            dgvMarcas.DataSource = service.GetMarcas();

            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.Columns[0].ReadOnly = true;
            dgvMarcas.Columns[3].ReadOnly = true;
            dgvMarcas.Columns[4].ReadOnly = true;
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarca.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtMarca.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El nombre de la marca solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MarcaModel Marca = new MarcaModel();
                    Marca.Marca = txtMarca.Text;

                    int resultado = service.InsertMarcas(Marca);

                    if (resultado == 0)
                    {
                        MessageBox.Show("La marca ya ha sido registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == 1)
                    {
                        MessageBox.Show("Marca registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvMarcas.DataSource = null;
                    dgvMarcas.DataSource = service.GetMarcas();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            txtMarca.Focus();
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Marcas de Vehículos {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetMarcas());

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "E2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = "Marcas de Vehículos";
                var rangoTituloTabla = workSheet.Range("A3", "E4");
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
        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count == 1 && dgvMarcas.SelectedCells.Count == dgvMarcas.SelectedRows[0].Cells.Count)
            {

                btnEliminar.Visible = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Visible = false;
                btnEliminar.Enabled = false;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.DeleteMarca(int.Parse(dgvMarcas.SelectedRows[0].Cells[0].Value.ToString()));
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = service.GetMarcas();
        }
        private void dgvMarcas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvMarcas.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    MarcaModel Marcas = new MarcaModel();
                    var row = dgvMarcas.Rows[e.RowIndex];

                    if (row.Cells[1].Value.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[2].Value.ToString().ToLower().Trim() != "activo" && row.Cells[2].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Marcas.Id = int.Parse(row.Cells[0].Value.ToString());
                        Marcas.Marca = row.Cells[1].Value.ToString().Trim();
                        Marcas.Estatus = row.Cells[2].Value.ToString().ToLower().Trim();
                        int resultado = service.UpdateMarcas(Marcas);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Registro actualizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("El registro ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvMarcas.DataSource = null;

                dgvMarcas.DataSource = service.GetMarcas();
                return;
            }));


        }

        private void dgvMarcas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                e.Cancel = true;
            }
        }
    }
}
