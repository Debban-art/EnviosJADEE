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
    public partial class frmVehículos : Form
    {
        VehiculosService service = new VehiculosService();

        public frmVehículos()
        {
            InitializeComponent();
        }

        private void frmVehículos_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            dgvVehiculos.DataSource = service.GetVehiculos();
            dgvVehiculos.Columns[0].ReadOnly = true;
            dgvVehiculos.Columns[7].ReadOnly = true;
            dgvVehiculos.Columns[8].ReadOnly = true;

            MarcasService marcasService = new MarcasService();
            cmbMarca.DataSource = marcasService.GetMarcas();
            cmbMarca.DisplayMember = "Marca";
            cmbMarca.ValueMember = "Id";

            TipoService tipoService = new TipoService();
            cmbTipo.DataSource = tipoService.GetTipos();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "Id";

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModelo.Text.Trim().Length == 0 || txtMatrícula.Text.Trim().Length == 0 || txtNoSerie.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtMatrícula.Text.Trim(), @"[\s!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtModelo.Text.Trim(), @"[!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("La matricula y el modelo solo pueden contener letras y números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtNoSerie.Text.Trim(), @"[\sA-Za-z!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("El número de serie solo puede contener números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertVehiculoModel Vehiculo = new InsertVehiculoModel();
                    Vehiculo.modelo = txtModelo.Text.Trim();
                    Vehiculo.matricula = txtMatrícula.Text.Trim();
                    Vehiculo.idMarca = int.Parse(cmbMarca.SelectedValue.ToString());
                    Vehiculo.idTipo = int.Parse(cmbTipo.SelectedValue.ToString());
                    Vehiculo.NoSerie = int.Parse(txtNoSerie.Text.Trim());

                    int resultado = service.InsertVehiculo(Vehiculo);

                    if (resultado == 0)
                    {
                        MessageBox.Show("El vehiculo ya ha sido registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == 1)
                    {
                        MessageBox.Show("Vehículo registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    dgvVehiculos.DataSource = null;
                    dgvVehiculos.DataSource = service.GetVehiculos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


            txtModelo.Text = "";
            txtMatrícula.Text = "";
            txtNoSerie.Text = "";



            txtModelo.Focus();

        }

        private void dgvVehiculos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvVehiculos.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                    GetVehiculoModel vehiculo = new GetVehiculoModel();
                    var row = dgvVehiculos.Rows[e.RowIndex];

                    if (Regex.Match(row.Cells[5].Value.ToString().Trim(), @"[\sA-Za-z!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("El número de serie solo puede contener números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[1].Value.ToString().Trim().Length == 0 || row.Cells[2].Value.ToString().Trim().Length == 0 || row.Cells[3].Value.ToString().Trim().Length == 0 || row.Cells[4].Value.ToString().Trim().Length == 0 || int.Parse(row.Cells[5].Value.ToString().Trim()) == null)
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[2].Value.ToString().Trim(), @"[\s!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[4].Value.ToString().Trim(), @"[!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("La matricula y el modelo solo pueden contener letras y números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[6].Value.ToString().ToLower().Trim() != "activo" && row.Cells[6].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        vehiculo.Id = int.Parse(row.Cells[0].Value.ToString().Trim());
                        vehiculo.Tipo = row.Cells[1].Value.ToString().Trim();
                        vehiculo.Matricula = row.Cells[2].Value.ToString().Trim();
                        vehiculo.Marca = row.Cells[3].Value.ToString().Trim();
                        vehiculo.Modelo = row.Cells[4].Value.ToString().Trim();
                        vehiculo.NoSerie = int.Parse(row.Cells[5].Value.ToString().Trim());
                        vehiculo.Estatus = row.Cells[6].Value.ToString().ToLower().Trim();
                        int resultado = service.UpdateVehiculo(vehiculo);

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
                            MessageBox.Show("El medio de transporte o la marca son inválidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource = service.GetVehiculos();
                return;
            }));
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Vehículos {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(service.GetVehiculos());

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "I2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = "Vehiculos";
                var rangoTituloTabla = workSheet.Range("A3", "I4");
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

        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count == 1 && dgvVehiculos.SelectedCells.Count == dgvVehiculos.SelectedRows[0].Cells.Count)
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

        private void dgvVehiculos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                e.Cancel = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.DeleteVehiculo(int.Parse(dgvVehiculos.SelectedRows[0].Cells[0].Value.ToString()));
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = service.GetVehiculos();
        }
    }
}



