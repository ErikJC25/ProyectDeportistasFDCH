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
    public partial class FrmFusionarEspecialidades : Form
    {
        private readonly List<SelectedEspecialidadDto> _seleccionados;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmFusionarEspecialidades(List<SelectedEspecialidadDto> seleccionados, FrmPrincipal principal, string nombreDisciplina = null)
        {
            InitializeComponent();

            _seleccionados = seleccionados ?? throw new ArgumentNullException(nameof(seleccionados));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            dataGridViewSeleccionados.AutoGenerateColumns = false;
            CargarGridDesdeSeleccionados();

            // Pre-fill con la primera especialidad recibida
            if (_seleccionados.Count > 0)
            {
                txtNuevoNombre.Text = _seleccionados[0].NombreEspecialidad ?? string.Empty;
                txtNuevaModalidad.Text = _seleccionados[0].Modalidad ?? string.Empty;
            }

            // Si nos pasaron el nombre de la disciplina, mostrarlo
            if (!string.IsNullOrWhiteSpace(nombreDisciplina))
            {
                lblDisciplina.Text = "Disciplina origen: " + nombreDisciplina;
            }
            else
            {
                // fallback: mostrar id si es único, o vacío
                var idsDisc = _seleccionados.Select(s => s.IdDisciplina).Distinct().ToList();
                if (idsDisc.Count == 1 && idsDisc[0] > 0)
                    lblDisciplina.Text = "Disciplina (ID): " + idsDisc[0];
                else if (idsDisc.Count > 1)
                    lblDisciplina.Text = "Disciplina: (múltiples)";
                else
                    lblDisciplina.Text = "Disciplina: --";
            }

        }

        private void CargarGridDesdeSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();

            foreach (var s in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add();
                var row = dataGridViewSeleccionados.Rows[idx];

                // Asegúrate de que el diseñador tiene columnas con estos Name:
                // col_NombreEspecialidad, col_Modalidad, colIdEspecialidad (oculta), colIdDisciplina (oculta)
                row.Cells["col_NombreEspecialidad"].Value = s.NombreEspecialidad ?? string.Empty;
                row.Cells["col_Modalidad"].Value = s.Modalidad ?? string.Empty;
                row.Cells["colIdEspecialidad"].Value = s.IdEspecialidad;
                row.Cells["colIdDisciplina"].Value = s.IdDisciplina;

                dataGridViewSeleccionados.Rows[idx].Tag = s;
            }

            dataGridViewSeleccionados.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
            this.Close();
        }

        private void btnFusionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreResultado = txtNuevoNombre.Text?.Trim();
                string modalidadResultado = txtNuevaModalidad.Text?.Trim();


                // ids y disciplina
                var idsSeleccionados = _seleccionados.Select(s => s.IdEspecialidad).Where(id => id > 0).Distinct().ToList();
                if (idsSeleccionados.Count < 2)
                {
                    MessageBox.Show("Seleccione al menos dos especialidades válidas para fusionar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var disciplinasDistinct = _seleccionados.Select(s => s.IdDisciplina).Distinct().ToList();
                if (disciplinasDistinct.Count != 1)
                {
                    MessageBox.Show("Todas las especialidades seleccionadas deben pertenecer a la misma disciplina.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idDisciplina = disciplinasDistinct[0];

                var confirma = MessageBox.Show($"¿Confirma fusionar {idsSeleccionados.Count} especialidades en \"{nombreResultado}\" (modalidad: {modalidadResultado})?",
                                               "Confirmar Fusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma != DialogResult.Yes) return;

                // obtener id usuario logeado desde FrmPrincipal (si existe)
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;

                // crear entidad nueva
                var nueva = new Especialidad
                {
                    nombre_especialidad = nombreResultado,
                    modalidad = string.IsNullOrWhiteSpace(modalidadResultado) ? null : modalidadResultado,
                    id_disciplina = idDisciplina
                };

                // Llamada a la capa lógica / datos
                bool ok = _puente.FusionarEspecialidadesCrearNuevoYReasignar(idsSeleccionados, nueva, idUsuario);

                if (!ok)
                {
                    MessageBox.Show("Ocurrió un error al intentar fusionar las especialidades. Revise logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
