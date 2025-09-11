using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmEditarCompetencia : Form
    {
        // Registro con toda la información que se pasa desde FrmInicio
        private readonly RegistroTotal _registro;

        // Puente a la capa lógica / datos
        private readonly Cls_Puente _puente = new Cls_Puente();

        // Referencia al frm principal para poder abrir FrmInicio al cerrar
        private readonly FrmPrincipal _frmPrincipal;

        // Deportista cargado desde BD (si existe) para comparar cambios y decidir actualizar o crear
        private Deportista deportistaActual = null;

        // Bandera para indicar que estamos rellenando controles programáticamente
        private bool _isProgrammaticallyChanging = false;

        public FrmEditarCompetencia(RegistroTotal registroCompleto, FrmPrincipal frmPrincipal)
        {
            InitializeComponent();

            // Guardar referencias (validamos para detectar errores temprano)
            _registro = registroCompleto ?? throw new ArgumentNullException(nameof(registroCompleto));
            _frmPrincipal = frmPrincipal ?? throw new ArgumentNullException(nameof(frmPrincipal));

            // Asegurar que los botones tienen asignados sus handlers (en caso de que el Designer no lo hiciera)
            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Suscribir Load para inicializar después de que los controles estén creados
            this.Load += FrmEditarCompetencia_Load;
        }

        // ---------------------------
        // LOAD: se dispara cuando el Form y controles ya están creados
        // ---------------------------
        private void FrmEditarCompetencia_Load(object sender, EventArgs e)
        {
            try
            {
                // 1) Poblar combos y listas básicas (eventos, disciplinas, técnicos, apellidos/cedulas usados para autocompletar)
                CargarListasIniciales();

                // 2) Rellenar los controles con la información del registro
                LlenarControlesConRegistro();

                // 3) Configurar autocompletes y estilo editable de combos (DropDown para permitir escribir)
                ConfigurarAutoCompletes();

                // 4) Suscribir eventos de SelectedIndexChanged / TextChanged para replicar UX de FrmAddDeportista
                SuscribirEventosUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------
        // 1) Poblar combos desde BD
        // -------------------------
        private void CargarListasIniciales()
        {
            // Eventos / Torneos
            try
            {
                var eventos = _puente.ObtenerEventos();
                cmbTorneo.DisplayMember = "nombre_evento";
                cmbTorneo.ValueMember = "id_evento";
                cmbTorneo.DataSource = eventos;
                cmbTorneo.SelectedIndex = -1;
            }
            catch { /* ignoramos excepción, el UI seguirá pero sin eventos */ }

            // Disciplinas
            try
            {
                var disciplinas = _puente.ObtenerTodasDisciplinas();
                cmbDisciplina.DisplayMember = "nombre_disciplina";
                cmbDisciplina.ValueMember = "id_disciplina";
                cmbDisciplina.DataSource = disciplinas;
                cmbDisciplina.SelectedIndex = -1;
                cmbEspecialidad.Enabled = false; // se habilitará si se selecciona disciplina
            }
            catch { }

            // Técnicos
            try
            {
                var tecnicos = _puente.ObtenerTecnicos();
                cmbTecnico.DisplayMember = "nombre_completo";
                cmbTecnico.ValueMember = "id_tecnico";
                cmbTecnico.DataSource = tecnicos;
                cmbTecnico.SelectedIndex = -1;
            }
            catch { }

            // Autocompletado para deportistas: cédulas y apellidos (necesarios para LlenarControlesConRegistro)
            try
            {
                var cedulas = _puente.ObtenerCedulas() ?? new List<string>();
                cmbCedula.DataSource = cedulas;
                cmbCedula.SelectedIndex = -1;
            }
            catch { }

            try
            {
                var apellidos = _puente.ObtenerApellidosUnicos() ?? new List<string>();
                cmbApellidos.DataSource = apellidos;
                cmbApellidos.SelectedIndex = -1;
            }
            catch { }
        }

        // ---------------------------------------------------
        // 2) Rellenar los controles con los valores del registro
        // ---------------------------------------------------
        private void LlenarControlesConRegistro()
        {
            _isProgrammaticallyChanging = true;
            try
            {
                // --- TORNEO / EVENTO ---
                if (_registro.IdEvento != 0)
                {
                    try { cmbTorneo.SelectedValue = _registro.IdEvento; }
                    catch { cmbTorneo.SelectedIndex = -1; }
                }
                else cmbTorneo.SelectedIndex = -1;

                // --- DEPORTISTA: Cedula, Apellidos, Nombres ---
                // Para lograr que la lista de apellidos/nombres se muestre correctamente, 
                // asignamos SelectedItem cuando el elemento existe en la DataSource.
                string ced = _registro.Cedula ?? string.Empty;
                string ap = _registro.Apellidos ?? string.Empty;
                string nm = _registro.Nombres ?? string.Empty;

                // Cedula: asignar texto (DataSource puede contener valores)
                cmbCedula.SelectedIndex = -1;
                if (!string.IsNullOrWhiteSpace(ced))
                {
                    // intentar seleccionar si existe en la lista de cedulas
                    var dsCed = cmbCedula.DataSource as List<string>;
                    if (dsCed != null && dsCed.Contains(ced))
                        cmbCedula.SelectedItem = ced;
                    else
                        cmbCedula.Text = ced;
                }
                else
                {
                    cmbCedula.Text = "";
                }

                // Apellidos: preferimos seleccionar el item si está en la lista
                cmbApellidos.SelectedIndex = -1;
                if (!string.IsNullOrWhiteSpace(ap))
                {
                    var dsAp = cmbApellidos.DataSource as List<string>;
                    if (dsAp != null && dsAp.Contains(ap))
                    {
                        cmbApellidos.SelectedItem = ap;
                    }
                    else
                    {
                        // Si no está en la lista, ponemos el texto (combo debe ser DropDown para permitir escribir)
                        cmbApellidos.Text = ap;
                    }
                }
                else
                {
                    cmbApellidos.Text = "";
                }

                // Cargar lista de nombres relacionados con el apellido (si hay)
                if (!string.IsNullOrWhiteSpace(ap))
                {
                    try
                    {
                        var nombresParaApellido = _puente.ObtenerNombresPorApellido(ap) ?? new List<string>();
                        cmbNombres.DataSource = nombresParaApellido;
                        cmbNombres.SelectedIndex = -1;
                        // Si el nombre del registro está en la lista, seleccionarlo
                        if (!string.IsNullOrWhiteSpace(nm) && nombresParaApellido.Contains(nm))
                        {
                            cmbNombres.SelectedItem = nm;
                        }
                        else
                        {
                            // si no está en la lista, dejar el texto (editable)
                            cmbNombres.Text = nm;
                        }
                    }
                    catch
                    {
                        // si falla la carga, simplemente asignar el texto
                        cmbNombres.DataSource = null;
                        cmbNombres.Text = nm;
                    }
                }
                else
                {
                    // Si no hay apellido, dejamos el combo de nombres vacío y editable
                    cmbNombres.DataSource = null;
                    cmbNombres.Text = nm;
                }

                // Intentar recuperar deportistaActual desde BD para comparar después
                try
                {
                    deportistaActual = null;
                    if (!string.IsNullOrWhiteSpace(ced))
                        deportistaActual = _puente.BuscarDeportistaPorCedula(ced);

                    if (deportistaActual == null && !string.IsNullOrWhiteSpace(nm) && !string.IsNullOrWhiteSpace(ap))
                        deportistaActual = _puente.BuscarDeportistaPorNombreCompleto(nm, ap);
                }
                catch { /* no fatal */ }

                // --- Genero / discapacidad ---
                txtGenero.Text = _registro.Genero ?? string.Empty;
                txtDiscapacidad.Text = _registro.TipoDiscapacidad ?? string.Empty;

                // --- DISCIPLINA / ESPECIALIDAD ---
                if (_registro.IdDisciplina != 0)
                {
                    try { cmbDisciplina.SelectedValue = _registro.IdDisciplina; }
                    catch { cmbDisciplina.SelectedIndex = -1; }
                }
                else
                {
                    cmbDisciplina.SelectedIndex = -1;
                }

                // Si disciplina trae valor, cargar especialidades correspondientes
                if (_registro.IdDisciplina != 0)
                {
                    try
                    {
                        var listaEsp = _puente.ObtenerEspecialidadesPorDisciplina(_registro.IdDisciplina);
                        cmbEspecialidad.DisplayMember = "nombre_especialidad";
                        cmbEspecialidad.ValueMember = "id_especialidad";
                        cmbEspecialidad.DataSource = listaEsp;
                        cmbEspecialidad.Enabled = true;
                    }
                    catch { cmbEspecialidad.DataSource = null; }
                }

                if (_registro.IdEspecialidad != 0)
                {
                    try { cmbEspecialidad.SelectedValue = _registro.IdEspecialidad; }
                    catch { cmbEspecialidad.SelectedIndex = -1; }
                }
                else
                {
                    cmbEspecialidad.SelectedIndex = -1;
                }

                txtModalidad.Text = _registro.Modalidad ?? string.Empty;

                // --- COMPETENCIA: categoria, division, participantes, record ---
                txtCategoria.Text = _registro.Categoria ?? string.Empty;
                txtDivision.Text = _registro.Division ?? string.Empty;
                txtParticipantes.Text = _registro.NumeroParticipantes ?? string.Empty;
                txtRecord.Text = _registro.Record ?? string.Empty;

                // --- Tecnico ---
                if (_registro.IdTecnico != 0)
                {
                    try { cmbTecnico.SelectedValue = _registro.IdTecnico; }
                    catch { cmbTecnico.SelectedIndex = -1; }
                }
                else cmbTecnico.SelectedIndex = -1;

                // --- Desempeño ---
                txtPuntos.Text = _registro.Puntos ?? string.Empty;
                txtMedalla.Text = _registro.Medalla ?? string.Empty;
                txtUbicacion.Text = _registro.Ubicacion ?? string.Empty;
                txtTimeMarca.Text = _registro.Tiempo ?? string.Empty;
                txtObservacion.Text = _registro.Observaciones ?? string.Empty;
            }
            finally
            {
                _isProgrammaticallyChanging = false;
            }
        }

        // ---------------------------
        // 3) Configurar autocompletes y estilo editable
        // ---------------------------
        private void ConfigurarAutoCompletes()
        {
            // Asegurar que los combos son tipo DropDown (editable) para permitir escribir y autocompletar
            var combosEditables = new ComboBox[] { cmbTorneo, cmbCedula, cmbApellidos, cmbNombres, cmbDisciplina, cmbEspecialidad, cmbTecnico };
            foreach (var c in combosEditables)
            {
                c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                c.AutoCompleteSource = AutoCompleteSource.ListItems;
                c.DropDownStyle = ComboBoxStyle.DropDown; // permite escribir además de seleccionar
            }
        }

        // ---------------------------
        // 4) Suscribir eventos (SelectedIndexChanged y TextChanged)
        // ---------------------------
        private void SuscribirEventosUI()
        {
            // SelectedIndexChanged relevantes
            cmbApellidos.SelectedIndexChanged -= cmbApellidos_SelectedIndexChanged;
            cmbApellidos.SelectedIndexChanged += cmbApellidos_SelectedIndexChanged;

            cmbCedula.SelectedIndexChanged -= cmbCedula_SelectedIndexChanged;
            cmbCedula.SelectedIndexChanged += cmbCedula_SelectedIndexChanged;

            cmbNombres.SelectedIndexChanged -= cmbNombres_SelectedIndexChanged;
            cmbNombres.SelectedIndexChanged += cmbNombres_SelectedIndexChanged;

            cmbDisciplina.SelectedIndexChanged -= cmbDisciplina_SelectedIndexChanged;
            cmbDisciplina.SelectedIndexChanged += cmbDisciplina_SelectedIndexChanged;

            cmbEspecialidad.SelectedIndexChanged -= cmbEspecialidad_SelectedIndexChanged;
            cmbEspecialidad.SelectedIndexChanged += cmbEspecialidad_SelectedIndexChanged;

            // TextChanged handlers para forzar mayúsculas (cada uno se desuscribe a sí mismo temporalmente)
            cmbCedula.TextChanged -= cmbCedula_TextChanged_1;
            cmbCedula.TextChanged += cmbCedula_TextChanged_1;

            cmbApellidos.TextChanged -= cmbApellidos_TextChanged_1;
            cmbApellidos.TextChanged += cmbApellidos_TextChanged_1;

            cmbNombres.TextChanged -= cmbNombres_TextChanged_1;
            cmbNombres.TextChanged += cmbNombres_TextChanged_1;

            cmbDisciplina.TextChanged -= cmbDisciplina_TextChanged_1;
            cmbDisciplina.TextChanged += cmbDisciplina_TextChanged_1;

            cmbEspecialidad.TextChanged -= cmbEspecialidad_TextChanged_1;
            cmbEspecialidad.TextChanged += cmbEspecialidad_TextChanged_1;

            cmbTecnico.TextChanged -= cmbTecnico_TextChanged_1;
            cmbTecnico.TextChanged += cmbTecnico_TextChanged_1;

            cmbTorneo.TextChanged -= cmbTorneo_TextChanged_1;
            cmbTorneo.TextChanged += cmbTorneo_TextChanged_1;
        }

        /// <summary>
        /// Fuerza mayúsculas en el ComboBox recibido. Para evitar reentradas
        /// desuscribe temporalmente sólo el handler correspondiente.
        /// </summary>
        private void ForzarMayusculasEnCombo(ComboBox combo, string handlerName)
        {
            if (combo == null) return;
            string original = combo.Text ?? string.Empty;
            string upper = original.ToUpper(CultureInfo.CurrentCulture);
            if (original == upper) return;

            // Desuscribir sólo el handler que corresponde (evitar afectar a otros)
            switch (handlerName)
            {
                case nameof(cmbCedula_TextChanged_1):
                    combo.TextChanged -= cmbCedula_TextChanged_1;
                    break;
                case nameof(cmbApellidos_TextChanged_1):
                    combo.TextChanged -= cmbApellidos_TextChanged_1;
                    break;
                case nameof(cmbNombres_TextChanged_1):
                    combo.TextChanged -= cmbNombres_TextChanged_1;
                    break;
                case nameof(cmbDisciplina_TextChanged_1):
                    combo.TextChanged -= cmbDisciplina_TextChanged_1;
                    break;
                case nameof(cmbEspecialidad_TextChanged_1):
                    combo.TextChanged -= cmbEspecialidad_TextChanged_1;
                    break;
                case nameof(cmbTecnico_TextChanged_1):
                    combo.TextChanged -= cmbTecnico_TextChanged_1;
                    break;
                case nameof(cmbTorneo_TextChanged_1):
                    combo.TextChanged -= cmbTorneo_TextChanged_1;
                    break;
            }

            int pos = combo.SelectionStart;
            int sel = combo.SelectionLength;
            combo.Text = upper;
            if (pos > combo.Text.Length) pos = combo.Text.Length;
            combo.SelectionStart = pos;
            combo.SelectionLength = sel;

            // Volver a suscribir
            switch (handlerName)
            {
                case nameof(cmbCedula_TextChanged_1):
                    combo.TextChanged += cmbCedula_TextChanged_1;
                    break;
                case nameof(cmbApellidos_TextChanged_1):
                    combo.TextChanged += cmbApellidos_TextChanged_1;
                    break;
                case nameof(cmbNombres_TextChanged_1):
                    combo.TextChanged += cmbNombres_TextChanged_1;
                    break;
                case nameof(cmbDisciplina_TextChanged_1):
                    combo.TextChanged += cmbDisciplina_TextChanged_1;
                    break;
                case nameof(cmbEspecialidad_TextChanged_1):
                    combo.TextChanged += cmbEspecialidad_TextChanged_1;
                    break;
                case nameof(cmbTecnico_TextChanged_1):
                    combo.TextChanged += cmbTecnico_TextChanged_1;
                    break;
                case nameof(cmbTorneo_TextChanged_1):
                    combo.TextChanged += cmbTorneo_TextChanged_1;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // ---------------------------
        // Guardar (actualizar) — actualiza únicamente el desempeño y entidades relacionadas
        // ---------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones mínimas
                if (string.IsNullOrWhiteSpace(cmbNombres.Text) || string.IsNullOrWhiteSpace(cmbApellidos.Text))
                {
                    MessageBox.Show("Nombres y Apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTorneo.SelectedIndex == -1 || !(cmbTorneo.SelectedValue is int))
                {
                    MessageBox.Show("Seleccione el torneo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar
                var confirm = MessageBox.Show("¿Desea guardar los cambios en este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // ===== 1) Deportista: insertar o actualizar según corresponda =====
                Deportista deportistaParaGuardar = new Deportista
                {
                    cedula = cmbCedula.Text?.Trim(),
                    nombres = cmbNombres.Text?.Trim(),
                    apellidos = cmbApellidos.Text?.Trim(),
                    genero = txtGenero.Text?.Trim(),
                    tipo_discapacidad = string.IsNullOrWhiteSpace(txtDiscapacidad.Text) ? "" : txtDiscapacidad.Text.Trim()
                };

                int deportistaId;
                if (deportistaActual == null)
                {
                    deportistaId = _puente.InsertarDeportista(deportistaParaGuardar);
                }
                else
                {
                    deportistaId = deportistaActual.id_deportista;
                    bool hayCambios =
                        deportistaActual.cedula != deportistaParaGuardar.cedula ||
                        deportistaActual.nombres != deportistaParaGuardar.nombres ||
                        deportistaActual.apellidos != deportistaParaGuardar.apellidos ||
                        deportistaActual.genero != deportistaParaGuardar.genero ||
                        deportistaActual.tipo_discapacidad != deportistaParaGuardar.tipo_discapacidad;

                    if (hayCambios)
                    {
                        deportistaParaGuardar.id_deportista = deportistaId;
                        _puente.ActualizarDeportista(deportistaParaGuardar);

                        //Registrar el cambio en el historial
                        HistorialCambio cambio = new HistorialCambio
                        {
                            id_usuario = _frmPrincipal._usuarioAutenticado.id_usuario,
                            tabla_afectada = "Deportistas",
                            id_registro_afectado = deportistaId,
                            accion = "EDICION",
                            fecha_cambio = DateTime.Now.ToString()
                        };
                        _puente.InsertarHistorialCambio(cambio);
                    }
                }
                if (deportistaId == 0) throw new Exception("No se pudo obtener/guardar el deportista.");

                // ===== 2) Técnico =====
                int tecnicoId = 0;
                if (cmbTecnico.SelectedValue is int tv && tv != 0) tecnicoId = tv;
                else if (!string.IsNullOrWhiteSpace(cmbTecnico.Text))
                {
                    tecnicoId = _puente.ObtenerIdTecnicoPorNombre(cmbTecnico.Text.Trim());
                    if (tecnicoId == 0)
                    {
                        Tecnico nuevo = new Tecnico { nombre_completo = cmbTecnico.Text.Trim() };
                        tecnicoId = _puente.InsertarTecnico(nuevo);
                    }
                }

                // ===== 3) Disciplina / Especialidad =====
                int idDisciplina = 0;
                if (cmbDisciplina.SelectedValue is int dv && dv != 0) idDisciplina = dv;
                else if (!string.IsNullOrWhiteSpace(cmbDisciplina.Text))
                {
                    idDisciplina = _puente.ObtenerIdDisciplinaPorNombre(cmbDisciplina.Text.Trim());
                    if (idDisciplina == 0)
                    {
                        Disciplina nueva = new Disciplina { nombre_disciplina = cmbDisciplina.Text.Trim() };
                        idDisciplina = _puente.InsertarDisciplina(nueva);
                    }
                }

                int idEspecialidad = 0;
                if (cmbEspecialidad.SelectedValue is int ev && ev != 0) idEspecialidad = ev;
                else if (!string.IsNullOrWhiteSpace(cmbEspecialidad.Text) && idDisciplina != 0)
                {
                    idEspecialidad = _puente.ObtenerIdEspecialidadPorNombre(cmbEspecialidad.Text.Trim(), idDisciplina);
                    if (idEspecialidad == 0)
                    {
                        Especialidad nuevaEsp = new Especialidad
                        {
                            nombre_especialidad = cmbEspecialidad.Text.Trim(),
                            modalidad = txtModalidad.Text?.Trim(),
                            id_disciplina = idDisciplina
                        };
                        idEspecialidad = _puente.InsertarEspecialidad(nuevaEsp);
                    }
                }

                // ===== 4) Competencia =====
                int idEvento = (int)cmbTorneo.SelectedValue;
                string categoria = txtCategoria.Text?.Trim();
                string division = txtDivision.Text?.Trim();
                string participantes = txtParticipantes.Text?.Trim();
                string record = txtRecord.Text?.Trim();

                int idCompetencia = _puente.BuscarCompetenciaExacta(categoria, division, participantes, record, idEvento, idEspecialidad);
                if (idCompetencia == 0)
                {
                    Competencia nuevaComp = new Competencia
                    {
                        categoria = categoria,
                        division = division,
                        numero_participantes = participantes,
                        record = record,
                        id_evento = idEvento,
                        id_especialidad = idEspecialidad
                    };
                    idCompetencia = _puente.InsertarCompetencia(nuevaComp);
                }
                if (idCompetencia == 0) throw new Exception("No se pudo obtener/crear la competencia.");

                // ===== 5) Desempeño: construir y actualizar usando el id existente =====
                Desempeno desempeno = new Desempeno
                {
                    id_desempeno = _registro.IdDesempeno, // usar ID existente para UPDATE
                    puntos = txtPuntos.Text?.Trim(),
                    medalla = txtMedalla.Text?.Trim(),
                    observaciones = txtObservacion.Text?.Trim(),
                    tiempo = txtTimeMarca.Text?.Trim(),
                    ubicacion = txtUbicacion.Text?.Trim(),
                    id_deportista = deportistaId,
                    id_competencia = idCompetencia,
                    id_tecnico = tecnicoId
                };

                // Llamada a la capa lógica para actualizar (debe existir ActualizarDesempeno en Cls_Puente/DbService)
                bool actualizado = _puente.ActualizarDesempeno(desempeno);
                if (!actualizado)
                {
                    MessageBox.Show("No se pudo actualizar el desempeño. Revise la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Participación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cerrar y volver a FrmInicio dentro del panel principal (misma lógica que otros forms)
                this.Close();
                _frmPrincipal.AbrirFormularioEnPanel(new FrmInicio(_frmPrincipal));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------
        // Cancelar: cerrar y regresar al inicio (sin cambios)
        // ---------------------------
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmPrincipal.AbrirFormularioEnPanel(new FrmInicio(_frmPrincipal));
        }
        // ---------------------------
        // EVENTOS: when discipline changes -> reload specialities
        // ---------------------------
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticallyChanging) return;

            if (cmbDisciplina.SelectedValue is int idDisc && idDisc != 0)
            {
                try
                {
                    var listaEsp = _puente.ObtenerEspecialidadesPorDisciplina(idDisc);
                    cmbEspecialidad.DisplayMember = "nombre_especialidad";
                    cmbEspecialidad.ValueMember = "id_especialidad";
                    cmbEspecialidad.DataSource = listaEsp;
                    cmbEspecialidad.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cargando especialidades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                cmbEspecialidad.DataSource = null;
                cmbEspecialidad.Enabled = false;
            }
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticallyChanging) return;
            if (cmbEspecialidad.SelectedValue is int idEsp && idEsp != 0)
            {
                try
                {
                    var esp = _puente.ObtenerEspecialidadPorId(idEsp);
                    if (esp != null)
                    {
                        txtModalidad.Text = esp.modalidad ?? string.Empty;
                    }
                }
                catch { }
            }
        }


        private void cmbApellidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticallyChanging) return;

            string apellido = cmbApellidos.SelectedItem as string ?? cmbApellidos.Text;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                // Si deseleccionó, vaciar nombres y limpiar deportistaActual
                _isProgrammaticallyChanging = true;
                try
                {
                    cmbNombres.DataSource = null;
                    cmbNombres.Text = string.Empty;
                    cmbNombres.Enabled = true;
                    deportistaActual = null;
                }
                finally { _isProgrammaticallyChanging = false; }
                return;
            }

            try
            {
                _isProgrammaticallyChanging = true;

                // Limpiar selección de cédula (cambia la "ruta" de identificación)
                cmbCedula.SelectedIndex = -1;
                cmbCedula.Text = string.Empty;
                deportistaActual = null;

                // Cargar nombres para ese apellido
                var nombres = _puente.ObtenerNombresPorApellido(apellido) ?? new List<string>();
                cmbNombres.DataSource = nombres;
                cmbNombres.SelectedIndex = -1;
                cmbNombres.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando nombres por apellido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProgrammaticallyChanging = false;
            }
        }

        private void cmbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticallyChanging) return;

            string ced = cmbCedula.SelectedItem as string ?? cmbCedula.Text;
            if (string.IsNullOrWhiteSpace(ced)) return;

            try
            {
                _isProgrammaticallyChanging = true;

                var dep = _puente.BuscarDeportistaPorCedula(ced);
                if (dep != null)
                {
                    // Llenar campos básicos del deportista
                    deportistaActual = dep;
                    cmbNombres.Text = dep.nombres ?? "";
                    // Si el apellido está en la lista, seleccionarlo
                    if (!string.IsNullOrWhiteSpace(dep.apellidos))
                    {
                        var dsAp = cmbApellidos.DataSource as List<string>;
                        if (dsAp != null && dsAp.Contains(dep.apellidos))
                            cmbApellidos.SelectedItem = dep.apellidos;
                        else
                            cmbApellidos.Text = dep.apellidos;
                    }
                    txtGenero.Text = dep.genero ?? "";
                    txtDiscapacidad.Text = dep.tipo_discapacidad ?? "";
                }
            }
            catch { }
            finally { _isProgrammaticallyChanging = false; }
        }

        private void cmbNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticallyChanging) return;
            if (cmbNombres.SelectedItem == null || string.IsNullOrWhiteSpace(cmbApellidos.Text)) return;

            string nombre = cmbNombres.SelectedItem as string ?? cmbNombres.Text;
            string apellido = cmbApellidos.SelectedItem as string ?? cmbApellidos.Text;

            try
            {
                _isProgrammaticallyChanging = true;
                var dep = _puente.BuscarDeportistaPorNombreCompleto(nombre, apellido);
                if (dep != null)
                {
                    deportistaActual = dep;
                    // sincronizar cédula/nombres/apellidos/género/discapacidad
                    cmbCedula.Text = dep.cedula ?? "";
                    cmbNombres.Text = dep.nombres ?? "";
                    cmbApellidos.Text = dep.apellidos ?? "";
                    txtGenero.Text = dep.genero ?? "";
                    txtDiscapacidad.Text = dep.tipo_discapacidad ?? "";
                }
            }
            catch { }
            finally { _isProgrammaticallyChanging = false; }
        }

        private void cmbCedula_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbCedula, nameof(cmbCedula_TextChanged_1));
        }

        private void cmbApellidos_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbApellidos, nameof(cmbApellidos_TextChanged_1));
        }

        private void cmbNombres_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbNombres, nameof(cmbNombres_TextChanged_1));
        }

        private void cmbDisciplina_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbDisciplina, nameof(cmbDisciplina_TextChanged_1));
        }

        private void cmbEspecialidad_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbEspecialidad, nameof(cmbEspecialidad_TextChanged_1));
        }

        private void cmbTecnico_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbTecnico, nameof(cmbTecnico_TextChanged_1));
        }

        private void cmbTorneo_TextChanged_1(object sender, EventArgs e)
        {
            ForzarMayusculasEnCombo(cmbTorneo, nameof(cmbTorneo_TextChanged_1));
        }
    }
}
