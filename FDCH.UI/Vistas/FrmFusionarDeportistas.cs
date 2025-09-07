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

            // Configura DataGrid (si no lo hiciste en diseñador)
            dataGridViewSeleccionados.AutoGenerateColumns = false;

            // Cargar la lista en el grid
            CargarGridDesdeSeleccionados();

            // Rellenar campos predeterminados con datos del primer registro (puedes cambiar)
            if (_seleccionados.Count > 0)
            {
                var primer = _seleccionados[0];
                txbCedula.Text = primer.Cedula;
                txbNombres.Text = primer.Nombres;
                txbApellidos.Text = primer.Apellidos;
                txbGenero.Text = primer.Genero;
                txbTipoDiscapacidad.Text = primer.TipoDiscapacidad;
            }
        }

        private void CargarGridDesdeSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();
            foreach (var s in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add(
                    s.Cedula,
                    s.Nombres,
                    s.Apellidos,
                    s.DisciplinasParticipadas,
                    s.Genero,
                    s.TipoDiscapacidad,
                    s.IdDeportista
                );
                // Guarda DTO entero en Tag por si lo necesitas
                dataGridViewSeleccionados.Rows[idx].Tag = s;
            }
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
            /// Volver al formulario de gestión
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
            this.Close();
        }

        /// <summary>
        /// Intentamos obtener el id del usuario actual desde el FrmPrincipal por reflexión,
        /// buscando propiedades comunes. Si no se encuentra, devuelve null y el historial se insertará con id_usuario = NULL.
        /// </summary>
        private int? ObtenerIdUsuarioDesdePrincipal()
        {
            try
            {
                // Intentamos algunas propiedades comunes que podrías tener en FrmPrincipal
                var posibles = new string[] { "UsuarioActual", "usuarioActual", "Usuario", "User", "IdUsuario", "IdUsuarioActual", "idUsuario", "Id" };

                foreach (var name in posibles)
                {
                    var prop = _frmPrincipal.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null)
                    {
                        var val = prop.GetValue(_frmPrincipal);
                        if (val == null) continue;

                        // Si la propiedad es un objeto Usuario con id_usuario
                        var t = val.GetType();
                        var idProp = t.GetProperty("id_usuario") ?? t.GetProperty("Id") ?? t.GetProperty("IdUsuario") ?? t.GetProperty("idUsuario");
                        if (idProp != null)
                        {
                            var idVal = idProp.GetValue(val);
                            if (idVal != null && int.TryParse(idVal.ToString(), out int idInt)) return idInt;
                        }

                        // Si la propiedad ya es int
                        if (val is int vi) return vi;
                        if (int.TryParse(val.ToString(), out int v2)) return v2;
                    }
                }
            }
            catch
            {
                // no crítico - devolvemos null
            }
            return null;
        }
        private void btnFusionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios (cedula, nombres, apellidos, genero)
                var cedula = txbCedula.Text?.Trim();
                var nombres = txbNombres.Text?.Trim();
                var apellidos = txbApellidos.Text?.Trim();
                var genero = txbGenero.Text?.Trim();
                var tipoDiscapacidad = txbTipoDiscapacidad.Text?.Trim();

                if (string.IsNullOrWhiteSpace(cedula) ||
                    string.IsNullOrWhiteSpace(nombres) ||
                    string.IsNullOrWhiteSpace(apellidos) ||
                    string.IsNullOrWhiteSpace(genero))
                {
                    MessageBox.Show("Los campos Cédula, Nombres, Apellidos y Género son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirma = MessageBox.Show("¿Confirma que desea fusionar los deportistas seleccionados en un solo registro?", "Confirmar Fusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma != DialogResult.Yes) return;

                // ID objetivo: primer id de la lista
                int idObjetivo = _seleccionados[0].IdDeportista;
                var idsAEliminar = _seleccionados.Skip(1).Select(x => x.IdDeportista).Where(id => id != 0 && id != idObjetivo).ToList();

                if (idObjetivo == 0)
                {
                    MessageBox.Show("El deportista objetivo no tiene un id válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Intentar obtener idUsuario del FrmPrincipal si existe (int) -- fallback 0
                int idUsuario = ObtenerIdUsuarioDesdeFrmPrincipal(_frmPrincipal);

                // 1) Actualizar el registro del deportista objetivo con los datos nuevos (si lo deseas)
                // Creamos entidad Deportista con la información fusionada
                Deportista deportistaFusionado = new Deportista
                {
                    id_deportista = idObjetivo,
                    cedula = cedula,
                    nombres = nombres,
                    apellidos = apellidos,
                    genero = genero,
                    tipo_discapacidad = tipoDiscapacidad
                };

                // Lógica: actualizar deportista objetivo (si tienes método ActualizarDeportista en puente)
                bool okUpdate = _puente.ActualizarDeportista(deportistaFusionado);
                if (!okUpdate)
                {
                    MessageBox.Show("No se pudo actualizar la información del deportista objetivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2) Transferir dependencias: para cada id a eliminar, actualizar Desempeno -> id_deportista = idObjetivo
                foreach (var idOld in idsAEliminar)
                {
                    bool okUpdDes = _puente.ActualizarIdDesempenoPorDeportista(idOld, idObjetivo);
                    if (!okUpdDes)
                    {
                        MessageBox.Show($"Error al reasignar desempeños desde id {idOld}. Operación interrumpida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 3) Eliminar los deportistas suprimidos
                foreach (var idDel in idsAEliminar)
                {
                    bool okDel = _puente.EliminarDeportistaPorId(idDel);
                    if (!okDel)
                    {
                        MessageBox.Show($"Error al eliminar deportista con id {idDel}. Operación interrumpida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 4) Insertar entrada en historial (registro único por operación y registros de borrado)
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                // Registrar acción de FUSION sobre el id objetivo
                _puente.InsertarHistorialCambio(idUsuario, "Deportistas", idObjetivo, "FUSION", fecha);
                // Registrar acciones de DELETE_FUSION para cada eliminado
                foreach (var idDel in idsAEliminar)
                {
                    _puente.InsertarHistorialCambio(idUsuario, "Deportistas", idDel, "DELETE_FUSION", fecha);
                }

                MessageBox.Show("Fusión completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver al FrmGestionarDeportistas para refrescar la vista
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la fusión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Intenta obtener el id de usuario desde FrmPrincipal utilizando reflexión (por si tienes una propiedad pública).
        /// Si no encuentra, devuelve 0.
        /// </summary>
        private int ObtenerIdUsuarioDesdeFrmPrincipal(FrmPrincipal principal)
        {
            try
            {
                if (principal == null) return 0;
                // Intentamos buscar una propiedad pública llamada "UsuarioActual" o "IdUsuario" o "Usuario"
                var t = principal.GetType();
                var prop = t.GetProperty("UsuarioActual") ?? t.GetProperty("IdUsuario") ?? t.GetProperty("Usuario");
                if (prop != null)
                {
                    var val = prop.GetValue(principal);
                    if (val == null) return 0;

                    // Si es entero directo:
                    if (val is int i) return i;

                    // Si es un objeto Usuario con id_usuario:
                    var propId = val.GetType().GetProperty("id_usuario");
                    if (propId != null)
                    {
                        var idVal = propId.GetValue(val);
                        if (idVal is int ii) return ii;
                    }
                }
            }
            catch { /* silencioso: si no se puede obtener, devolvemos 0 */ }

            return 0;
        }
    }
}
