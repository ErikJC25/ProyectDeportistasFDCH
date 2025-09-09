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

            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            // Configuraciones de grids básicas
            dgvDisciplinas.AutoGenerateColumns = false;
            dgvDisciplinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDisciplinas.MultiSelect = false;
            dgvDisciplinas.AllowUserToAddRows = false;

            dgvEspecialidades.AutoGenerateColumns = false;
            dgvEspecialidades.AllowUserToAddRows = false;
        }


        private void dgvEspecialidades_SelectionChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento: cambió la selección en el grid de disciplinas -> cargar especialidades.
        /// </summary>
        private void dgvDisciplinas_SelectionChanged(object sender, EventArgs e)
        {

        }





        private void FrmGestionarDisciplinasEspecialidades_Load(object sender, EventArgs e)
        {
            CargarDisciplinasInicial();
        }

        private void CargarDisciplinasInicial()
        {
            try
            {
                _listaDisciplinas = _puente.ObtenerDisciplinas() ?? new List<Disciplina>();
                // por defecto orden agregado = id desc
                var orden = _listaDisciplinas.OrderByDescending(d => d.id_disciplina).ToList();
                PoblarGridDisciplinas(orden);

                // llenar cmbDisciplinas para el panel de especialidades
                cmbDisciplinas.DisplayMember = "nombre_disciplina";
                cmbDisciplinas.ValueMember = "id_disciplina";
                cmbDisciplinas.DataSource = _listaDisciplinas.OrderBy(x => x.nombre_disciplina).ToList();

                if (dgvDisciplinas.Rows.Count > 0)
                    dgvDisciplinas.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando disciplinas: " + ex.Message);
            }
        }

        private void PoblarGridDisciplinas(List<Disciplina> lista)
        {
            dgvDisciplinas.Rows.Clear();
            foreach (var d in lista)
            {
                int idx = dgvDisciplinas.Rows.Add(false, d.nombre_disciplina ?? "", "Editar", d.id_disciplina);
                dgvDisciplinas.Rows[idx].Tag = new SelectedDisciplinaDto { IdDisciplina = d.id_disciplina, NombreDisciplina = d.nombre_disciplina };
            }
        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvEspecialidades.Columns[e.ColumnIndex].Name;
            var row = dgvEspecialidades.Rows[e.RowIndex];

            if (col == "colSeleccionarEsp")
            {
                var cell = row.Cells["colSeleccionarEsp"];
                bool cur = cell.Value is bool b && b;
                cell.Value = !cur;
            }
            else if (col == "colEditarEsp")
            {
                SelectedEspecialidadDto dto = row.Tag as SelectedEspecialidadDto;
                if (dto == null)
                {
                    int idEsp = 0, idDisc = 0;
                    int.TryParse(row.Cells["colIdEspecialidad"].Value?.ToString(), out idEsp);
                    int.TryParse(row.Cells["colIdDiscRelacion"].Value?.ToString(), out idDisc);
                    dto = new SelectedEspecialidadDto
                    {
                        IdEspecialidad = idEsp,
                        IdDisciplina = idDisc,
                        NombreEspecialidad = row.Cells["colNombreEspecialidad"].Value?.ToString() ?? "",
                        Modalidad = row.Cells["colModalidad"].Value?.ToString() ?? ""
                    };
                }

                //var frm = new FrmEditarEspecialidad(dto, _puente);
                //var r = frm.ShowDialog(this);
                //if (r == DialogResult.OK && cmbDisciplinas.SelectedValue is int idDisc2) CargarEspecialidadesDeDisciplina(idDisc2);
            }
        }

        private void btnOrdenarId_Click(object sender, EventArgs e)
        {
            txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
            txtNombreEspecialidad.ForeColor = Color.DarkGray;
            PoblarGridEspecialidades(_listaEspecialidadesActual.OrderByDescending(x => x.id_especialidad).ToList());
        }

        private void btnOrdenarAlfabeticamente_Click(object sender, EventArgs e)
        {
            txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
            txtNombreEspecialidad.ForeColor = Color.DarkGray;
            PoblarGridEspecialidades(_listaEspecialidadesActual.OrderBy(x => x.nombre_especialidad).ToList());
        }

       
        private void btnFusionarEspecialidades_Click(object sender, EventArgs e)
        {
            var seleccionadas = GetSelectedEspecialidadesDto();
            if (seleccionadas.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos especialidades para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*var frm = new FrmFusionarEspecialidades(seleccionadas, _puente, ObtenerIdUsuarioActual());
            var r = frm.ShowDialog(this);
            if (r == DialogResult.OK)
            {
                // refrescar detalle (si había una disciplina seleccionada)
                if (cmbDisciplinas.SelectedValue is int idDisc) CargarEspecialidadesDeDisciplina(idDisc);
            }
            */
        }

        private void btnBuscarDisciplina_Click(object sender, EventArgs e)
        {
            string placeholder = "NOMBRE DISCIPLINA";
            var criterio = (string.IsNullOrWhiteSpace(txtNombreDisciplina.Text) || (txtNombreDisciplina.Text == placeholder && txtNombreDisciplina.ForeColor == Color.DarkGray)) ? "" : txtNombreDisciplina.Text.Trim();

            var filtrados = _listaDisciplinas.Where(d => string.IsNullOrEmpty(criterio) || (d.nombre_disciplina ?? "").IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
                                             .OrderByDescending(d => d.id_disciplina).ToList();
            PoblarGridDisciplinas(filtrados);
        }

        private void btnLimpiarDisciplina_Click(object sender, EventArgs e)
        {
            txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
            txtNombreDisciplina.ForeColor = Color.DarkGray;
            PoblarGridDisciplinas(_listaDisciplinas.OrderByDescending(d => d.id_disciplina).ToList());
        }

        private void btnOrdenAlfabeticoDisciplinas_Click(object sender, EventArgs e)
        {
            txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
            txtNombreDisciplina.ForeColor = Color.DarkGray;
            PoblarGridDisciplinas(_listaDisciplinas.OrderBy(d => d.nombre_disciplina).ToList());
        }

        private void btnOrdenAgregacionDisciplinas_Click(object sender, EventArgs e)
        {
            txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
            txtNombreDisciplina.ForeColor = Color.DarkGray;
            PoblarGridDisciplinas(_listaDisciplinas.OrderByDescending(d => d.id_disciplina).ToList());
        }

        private void btnAgregarDisciplina_Click(object sender, EventArgs e)
        {
            /*
            // Abrir formulario agregar (implementar FrmAgregarDisciplina si quieres)
            var frm = new FrmAgregarDisciplina(_puente, this); // puede ser una simple ventana modal
            frm.ShowDialog(this);

            // refrescar
            CargarDisciplinasInicial();
            */
        }

        private void btnFusionarDisciplina_Click(object sender, EventArgs e)
        {
            /*
            var seleccionadas = GetSelectedDisciplinasDto();
            if (seleccionadas.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos disciplinas para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir FrmFusionarDisciplinas (debes implementarlo). Le pasamos la lista de DTOs y el idUsuario.
            var frm = new FrmFusionarDisciplinas(seleccionadas, _puente, ObtenerIdUsuarioActual());
            var r = frm.ShowDialog(this);
            if (r == DialogResult.OK)
            {
                // refrescar
                CargarDisciplinasInicial();
            }
            */
        }

        private List<SelectedDisciplinaDto> GetSelectedDisciplinasDto()
        {
            var lista = new List<SelectedDisciplinaDto>();
            foreach (DataGridViewRow row in dgvDisciplinas.Rows)
            {
                if (row.Cells["colSeleccionarDisc"].Value is bool sel && sel)
                {
                    if (row.Tag is SelectedDisciplinaDto dto) lista.Add(dto);
                    else
                    {
                        int id = 0; int.TryParse(row.Cells["colIdDisciplina"].Value?.ToString(), out id);
                        lista.Add(new SelectedDisciplinaDto { IdDisciplina = id, NombreDisciplina = row.Cells["colNombreDisciplina"].Value?.ToString() ?? "" });
                    }
                }
            }
            return lista;
        }

        private void dgvDisciplinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvDisciplinas.Columns[e.ColumnIndex].Name;
            var row = dgvDisciplinas.Rows[e.RowIndex];

            if (col == "colSeleccionarDisc")
            {
                var cell = row.Cells["colSeleccionarDisc"];
                bool cur = cell.Value is bool b && b;
                cell.Value = !cur;
            }
            else if (col == "colEditarDisc")
            {
                // abrir editar disciplina pasando DTO
                SelectedDisciplinaDto dto = row.Tag as SelectedDisciplinaDto;
                if (dto == null)
                {
                    int id = 0; int.TryParse(row.Cells["colIdDisciplina"].Value?.ToString(), out id);
                    dto = new SelectedDisciplinaDto { IdDisciplina = id, NombreDisciplina = row.Cells["colNombreDisciplina"].Value?.ToString() ?? "" };
                }
                
                /*
                var frm = new FrmEditarDisciplina(dto, _puente);
                var r = frm.ShowDialog(this);
                if (r == DialogResult.OK) CargarDisciplinasInicial();
                */

            }
        }

        private void cmbDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplinas.SelectedItem is Disciplina sel)
            {
                CargarEspecialidadesDeDisciplina(sel.id_disciplina);
            }
            else if (cmbDisciplinas.SelectedValue is int idVal && idVal > 0)
            {
                CargarEspecialidadesDeDisciplina((int)cmbDisciplinas.SelectedValue);
            }
            else
            {
                _listaEspecialidadesActual = new List<Especialidad>();
                PoblarGridEspecialidades(_listaEspecialidadesActual);
            }
        }

        private void CargarEspecialidadesDeDisciplina(int idDisc)
        {
            try
            {
                _listaEspecialidadesActual = _puente.ObtenerEspecialidadesPorDisciplina(idDisc) ?? new List<Especialidad>();
                PoblarGridEspecialidades(_listaEspecialidadesActual.OrderByDescending(e => e.id_especialidad).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando especialidades: " + ex.Message);
            }
        }

        private void PoblarGridEspecialidades(List<Especialidad> lista)
        {
            dgvEspecialidades.Rows.Clear();
            foreach (var esp in lista)
            {
                int idx = dgvEspecialidades.Rows.Add(false,
                                                     esp.nombre_especialidad ?? "",
                                                     esp.modalidad ?? "",
                                                     "Editar",
                                                     esp.id_disciplina,
                                                     esp.id_especialidad);
                dgvEspecialidades.Rows[idx].Tag = new SelectedEspecialidadDto
                {
                    IdEspecialidad = esp.id_especialidad,
                    IdDisciplina = esp.id_disciplina,
                    NombreEspecialidad = esp.nombre_especialidad,
                    Modalidad = esp.modalidad
                };
            }
        }

        private void btnBuscarEspecialidad_Click(object sender, EventArgs e)
        {
            string placeholder = "NOMBRE ESPECIALIDAD";
            var criterio = (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text) || (txtNombreEspecialidad.Text == placeholder && txtNombreEspecialidad.ForeColor == Color.DarkGray)) ? "" : txtNombreEspecialidad.Text.Trim();

            var filtrados = _listaEspecialidadesActual.Where(x => string.IsNullOrWhiteSpace(criterio) || (x.nombre_especialidad ?? "").IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
                                                     .OrderByDescending(x => x.id_especialidad).ToList();
            PoblarGridEspecialidades(filtrados);
        }

        private void btnLimpiarEspecialidad_Click(object sender, EventArgs e)
        {
            txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
            txtNombreEspecialidad.ForeColor = Color.DarkGray;
            PoblarGridEspecialidades(_listaEspecialidadesActual.OrderByDescending(x => x.id_especialidad).ToList());
        }

        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            /*
            // abrir formulario de agregar especialidad — necesita seleccionar disciplina primero
            if (cmbDisciplinas.SelectedItem is Disciplina disc)
            {
                var frm = new FrmAgregarEspecialidad(disc.id_disciplina, _puente);
                var r = frm.ShowDialog(this);
                if (r == DialogResult.OK) CargarEspecialidadesDeDisciplina(disc.id_disciplina);
            }
            else MessageBox.Show("Seleccione primero una disciplina.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            */
        }

        private List<SelectedEspecialidadDto> GetSelectedEspecialidadesDto()
        {
            var lista = new List<SelectedEspecialidadDto>();
            foreach (DataGridViewRow row in dgvEspecialidades.Rows)
            {
                if (row.Cells["colSeleccionarEsp"].Value is bool sel && sel)
                {
                    if (row.Tag is SelectedEspecialidadDto dto) lista.Add(dto);
                    else
                    {
                        int idEsp = 0, idDisc = 0;
                        int.TryParse(row.Cells["colIdEspecialidad"].Value?.ToString(), out idEsp);
                        int.TryParse(row.Cells["colIdDiscRelacion"].Value?.ToString(), out idDisc);
                        lista.Add(new SelectedEspecialidadDto
                        {
                            IdEspecialidad = idEsp,
                            IdDisciplina = idDisc,
                            NombreEspecialidad = row.Cells["colNombreEspecialidad"].Value?.ToString() ?? "",
                            Modalidad = row.Cells["colModalidad"].Value?.ToString() ?? ""
                        });
                    }
                }
            }
            return lista;
        }


        private int ObtenerIdUsuarioActual()
        {
            int idUsuario = 0;
            try
            {
                if (_frmPrincipal?._usuarioAutenticado != null)
                    idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
            }
            catch { idUsuario = 0; }

            return idUsuario;
        }

        private void txtNombreDisciplina_Enter(object sender, EventArgs e)
        {
            if (txtNombreDisciplina.Text == "NOMBRE DISCIPLINA" && txtNombreDisciplina.ForeColor == Color.DarkGray)
            {
                txtNombreDisciplina.Text = "";
                txtNombreDisciplina.ForeColor = Color.Black;
            }
        }

        private void txtNombreDisciplina_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDisciplina.Text))
            {
                txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
                txtNombreDisciplina.ForeColor = Color.DarkGray;
            }
        }

        private void txtNombreDisciplina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscarDisciplina_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtNombreEspecialidad_Enter(object sender, EventArgs e)
        {
            if (txtNombreEspecialidad.Text == "NOMBRE ESPECIALIDAD" && txtNombreDisciplina.ForeColor == Color.DarkGray)
            {
                txtNombreEspecialidad.Text = "";
                txtNombreEspecialidad.ForeColor = Color.Black;
            }
        }

        private void txtNombreEspecialidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
                txtNombreEspecialidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtNombreEspecialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscarEspecialidad_Click(sender, e);
                e.Handled = true;
            }
        }
    }
    
}
