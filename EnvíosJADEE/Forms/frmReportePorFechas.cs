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
    public partial class frmReportePorFechas : Form
    {
        FiltrarOrdenesService filtrarOrdenes = new FiltrarOrdenesService();
        public frmReportePorFechas()
        {
            InitializeComponent();
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime FechaInicial = dtpFechaInicial.Value;
            DateTime FechaFinal = dtpFechaFinal.Value;

            dgvOrdenesPorFecha.DataSource = null;
            dgvOrdenesPorFecha.DataSource = filtrarOrdenes.GetOrdenesFiltradaFecha(FechaInicial, FechaFinal);
        }

        private void frmReportePorFechas_Load(object sender, EventArgs e)
        {
            MenuBuilder.BuildMenu(this);
        }
    }
}
