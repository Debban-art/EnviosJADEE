using ClosedXML.Excel;
using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace EnvíosJADEE.Forms
{
    public partial class frmModulos : Form
    {
        ModulosService service = new ModulosService();
        public frmModulos()
        {
            InitializeComponent();
        }

        private void frmModulos_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            //Mostrar en la dgv la tabla de modulos
            ModulosService service = new ModulosService();
            dgvModulos.DataSource = service.GetModulos();
            dgvModulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Mostrar en la cmb todas las categorías disponibles
            CategoriasService categoriasService = new CategoriasService();
            cmbCategoria.DataSource = categoriasService.GetCategorias();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            dgvModulos.Columns[0].ReadOnly = true;
            dgvModulos.Columns[4].ReadOnly = true;
            dgvModulos.Columns[5].ReadOnly = true;

        }

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
                    InsertModuloModel modulo = new InsertModuloModel();
                    modulo.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                    modulo.Nombre = txtNombre.Text;

                    int resultado = service.InsertModulos(modulo);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Módulo añadido exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("El módulo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvModulos.DataSource = null;
            dgvModulos.DataSource = service.GetModulos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbCategoria.SelectedIndex = 0;
            txtNombre.Text = "";

            cmbCategoria.Focus();
        }


        private void dgvModulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvModulos.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {

                    GetModuloModel Modulos = new GetModuloModel();
                    var row = dgvModulos.Rows[e.RowIndex];

                    if (row.Cells[1].Value.ToString().Trim().Length == 0 || row.Cells[2].Value.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[2].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[3].Value.ToString().ToLower().Trim() != "activo" && row.Cells[3].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Modulos.Id = int.Parse(row.Cells[0].Value.ToString());
                        Modulos.Nombre = row.Cells[1].Value.ToString();
                        Modulos.Categoria = row.Cells[2].Value.ToString();
                        Modulos.Estatus = row.Cells[3].Value.ToString();
                        int resultado = service.UpdateModulos(Modulos);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Modulo actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("Este módulo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (resultado == 2)
                        {
                            MessageBox.Show("Categoría inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dgvModulos.DataSource = null;
                dgvModulos.DataSource = service.GetModulos();
                return;
            }));

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Módulos {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetModulos());

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "F2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = $"Registro de Módulos";
                var rangoTituloTabla = workSheet.Range("A3", "F4");
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

        private void dgvModulos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                e.Cancel = true;
            }
        }

        private void dgvModulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModulos.SelectedRows.Count == 1 && dgvModulos.SelectedCells.Count == dgvModulos.SelectedRows[0].Cells.Count)
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
            service.DeleteModulos(int.Parse(dgvModulos.SelectedRows[0].Cells[0].Value.ToString()));
            dgvModulos.DataSource = null;
            dgvModulos.DataSource = service.GetModulos();
        }
    }
}
