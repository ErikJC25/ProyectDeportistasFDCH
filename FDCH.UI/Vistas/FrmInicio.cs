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
            CargarDatosEnDataGridView();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            // Llama al método y asigna los datos al DataGridView
            List<RegistroTotal> registros = puente.ObtenerRegistrosCompletos();
            dataGridView1.DataSource = registros;
        }

        public void CargarDatosEnDataGridView()
        {
            // Llama al método y asigna los datos al DataGridView
            List<RegistroTotal> registros = puente.ObtenerRegistrosCompletos();
            dataGridView1.DataSource = registros;
        }


        public event Action<RegistroTotal> EventoEditar;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic haya sido en la columna de tu botón (ej. "colEditar")
            // y que no haya sido en la fila de encabezado.
            if (e.ColumnIndex == dataGridView1.Columns["colEditar"].Index && e.RowIndex >= 0)
            {
                // 1. Obtén el objeto de datos completo de la fila
                // DataBoundItem es la propiedad que contiene el objeto al que está enlazada la fila.
                RegistroTotal registroCompleto = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // 2. Extrae los IDs y datos que necesitas del objeto 'registroCompleto'
                int idDeportista = registroCompleto.IdDeportista;
                string nombreDeportista = registroCompleto.Nombres + " " + registroCompleto.Apellidos;

                // 3. Pasa los datos (los IDs ocultos y la información visible) al formulario de edición.
                EventoEditar?.Invoke(registroCompleto); // Notifica al principal
                this.Close();

                // Refresca el DataGridView para reflejar los cambios hechos en el otro formulario.
                CargarDatosEnDataGridView();
            }
        }

        public event Action<int> EventoPerfil;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic fue en la fila de datos (no en el encabezado).
            // Y que la columna no es la primera columna en blanco (la de la selección de fila).
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // 1. Obtén el objeto de datos completo de la fila seleccionada.
                // Reemplaza "colNombreDeportista" con el nombre de tu columna
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Nombres")
                {
                    // 2. Obtén el objeto de datos completo de la fila seleccionada.
                    RegistroTotal registro = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // 3. Extrae el ID del deportista desde el objeto.
                    int idDeportista = registro.IdDeportista;

                    // 4. Abre el nuevo formulario y pásale el ID del deportista.
                    EventoPerfil?.Invoke(idDeportista); // Notifica al principal
                    this.Close();
                }
            }
        }
    }
}
