using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FDCH.UI.Vistas
{
    public partial class FrmAddDeportista : Form
    {
        private int _idEvento;
        private Cls_Puente puente = new Cls_Puente();
        private Deportista deportistaActual = null; // Almacena el deportista cargado para comparar cambios
        // variable "bandera" para saber si el cambio lo hizo el usuario o el programa
        private bool _cambioInternoPrograma = false;

        FrmPrincipal _frmprincipal;


        public FrmAddDeportista(int idTorneo, FrmPrincipal principal) : this(principal) // Llama al constructor por defecto
        {
            _idEvento = idTorneo;
            var objEvento = puente.ObtenerEventoPorId(idTorneo);
            if (objEvento != null)
            {
                cmbTorneo.SelectedValue = objEvento.id_evento;
                cmbTorneo.Enabled = false;
            }
        }

        public FrmAddDeportista(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
            cmbTorneo.Focus();
            ConfiguracionInicial();
        }

        private void FrmAddDeportista_Shown(object sender, EventArgs e)
        {
            CargarListasDeportistas(); // Carga cédulas y apellidos
        }

        // Carga los datos iniciales en los ComboBox
        private void ConfiguracionInicial()
        {
            CargarEventos();
            CargarDisciplinas();
            CargarTecnicos();

            cmbTorneo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTorneo.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbCedula.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCedula.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbApellidos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbApellidos.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbNombres.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNombres.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbDisciplina.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDisciplina.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbEspecialidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEspecialidad.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbTecnico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTecnico.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        private void CargarEventos()
        {
            try
            {
                var listaeventos = puente.ObtenerEventos();
                cmbTorneo.DataSource = listaeventos;
                cmbTorneo.DisplayMember = "nombre_evento";
                cmbTorneo.ValueMember = "id_evento";
                cmbTorneo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos: " + ex.Message);
            }
        }

        private void CargarTecnicos()
        {
            try
            {
                var listatecnicos = puente.ObtenerTecnicos();
                cmbTecnico.DataSource = listatecnicos;
                cmbTecnico.DisplayMember = "nombre_completo";
                cmbTecnico.ValueMember = "id_tecnico";
                cmbTecnico.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los técnicos: " + ex.Message);
            }
        }

        private void CargarDisciplinas()
        {
            try
            {
                var disciplinas = puente.ObtenerTodasDisciplinas();
                cmbDisciplina.DataSource = disciplinas;
                cmbDisciplina.DisplayMember = "nombre_disciplina";
                cmbDisciplina.ValueMember = "id_disciplina";
                cmbDisciplina.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las disciplinas: " + ex.Message);
            }
        }

        // Carga las listas iniciales para autocompletar deportistas
        private void CargarListasDeportistas()
        {
            try
            {
                cmbCedula.DataSource = puente.ObtenerCedulas();
                cmbCedula.SelectedIndex = -1;

                cmbApellidos.DataSource = puente.ObtenerApellidosUnicos();
                cmbApellidos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listas de deportistas: " + ex.Message);
            }
        }


        private void CargarEspecialidadesPorDisciplina(int idDisciplina)
        {
            try
            {
                var especialidades = puente.ObtenerEspecialidadesPorDisciplina(idDisciplina);
                cmbEspecialidad.DataSource = especialidades;
                cmbEspecialidad.DisplayMember = "nombre_especialidad";
                cmbEspecialidad.ValueMember = "id_especialidad";
                cmbEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message);
            }
        }

        private void CargarModalidadPorEspecialidad(int idEspecialidad)
        {
            try
            {
                var especialidad = puente.ObtenerEspecialidadPorId(idEspecialidad);
                if (especialidad != null)
                {
                    txtModalidad.Text = especialidad.modalidad ?? "";
                    txtModalidad.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la modalidad: " + ex.Message);
            }
        }

        // Rellena los campos del formulario con los datos de un deportista
        private void LlenarCamposDeportista(Deportista dep)
        {
            deportistaActual = dep; // Guardamos el estado original
            if (dep != null)
            {
                cmbCedula.Text = dep.cedula ?? "";
                cmbNombres.Text = dep.nombres ?? "";
                cmbApellidos.Text = dep.apellidos ?? "";
                txtGenero.Text = dep.genero ?? "";
                txtDiscapacidad.Text = dep.tipo_discapacidad ?? "";

                txtGenero.ForeColor = Color.Black;
                txtDiscapacidad.ForeColor = Color.Black;
            }
        }


        // Eventos de SelectedIndexChanged para el autocompletado
        private void cmbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el cambio lo está haciendo nuestro propio código, lo ignoramos.
            if (_cambioInternoPrograma) return;
            if (cmbCedula.SelectedItem == null) return;

            var deportista = puente.BuscarDeportistaPorCedula(cmbCedula.SelectedItem.ToString());
            if (deportista != null)
            {
                try
                {
                    // Activamos la bandera para tener el control
                    _cambioInternoPrograma = true;

                    // Llenamos todos los campos
                    LlenarCamposDeportista(deportista);

                }
                finally
                {
                    // Desactivamos la bandera, devolviendo el control a los eventos del usuario.
                    _cambioInternoPrograma = false;
                }
            }
        }


        private void cmbNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cambioInternoPrograma) return;
            if (cmbNombres.SelectedItem == null || cmbApellidos.SelectedItem == null) return;

            var deportista = puente.BuscarDeportistaPorNombreCompleto(
                cmbNombres.SelectedItem.ToString(),
                cmbApellidos.SelectedItem.ToString()
            );

            if (deportista != null)
            {
                try
                {
                    _cambioInternoPrograma = true;
                    LlenarCamposDeportista(deportista);
                }
                finally
                {
                    _cambioInternoPrograma = false;
                }
            }
        }


        private void cmbApellidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cambioInternoPrograma) return;
            if (cmbApellidos.SelectedItem == null)
            {
                cmbNombres.DataSource = null;
                return;
            }

            try
            {
                _cambioInternoPrograma = true;

                // Si el usuario elige un apellido, reseteamos la ruta de la cédula.
                cmbCedula.SelectedIndex = -1;
                deportistaActual = null; // Limpiamos el deportista actual
                LimpiarCamposParcialmente(); // Limpiamos campos dependientes
            }
            finally
            {
                _cambioInternoPrograma = false;
            }

            try
            {
                // Cargamos los nombres correspondientes al apellido y habilitamos el combo.
                var nombres = puente.ObtenerNombresPorApellido(cmbApellidos.SelectedItem.ToString());
                cmbNombres.DataSource = nombres;

                if(nombres.Count != 0)
                {
                    cmbNombres.SelectedIndex = 0;
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar nombres: " + ex.Message);
            }
        }

        // Pequeño método para limpiar solo los campos que dependen de la selección.
        private void LimpiarCamposParcialmente()
        {
            cmbNombres.Text = "";
            txtGenero.Text = "MASCULINO / FEMENINO";
            txtGenero.ForeColor = Color.DarkGray;
            txtDiscapacidad.Text = "NINGUNA";
            txtDiscapacidad.ForeColor = Color.DarkGray;
        }



        // Evento para el ComboBox de Disciplina
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedValue is int idDisciplina)
            {
                CargarEspecialidadesPorDisciplina(idDisciplina);
                txtModalidad.Text = "INDIVIDUAL / EQUIPO";
                txtModalidad.ForeColor = Color.DarkGray;
            }
            else
            {
                cmbEspecialidad.DataSource = null;
            }
        }



        // Evento para el ComboBox de Especialidad
        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedValue is int idEspecialidad)
            {
                CargarModalidadPorEspecialidad(idEspecialidad);
            }
        }

        // Evento principal para agregar o actualizar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones de campos obligatorios
            if (string.IsNullOrWhiteSpace(cmbNombres.Text) ||
                string.IsNullOrWhiteSpace(cmbApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtGenero.Text) ||
                string.IsNullOrWhiteSpace(cmbDisciplina.Text) ||
                string.IsNullOrWhiteSpace(cmbEspecialidad.Text) ||
                string.IsNullOrWhiteSpace(txtModalidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (nombres, apellidos, género, disciplina, especialidad y modalidad).", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar si el torneo existe
            if (cmbTorneo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un torneo existente de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _idEvento = (int)cmbTorneo.SelectedValue;


            // Preguntar si esta seguro de agregar los datos
            var confirmar = MessageBox.Show("¿Está seguro/a que desea guardar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;


            // Reemplazar los valores de placeholder con cadenas vacías si no han sido modificados
            string tipoDiscapacidad = (txtDiscapacidad.Text == "NINGUNA" && txtDiscapacidad.ForeColor == Color.DarkGray) ? "" : txtDiscapacidad.Text;
            string categoria = (txtCategoria.Text == "SUB21 / MENOR..." && txtCategoria.ForeColor == Color.DarkGray) ? "" : txtCategoria.Text;
            string division = (txtDivision.Text == "55 KG" && txtDivision.ForeColor == Color.DarkGray) ? "" : txtDivision.Text;
            string participantes = (txtParticipantes.Text == "12" && txtParticipantes.ForeColor == Color.DarkGray) ? "" : txtParticipantes.Text;
            string record = (txtRecord.Text == "10" && txtRecord.ForeColor == Color.DarkGray) ? "" : txtRecord.Text;
            string puntos = (txtPuntos.Text == "5" && txtPuntos.ForeColor == Color.DarkGray) ? "" : txtPuntos.Text;
            string medalla = (txtMedalla.Text == "ORO / PLATA / BRONCE" && txtMedalla.ForeColor == Color.DarkGray) ? "" : txtMedalla.Text;
            string ubicacion = (txtUbicacion.Text == "3" && txtUbicacion.ForeColor == Color.DarkGray) ? "" : txtUbicacion.Text;
            string tiempoMarca = (txtTimeMarca.Text == "55 SEG / 120 KG" && txtTimeMarca.ForeColor == Color.DarkGray) ? "" : txtTimeMarca.Text;



            // Lógica de guardado
            try
            {
                // =================================================================
                // PARTE 1: OBTENER O GUARDAR DEPORTISTA
                // =================================================================
                Deportista deportistaParaGuardar = new Deportista
                {
                    cedula = cmbCedula.Text,
                    nombres = cmbNombres.Text,
                    apellidos = cmbApellidos.Text,
                    genero = txtGenero.Text,
                    tipo_discapacidad = tipoDiscapacidad
                };

                int deportistaId;
                if (deportistaActual == null)
                {
                    deportistaId = puente.InsertarDeportista(deportistaParaGuardar);

                    //Registrar la agregacion en el historial
                    HistorialCambio cambio = new HistorialCambio
                    {
                        id_usuario = _frmprincipal._usuarioAutenticado.id_usuario,
                        tabla_afectada = "Deportistas",
                        id_registro_afectado = deportistaId,
                        accion = "AGREGADO",
                        fecha_cambio = DateTime.Now.ToString()
                    };
                    puente.InsertarHistorialCambio(cambio);
                }
                else
                {
                    deportistaId = deportistaActual.id_deportista;
                    if (deportistaActual.nombres != deportistaParaGuardar.nombres ||
                        deportistaActual.apellidos != deportistaParaGuardar.apellidos ||
                        deportistaActual.genero != deportistaParaGuardar.genero ||
                        deportistaActual.tipo_discapacidad != deportistaParaGuardar.tipo_discapacidad ||
                        deportistaActual.cedula != deportistaParaGuardar.cedula)
                    {
                        deportistaParaGuardar.id_deportista = deportistaId;
                        puente.ActualizarDeportista(deportistaParaGuardar);


                        //Registrar el cambio en el historial
                        HistorialCambio cambio = new HistorialCambio
                        {
                            id_usuario = _frmprincipal._usuarioAutenticado.id_usuario,
                            tabla_afectada = "Deportistas",
                            id_registro_afectado = deportistaId,
                            accion = "EDICION",
                            fecha_cambio = DateTime.Now.ToString()
                        };
                        puente.InsertarHistorialCambio(cambio);
                    }
                }
                if (deportistaId == 0) throw new Exception("No se pudo guardar el deportista.");

                // =================================================================
                // PARTE 2: OBTENER O GUARDAR TÉCNICO
                // =================================================================
                int tecnicoId;
                string nombreTecnico = cmbTecnico.Text;

                // Comprobamos si el técnico seleccionado ya tiene un ID (si el usuario eligió de la lista)
                if (cmbTecnico.SelectedValue != null)
                {
                    tecnicoId = (int)cmbTecnico.SelectedValue;
                }
                else
                {
                    // Si no, es porque el usuario escribió uno nuevo. Buscamos por nombre.
                    tecnicoId = puente.ObtenerIdTecnicoPorNombre(nombreTecnico);
                }

                if (tecnicoId == 0) // El técnico no existe
                {
                    // El técnico es nuevo, lo insertamos y obtenemos el nuevo ID
                    Tecnico nuevoTecnico = new Tecnico { nombre_completo = nombreTecnico };
                    tecnicoId = puente.InsertarTecnico(nuevoTecnico);
                }
                if (tecnicoId == 0) throw new Exception("No se pudo guardar el técnico.");

                // =================================================================
                // PARTE 3: OBTENER O GUARDAR DISCIPLINA Y ESPECIALIDAD
                // =================================================================
                // --- Disciplina ---
                int disciplinaId;
                string nombreDisciplina = cmbDisciplina.Text;

                // Comprobamos si la disciplina seleccionada ya tiene un ID (si el usuario eligió de la lista)
                if (cmbDisciplina.SelectedValue != null)
                {
                    disciplinaId = (int)cmbDisciplina.SelectedValue;
                }
                else
                {
                    // Si no, es porque el usuario escribió una nueva. Buscamos por nombre.
                    disciplinaId = puente.ObtenerIdDisciplinaPorNombre(nombreDisciplina);
                }

                if (disciplinaId == 0) // La disciplina no existe
                {
                    Disciplina nuevaDisciplina = new Disciplina { nombre_disciplina = nombreDisciplina };
                    disciplinaId = puente.InsertarDisciplina(nuevaDisciplina);
                }
                if (disciplinaId == 0) throw new Exception("No se pudo guardar la disciplina.");

                // --- Especialidad ---
                int especialidadId;
                string nombreEspecialidad = cmbEspecialidad.Text;

                if (cmbEspecialidad.SelectedValue != null)
                {
                    especialidadId = (int)cmbEspecialidad.SelectedValue;
                }
                else
                {
                    especialidadId = puente.ObtenerIdEspecialidadPorNombre(nombreEspecialidad, disciplinaId);
                }

                if (especialidadId == 0) // La especialidad no existe para esta disciplina
                {
                    Especialidad nuevaEspecialidad = new Especialidad
                    {
                        nombre_especialidad = nombreEspecialidad,
                        modalidad = txtModalidad.Text,
                        id_disciplina = disciplinaId
                    };
                    especialidadId = puente.InsertarEspecialidad(nuevaEspecialidad);
                }
                if (especialidadId == 0) throw new Exception("No se pudo guardar la especialidad.");

                // =================================================================
                // PARTE 4: OBTENR O GUARDAR COMPETENCIA Y GUARDAR DESEMPEÑO (Usando los IDs obtenidos)
                // =================================================================
                int competenciaId;

                competenciaId = puente.BuscarCompetenciaExacta(categoria, division, participantes, record, _idEvento, especialidadId);

                if (competenciaId == 0)
                {
                    // La competencia no existe, la creamos
                    Competencia competencia = new Competencia
                    {
                        categoria = categoria,
                        division = division,
                        numero_participantes = participantes,
                        record = record,
                        id_evento = _idEvento,
                        id_especialidad = especialidadId // Usamos el ID de la especialidad
                    };
                    competenciaId = puente.InsertarCompetencia(competencia);
                }
                if (competenciaId == 0) throw new Exception("No se pudo guardar la competencia.");

                Desempeno desempeno = new Desempeno
                {
                    puntos = puntos,
                    medalla = medalla,
                    observaciones = txtObservacion.Text,
                    tiempo = tiempoMarca,
                    ubicacion = ubicacion,
                    id_deportista = deportistaId,   // Usamos el ID del deportista
                    id_competencia = competenciaId, // Usamos el ID de competencia
                    id_tecnico = tecnicoId          // Usamos el ID del técnico
                };
                int desempenoId = puente.InsertarDesempeno(desempeno);

                //Registrar la participacion en el historial
                HistorialCambio nuevoDesempeno = new HistorialCambio
                {
                    id_usuario = _frmprincipal._usuarioAutenticado.id_usuario,
                    tabla_afectada = "Desempeno",
                    id_registro_afectado = desempenoId,
                    accion = "AGREGACION",
                    fecha_cambio = DateTime.Now.ToString()
                };
                puente.InsertarHistorialCambio(nuevoDesempeno);

                // --- (Mensajes de éxito y opción de continuar se mantienen igual) ---
                MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var continuar = MessageBox.Show("¿Desea agregar otro deportista a este mismo torneo?", "Continuar Agregando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (continuar == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    cmbTorneo.SelectedValue = _idEvento; // Mantenemos el torneo seleccionado
                }
                else
                {
                    this.Close();
                    _frmprincipal.AbrirFormularioEnPanel(new FrmInicio(_frmprincipal));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarFormulario()
        {
            // 1. Limpia el objeto del deportista que se había cargado
            deportistaActual = null;

            // 2. Usamos la bandera para evitar que se disparen eventos de autocompletado mientras limpiamos
            _cambioInternoPrograma = true;

            try
            {
                // --- Restablece la sección del Deportista ---
                // Limpiamos la SELECCIÓN y el TEXTO, pero NO el DataSource (la lista de ítems)
                cmbCedula.SelectedIndex = -1;
                cmbApellidos.SelectedIndex = -1;
                cmbTecnico.SelectedIndex = -1;
                cmbCedula.Text = "";
                cmbApellidos.Text = "";
                cmbTecnico.Text = "";

                // El ComboBox de nombres sí se vacía y deshabilita, porque depende del apellido
                cmbNombres.DataSource = null;
                cmbNombres.Text = "";

                // --- Restablece la sección de Disciplina ---
                cmbDisciplina.SelectedIndex = -1;
                // El ComboBox de especialidad también se vacía y deshabilita
                cmbEspecialidad.DataSource = null;
                cmbEspecialidad.Text = "";

                // --- Restablece TODOS los TextBox a su estado inicial (con texto de ayuda) ---
                txtGenero.Text = "MASCULINO / FEMENINO";
                txtGenero.ForeColor = Color.DarkGray;

                txtDiscapacidad.Text = "NINGUNA";
                txtDiscapacidad.ForeColor = Color.DarkGray;

                txtModalidad.Text = "INDIVIDUAL / EQUIPO";
                txtModalidad.ForeColor = Color.DarkGray;

                txtCategoria.Text = "SUB21 / MENOR...";
                txtCategoria.ForeColor = Color.DarkGray;

                txtDivision.Text = "55 KG";
                txtDivision.ForeColor = Color.DarkGray;

                txtParticipantes.Text = "12";
                txtParticipantes.ForeColor = Color.DarkGray;

                txtRecord.Text = "10";
                txtRecord.ForeColor = Color.DarkGray;

                txtPuntos.Text = "5";
                txtPuntos.ForeColor = Color.DarkGray;

                txtMedalla.Text = "ORO / PLATA / BRONCE";
                txtMedalla.ForeColor = Color.DarkGray;

                txtUbicacion.Text = "3";
                txtUbicacion.ForeColor = Color.DarkGray;

                txtTimeMarca.Text = "55 SEG / 120 KG";
                txtTimeMarca.ForeColor = Color.DarkGray;

                txtObservacion.Text = "";

                // Si el torneo no está bloqueado, también lo limpiamos
                if (cmbTorneo.Enabled)
                {
                    //cmbTorneo.SelectedIndex = -1;
                }

                // 3. Enfoca el cursor en el primer campo para facilitar la siguiente entrada
                cmbCedula.Focus();
            }
            finally
            {
                // 4. Al final, devolvemos el control a los eventos del usuario
                _cambioInternoPrograma = false;
            }
        }


        private void txtGenero_Enter(object sender, EventArgs e)
        {
            if (txtGenero.Text == "MASCULINO / FEMENINO" && txtGenero.ForeColor == Color.DarkGray)
            {
                txtGenero.Text = "";
                txtGenero.ForeColor = Color.Black;
            }
        }

        private void txtGenero_Leave(object sender, EventArgs e)
        {
            if (txtGenero.Text == "")
            {
                txtGenero.Text = "MASCULINO / FEMENINO";
                txtGenero.ForeColor = Color.DarkGray;
            }
        }

        private void txtModalidad_Enter(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "INDIVIDUAL / EQUIPO" && txtModalidad.ForeColor == Color.DarkGray)
            {
                txtModalidad.Text = "";
                txtModalidad.ForeColor = Color.Black;
            }
        }

        private void txtModalidad_Leave(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "")
            {
                txtModalidad.Text = "INDIVIDUAL / EQUIPO";
                txtModalidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtCategoria_Enter(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "SUB21 / MENOR..." && txtCategoria.ForeColor == Color.DarkGray)
            {
                txtCategoria.Text = "";
                txtCategoria.ForeColor = Color.Black;
            }
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "")
            {
                txtCategoria.Text = "SUB21 / MENOR...";
                txtCategoria.ForeColor = Color.DarkGray;
            }
        }

        private void txtDivision_Enter(object sender, EventArgs e)
        {
            if (txtDivision.Text == "55 KG" && txtDivision.ForeColor == Color.DarkGray)
            {
                txtDivision.Text = "";
                txtDivision.ForeColor = Color.Black;
            }
        }

        private void txtDivision_Leave(object sender, EventArgs e)
        {
            if (txtDivision.Text == "")
            {
                txtDivision.Text = "55 KG";
                txtDivision.ForeColor = Color.DarkGray;
            }
        }

        private void txtParticipantes_Enter(object sender, EventArgs e)
        {
            if (txtParticipantes.Text == "12" && txtParticipantes.ForeColor == Color.DarkGray)
            {
                txtParticipantes.Text = "";
                txtParticipantes.ForeColor = Color.Black;
            }
        }

        private void txtParticipantes_Leave(object sender, EventArgs e)
        {
            if (txtParticipantes.Text == "")
            {
                txtParticipantes.Text = "12";
                txtParticipantes.ForeColor = Color.DarkGray;
            }
        }

        private void txtRecord_Enter(object sender, EventArgs e)
        {
            if (txtRecord.Text == "10" && txtRecord.ForeColor == Color.DarkGray)
            {
                txtRecord.Text = "";
                txtRecord.ForeColor = Color.Black;
            }
        }

        private void txtRecord_Leave(object sender, EventArgs e)
        {
            if (txtRecord.Text == "")
            {
                txtRecord.Text = "10";
                txtRecord.ForeColor = Color.DarkGray;
            }
        }

        private void txtPuntos_Enter(object sender, EventArgs e)
        {
            if (txtPuntos.Text == "5" && txtPuntos.ForeColor == Color.DarkGray)
            {
                txtPuntos.Text = "";
                txtPuntos.ForeColor = Color.Black;
            }
        }

        private void txtPuntos_Leave(object sender, EventArgs e)
        {
            if (txtPuntos.Text == "")
            {
                txtPuntos.Text = "5";
                txtPuntos.ForeColor = Color.DarkGray;
            }
        }

        private void txtMedalla_Enter(object sender, EventArgs e)
        {
            if (txtMedalla.Text == "ORO / PLATA / BRONCE" && txtMedalla.ForeColor == Color.DarkGray)
            {
                txtMedalla.Text = "";
                txtMedalla.ForeColor = Color.Black;
            }
        }

        private void txtMedalla_Leave(object sender, EventArgs e)
        {
            if (txtMedalla.Text == "")
            {
                txtMedalla.Text = "ORO / PLATA / BRONCE";
                txtMedalla.ForeColor = Color.DarkGray;
            }
        }

        private void txtUbicacion_Enter(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == "3" && txtUbicacion.ForeColor == Color.DarkGray)
            {
                txtUbicacion.Text = "";
                txtUbicacion.ForeColor = Color.Black;
            }
        }

        private void txtUbicacion_Leave(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == "")
            {
                txtUbicacion.Text = "3";
                txtUbicacion.ForeColor = Color.DarkGray;
            }
        }

        private void txtTimeMarca_Enter(object sender, EventArgs e)
        {
            if (txtTimeMarca.Text == "55 SEG / 120 KG" && txtTimeMarca.ForeColor == Color.DarkGray)
            {
                txtTimeMarca.Text = "";
                txtTimeMarca.ForeColor = Color.Black;
            }
        }

        private void txtTimeMarca_Leave(object sender, EventArgs e)
        {
            if (txtTimeMarca.Text == "")
            {
                txtTimeMarca.Text = "55 SEG / 120 KG";
                txtTimeMarca.ForeColor = Color.DarkGray;
            }
        }

        private void txtDiscapacidad_Enter(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "NINGUNA" && txtDiscapacidad.ForeColor == Color.DarkGray)
            {
                txtDiscapacidad.Text = "";
                txtDiscapacidad.ForeColor = Color.Black;
            }
        }

        private void txtDiscapacidad_Leave(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "")
            {
                txtDiscapacidad.Text = "NINGUNA";
                txtDiscapacidad.ForeColor = Color.DarkGray;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void cmbCedula_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbCedula.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbCedula.TextChanged -= cmbCedula_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbCedula.SelectionStart;
                int selectionLength = cmbCedula.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbCedula.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbCedula.Text.Length)
                {
                    cursorPosition = cmbCedula.Text.Length;
                }
                cmbCedula.SelectionStart = cursorPosition;
                cmbCedula.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbCedula.TextChanged += cmbCedula_TextChanged;
            }
        }

        private void cmbApellidos_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbApellidos.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbApellidos.TextChanged -= cmbApellidos_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbApellidos.SelectionStart;
                int selectionLength = cmbApellidos.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbApellidos.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbApellidos.Text.Length)
                {
                    cursorPosition = cmbApellidos.Text.Length;
                }
                cmbApellidos.SelectionStart = cursorPosition;
                cmbApellidos.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbApellidos.TextChanged += cmbApellidos_TextChanged;
            }
        }

        private void cmbNombres_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbNombres.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbNombres.TextChanged -= cmbNombres_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbNombres.SelectionStart;
                int selectionLength = cmbNombres.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbNombres.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbNombres.Text.Length)
                {
                    cursorPosition = cmbNombres.Text.Length;
                }
                cmbNombres.SelectionStart = cursorPosition;
                cmbNombres.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbNombres.TextChanged += cmbNombres_TextChanged;
            }
        }

        private void cmbDisciplina_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbDisciplina.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbDisciplina.TextChanged -= cmbDisciplina_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbDisciplina.SelectionStart;
                int selectionLength = cmbDisciplina.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbDisciplina.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbDisciplina.Text.Length)
                {
                    cursorPosition = cmbDisciplina.Text.Length;
                }
                cmbDisciplina.SelectionStart = cursorPosition;
                cmbDisciplina.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbDisciplina.TextChanged += cmbDisciplina_TextChanged;
            }
        }

        private void cmbEspecialidad_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbEspecialidad.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbEspecialidad.TextChanged -= cmbEspecialidad_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbEspecialidad.SelectionStart;
                int selectionLength = cmbEspecialidad.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbEspecialidad.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbEspecialidad.Text.Length)
                {
                    cursorPosition = cmbEspecialidad.Text.Length;
                }
                cmbEspecialidad.SelectionStart = cursorPosition;
                cmbEspecialidad.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbEspecialidad.TextChanged += cmbEspecialidad_TextChanged;
            }
        }

        private void cmbTecnico_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbTecnico.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbTecnico.TextChanged -= cmbTecnico_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbTecnico.SelectionStart;
                int selectionLength = cmbTecnico.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbTecnico.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbTecnico.Text.Length)
                {
                    cursorPosition = cmbTecnico.Text.Length;
                }
                cmbTecnico.SelectionStart = cursorPosition;
                cmbTecnico.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbTecnico.TextChanged += cmbTecnico_TextChanged;
            }
        }

        private void cmbTorneo_TextChanged(object sender, EventArgs e)
        {
            string currentText = cmbTorneo.Text;
            string upperText = currentText.ToUpper();

            // Solo si el texto actual es diferente de su versión en mayúsculas, procedemos
            if (currentText != upperText)
            {
                // 1. MUY IMPORTANTE: Desuscribir el evento TextChanged temporalmente
                //    Esto evita que la siguiente línea (comboBox1.Text = ...) vuelva a disparar este mismo evento.
                cmbTorneo.TextChanged -= cmbTorneo_TextChanged;

                // 2. Guardar la posición actual del cursor y la longitud de la selección
                int cursorPosition = cmbTorneo.SelectionStart;
                int selectionLength = cmbTorneo.SelectionLength;

                // 3. Aplicar el texto en mayúsculas
                cmbTorneo.Text = upperText;

                // 4. Restaurar la posición del cursor y la selección
                if (cursorPosition > cmbTorneo.Text.Length)
                {
                    cursorPosition = cmbTorneo.Text.Length;
                }
                cmbTorneo.SelectionStart = cursorPosition;
                cmbTorneo.SelectionLength = selectionLength;

                // 5. MUY IMPORTANTE: Volver a suscribir el evento TextChanged
                //    Para que siga funcionando cuando el usuario escriba.
                cmbTorneo.TextChanged += cmbTorneo_TextChanged;
            }
        }

        
    }
}