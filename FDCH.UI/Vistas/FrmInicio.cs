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
        FrmPrincipal _frmprincipal;

        public FrmInicio(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
            dataGridView1.AutoGenerateColumns = false;

            if (_frmprincipal.bloqueoActivo == false)
            {
                dataGridView1.Columns["colEditar"].Visible = false;
            }
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            CargarDatosEnDataGridView();
        }

        public void CargarDatosEnDataGridView()
        {
            // Llama al método y asigna los datos al DataGridView
            List<RegistroTotal> registros = puente.ObtenerRegistrosCompletos();
            dataGridView1.DataSource = registros;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*  PARTE DE CODIGO MODIFICADA PARA QUE PERMITA ELEGIR SI DESEA EDITAR TORNEO O COMPETENCIA
            
            // Verifica que el clic haya sido en la columna de tu botón (ej. "colEditar")
            // y que no haya sido en la fila de encabezado.
            if (e.ColumnIndex == dataGridView1.Columns["colEditar"].Index && e.RowIndex >= 0)
            {
                // 1. Obtén el objeto de datos completo de la fila
                // DataBoundItem es la propiedad que contiene el objeto al que está enlazada la fila.
                RegistroTotal registroCompleto = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // 2. Pasa los datos (los IDs ocultos y la información visible) al formulario de edición.
                _frmprincipal.AbrirFormularioEnPanel(new FrmEditarRegistro(registroCompleto));
                this.Close();
            }
            */
            // Comprueba que la columna "colEditar" exista y que el clic sea en una fila de datos
            if (e.RowIndex < 0) return;
            if (!dataGridView1.Columns.Contains("colEditar")) return;

            if (e.ColumnIndex == dataGridView1.Columns["colEditar"].Index && e.RowIndex >= 0)
            {
                // Obtener el registro completo de la fila
                RegistroTotal registroCompleto = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Opciones personalizadas
                string[] opciones = new string[] { "Editar Torneo", "Editar Desempeño Deportista" };

                // Personalización de botones (opcional)
                Action<Button, int> customizer = (btn, idx) =>
                {
                    if (idx == 0)
                    {
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                    }
                    else if (idx == 1)
                    {
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                    }

                    var t = new ToolTip();
                    t.SetToolTip(btn, $"Abrir: {btn.Text}");
                };

                using (var dlg = new FrmSeleccionEditor("Opciones de Edición", "Seleccione la acción para este registro", opciones, customizer))
                {
                    var r = dlg.ShowDialog(this);
                    if (r == DialogResult.OK)
                    {
                        if (dlg.SelectedIndex == 0)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmEditarEvento(registroCompleto, _frmprincipal));
                            this.Close();
                        }
                        else if (dlg.SelectedIndex == 1)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmEditarCompetencia(registroCompleto, _frmprincipal));
                            this.Close();
                        }
                        /*else if (dlg.SelectedIndex == 2)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmVerSolo(registroCompleto));
                            this.Close();
                        }*/
                    }
                    else
                    {
                        // Cancel: no hacer nada
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic fue en la fila de datos (no en el encabezado).
            // Y que la columna no es la primera columna en blanco (la de la selección de fila).
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // 1. Obtén el objeto de datos completo de la fila seleccionada.
                // Reemplaza "colNombreDeportista" con el nombre de tu columna
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Apellidos" || dataGridView1.Columns[e.ColumnIndex].Name == "Nombres")
                {
                    // 2. Obtén el objeto de datos completo de la fila seleccionada.
                    RegistroTotal registro = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // 3. Extrae el ID del deportista desde el objeto.
                    int idDeportista = registro.IdDeportista;

                    // 4. Abre el nuevo formulario y pásale el ID del deportista.
                    _frmprincipal.AbrirFormularioEnPanel(new FrmHistorialDeportista(idDeportista));
                    this.Close();
                }
            }
        }

        private void btnExportExcelGeneral_Click(object sender, EventArgs e)
        {
            ExportarExcel.ExportarAExcelGeneral(dataGridView1);
        }
    }
}
