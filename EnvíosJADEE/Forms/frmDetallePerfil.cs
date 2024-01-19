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
    public partial class frmDetallePerfil : Form
    {
        public frmDetallePerfil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbModulo.SelectedIndex = 0;
            cmbPerfil.SelectedIndex = 0;
            txtUsuario.Text = "";

            cmbModulo.Focus();
        }

        private void frmDetallePerfil_Load(object sender, EventArgs e)
        {

        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
