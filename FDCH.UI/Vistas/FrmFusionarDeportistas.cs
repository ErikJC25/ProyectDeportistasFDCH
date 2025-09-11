using FDCH.Entidades;
using FDCH.Logica;
using System.Reflection;
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
    public partial class FrmFusionarDeportistas : Form
    {
        private readonly List<SelectedRowDto> _seleccionados;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmFusionarDeportistas(List<SelectedRowDto> seleccionados, FrmPrincipal principal)
        {
           

            InitializeComponent();

            _seleccionados = seleccionados ?? throw new ArgumentNullException(nameof(seleccionados));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            dataGridViewSeleccionados.AutoGenerateColumns = false;
            CargarGridDesdeSeleccionados();

            // Prefill con el primer seleccionado
            if (_seleccionados.Count > 0)
            {
                var p = _seleccionados[0];
                txbCedula.Text = p.Cedula ?? string.Empty;
                txbNombres.Text = p.Nombres ?? string.Empty;
                txbApellidos.Text = p.Apellidos ?? string.Empty;
                txbGenero.Text = p.Genero ?? string.Empty;
                txbTipoDiscapacidad.Text = p.TipoDiscapacidad ?? string.Empty;
            }
        }

        private void CargarGridDesdeSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();
            foreach (var s in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add();
                var row = dataGridViewSeleccionados.Rows[idx];
                row.Cells["colCedula"].Value = s.Cedula ?? "";
                row.Cells["colNombres"].Value = s.Nombres ?? "";
                row.Cells["colApellidos"].Value = s.Apellidos ?? "";
                row.Cells["colDisciplinas"].Value = s.DisciplinasParticipadas ?? "";
                row.Cells["colGenero"].Value = s.Genero ?? "";
                row.Cells["colTipoDiscapacidad"].Value = s.TipoDiscapacidad ?? "";
                row.Cells["colIdDeportista"].Value = s.IdDeportista;
                row.Tag = s;
            }
            dataGridViewSeleccionados.ClearSelection();
            dataGridViewSeleccionados.ReadOnly = true;
        }


        private void FrmFusionarDeportistas_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarDataGridConSeleccionados();

                // Prefill con el primer registro (target)
                var target = _seleccionados[0];
                txbCedula.Text = target.Cedula ?? string.Empty;
                txbNombres.Text = target.Nombres ?? string.Empty;
                txbApellidos.Text = target.Apellidos ?? string.Empty;
                txbGenero.Text = target.Genero ?? string.Empty;
                txbTipoDiscapacidad.Text = target.TipoDiscapacidad ?? string.Empty;

                // Opcional: desactivar edición del grid (solo vista)
                dataGridViewSeleccionados.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena el datagrid ya creado en el diseñador con los deportistas seleccionados.
        /// </summary>
        private void LlenarDataGridConSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();

            foreach (var d in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add();
                var row = dataGridViewSeleccionados.Rows[idx];

                // Asegúrate de que las columnas con estos names existan en tu DataGridView del diseñador
                row.Cells["colCedula"].Value = d.Cedula ?? string.Empty;
                row.Cells["colNombres"].Value = d.Nombres ?? string.Empty;
                row.Cells["colApellidos"].Value = d.Apellidos ?? string.Empty;
                // Si tu entidad tiene un campo calculado con las disciplinas, úsalo; si no, deja vacío
                row.Cells["colDisciplinas"].Value = (d as dynamic).DisciplinasParticipadas ?? string.Empty;
                row.Cells["colGenero"].Value = d.Genero ?? string.Empty;
                row.Cells["colTipoDiscapacidad"].Value = d.TipoDiscapacidad ?? string.Empty;

                // Columna oculta con id
                row.Cells["colIdDeportista"].Value = d.IdDeportista;
            }

            dataGridViewSeleccionados.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
            this.Close();
        }
        
        private void btnFusionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                var cedula = txbCedula.Text?.Trim();
                var nombres = txbNombres.Text?.Trim();
                var apellidos = txbApellidos.Text?.Trim();
                var genero = txbGenero.Text?.Trim();
                var tipoDiscapacidad = txbTipoDiscapacidad.Text?.Trim();

                if (
                    string.IsNullOrWhiteSpace(nombres) ||
                    string.IsNullOrWhiteSpace(apellidos) ||
                    string.IsNullOrWhiteSpace(genero))
                {
                    MessageBox.Show("Los campos Nombres, Apellidos y Género son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirma = MessageBox.Show("¿Confirma crear un nuevo deportista fusionado y reasignar las participaciones en torneos a este nuevo registro?", "Confirmar Fusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma != DialogResult.Yes) return;

                var nuevo = new Deportista
                {
                    cedula = cedula,
                    nombres = nombres,
                    apellidos = apellidos,
                    genero = genero,
                    tipo_discapacidad = tipoDiscapacidad
                };

                var idsAntiguos = _seleccionados.Select(s => s.IdDeportista).Where(id => id > 0).Distinct().ToList();
                if (idsAntiguos.Count < 1)
                {
                    MessageBox.Show("No se han podido obtener ids válidos de los deportistas seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener id de usuario logeado desde FrmPrincipal (estructura que ya tienes)
                int idUsuario = 0;
                try
                {
                    if (_frmPrincipal?._usuarioAutenticado != null)
                        idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
                }
                catch { idUsuario = 0; }

                bool ok = _puente.FusionarDeportistas(idsAntiguos, nuevo, idUsuario, out int nuevoId);

                if (!ok || nuevoId == 0)
                {
                    MessageBox.Show("Ocurrió un error al fusionar. Revisa logs o permisos de BD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Fusión exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver al gestor y refrescar la vista
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la fusión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
