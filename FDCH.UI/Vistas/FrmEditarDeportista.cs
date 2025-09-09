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
    public partial class FrmEditarDeportista : Form
    {
        private readonly SelectedRowDto _dto;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmEditarDeportista(SelectedRowDto dto, FrmPrincipal principal)
        {
            InitializeComponent();

            _dto = dto ?? throw new ArgumentNullException(nameof(dto));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtNombres.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtApellidos.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtGenero.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtTipoDiscapacidad.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtTipoDiscapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnGuardarCambios_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnGuardarCambios.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones mínimas
                if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Los campos Nombres y Apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmar = MessageBox.Show("¿Desea guardar los cambios de este deportista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar != DialogResult.Yes) return;

                // Construir entidad Deportista para actualización
                var actualizado = new Deportista
                {
                    id_deportista = _dto.IdDeportista,
                    cedula = string.IsNullOrWhiteSpace(txtCedula.Text) ? null : txtCedula.Text.Trim(),
                    nombres = txtNombres.Text.Trim(),
                    apellidos = txtApellidos.Text.Trim(),
                    genero = string.IsNullOrWhiteSpace(txtGenero.Text) ? null : txtGenero.Text.Trim(),
                    tipo_discapacidad = string.IsNullOrWhiteSpace(txtTipoDiscapacidad.Text) ? null : txtTipoDiscapacidad.Text.Trim()
                };

                bool ok = _puente.ActualizarDeportista(actualizado);
                if (!ok)
                {
                    MessageBox.Show("No se pudo actualizar el deportista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Registrar en historial: sólo registrar la edición del deportista resultante
                int idUsuario = 0;
                try
                {
                    if (_frmPrincipal?._usuarioAutenticado != null)
                        idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;
                }
                catch { idUsuario = 0; }

                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _puente.InsertarHistorialCambio(idUsuario, "Deportistas", actualizado.id_deportista, "DEPORTISTA EDITADO", fecha);

                MessageBox.Show("Deportista actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a la gestión y refrescar
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEditarDeportista_Load(object sender, EventArgs e)
        {
            try
            {
                // Rellenar controles desde DTO (sin lanzar consultas adicionales)
                txtCedula.Text = _dto.Cedula ?? string.Empty;
                txtNombres.Text = _dto.Nombres ?? string.Empty;
                txtApellidos.Text = _dto.Apellidos ?? string.Empty;
                txtGenero.Text = _dto.Genero ?? string.Empty;
                txtTipoDiscapacidad.Text = _dto.TipoDiscapacidad ?? string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
            this.Close();
        }
    }
}
