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
    public partial class frmMedios : Form
    {
        TipoService service = new TipoService();
        public frmMedios()
        {
            InitializeComponent();
        }

        private void frmTipos_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            TipoService service = new TipoService();
            dgvTipos.DataSource = service.GetTipos();
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.Columns[0].ReadOnly = true;
            dgvTipos.Columns[3].ReadOnly = true;
            dgvTipos.Columns[4].ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTipo.Text = "";
            txtTipo.Focus();
        }

        private void btnAñadir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtTipo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtTipo.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El nombre del medio solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TipoModel Tipo = new TipoModel();
                    Tipo.Tipo = txtTipo.Text;

                    int resultado = service.InsertTipo(Tipo);

                    if (resultado == 0)
                    {
                        MessageBox.Show("El medio de transporte ya ha sido registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == 1)
                    {
                        MessageBox.Show("Registro añadido exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvTipos.DataSource = null;
                    dgvTipos.DataSource = service.GetTipos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Medios de Transporte {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetTipos());

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


                workSheet.Cell("A3").Value = "Medios de Transporte";
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

        private void dgvTipos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                e.Cancel = true;
            }
        }

        private void dgvTipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvTipos.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    TipoModel Tipo = new TipoModel();

                    var row = dgvTipos.Rows[e.RowIndex];

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
                        Tipo.Id = int.Parse(row.Cells[0].Value.ToString());
                        Tipo.Tipo = row.Cells[1].Value.ToString().Trim();
                        Tipo.Estatus = row.Cells[2].Value.ToString().Trim().ToLower();
                        int resultado = service.UpdateTipo(Tipo);

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
                dgvTipos.DataSource = null;
                dgvTipos.DataSource = service.GetTipos();
                return;
            }));

        }

        private void dgvTipos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipos.SelectedRows.Count == 1 && dgvTipos.SelectedCells.Count == dgvTipos.SelectedRows[0].Cells.Count)
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
            service.DeleteTipo(int.Parse(dgvTipos.SelectedRows[0].Cells[0].Value.ToString()));
            dgvTipos.DataSource = null;
            dgvTipos.DataSource = service.GetTipos();
        }
    }
}
