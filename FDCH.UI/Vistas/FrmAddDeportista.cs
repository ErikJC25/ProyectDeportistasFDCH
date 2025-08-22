using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public FrmAddDeportista(int idTorneo)
        {
            InitializeComponent();
            _idEvento = idTorneo;
            txtCedula.Focus();
        }

        // Nuevo: Método para cargar las disciplinas al inicio
        private void FrmAddDeportista_Load(object sender, EventArgs e)
        {
            CargarDisciplinas();
            cmbEspecialidad.Enabled = false; // Deshabilitar el ComboBox de especialidades al inicio
        }

        private void CargarDisciplinas()
        {
            try
            {
                var disciplinas = puente.ObtenerTodasDisciplinas();
                cmbDisciplina.DataSource = disciplinas;
                cmbDisciplina.DisplayMember = "nombre_disciplina";
                cmbDisciplina.ValueMember = "id_disciplina";
                cmbDisciplina.SelectedIndex = -1; // Para que no seleccione nada por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las disciplinas: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Reemplazamos los TextBox por ComboBox para Disciplina y Especialidad
            string nombreDisciplina = cmbDisciplina.Text;
            string nombreEspecialidad = cmbEspecialidad.Text;

            // Recoge todos los demás datos como antes
            Deportista deportista = new Deportista
            {
                cedula = txtCedula.Text ?? "",
                nombres = txtNombres.Text ?? "",
                apellidos = txtApellidos.Text ?? "",
                genero = txtGenero.Text ?? "",
                tipo_discapacidad = txtDiscapacidad.Text ?? ""
            };

            Tecnico tecnico = new Tecnico
            {
                nombre_completo = txtTecnico.Text ?? ""
            };

            Especialidad especialidad = new Especialidad
            {
                nombre_especialidad = nombreEspecialidad,
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

            bool exito = puente.InsertarRegistroComplejo(deportista, tecnico, nombreDisciplina, especialidad, competencia, desempeno);

            if (exito)
            {
                MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- Lógica para continuar agregando deportistas ---
                var continuar = MessageBox.Show(
                    "¿Desea agregar otro deportista a este mismo torneo?",
                    "Continuar Agregando",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (continuar == DialogResult.Yes)
                {
                    LimpiarFormulario(); // Nuevo método para limpiar los campos
                }
                else
                {
                    this.Close(); // Cierra el formulario si el usuario no desea continuar
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarFormulario()
        {
            // Limpia los TextBox principales
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";

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
            txtCedula.Focus();
        }

        private void txtGenero_Enter(object sender, EventArgs e)
        {
            if(txtGenero.Text == "Masculino / Femenino")
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
            if (txtModalidad.Text == "Individual / Equipo")
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
            if (txtCategoria.Text == "Sub21 / Menor...")
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
            if (txtDivision.Text == "55 kg")
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
            if (txtParticipantes.Text == "12")
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
            if (txtRecord.Text == "10")
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
            if (txtPuntos.Text == "5")
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
            if (txtMedalla.Text == "Oro / Plata / Bronce")
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
            if (txtUbicacion.Text == "3")
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
            if (txtTimeMarca.Text == "55 seg / 120 kg")
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
            if (txtTecnico.Text == "Nombre Apellido")
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
            if (txtDiscapacidad.Text == "Ninguna")
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

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex != -1)
            {
                cmbEspecialidad.Enabled = true;
                CargarEspecialidadesPorDisciplina((int)cmbDisciplina.SelectedValue);
            }
            else
            {
                // Si el usuario borra la selección (escribe algo nuevo), deshabilita el de especialidades
                cmbEspecialidad.Enabled = false;
                cmbEspecialidad.DataSource = null;
                cmbEspecialidad.Text = "";
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

    }
}
