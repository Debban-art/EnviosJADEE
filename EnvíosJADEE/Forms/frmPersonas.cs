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
    public partial class frmPersonas : Form
    {
        PersonaUsuarioService personaService = new PersonaUsuarioService();
        public frmPersonas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtDireccion.Text = "";


            txtNombre.Focus();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Trim().Length == 0 || txtApPaterno.Text.Trim().Length == 0 || txtApMaterno.Text.Trim().Length == 0 || txtDireccion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtNombre.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtApPaterno.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtApMaterno.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(txtDireccion.Text.Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                {
                    MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.Match(txtNombre.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(txtApPaterno.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(txtApMaterno.Text.Trim(), @"\w+(?:\s[a-zA-Z])+").Success)
                {
                    MessageBox.Show("Favor de ingresar un solo nombre/apellido por campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertPersonaModel persona = new InsertPersonaModel();
                    persona.Nombre = txtNombre.Text.Trim();
                    persona.ApellidoPaterno = txtApPaterno.Text.Trim();
                    persona.ApellidoMaterno = txtApMaterno.Text.Trim();
                    persona.Dirección = txtDireccion.Text.Trim();

                    UsuarioModel usuario = new UsuarioModel();
                    usuario.IdPerfil = int.Parse(cmbPerfiles.SelectedValue.ToString());

                    int resultado = personaService.InsertPersonaUsuario(persona, usuario);

                    if (resultado == 1)
                    {
                        MessageBox.Show("Cuenta añadida con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPersonas.DataSource = null;
                        dgvPersonas.DataSource = personaService.GetPersonasUsuario();
                        dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvPersonas.Columns[0].ReadOnly = true;
                        dgvPersonas.Columns[4].ReadOnly = true;
                        dgvPersonas.Columns[8].ReadOnly = true;
                        dgvPersonas.Columns[9].ReadOnly = true;
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("El usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);

            PerfilService perfilService = new PerfilService();
            cmbPerfiles.DataSource = perfilService.GetPerfiles();
            cmbPerfiles.DisplayMember = "Nombre";
            cmbPerfiles.ValueMember = "Id";


            dgvPersonas.DataSource = personaService.GetPersonasUsuario();
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.Columns[0].ReadOnly= true;
            dgvPersonas.Columns[4].ReadOnly = true;
            dgvPersonas.Columns[8].ReadOnly = true;
            dgvPersonas.Columns[9].ReadOnly = true;
        }

        private void dgvPersonas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            this.BeginInvoke(new MethodInvoker(() =>
            {
                dgvPersonas.Rows[e.RowIndex].ErrorText = string.Empty;

                try
                {
                   GetPersonaModel persona = new GetPersonaModel();
                    PerfilService perfilService = new PerfilService();
                    var row = dgvPersonas.Rows[e.RowIndex];

                    if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Trim() == "" || row.Cells[2].Value == null || row.Cells[2].Value.ToString().Trim() == "" ||row.Cells[3].Value == null || row.Cells[3].Value.ToString().Trim() == "" || row.Cells[5].Value == null || row.Cells[5].Value.ToString().Trim() == "" || row.Cells[6].Value == null || row.Cells[6].Value.ToString().Trim() == "" || row.Cells[7].Value == null || row.Cells[7].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[2].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[3].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[5].Value.ToString().Trim(), @"[!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[6].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success || Regex.Match(row.Cells[7].Value.ToString().Trim(), @"[\d!@#$%^&*()_+{}\[\]:;<>,.?/~\\]").Success)
                    {
                        MessageBox.Show("Los datos solo pueden contener letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Regex.Match(row.Cells[1].Value.ToString(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[2].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[3].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success || Regex.Match(row.Cells[6].Value.ToString().Trim(), @"\w+(?:\s[a-zA-Z])+").Success)
                    {
                        MessageBox.Show("Favor de ingresar un solo nombre/apellido por campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (row.Cells[7].Value.ToString().ToLower().Trim() != "activo" && row.Cells[7].Value.ToString().ToLower().Trim() != "inactivo")
                    {
                        MessageBox.Show("Ingrese un estatus válido: activo o inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        persona.Id = int.Parse(row.Cells[0].Value.ToString().Trim());
                        persona.Nombre = row.Cells[1].Value.ToString().Trim();
                        persona.ApellidoPaterno = row.Cells[2].Value.ToString().Trim();
                        persona.ApellidoMaterno = row.Cells[3].Value.ToString().Trim();
                        persona.Perfil = row.Cells[6].Value.ToString().ToLower().Trim();
                        persona.Dirección = row.Cells[5].Value.ToString().Trim();
                        persona.Estatus = row.Cells[7].Value.ToString().ToLower().Trim();

                        int resultado = personaService.UpdatePersonasUsuario(persona);

                        if (resultado == 1)
                        {
                            MessageBox.Show("Cuenta actualizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (resultado == 0)
                        {
                            MessageBox.Show("El nombre de ese usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (resultado == 2)
                        {
                            MessageBox.Show("Perfil inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvPersonas.DataSource = null;
                dgvPersonas.DataSource = personaService.GetPersonasUsuario();
                return;
            }));


        }

        private void dgvPersonas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        { 
            if (e.ColumnIndex == 0 || e.ColumnIndex == 4 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
            {
                e.Cancel = true;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, $"Personas {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");


            try
            {
                XLWorkbook workBook = new XLWorkbook();
                var workSheet = workBook.AddWorksheet();

                var tablaDeRegistros = workSheet.Cell(5, 1).InsertTable(personaService.GetPersonasUsuario());

                workSheet.Cell("A1").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A1").Value = "Fecha";
                workSheet.Cell("B1").Style.Fill.SetBackgroundColor(XLColor.FromArgb(100, 220, 230, 241));
                workSheet.Cell("B1").Value = DateTime.Now.Date;

                workSheet.Cell("A2").Style.Font.SetFontColor(XLColor.White).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetBold();
                workSheet.Cell("A2").Value = "Hora";
                workSheet.Cell("B2").Value = DateTime.Now.TimeOfDay;

                workSheet.Cell("C1").Value = "Envios JADEE";
                var rangoNombreEmpresa = workSheet.Range("C1", "J2");
                rangoNombreEmpresa.Merge().Style.Font.SetBold().Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center).Fill.SetBackgroundColor(XLColor.FromArgb(100, 79, 129, 189)).Font.SetFontColor(XLColor.White).Font.SetFontSize(20);


                workSheet.Cell("A3").Value = $"Registro de Personas";
                var rangoTituloTabla = workSheet.Range("A3", "J4");
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

        private void dgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count == 1 && dgvPersonas.SelectedCells.Count == dgvPersonas.SelectedRows[0].Cells.Count)
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
            personaService.DeletePersonaUsuario(int.Parse(dgvPersonas.SelectedRows[0].Cells[0].Value.ToString()));
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = personaService.GetPersonasUsuario();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
