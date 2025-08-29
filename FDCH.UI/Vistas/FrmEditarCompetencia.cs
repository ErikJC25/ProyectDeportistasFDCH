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
    public partial class FrmEditarCompetencia : Form
    {
        //Se guarda el objeto registro recibido, necesario para rellenar los textbox y combobox
        private readonly RegistroTotal _registro;
        //Se instancia la capa lógica
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmEditarCompetencia(RegistroTotal registroCompleto, FrmPrincipal parent = null)
        {
            InitializeComponent();
            //Se asigna _registro
            _registro = registroCompleto ?? throw new ArgumentNullException(nameof(registroCompleto));
            //Suscribe el manejador Load que se ejecutará cuando el dormulario y sus controles estén listos
            this.Load += FrmEditarCompetencia_Load;
        }

        private void FrmEditarCompetencia_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();                 // 1) Poblar comboboxes desde BD / lógica
                //LlenarControlesConRegistro();   // 2) Seleccionar los valores que corresponden al registro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCombos()
        {
            /*// --- EVENTOS / TORNEOS ---
            var eventos = _puente.ObtenerEventos();
            // Asumimos que Evento tiene propiedades: id_evento, nombre_evento, lugar, fecha_inicio, fecha_fin, tipo_evento, nivel_evento
            cmbTorneo.DisplayMember = "nombre_evento";
            cmbTorneo.ValueMember = "id_evento";
            cmbTorneo.DataSource = eventos;
            // Suscribimos para actualizar campos de evento cuando el usuario seleccione otro torneo
            cmbTorneo.SelectedIndexChanged -= cmbTorneo_SelectedIndexChanged;
            cmbTorneo.SelectedIndexChanged += cmbTorneo_SelectedIndexChanged;

            // --- DISCIPLINAS ---
            var disciplinas = _puente.ObtenerDisciplinas();
            cmbDisciplina.DisplayMember = "nombre_disciplina";
            cmbDisciplina.ValueMember = "id_disciplina";
            cmbDisciplina.DataSource = disciplinas;
            cmbDisciplina.SelectedIndexChanged -= cmbDisciplina_SelectedIndexChanged;
            cmbDisciplina.SelectedIndexChanged += cmbDisciplina_SelectedIndexChanged;

            // --- ESPECIALIDADES (se cargarán según disciplina) ---
            int idDiscRegistro = _registro.IdDisciplina;
            var especialidades = _puente.ObtenerEspecialidadesPorDisciplina(idDiscRegistro);
            cmbEspecialidad.DisplayMember = "nombre_especialidad";
            cmbEspecialidad.ValueMember = "id_especialidad";
            cmbEspecialidad.DataSource = especialidades;
            // Suscribir para mostrar modalidad cuando se cambie especialidad
            cmbEspecialidad.SelectedIndexChanged -= cmbEspecialidad_SelectedIndexChanged;
            cmbEspecialidad.SelectedIndexChanged += cmbEspecialidad_SelectedIndexChanged;

            // --- COMPETENCIAS ---
            var competencias = _puente.ObtenerCompetencias();
            var competenciasDto = competencias
                .Select(c => new
                {
                    id_competencia = c.id_competencia,
                    DisplayText = $"{c.categoria ?? ""} - {c.division ?? ""} (Record: {c.record ?? ""})"
                })
                .ToList();
            cmbCompetencia.DisplayMember = "DisplayText";
            cmbCompetencia.ValueMember = "id_competencia";
            cmbCompetencia.DataSource = competenciasDto;

            // --- TECNICOS ---
            var tecnicos = _puente.ObtenerTecnicos();
            cmbTecnico.DisplayMember = "nombre_completo";
            cmbTecnico.ValueMember = "id_tecnico";
            cmbTecnico.DataSource = tecnicos;

            // --- COMBOS SIMPLES ---
            cmbGenero.Items.Clear();
            cmbGenero.Items.AddRange(new object[] { "M", "F", "Otro" });

            cmbMedalla.Items.Clear();
            cmbMedalla.Items.AddRange(new object[] { "Oro", "Plata", "Bronce", "Ninguna" });
            */
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
