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
    public partial class FrmAgregarNuevaEspecialidad : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;
        public FrmAgregarNuevaEspecialidad(FrmPrincipal principal, string nombreDisciplina = null)
        {
            InitializeComponent();

            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            lblDisciplina.Text = nombreDisciplina;
        }

        private void txtNombreEspecialidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtModalidad.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnAgregarEspecialidad_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnAgregarEspecialidad.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreEspecialidad.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese el nombre de la especialidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación
                var conf = MessageBox.Show($"¿Desea agregar la especialidad: {nombre} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes) return;

                var nueva = new Especialidad
                {
                    nombre_especialidad = nombre,
                    modalidad = txtModalidad.Text.Trim(),
                    id_disciplina = _puente.ObtenerIdDisciplinaPorNombre(lblDisciplina.Text)
                };

                int nuevoId = _puente.InsertarEspecialidad(nueva);

                if (nuevoId <= 0)
                {
                    MessageBox.Show("No se pudo insertar la Especialidad. Verifique que no exista una con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Registrar en historial (si tienes este método)
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _puente.InsertarHistorialCambio(idUsuario, "Especialidades", nuevoId, "ESPECIALIDAD AGREGADA", fecha);

                MessageBox.Show("Especialidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a la gestión (abrir formulario de gestión o cerrar y refrescar desde quien llamó)
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar disciplina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
            this.Close();
        }
    }
}
