using ClosedXML.Excel;
using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnvíosJADEE.Forms
{
    public partial class frmCategorías : Form
    {
        CategoriasService service = new CategoriasService();
        public frmCategorías()
        {
            InitializeComponent();
        }

        private void frmCategorías_Load(object sender, EventArgs e)
        {
            CategoriasService service = new CategoriasService();
            MenuBuilder.BuildMenu(this);
            dgvCategorías.DataSource = service.GetCategorias();
            dgvCategorías.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorías.Columns[0].ReadOnly = true;
            dgvCategorías.Columns[3].ReadOnly = true;
            dgvCategorías.Columns[4].ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtNombre.Focus();
        }

        //INSERTAR UNA NUEVA CATEGORÍA 
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se puede dejar el campo en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtNombre.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CategoríaModel categoría = new CategoríaModel();
                    categoría.Nombre = txtNombre.Text;

                    int resultado = service.InsertCategorías(categoría);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Categoría añadida exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("La categoría ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvCategorías.DataSource = null;
            dgvCategorías.DataSource = service.GetCategorias();


        }

        //EDITAR UNA CATEGORÍA
        private void dgvCategorías_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvCategorías.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {

                    CategoríaModel categoría = new CategoríaModel();
                    var row = dgvCategorías.Rows[e.RowIndex];

                    if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Trim() == "")
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
                        categoría.Id = int.Parse(row.Cells[0].Value.ToString());
                        categoría.Nombre = row.Cells[1].Value.ToString().Trim();
                        categoría.Estatus = row.Cells[2].Value.ToString().Trim().ToLower();

                        int resultado = service.UpdateCategorías(categoría);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Categoría actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("Esa categoría ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvCategorías.DataSource = null;
                dgvCategorías.DataSource = service.GetCategorias();

                return;
            }));
            
        }

        private void dgvCategorías_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                e.Cancel = true;
            }
        }

        //EXPORTAR A EXCEL
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Categorías {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetCategorias());

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


                workSheet.Cell("A3").Value = "Registro de Categorías";
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

        private void dgvCategorías_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.DeleteCategoria(int.Parse(dgvCategorías.SelectedRows[0].Cells[0].Value.ToString()));
            dgvCategorías.DataSource = null;
            dgvCategorías.DataSource = service.GetCategorias();
        }

        private void dgvCategorías_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorías.SelectedRows.Count == 1 && dgvCategorías.SelectedCells.Count == dgvCategorías.SelectedRows[0].Cells.Count)
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

        
    }
}
