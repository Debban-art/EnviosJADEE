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
    public partial class frmDetallePerfil : Form
    {
        DetallePerfilService service = new DetallePerfilService();
        public frmDetallePerfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbModulo.SelectedIndex = 0;
            cmbPerfil.SelectedIndex = 0;

            cmbModulo.Focus();
        }

        private void frmDetallePerfil_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            dgvDetallePerfil.DataSource = service.GetDetallePerfil();
            dgvDetallePerfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ModulosService modulosService = new ModulosService(); 
            PerfilService perfilService = new PerfilService();

            cmbModulo.DataSource = modulosService.GetModulos();
            cmbModulo.DisplayMember = "Nombre";
            cmbModulo.ValueMember = "Id";

            cmbPerfil.DataSource = perfilService.GetPerfiles();
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "Id";

            dgvDetallePerfil.Columns[0].ReadOnly = true;
            dgvDetallePerfil.Columns[4].ReadOnly = true;
            dgvDetallePerfil.Columns[5].ReadOnly = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                InsertDetallePerfilModel detallePerfil = new InsertDetallePerfilModel();
                detallePerfil.IdModulo = int.Parse(cmbModulo.SelectedValue.ToString());
                detallePerfil.IdPerfil = int.Parse(cmbPerfil.SelectedValue.ToString());

                int resultado = service.InsertDetallePerfil(detallePerfil);

                if (resultado == 1)
                {
                    MessageBox.Show("Registro añadido con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultado == 0)
                {
                    MessageBox.Show("El registro ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dgvDetallePerfil.DataSource = null;
                dgvDetallePerfil.DataSource = service.GetDetallePerfil();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDetallePerfil_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvDetallePerfil.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    DetallePerfilService service = new DetallePerfilService();
                    GetDetallePerfilModel DetallePerfil = new GetDetallePerfilModel();

                    var row = dgvDetallePerfil.Rows[e.RowIndex];

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
                        DetallePerfil.Id = int.Parse(row.Cells[0].Value.ToString());
                        DetallePerfil.Modulo = row.Cells[1].Value.ToString().Trim();
                        DetallePerfil.Perfil = row.Cells[2].Value.ToString().Trim();
                        DetallePerfil.Estatus = row.Cells[3].Value.ToString().Trim().ToLower();
                        int resultado = service.UpdateDetallePerfil(DetallePerfil);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Registro actualizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("El registro ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (resultado == 2)
                        {
                            MessageBox.Show("Módulo o perfil inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvDetallePerfil.DataSource = null;
                dgvDetallePerfil.DataSource = service.GetDetallePerfil();
                return;
            }));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.DeleteDetallePerfil(int.Parse(dgvDetallePerfil.SelectedRows[0].Cells[0].Value.ToString()));
            dgvDetallePerfil.DataSource = null;
            dgvDetallePerfil.DataSource = service.GetDetallePerfil();
        }

        private void dgvDetallePerfil_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                e.Cancel = true;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Detalles de Perfiles {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetDetallePerfil());

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


                workSheet.Cell("A3").Value = "Detalles de perfiles";
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

        private void dgvDetallePerfil_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetallePerfil.SelectedRows.Count == 1 && dgvDetallePerfil.SelectedCells.Count == dgvDetallePerfil.SelectedRows[0].Cells.Count)
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
