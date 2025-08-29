using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmHistorialDeportista : Form
    {
        Cls_Puente puente = new Cls_Puente(); // Instancia de Cls_Puente
        Deportista deportista = new Deportista(); // Instancia de Deportista
        int idDeportista;

        public FrmHistorialDeportista(int idDeportista)
        {
            InitializeComponent();
            this.idDeportista = idDeportista;
            dataGridView1.AutoGenerateColumns = false;
            CargarDatosEnDataGridView();
        }

        private void FrmHistorialDeportista_Load(object sender, EventArgs e)
        {

        }

        public void CargarDatosEnDataGridView()
        {
            // Llama al método y asigna los datos al DataGridView
            List<RegistroTotal> registros = puente.ObtenerRegistrosCompletosIdDeportista(idDeportista);

            lblNombre.Text = registros[0].Nombres + " " + registros[0].Apellidos;

            dataGridView1.DataSource = registros;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel.ExportarAExcel(dataGridView1);
        }

        private void btnExportarDeportista_Click(object sender, EventArgs e)
        {
            ExportarWord.ExportarAWord(dataGridView1);
        }
    }
}
