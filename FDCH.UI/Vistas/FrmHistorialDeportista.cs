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

        FrmPrincipal _frmprincipal;

        public FrmHistorialDeportista(int idDeportista, FrmPrincipal principal)
        {
            InitializeComponent();
            this.idDeportista = idDeportista;
            dataGridView1.AutoGenerateColumns = false;

            _frmprincipal = principal;
            if (_frmprincipal.bloqueoActivo == false)
            {
                dataGridView1.Columns["colEditar"].Visible = false;
            }

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
            //ExportarWord.ExportarAWord(dataGridView1);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
