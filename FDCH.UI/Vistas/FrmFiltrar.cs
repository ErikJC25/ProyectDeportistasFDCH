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
    public partial class FrmFiltrar : Form
    {
        public FrmPrincipal _frmprincipal;
        //Director para los certificados
        private Director _director;
        Cls_Puente puente = new Cls_Puente(); // Instancia de Cls_Puente
        public FrmFiltrar(FrmBusqueda frmBuscar, FrmPrincipal frmprincipal)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false; // Desactivar la generación automática de columnas

            if (frmBuscar._frmprincipal.bloqueoActivo == false)
            {
                dataGridView1.Columns["colEditar"].Visible = false;
            }

            _frmprincipal = frmprincipal;
        }

        private void chkAntiguoActual_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAntiguoActual.Checked)
            {
                chkAntiguoActual.ForeColor = Color.Black;
                chkAlfabeticamente.Checked = false;
            }
            else
            {
                chkAntiguoActual.ForeColor = Color.DarkGray;
            }
        }

        private void chkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasculino.Checked)
            {
                chkMasculino.ForeColor = Color.Black;
            }
            else
            {
                chkMasculino.ForeColor = Color.DarkGray;
            }
        }

        private void chkFemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFemenino.Checked)
            {
                chkFemenino.ForeColor = Color.Black;
            }
            else
            {
                chkFemenino.ForeColor = Color.DarkGray;
            }
        }

        private void chkAlfabeticamente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlfabeticamente.Checked)
            {
                chkAlfabeticamente.ForeColor = Color.Black;
                chkAntiguoActual.Checked = false;
            }
            else
            {
                chkAlfabeticamente.ForeColor = Color.DarkGray;
            }
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            if (txtCedula.Text == "CEDULA" && txtCedula.ForeColor == Color.DarkGray)
            {
                txtCedula.Text = "";
                txtCedula.ForeColor = Color.Black;
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if (txtCedula.Text == "")
            {
                txtCedula.Text = "CEDULA";
                txtCedula.ForeColor = Color.DarkGray;
            }
        }


        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "APELLIDOS" && txtApellidos.ForeColor == Color.DarkGray)
            {
                txtApellidos.Text = "";
                txtApellidos.ForeColor = Color.Black;
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                txtApellidos.Text = "APELLIDOS";
                txtApellidos.ForeColor = Color.DarkGray;
            }
        }


        private void txtNombres_Enter(object sender, EventArgs e)
        {
            if (txtNombres.Text == "NOMBRES" && txtNombres.ForeColor == Color.DarkGray)
            {
                txtNombres.Text = "";
                txtNombres.ForeColor = Color.Black;
            }
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (txtNombres.Text == "")
            {
                txtNombres.Text = "NOMBRES";
                txtNombres.ForeColor = Color.DarkGray;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Crear una lista para almacenar las condiciones de la búsqueda.
            var condiciones = new List<string>();
            // Crear una lista para almacenar los parámetros de la consulta.
            var parametros = new List<System.Data.SQLite.SQLiteParameter>();

            // Definir los placeholders para los campos de texto.
            string placeholderCedula = "CEDULA";
            string placeholderApellidos = "APELLIDOS";
            string placeholderNombres = "NOMBRES";

            // 1. Añadir condiciones para los campos de texto
            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text != placeholderCedula && txtCedula.ForeColor != Color.DarkGray)
            {
                condiciones.Add("d.cedula LIKE @cedula");
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@cedula", $"%{txtCedula.Text}%"));
            }

            if (!string.IsNullOrWhiteSpace(txtApellidos.Text) && txtApellidos.Text != placeholderApellidos && txtApellidos.ForeColor != Color.DarkGray)
            {
                condiciones.Add("d.apellidos LIKE @apellidos");
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@apellidos", $"%{txtApellidos.Text}%"));
            }

            if (!string.IsNullOrWhiteSpace(txtNombres.Text) && txtNombres.Text != placeholderNombres && txtNombres.ForeColor != Color.DarkGray)
            {
                condiciones.Add("d.nombres LIKE @nombres");
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@nombres", $"%{txtNombres.Text}%"));
            }


            // 2. Añadir condiciones para los CheckBox (Género)
            if (chkMasculino.Checked && !chkFemenino.Checked)
            {
                condiciones.Add("d.genero = 'MASCULINO'");
            }
            else if (chkFemenino.Checked && !chkMasculino.Checked)
            {
                condiciones.Add("d.genero = 'FEMENINO'");
            }
            // Si ambos o ninguno están marcados, no se añade filtro por género.

            // 3. Validar si al menos un filtro fue seleccionado
            if (condiciones.Count == 0)
            {
                MessageBox.Show("Por favor, ingrese o seleccione al menos un criterio para realizar la búsqueda.", "Campos de Búsqueda Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Unir las condiciones en una sola cadena para la cláusula WHERE.
            string whereClause = string.Join(" AND ", condiciones);

            // 4. Determinar la cláusula ORDER BY
            string orderByClause = "";
            if (chkAlfabeticamente.Checked)
            {
                orderByClause = "ORDER BY d.apellidos ASC, d.nombres ASC";
            }
            else if (chkAntiguoActual.Checked)
            {
                orderByClause = "ORDER BY e.fecha_inicio ASC";
            }
            // Si se marcan ambos o ninguno, puedes definir un comportamiento por defecto
            // o priorizar uno de ellos. En este caso, no se añade ORDER BY.


            // 5. Llamar al método de la capa lógica
            // Asegúrate de que tu Cls_Puente tenga este nuevo método
            // que acepta la cláusula WHERE, los parámetros y la cláusula ORDER BY.
            var puente = new Cls_Puente();
            var resultados = puente.BuscarParticipacionesDeportistaFiltrado(whereClause, parametros, orderByClause);

            if (resultados == null || resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para los criterios de búsqueda proporcionados.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Limpiar el DataGridView si no hay resultados
                return;
            }

            // Actualizar el DataGridView con los resultados
            dataGridView1.DataSource = resultados;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "CEDULA";
            txtCedula.ForeColor = Color.DarkGray;
            txtApellidos.Text = "APELLIDOS";
            txtApellidos.ForeColor = Color.DarkGray;
            txtNombres.Text = "NOMBRES";
            txtNombres.ForeColor = Color.DarkGray;

            chkAntiguoActual.Checked = false;
            chkMasculino.Checked = false;
            chkFemenino.Checked = false;
            chkAlfabeticamente.Checked = false;

            dataGridView1.DataSource = null; // Limpiar el DataGridView
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtApellidos.Focus(); // Mueve el foco al siguiente campo
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNombres.Focus(); // Mueve el foco al siguiente campo
                e.Handled = true;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e); // Llama al método que maneja el clic del botón
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Comprueba que la columna "colEditar" exista y que el clic sea en una fila de datos
            if (e.RowIndex < 0) return;
            if (!dataGridView1.Columns.Contains("colEditar")) return;

            if (e.ColumnIndex == dataGridView1.Columns["colEditar"].Index && e.RowIndex >= 0)
            {
                // Obtener el registro completo de la fila
                RegistroTotal registroCompleto = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Opciones personalizadas
                string[] opciones = new string[] { "Editar Torneo", "Editar Desempeño Deportista" };

                // Personalización de botones (opcional)
                Action<Button, int> customizer = (btn, idx) =>
                {
                    if (idx == 0)
                    {
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                    }
                    else if (idx == 1)
                    {
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                    }

                    var t = new ToolTip();
                    t.SetToolTip(btn, $"Abrir: {btn.Text}");
                };

                using (var dlg = new FrmSeleccionEditor("Opciones de Edición", "Seleccione la acción para este registro", opciones, customizer))
                {
                    var r = dlg.ShowDialog(this);
                    if (r == DialogResult.OK)
                    {
                        if (dlg.SelectedIndex == 0)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmEditarEvento(registroCompleto, _frmprincipal));
                            this.Close();
                        }
                        else if (dlg.SelectedIndex == 1)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmEditarCompetencia(registroCompleto, _frmprincipal));
                            this.Close();
                        }
                        /*else if (dlg.SelectedIndex == 2)
                        {
                            _frmprincipal.AbrirFormularioEnPanel(new FrmVerSolo(registroCompleto));
                            this.Close();
                        }*/
                    }
                    else
                    {
                        // Cancel: no hacer nada
                    }
                }
            }
        }

        private async void btnExportarWord_Click(object sender, EventArgs e)
        {
            // Deshabilitar botón / feedback
            btnExportarWord.Enabled = false;
            var prevCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            //Obtención de los datos del director

            string titulo = "";
            string rol = "";

            try
            {
                _director = puente.ObtenerDirector() ?? new Director(); // si no existe, nuevo objeto
                titulo = _director.titulo ?? "";
                rol = _director.rol ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos del director: " + ex.Message);
            }


            try
            {
                // Llamada al generador pasando la tabla, el form, el rol y el título
                await FDCH.UI.ExportarWord.ExportarDesdePlantillaAsync(dataGridView1, this, titulo, rol);
            }
            finally
            {
                // Restaurar estado UI
                Cursor = prevCursor;
                btnExportarWord.Enabled = true;
            }
        }
    }
}
