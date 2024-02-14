﻿using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmModulos : Form
    {
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
            dgvModulos.Columns[3].ReadOnly = true;
            dgvModulos.Columns[5].ReadOnly = true;
            dgvModulos.Columns[6].ReadOnly = true;

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Llamar el insertModulo
                ModulosService moduloService = new ModulosService();
                ModuloModel modulo = new ModuloModel();

                modulo.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                modulo.Nombre = txtNombre.Text;

                moduloService.InsertModulos(modulo);

                //Refresh la tabla de modulos
                dgvModulos.DataSource = null;
                dgvModulos.DataSource = moduloService.GetModulos();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbCategoria.SelectedIndex = 0;
            txtNombre.Text = "";

            cmbCategoria.Focus();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();

            frmHome.Show();
            this.Close();
        }

        private void dgvModulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvModulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ModulosService service = new ModulosService();
            ModuloModel Modulos = new ModuloModel();
            var row = dgvModulos.Rows[e.RowIndex];

            Modulos.Id = int.Parse(row.Cells[0].Value.ToString());
            Modulos.Nombre = row.Cells[1].Value.ToString();
            Modulos.IdCategoria = int.Parse(row.Cells[2].Value.ToString());
            Modulos.Estatus = row.Cells[4].Value.ToString();
            service.UpdateModulos(Modulos);
            dgvModulos.DataSource = null;
            ModulosService Modulosservice = new ModulosService();
            dgvModulos.DataSource = service.GetModulos();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmHome(), this);

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmDetallePerfil(), this);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMedios(), this);
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMarcas(), this);
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmVehículos(), this);
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmCategorías(), this);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
