using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmVehículos(), this);
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmMarcas(), this); ;
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmCategorías(), this);
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmModulos(), this);
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPerfiles(), this);
        }

        private void detallesPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new DetallePerfil(), this);
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmPersonas(), this);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = SesionClass.NombreUsuario;
            ModulosPorPerfilService service = new ModulosPorPerfilService();
            List<CategoríaModel> categorias = new List<CategoríaModel>();
            List<ModuloModel> modulos = new List<ModuloModel>();

            categorias = service.GetCategoriasPorPerfil(SesionClass.IdPerfil);

            ToolStrip menu = new ToolStrip();
            foreach (CategoríaModel categoria in categorias)
            {
                ToolStripDropDownButton categoriaItem = new ToolStripDropDownButton(categoria.Nombre);
                
                modulos = service.GetModulosPorPerfil(categoria.Id);
                foreach (ModuloModel modulo in modulos)
                {
                    ToolStripMenuItem moduloItem = new ToolStripMenuItem(modulo.Nombre);
                    categoriaItem.DropDownItems.Add(moduloItem);
                }
                menu.Items.Add(categoriaItem);

            }
            Controls.Add(menu);
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePages.ChangeWindow(new frmTipos(), this);
        }
    }
}
