using ClosedXML.Excel;
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
    public partial class frmRepartidores : Form
    {
        RepartidoresService  service = new RepartidoresService();
        public frmRepartidores()
        {
            InitializeComponent();
        }

        private void frmRepartidores_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            dgvRepartidores.DataSource = service.GetRepartidores();
            dgvRepartidores.Columns[0].ReadOnly = true;
            dgvRepartidores.Columns[3].ReadOnly = true;
            dgvRepartidores.Columns[5].ReadOnly = true;
            dgvRepartidores.Columns[6].ReadOnly = true;

            cmbVehiculos.DataSource = service.GetVehiculos();
            cmbVehiculos.DisplayMember = "Nombre";
            cmbVehiculos.ValueMember = "Id";
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRepartidor.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se pueden dejar el campo en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtRepartidor.Text.Trim(), @"[\d\s!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El nombre del repartidor solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmbVehiculos.SelectedValue == null)
                {
                    MessageBox.Show("No hay vehiculos disponibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertRepartidorModel repartidor = new InsertRepartidorModel();
                    repartidor.IdVehiculo = int.Parse(cmbVehiculos.SelectedValue.ToString());
                    repartidor.Nombre = txtRepartidor.Text.Trim();

                    int resultado = service.InsertRepartidor(repartidor);

                    if (resultado == 0)
                    {
                        MessageBox.Show("El repartidor ya esta registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == 1)
                    {
                        MessageBox.Show("Repartidor registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    dgvRepartidores.DataSource = null;
                    dgvRepartidores.DataSource = service.GetRepartidores();
                    cmbVehiculos.DataSource = null;
                    cmbVehiculos.DataSource = service.GetVehiculos();
                    cmbVehiculos.DisplayMember = "Nombre";
                    cmbVehiculos.ValueMember = "Id";
                    txtRepartidor.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtRepartidor.Text = "";
            txtRepartidor.Focus();

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Repartidores {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetRepartidores());

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "G2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = "Repartidores";
                var rangoTituloTabla = workSheet.Range("A3", "G4");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.DeleteRepartidor(int.Parse(dgvRepartidores.SelectedRows[0].Cells[0].Value.ToString()));
            dgvRepartidores.DataSource = null;
            dgvRepartidores.DataSource = service.GetRepartidores();
            cmbVehiculos.DataSource = null;
            cmbVehiculos.DataSource = service.GetVehiculos();
            cmbVehiculos.DisplayMember = "Nombre";
            cmbVehiculos.ValueMember = "Id";
        }

        private void dgvRepartidores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRepartidores.SelectedRows.Count == 1 && dgvRepartidores.SelectedCells.Count == dgvRepartidores.SelectedRows[0].Cells.Count)
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

        private void dgvRepartidores_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 3 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                e.Cancel = true;
            }
        }

        private void dgvRepartidores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvRepartidores.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    GetRepartidorModel repartidor = new GetRepartidorModel();
                    var row = dgvRepartidores.Rows[e.RowIndex];

                    if (row.Cells[1].Value.ToString().Trim().Length == 0 || row.Cells[2].Value.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString().Trim(), @"[\d\s!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("El nombre solo puede contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[2].Value.ToString().Trim(), @"[\s!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("La matricula solo puede contener letras y números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[4].Value.ToString().ToLower().Trim() != "activo" && row.Cells[4].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        
                        repartidor.Id = int.Parse(row.Cells[0].Value.ToString().Trim());
                        repartidor.Nombre = row.Cells[1].Value.ToString().Trim();
                        repartidor.Matricula = row.Cells[2].Value.ToString().Trim();
                        repartidor.Estatus = row.Cells[4].Value.ToString().ToLower().Trim();
                        int resultado = service.UpdateRepartidor(repartidor);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Registro actualizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("El repartidor o el vehiculo ya han sido registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (resultado == 2)
                        {
                            MessageBox.Show("La matricula no es válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dgvRepartidores.DataSource = null;
                dgvRepartidores.DataSource = service.GetRepartidores();
                cmbVehiculos.DataSource = service.GetVehiculos();
                cmbVehiculos.DisplayMember = "Nombre";
                cmbVehiculos.ValueMember = "Id";
                return;
            }));
        }
    }
}
