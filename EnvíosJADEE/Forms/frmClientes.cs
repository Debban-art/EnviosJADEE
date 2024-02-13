using EnvíosJADEE.Models;
using EnvíosJADEE.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvíosJADEE.Forms
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se pueden dejar campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ClientesModel Cliente = new ClientesModel();
                Cliente.Nombre = txtNombre.Text;
                Cliente.ApellidoPaterno = txtApPaterno.Text;
                Cliente.ApellidoPaterno = txtApMaterno.Text;
                Cliente.País = txtPaís.Text;
                Cliente.Estado = txtEstado.Text;
                Cliente.Ciudad = txtCiudad.Text;
                Cliente.CodigoPostal = txtCodigoPostal.Text;
                Cliente.Domicilio = txtDomicilio.Text;
                Cliente.NoCasa = txtNoCasa.Text;
                ClientesService service = new ClientesService();
                service.InsertClientes(Cliente);

                dgvClientes.DataSource = null;
                ClientesService Clienteservice = new ClientesService();
                dgvClientes.DataSource = Clienteservice.GetClientes();

            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
