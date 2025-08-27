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
            deportista = puente.ObtenerDeportistaPorId(idDeportista);
            lblNombre.Text = deportista.nombres + " " + deportista.apellidos;
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
            dataGridView1.DataSource = registros;
        }
    }
}
