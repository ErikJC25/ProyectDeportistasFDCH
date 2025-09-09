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
    public partial class FrmFusionarDisciplinas : Form
    {
        private readonly List<SelectedDisciplinaDto> _seleccionados;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmFusionarDisciplinas(List<SelectedDisciplinaDto> seleccionados, FrmPrincipal principal)
        {
            InitializeComponent();

            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));
            _seleccionados = seleccionados ?? throw new ArgumentNullException(nameof(seleccionados));


            dataGridViewSeleccionados.AutoGenerateColumns = false;

            CargarGridDesdeSeleccionados();

            // Pre-fill textbox con la primera disciplina recibida
            if (_seleccionados.Count > 0)
            {
                txtNuevoNombre.Text = _seleccionados[0].NombreDisciplina ?? string.Empty;
            }
        }


        private void CargarGridDesdeSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();

            foreach (var s in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add();
                var row = dataGridViewSeleccionados.Rows[idx];

                // Nombre visible y columna oculta con id
                row.Cells["col_Nombre"].Value = s.NombreDisciplina ?? string.Empty;
                row.Cells["colIdDisciplina"].Value = s.IdDisciplina;

                // Guardar DTO por si lo necesitas luego
                dataGridViewSeleccionados.Rows[idx].Tag = s;
            }

            dataGridViewSeleccionados.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Volver al formulario de gestión (refrescar)
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
            this.Close();
        }

        private void btnFusionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreResultado = txtNuevoNombre.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nombreResultado))
                {
                    MessageBox.Show("Ingrese el nombre de la disciplina resultante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ids seleccionados (únicos)
                var idsSeleccionados = _seleccionados.Select(s => s.IdDisciplina).Where(id => id > 0).Distinct().ToList();
                if (idsSeleccionados.Count < 2)
                {
                    MessageBox.Show("Seleccione al menos dos disciplinas válidas para fusionar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirma = MessageBox.Show($"¿Confirma fusionar {idsSeleccionados.Count} disciplinas en \"{nombreResultado}\" ?",
                                               "Confirmar Fusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma != DialogResult.Yes) return;

                // obtener id usuario logeado desde FrmPrincipal (si existe)
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;

                // Llamar a la capa lógica: crear nuevo (o usar existente) y reasignar
                bool ok = _puente.FusionarDisciplinas(idsSeleccionados, nombreResultado, idUsuario);

                if (!ok)
                {
                    MessageBox.Show("Ocurrió un error al intentar fusionar las disciplinas. Revise los logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Fusión completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a gestión para refrescar
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la fusión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNuevoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnFusionar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnFusionar.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }
    }
}
