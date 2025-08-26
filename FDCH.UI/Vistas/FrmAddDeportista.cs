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
using FDCH.Entidades;
using FDCH.Logica;

namespace FDCH.UI.Vistas
{
    public partial class FrmAddDeportista : Form
    {
        private int _idEvento;
        private Cls_Puente puente = new Cls_Puente();
        private Evento objEvento = new Evento();
        private List<Evento> listaeventos;
        private Deportista deportistaActual = null; // Almacena el deportista si existe

        public FrmAddDeportista(int idTorneo)
        {
            InitializeComponent();
            _idEvento = idTorneo;
            objEvento = puente.ObtenerEventoPorId(idTorneo);
            cmbTorneo.Text = objEvento.nombre_evento;
            cmbTorneo.Enabled = false; // Deshabilitar el ComboBox de torneos
            cmbCedula.Focus();
            CargarDisciplinas();
            CargarEspecialidades(); // Cargar la lista completa de especialidades
            cmbEspecialidad.Enabled = true; // Habilitar desde el inicio
            CargarDeportistas();
        }

        public FrmAddDeportista()
        {
            InitializeComponent();
            cmbTorneo.Focus();
            CargarEventos();
            CargarDisciplinas();
            CargarEspecialidades(); // Cargar la lista completa de especialidades
            cmbEspecialidad.Enabled = true; // Habilitar desde el inicio
            CargarDeportistas();
        }

        private void CargarEventos()
        {
            try
            {
                listaeventos = puente.ObtenerEventos();
                cmbTorneo.DataSource = listaeventos;
                cmbTorneo.DisplayMember = "nombre_torneo";
                cmbTorneo.ValueMember = "id_evento";
                cmbTorneo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los eventos: " + ex.Message);
            }
        }

        private void CargarDeportistas()
        {
            try
            {
                var deportistas = puente.ObtenerTodosDeportistas();
                // Enlazar los 3 ComboBox al mismo DataSource
                cmbCedula.DataSource = new BindingSource(deportistas, null);
                cmbNombres.DataSource = new BindingSource(deportistas, null);
                cmbApellidos.DataSource = new BindingSource(deportistas, null);

                cmbCedula.DisplayMember = "cedula";
                cmbNombres.DisplayMember = "nombres";
                cmbApellidos.DisplayMember = "apellidos";

                cmbCedula.ValueMember = "cedula";
                cmbNombres.ValueMember = "nombres";
                cmbApellidos.ValueMember = "apellidos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los deportistas: " + ex.Message);
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

        private void CargarEspecialidades()
        {
            try
            {
                var especialidades = puente.ObtenerTodasEspecialidades();
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
                if (especialidad != null && !string.IsNullOrEmpty(especialidad.modalidad))
                {
                    txtModalidad.Text = especialidad.modalidad;
                    txtModalidad.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la modalidad: " + ex.Message);
            }
        }

        private void AutocompletarDeportista(string cedula, string nombres, string apellidos)
        {
            // Busca primero por cédula, luego por nombres y apellidos
            deportistaActual = puente.BuscarDeportista(cedula, nombres, apellidos);
            if (deportistaActual != null)
            {
                // Autocompleta los campos si se encuentra un deportista
                cmbCedula.Text = deportistaActual.cedula ?? "";
                cmbNombres.Text = deportistaActual.nombres ?? "";
                cmbApellidos.Text = deportistaActual.apellidos ?? "";
                txtGenero.Text = deportistaActual.genero ?? "";
                txtDiscapacidad.Text = deportistaActual.tipo_discapacidad ?? "";

                // Cambia el color del texto si se autocompleta con valores existentes
                if (!string.IsNullOrEmpty(txtGenero.Text) && txtGenero.Text != "Masculino / Femenino") txtGenero.ForeColor = Color.Black;
                if (!string.IsNullOrEmpty(txtDiscapacidad.Text) && txtDiscapacidad.Text != "Ninguna") txtDiscapacidad.ForeColor = Color.Black;
            }
        }

        // Evento para el ComboBox de Cédula
        private void cmbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCedula.SelectedIndex != -1 && cmbCedula.SelectedValue != null)
            {
                AutocompletarDeportista(cmbCedula.SelectedValue.ToString(), null, null);
            }
        }

        // Evento para el ComboBox de Nombres
        private void cmbNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombres.SelectedIndex != -1 && cmbNombres.SelectedValue != null)
            {
                AutocompletarDeportista(null, cmbNombres.SelectedValue.ToString(), null);
            }
        }

        // Evento para el ComboBox de Apellidos
        private void cmbApellidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbApellidos.SelectedIndex != -1 && cmbApellidos.SelectedValue != null)
            {
                AutocompletarDeportista(null, null, cmbApellidos.SelectedValue.ToString());
            }
        }

        // Evento para el ComboBox de Disciplina
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex != -1 && cmbDisciplina.SelectedValue is int idDisciplina)
            {
                CargarEspecialidadesPorDisciplina(idDisciplina);
            }
            else
            {
                // Si la selección se borra, recarga todas las especialidades
                CargarEspecialidades();
            }
        }

        // Evento para el ComboBox de Especialidad
        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedIndex != -1 && cmbEspecialidad.SelectedValue is int idEspecialidad)
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

            // Mapeo de datos desde el formulario a las entidades
            Deportista nuevoDeportista = new Deportista
            {
                cedula = cmbCedula.Text ?? "",
                nombres = cmbNombres.Text ?? "",
                apellidos = cmbApellidos.Text ?? "",
                genero = txtGenero.Text ?? "",
                tipo_discapacidad = txtDiscapacidad.Text ?? ""
            };

            Tecnico tecnico = new Tecnico
            {
                nombre_completo = txtTecnico.Text ?? ""
            };

            Especialidad especialidad = new Especialidad
            {
                nombre_especialidad = cmbEspecialidad.Text,
                modalidad = txtModalidad.Text ?? ""
            };

            Competencia competencia = new Competencia
            {
                categoria = txtCategoria.Text ?? "",
                division = txtDivision.Text ?? "",
                numero_participantes = txtParticipantes.Text ?? "",
                record = txtRecord.Text ?? "",
                id_evento = _idEvento
            };

            Desempeno desempeno = new Desempeno
            {
                puntos = txtPuntos.Text ?? "",
                medalla = txtMedalla.Text ?? "",
                observaciones = "",
                tiempo = txtTimeMarca.Text ?? "",
                ubicacion = txtUbicacion.Text ?? ""
            };

            // Confirmación
            var confirm = MessageBox.Show("¿Desea guardar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            bool exito;
            if (deportistaActual != null)
            {
                // Lógica de actualización si el deportista existe
                exito = puente.ActualizarRegistroComplejo(deportistaActual, nuevoDeportista, tecnico, cmbDisciplina.Text, especialidad, competencia, desempeno);
            }
            else
            {
                // Lógica de inserción si el deportista es nuevo
                exito = puente.InsertarRegistroComplejo(nuevoDeportista, tecnico, cmbDisciplina.Text, especialidad, competencia, desempeno);
            }

            if (exito)
            {
                MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var continuar = MessageBox.Show(
                    "¿Desea agregar otro deportista a este mismo torneo?",
                    "Continuar Agregando",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (continuar == DialogResult.Yes)
                {
                    LimpiarFormulario();
                    CargarDeportistas(); // Recargar la lista de deportistas
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarFormulario()
        {
            // Limpia los TextBox principales
            cmbCedula.Text = "";
            cmbNombres.Text = "";
            cmbApellidos.Text = "";

            // Restablece los TextBox con texto de ayuda a sus valores por defecto
            txtGenero.Text = "Masculino / Femenino";
            txtGenero.ForeColor = Color.DarkGray;

            txtDiscapacidad.Text = "Ninguna";
            txtDiscapacidad.ForeColor = Color.DarkGray;

            txtTecnico.Text = "Nombre Apellido";
            txtTecnico.ForeColor = Color.DarkGray;

            txtModalidad.Text = "Individual / Equipo";
            txtModalidad.ForeColor = Color.DarkGray;

            txtCategoria.Text = "Sub21 / Menor...";
            txtCategoria.ForeColor = Color.DarkGray;

            txtDivision.Text = "55 kg";
            txtDivision.ForeColor = Color.DarkGray;

            txtParticipantes.Text = "12";
            txtParticipantes.ForeColor = Color.DarkGray;

            txtRecord.Text = "10";
            txtRecord.ForeColor = Color.DarkGray;

            txtPuntos.Text = "5";
            txtPuntos.ForeColor = Color.DarkGray;

            txtMedalla.Text = "Oro / Plata / Bronce";
            txtMedalla.ForeColor = Color.DarkGray;

            txtUbicacion.Text = "3";
            txtUbicacion.ForeColor = Color.DarkGray;

            txtTimeMarca.Text = "55 seg / 120 kg";
            txtTimeMarca.ForeColor = Color.DarkGray;

            // Resetea los ComboBox de Disciplina y Especialidad
            cmbDisciplina.SelectedIndex = -1;
            cmbDisciplina.Text = "";
            cmbEspecialidad.SelectedIndex = -1;
            cmbEspecialidad.Text = "";
            cmbEspecialidad.Enabled = false; // Deshabilita el de especialidades como al inicio

            // Opcional: enfoca el cursor en el primer campo para facilitar la entrada de datos
            cmbCedula.Focus();
        }

        private void txtGenero_Enter(object sender, EventArgs e)
        {
            if(txtGenero.Text == "Masculino / Femenino" && txtGenero.ForeColor == Color.DarkGray)
            {
                txtGenero.Text = "";
                txtGenero.ForeColor = Color.Black;
            }
        }

        private void txtGenero_Leave(object sender, EventArgs e)
        {
            if (txtGenero.Text == "")
            {
                txtGenero.Text = "Masculino / Femenino";
                txtGenero.ForeColor = Color.DarkGray;
            }
        }

        private void txtModalidad_Enter(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "Individual / Equipo" && txtModalidad.ForeColor == Color.DarkGray)
            {
                txtModalidad.Text = "";
                txtModalidad.ForeColor = Color.Black;
            }
        }

        private void txtModalidad_Leave(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "")
            {
                txtModalidad.Text = "Individual / Equipo";
                txtModalidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtCategoria_Enter(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "Sub21 / Menor..." && txtCategoria.ForeColor == Color.DarkGray)
            {
                txtCategoria.Text = "";
                txtCategoria.ForeColor = Color.Black;
            }
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "")
            {
                txtCategoria.Text = "Sub21 / Menor...";
                txtCategoria.ForeColor = Color.DarkGray;
            }
        }

        private void txtDivision_Enter(object sender, EventArgs e)
        {
            if (txtDivision.Text == "55 kg" && txtDivision.ForeColor == Color.DarkGray)
            {
                txtDivision.Text = "";
                txtDivision.ForeColor = Color.Black;
            }
        }

        private void txtDivision_Leave(object sender, EventArgs e)
        {
            if (txtDivision.Text == "")
            {
                txtDivision.Text = "55 kg";
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
            if (txtMedalla.Text == "Oro / Plata / Bronce" && txtMedalla.ForeColor == Color.DarkGray)
            {
                txtMedalla.Text = "";
                txtMedalla.ForeColor = Color.Black;
            }
        }

        private void txtMedalla_Leave(object sender, EventArgs e)
        {
            if (txtMedalla.Text == "")
            {
                txtMedalla.Text = "Oro / Plata / Bronce";
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
            if (txtTimeMarca.Text == "55 seg / 120 kg" && txtTimeMarca.ForeColor == Color.DarkGray)
            {
                txtTimeMarca.Text = "";
                txtTimeMarca.ForeColor = Color.Black;
            }
        }

        private void txtTimeMarca_Leave(object sender, EventArgs e)
        {
            if (txtTimeMarca.Text == "")
            {
                txtTimeMarca.Text = "55 seg / 120 kg";
                txtTimeMarca.ForeColor = Color.DarkGray;
            }
        }

        private void txtTecnico_Enter(object sender, EventArgs e)
        {
            if (txtTecnico.Text == "Nombre Apellido" && txtTecnico.ForeColor == Color.DarkGray)
            {
                txtTecnico.Text = "";
                txtTecnico.ForeColor = Color.Black;
            }
        }

        private void txtTecnico_Leave(object sender, EventArgs e)
        {
            if (txtTecnico.Text == "")
            {
                txtTecnico.Text = "Nombre Apellido";
                txtTecnico.ForeColor = Color.DarkGray;
            }
        }

        private void txtDiscapacidad_Enter(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "Ninguna" && txtDiscapacidad.ForeColor == Color.DarkGray)
            {
                txtDiscapacidad.Text = "";
                txtDiscapacidad.ForeColor = Color.Black;
            }
        }

        private void txtDiscapacidad_Leave(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "")
            {
                txtDiscapacidad.Text = "Ninguna";
                txtDiscapacidad.ForeColor = Color.DarkGray;
            }
        }

    }
}
