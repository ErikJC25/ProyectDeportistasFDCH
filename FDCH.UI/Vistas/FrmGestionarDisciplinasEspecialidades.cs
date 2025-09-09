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
    public partial class FrmGestionarDisciplinasEspecialidades : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;

        // Cache de datos
        private List<Disciplina> _listaDisciplinas = new List<Disciplina>();
        private List<Especialidad> _listaEspecialidadesActual = new List<Especialidad>();

        public FrmGestionarDisciplinasEspecialidades(FrmPrincipal principal)
        {
            InitializeComponent();

            ConfigureGrids();
        }

        private void ConfigureGrids()
        {
            // Disciplinas: selección de fila única
            dgvDisciplinas.AutoGenerateColumns = false;
            dgvDisciplinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDisciplinas.MultiSelect = false;
            dgvDisciplinas.AllowUserToAddRows = false;
            dgvDisciplinas.ReadOnly = true;
            dgvDisciplinas.RowHeadersVisible = false;

            // Especialidades: permitir chequear filas
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.MultiSelect = false;
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.RowHeadersVisible = false;
            // Nota: las celdas checkbox son editables.
        }

        private void dgvEspecialidades_SelectionChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento: cambió la selección en el grid de disciplinas -> cargar especialidades.
        /// </summary>
        private void dgvDisciplinas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDisciplinas.SelectedRows == null || dgvDisciplinas.SelectedRows.Count == 0)
            {
                // limpiar detalle
                _listaEspecialidadesActual = new List<Especialidad>();
                PoblarGridEspecialidades(_listaEspecialidadesActual);
                return;
            }

            var fila = dgvDisciplinas.SelectedRows[0];

            if (!int.TryParse(fila.Cells["colIdDisciplina"].Value?.ToString(), out int idDisc))
            {
                // si el Tag tiene el objeto, leerlo
                if (fila.Tag is Disciplina tagDisc) idDisc = tagDisc.id_disciplina;
                else
                {
                    _listaEspecialidadesActual = new List<Especialidad>();
                    PoblarGridEspecialidades(_listaEspecialidadesActual);
                    return;
                }
            }

            CargarEspecialidadesParaDisciplina(idDisc);
        }

        private void CargarEspecialidadesParaDisciplina(int idDisc)
        {
            try
            {
                // Obtener la lista desde la capa puente (una sola consulta por disciplina)
                _listaEspecialidadesActual = _puente.ObtenerEspecialidadesPorDisciplina(idDisc) ?? new List<Especialidad>();

                // Mostrar por defecto ordenadas por nombre
                var ordenadas = _listaEspecialidadesActual.OrderBy(x => x.nombre_especialidad).ToList();
                PoblarGridEspecialidades(ordenadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblarGridEspecialidades(List<Especialidad> lista)
        {
            dgvEspecialidades.Rows.Clear();

            foreach (var esp in lista)
            {
                string modal = esp.modalidad ?? string.Empty;
                int idx = dgvEspecialidades.Rows.Add(
                    false,                     // colSeleccionarEsp - checkbox
                    esp.nombre_especialidad ?? string.Empty,
                    modal,
                    "Editar",                  // colEditarEsp
                    esp.id_disciplina,         // colIdDiscRelacion (oculta)
                    esp.id_especialidad        // colIdEspecialidad (oculta)
                );

                dgvEspecialidades.Rows[idx].Tag = esp;
            }
        }

        private void FrmGestionarDisciplinasEspecialidades_Load(object sender, EventArgs e)
        {
            CargarDisciplinas();
        }

        /// <summary>
        /// Carga todas las disciplinas desde la BD y las muestra.
        /// </summary>
        private void CargarDisciplinas()
        {
            try
            {
                _listaDisciplinas = _puente.ObtenerDisciplinas() ?? new List<Disciplina>();

                // Mostrar ordenado alfabéticamente por defecto
                var ordenadas = _listaDisciplinas.OrderBy(x => x.nombre_disciplina).ToList();
                PoblarGridDisciplinas(ordenadas);

                // Seleccionar la primera fila si existe (para cargar detalle)
                if (dgvDisciplinas.Rows.Count > 0)
                {
                    dgvDisciplinas.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando disciplinas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblarGridDisciplinas(List<Disciplina> lista)
        {
            dgvDisciplinas.Rows.Clear();
            foreach (var disc in lista)
            {
                int idx = dgvDisciplinas.Rows.Add(
                    disc.nombre_disciplina ?? string.Empty,
                    "Editar",              // columna botón editar (si la tienes)
                    disc.id_disciplina     // columna oculta
                );
                // Guardar objeto completo en Tag (útil)
                dgvDisciplinas.Rows[idx].Tag = disc;
            }
        }

        /// <summary>
        /// Maneja clicks en el grid de especialidades: checkbox o editar.
        /// </summary>
        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvEspecialidades.Columns[e.ColumnIndex].Name;

            if (colName == "colSeleccionarEsp")
            {
                // Toggle manual (necesario para que el valor se actualice inmediatamente)
                var cell = dgvEspecialidades.Rows[e.RowIndex].Cells["colSeleccionarEsp"];
                bool current = cell.Value is bool b && b;
                cell.Value = !current;
            }
            else if (colName == "colEditarEsp")
            {
                // Abrir formulario editar especialidad (si lo tienes)
                var fila = dgvEspecialidades.Rows[e.RowIndex];
                Especialidad esp = fila.Tag as Especialidad;
                if (esp == null)
                {
                    // construir desde celdas como fallback
                    if (!int.TryParse(fila.Cells["colIdEspecialidad"].Value?.ToString(), out int idEsp))
                    {
                        MessageBox.Show("No pude identificar la especialidad a editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    esp = new Especialidad
                    {
                        id_especialidad = idEsp,
                        nombre_especialidad = fila.Cells["colNombreEspecialidad"].Value?.ToString(),
                        modalidad = fila.Cells["colModalidad"].Value?.ToString(),
                        id_disciplina = int.TryParse(fila.Cells["colIdDiscRelacion"].Value?.ToString(), out int idD) ? idD : 0
                    };
                }

                // TODO: Abrir FrmEditarEspecialidad(esp, this) <-- implementar formulario si lo necesitas.
                MessageBox.Show($"Pulsaste editar para la especialidad: {esp.nombre_especialidad} (ID {esp.id_especialidad})", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOrdenarId_Click(object sender, EventArgs e)
        {
            // Ordenar la lista actual por id_especialidad descendente (mayor -> menor)
            var ordenadas = _listaEspecialidadesActual.OrderByDescending(x => x.id_especialidad).ToList();
            PoblarGridEspecialidades(ordenadas);
        }

        private void btnOrdenarAlfabeticamente_Click(object sender, EventArgs e)
        {
            var ordenadas = _listaEspecialidadesActual.OrderBy(x => x.nombre_especialidad).ToList();
            PoblarGridEspecialidades(ordenadas);
        }

        /// <summary>
        /// Recolecta las especialidades marcadas (checkbox) y abre el formulario de fusión (si corresponde).
        /// </summary>
        private void btnFusionarEspecialidades_Click(object sender, EventArgs e)
        {
            var seleccionadas = new List<Especialidad>();
            foreach (DataGridViewRow row in dgvEspecialidades.Rows)
            {
                if (row.Cells["colSeleccionarEsp"].Value is bool sel && sel)
                {
                    if (row.Tag is Especialidad eObj) seleccionadas.Add(eObj);
                    else
                    {
                        if (int.TryParse(row.Cells["colIdEspecialidad"].Value?.ToString(), out int idEsp))
                        {
                            seleccionadas.Add(new Especialidad
                            {
                                id_especialidad = idEsp,
                                nombre_especialidad = row.Cells["colNombreEspecialidad"].Value?.ToString(),
                                modalidad = row.Cells["colModalidad"].Value?.ToString(),
                                id_disciplina = int.TryParse(row.Cells["colIdDiscRelacion"].Value?.ToString(), out int idD) ? idD : 0
                            });
                        }
                    }
                }
            }

            if (seleccionadas.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos especialidades para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir formulario de fusión (a implementar) pasando la lista de especialidades y la disciplina padre si hace falta.
            // var frm = new FrmFusionarEspecialidades(seleccionadas, disciplinaPadre, this);
            // _parent.AbrirFormularioEnPanel(frm);

            MessageBox.Show($"Se iniciarían la fusión de {seleccionadas.Count} especialidades (implementar FrmFusionarEspecialidades).", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
