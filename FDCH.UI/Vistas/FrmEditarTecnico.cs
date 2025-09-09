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
    public partial class FrmEditarTecnico : Form
    {
        private readonly TecnicoRowDto _dto;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmEditarTecnico(TecnicoRowDto dto, FrmPrincipal principal)
        {
            InitializeComponent();
            _dto = dto ?? throw new ArgumentNullException(nameof(dto));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones mínimas
                if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
                {
                    MessageBox.Show("El campo nombre completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmar = MessageBox.Show("¿Desea guardar los cambios de este técnico?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar != DialogResult.Yes) return;

                // Construir entidad Tecnico para actualización
                var actualizado = new Tecnico
                {
                    id_tecnico = _dto.IdTecnico,
                    nombre_completo = txtNombreCompleto.Text.Trim(),
                };

                bool ok = _puente.ActualizarTecnico(actualizado);
                if (!ok)
                {
                    MessageBox.Show("No se pudo actualizar el técnico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _puente.InsertarHistorialCambio(idUsuario, "Tecnicos", actualizado.id_tecnico, "TECNICO EDITADO", fecha);

                MessageBox.Show("Técnico actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a la gestión y refrescar
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
            this.Close();
        }

        private void FrmEditarTecnico_Load(object sender, EventArgs e)
        {
            try
            {
                // Rellenar controles desde DTO (sin lanzar consultas adicionales)
                
                txtNombreCompleto.Text = _dto.NombreCompleto ?? string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
