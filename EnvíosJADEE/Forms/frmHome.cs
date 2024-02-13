using EnvíosJADEE.Clases;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = SesionClass.NombreUsuario;


            ModulosPorPerfilService service = new ModulosPorPerfilService();
            List<CategoríaModel> categorias = new List<CategoríaModel>();
            List<ModuloModel> modulos = new List<ModuloModel>();

            categorias = service.GetCategoriasPorPerfil(SesionClass.IdPerfil);

            ToolStrip menu = new ToolStrip();
            ToolStripMenuItem inicio = new ToolStripMenuItem("Inicio");
            menu.Items.Add(inicio);
            foreach (CategoríaModel categoria in categorias)
            {
                ToolStripDropDownButton categoriaItem = new ToolStripDropDownButton(categoria.Nombre);
                
                modulos = service.GetModulosPorPerfil(categoria.Id);
                foreach (ModuloModel modulo in modulos)
                {
                    ToolStripMenuItem moduloItem = new ToolStripMenuItem(modulo.Nombre);
                    moduloItem.BackColor = Color.FromArgb(0, 75, 69);
                    moduloItem.Font = new Font("Segoe UI", 14.5f, FontStyle.Regular);
                    categoriaItem.DropDownItems.Add(moduloItem);
                }
                menu.Items.Add(categoriaItem);

            }
            Controls.Add(menu);

            menu.BackColor = Color.FromArgb(0, 75, 69);
            menu.Font = new Font("Segoe UI", 14.5f, FontStyle.Regular);
            menu.GripStyle = ToolStripGripStyle.Hidden;
            menu.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        private void Item_Click(object sender, EventArgs e, Form nextPage)
        {
            ChangePages.ChangeWindow(nextPage, this);
        }
    }
}
