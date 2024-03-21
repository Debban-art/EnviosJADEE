using EnvíosJADEE.Clases;
using EnvíosJADEE.Forms;
using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public static class MenuBuilder
{
    public static void BuildMenu(Form parentForm)
    {

        ModulosPorPerfilService service = new ModulosPorPerfilService();
        List<CategoríaModel> categorias = service.GetCategoriasPorPerfil(SesionClass.IdPerfil);

        ToolStrip menu = new ToolStrip();
        menu.BackColor = Color.FromArgb(0, 75, 69);
        menu.Font = new Font("Segoe UI", 14.5f, FontStyle.Regular);
        menu.GripStyle = ToolStripGripStyle.Hidden;
        menu.RenderMode = ToolStripRenderMode.ManagerRenderMode;

        ToolStripMenuItem inicio = new ToolStripMenuItem("Inicio");
        inicio.Click += (s, ev) => OpenFormByType(typeof(frmHome), parentForm); // Manejar el evento de clic para el ítem de inicio
        menu.Items.Add(inicio);

        foreach (CategoríaModel categoria in categorias)
        {
            ToolStripDropDownButton categoriaItem = new ToolStripDropDownButton(categoria.Nombre);

            List<GetModuloModel> modulos = service.GetModulosPorPerfil(categoria.Id);
            foreach (GetModuloModel modulo in modulos)
            {
                ToolStripMenuItem moduloItem = new ToolStripMenuItem(modulo.Nombre);
                moduloItem.BackColor = Color.FromArgb(0, 75, 69);
                moduloItem.Font = new Font("Segoe UI", 14.5f, FontStyle.Regular);

                // Obtener el nombre del formulario usando la convención de nombres
                string formName = $"frm{modulo.Nombre}";

                // Intentar encontrar el tipo de formulario por su nombre
                Type formType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(t => t.Name.Equals(formName, StringComparison.OrdinalIgnoreCase));

                // Si se encontró el tipo de formulario, asignar el evento Click
                if (formType != null)
                {
                    moduloItem.Click += (s, ev) => OpenFormByType(formType, parentForm);
                }
                else
                {
                    // Manejar el caso donde no se encontró el formulario
                    moduloItem.Click += (s, ev) => MessageBox.Show($"No se encontró el formulario {formName}");
                }

                categoriaItem.DropDownItems.Add(moduloItem);
            }
            menu.Items.Add(categoriaItem);
        }

        parentForm.Controls.Add(menu);
    }

    private static void OpenFormByType(Type formType, Form parentForm)
    {
        Form form = (Form)Activator.CreateInstance(formType);
        form.Show();
        parentForm.Hide();
    }
}
