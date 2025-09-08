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
    public partial class FrmSepararDeportistas : Form
    {
        private readonly SelectedRowDto _originalRow;
        private readonly FrmPrincipal _frmPrincipal;
        private readonly Cls_Puente _puente = new Cls_Puente();
        public FrmSepararDeportistas(SelectedRowDto originalRow, FrmPrincipal principal)
        {
            InitializeComponent();

            _originalRow = originalRow ?? throw new ArgumentNullException(nameof(originalRow));
            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));

            // Configuraciones iniciales
            dataGridViewTargets.AutoGenerateColumns = false;
        }

        private void FrmSepararDeportistas_Load(object sender, EventArgs e)
        {
            // Rellenar textboxes con la fila original (solo lectura)
            txtOrigCedula.Text = _originalRow.Cedula ?? string.Empty;
            txtOrigNombres.Text = _originalRow.Nombres ?? string.Empty;
            txtOrigApellidos.Text = _originalRow.Apellidos ?? string.Empty;
            txtOrigGenero.Text = _originalRow.Genero ?? string.Empty;
            txtOrigTipoDiscapacidad.Text = _originalRow.TipoDiscapacidad ?? string.Empty;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AgregarFilaTarget();
        }

        private void AgregarFilaTarget(string cedula = "", string nombres = "", string apellidos = "", string genero = "", string tipoDiscapacidad = "")
        {
            int idx = dataGridViewTargets.Rows.Add();
            var row = dataGridViewTargets.Rows[idx];
            row.Cells["colT_Cedula"].Value = cedula ?? "";
            row.Cells["colT_Nombres"].Value = nombres ?? "";
            row.Cells["colT_Apellidos"].Value = apellidos ?? "";
            row.Cells["colT_Genero"].Value = genero ?? "";
            row.Cells["colT_TipoDiscapacidad"].Value = tipoDiscapacidad ?? "";
        }

        private void dataGridViewTargets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dataGridViewTargets.Columns[e.ColumnIndex].Name;
            if (colName == "colT_Eliminar")
            {
                // eliminar fila actual
                dataGridViewTargets.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Volver a la pantalla de gestión
            _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
            this.Close();
        }

        private void btnSeparar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recolectar nuevos deportistas desde el grid
                var nuevos = new List<Deportista>();
                foreach (DataGridViewRow row in dataGridViewTargets.Rows)
                {
                    // Ignorar fila nueva en edición
                    if (row.IsNewRow) continue;

                    string cedula = row.Cells["colT_Cedula"].Value?.ToString()?.Trim();
                    string nombres = row.Cells["colT_Nombres"].Value?.ToString()?.Trim();
                    string apellidos = row.Cells["colT_Apellidos"].Value?.ToString()?.Trim();
                    string genero = row.Cells["colT_Genero"].Value?.ToString()?.Trim();
                    string tipoDiscap = row.Cells["colT_TipoDiscapacidad"].Value?.ToString()?.Trim();

                    // Validar campos obligatorios (al menos nombres y apellidos, según definiste)
                    if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
                    {
                        MessageBox.Show("Cada nuevo deportista debe tener Nombres y Apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    nuevos.Add(new Deportista
                    {
                        cedula = string.IsNullOrWhiteSpace(cedula) ? null : cedula,
                        nombres = nombres,
                        apellidos = apellidos,
                        genero = string.IsNullOrWhiteSpace(genero) ? null : genero,
                        tipo_discapacidad = string.IsNullOrWhiteSpace(tipoDiscap) ? null : tipoDiscap
                    });
                }

                if (nuevos.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un deportista para realizar la separación.", "Separar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idOriginal = _originalRow.IdDeportista;
                int idUsuario = 0;
                if (_frmPrincipal?._usuarioAutenticado != null) idUsuario = _frmPrincipal._usuarioAutenticado.id_usuario;

                var confirm = MessageBox.Show("¿Confirma que desea crear los nuevos deportistas duplicando los desempeños del original y eliminar el original?", "Confirmar Separación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                bool ok = _puente.SepararDeportista(idOriginal, nuevos, idUsuario);
                if (!ok)
                {
                    MessageBox.Show("Ocurrió un error durante la separación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Separación realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmPrincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmPrincipal));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al separar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
