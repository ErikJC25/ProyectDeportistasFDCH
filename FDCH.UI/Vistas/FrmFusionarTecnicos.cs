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
    public partial class FrmFusionarTecnicos : Form
    {
        private readonly List<TecnicoRowDto> _seleccionados;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmFusionarTecnicos(List<TecnicoRowDto> seleccionados, FrmPrincipal principal)
        {
            InitializeComponent();
            _seleccionados = seleccionados ?? throw new ArgumentNullException(nameof(seleccionados));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            dataGridViewSeleccionados.AutoGenerateColumns = false;

            // Cargar en grid y prefills
            CargarGridDesdeSeleccionados();

            // Pre-llenar el textbox del nuevo técnico con el primer seleccionado (puedes cambiar)
            if (_seleccionados.Count > 0)
            {
                txtNuevoNombre.Text = _seleccionados[0].NombreCompleto ?? string.Empty;
            }
        }

        private void txtNuevoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnFusionar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Agregar
                btnFusionar.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void CargarGridDesdeSeleccionados()
        {
            dataGridViewSeleccionados.Rows.Clear();

            foreach (var s in _seleccionados)
            {
                int idx = dataGridViewSeleccionados.Rows.Add();
                var row = dataGridViewSeleccionados.Rows[idx];

                // Asegúrate de que el designer tiene columnas con estos Name:
                // col_Cedula (si no existe para técnicos se puede omitir), col_Nombre, col_Disciplinas, colIdTecnico (oculta)
                row.Cells["col_Nombre"].Value = s.NombreCompleto ?? string.Empty;
                row.Cells["col_Disciplinas"].Value = s.DisciplinasDirigidas ?? string.Empty;
                row.Cells["colIdTecnico"].Value = s.IdTecnico;

                // guardamos el DTO por si lo necesitamos
                dataGridViewSeleccionados.Rows[idx].Tag = s;
            }

            dataGridViewSeleccionados.ClearSelection();
        }

        private void btnFusionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoNombre = txtNuevoNombre.Text?.Trim();
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    MessageBox.Show("Ingrese el nombre completo del técnico resultante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación
                var conf = MessageBox.Show("¿Confirma la fusión de los técnicos seleccionados en un único técnico nuevo?", "Confirmar Fusión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf != DialogResult.Yes) return;

                // Preparar lista de ids viejos
                var idsViejos = _seleccionados.Select(x => x.IdTecnico).Where(id => id > 0).Distinct().ToList();
                if (idsViejos.Count < 2)
                {
                    MessageBox.Show("Se requieren al menos dos técnicos válidos para fusionar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construir entidad nuevo técnico
                Tecnico nuevo = new Tecnico { nombre_completo = nuevoNombre };

                // Obtener id usuario logeado desde FrmPrincipal
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;

                // Llamar a la lógica / DB
                bool ok = _puente.FusionarTecnicosCrearNuevoYReasignar(idsViejos, nuevo, idUsuario);

                if (!ok)
                {
                    MessageBox.Show("Ocurrió un error al intentar fusionar los técnicos. Revise logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Fusión completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver a gestión para refrescar
                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la fusión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarTecnicos(_frmPrincipal));
            this.Close();
        }
    }
}
