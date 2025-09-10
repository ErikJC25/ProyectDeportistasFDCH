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
    public partial class FrmAgregarNuevaDisciplina : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;
        public FrmAgregarNuevaDisciplina(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));
        }

        private void btnAgregarDisciplina_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreDisciplina.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese el nombre de la disciplina.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación
                var conf = MessageBox.Show($"¿Desea agregar la disciplina: {nombre} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes) return;

                var nueva = new Disciplina
                {
                    nombre_disciplina = nombre
                };

                int nuevoId = _puente.InsertarDisciplina(nueva);

                if (nuevoId <= 0)
                {
                    MessageBox.Show("No se pudo insertar la disciplina. Verifique que no exista una con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Registrar en historial (si tienes este método)
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _puente.InsertarHistorialCambio(idUsuario, "Disciplinas", nuevoId, "DISCIPLINA AGREGADA", fecha);

                MessageBox.Show("Disciplina agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a la gestión (abrir formulario de gestión o cerrar y refrescar desde quien llamó)
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar disciplina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreDisciplina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnAgregarDisciplina_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnAgregarDisciplina.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDisciplinasEspecialidades(_frmPrincipal));
            this.Close();
        }
    }
}
