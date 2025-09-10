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
    public partial class FrmAgregarNuevoTecnico : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;
        public FrmAgregarNuevoTecnico(FrmPrincipal principal)
        {
            
            InitializeComponent();
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnAgregarNuevo_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnAgregarNuevo.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
                {
                    MessageBox.Show("El campo de nombre completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirma = MessageBox.Show("¿Está seguro de agregar este nuevo técnico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirma != DialogResult.Yes) return;

                // Construir entidad
                var tecnico = new Tecnico
                {
                    nombre_completo = txtNombreCompleto.Text,
                };


                int nuevoId = 0;
                try
                {
                    nuevoId = _puente.InsertarTecnico(tecnico);
                }
                catch (Exception exDb)
                {
                    MessageBox.Show("Error al insertar técnico: " + exDb.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (nuevoId <= 0)
                {
                    MessageBox.Show("No se pudo insertar el técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Registrar en historial un único registro para la creación
                int idUsuario = 0;
                try
                {
                    if (_frmPrincipal?._usuarioAutenticado != null)
                        idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
                }
                catch { idUsuario = 0; }

                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                try
                {
                    _puente.InsertarHistorialCambio(idUsuario, "Tecnicos", nuevoId, "TECNICO AGREGADO", fecha);
                }
                catch
                {
                    // No crítico: fallar el historial no debe invalidar la creación
                }

                MessageBox.Show("Tecnico agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
            this.Close();
        }
    }
}
