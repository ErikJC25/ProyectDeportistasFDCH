using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDCH.Logica;
using FDCH.Entidades;

namespace FDCH.UI.Vistas
{
    public partial class FrmInicio : Form
    {
        Cls_Puente puente = new Cls_Puente(); // Instancia de Cls_Puente

        public FrmInicio()
        {
            InitializeComponent();
            this.Load += FrmInicio_Load; // Suscribe el evento Load
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            // Llama al método y asigna los datos al DataGridView
            //List<RegistroTotal> registros = puente.ObtenerRegistrosCompletos();
            //dataGridView1.DataSource = registros;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
