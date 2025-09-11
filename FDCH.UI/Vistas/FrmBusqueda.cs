using FDCH.Logica;
using FDCH.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmBusqueda : Form
    {
        Cls_Puente puente = new Cls_Puente(); // Instancia de Cls_Puente
        public FrmPrincipal _frmprincipal;
        //Director para los certificados
        private Director _director;

        public FrmBusqueda(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
            dataGridView1.AutoGenerateColumns = false; // Desactivar la generación automática de columnas

            if (_frmprincipal.bloqueoActivo == false)
            {
                dataGridView1.Columns["colEditar"].Visible = false;
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
            // Definición de placeholders actuales
            string placeholderCedula = "CEDULA";
            string placeholderApellidos = "APELLIDOS";
            string placeholderNombres = "NOMBRES";

            // Validar que al menos uno de los campos de búsqueda tenga un valor.
            // Se elimina el espacio en blanco y se compara con el placeholder.
            if ((string.IsNullOrWhiteSpace(txtCedula.Text) || txtCedula.Text == placeholderCedula && txtCedula.ForeColor == Color.DarkGray) &&
                (string.IsNullOrWhiteSpace(txtApellidos.Text) || txtApellidos.Text == placeholderApellidos && txtApellidos.ForeColor == Color.DarkGray) &&
                (string.IsNullOrWhiteSpace(txtNombres.Text) || txtNombres.Text == placeholderNombres && txtNombres.ForeColor == Color.DarkGray))
            {
                MessageBox.Show("Por favor, ingrese al menos un valor en los campos Cédula, Apellidos o Nombres para realizar la búsqueda.",
                                "Campos de Búsqueda Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si la validación falla
            }

            var parametros = new List<System.Data.SQLite.SQLiteParameter>();
            string whereClause = "";


            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text != placeholderCedula && txtCedula.ForeColor != Color.DarkGray)
            {
                whereClause += "d.cedula LIKE @cedula";
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@cedula", $"%{txtCedula.Text}%"));
            }

            if (!string.IsNullOrWhiteSpace(txtApellidos.Text) && txtApellidos.Text != placeholderApellidos && txtApellidos.ForeColor != Color.DarkGray)
            {
                if (!string.IsNullOrEmpty(whereClause)) whereClause += " AND ";
                whereClause += "d.apellidos LIKE @apellidos";
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@apellidos", $"%{txtApellidos.Text}%"));

            }

            if (!string.IsNullOrWhiteSpace(txtNombres.Text) && txtNombres.Text != placeholderNombres && txtNombres.ForeColor != Color.DarkGray)
            {
                if (!string.IsNullOrEmpty(whereClause)) whereClause += " AND ";
                whereClause += "d.nombres LIKE @nombres";
                parametros.Add(new System.Data.SQLite.SQLiteParameter("@nombres", $"%{txtNombres.Text}%"));

            }

            // Aquí se llamaría al método de búsqueda con la condición construida
            var resultados = puente.BuscarParticipacionesDeportista(whereClause, parametros);

            if (resultados == null || resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para los criterios de búsqueda proporcionados.",
                                "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1.DataSource = null; // Limpia el DataGridView si no hay resultados
                return;
            }

            dataGridView1.DataSource = resultados;
        }



        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmprincipal.AbrirFormularioEnPanel(new FrmFiltrar(this, _frmprincipal));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            // Restablecer los campos de texto a sus valores predeterminados
            txtCedula.Text = "CEDULA";
            txtCedula.ForeColor = Color.DarkGray;
            txtApellidos.Text = "APELLIDOS";
            txtApellidos.ForeColor = Color.DarkGray;
            txtNombres.Text = "NOMBRES";
            txtNombres.ForeColor = Color.DarkGray;

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnBuscar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el siguiente campos
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
                // Pone el foco de control en el siguiente campos
                txtNombres.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnBuscar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Buscar
                btnBuscar.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
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

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic fue en la fila de datos (no en el encabezado).
            // Y que la columna no es la primera columna en blanco (la de la selección de fila).
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // 1. Obtén el objeto de datos completo de la fila seleccionada.
                // Reemplaza "colNombreDeportista" con el nombre de tu columna
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Apellidos" || dataGridView1.Columns[e.ColumnIndex].Name == "Nombres")
                {
                    // 2. Obtén el objeto de datos completo de la fila seleccionada.
                    RegistroTotal registro = (RegistroTotal)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                    // 3. Extrae el ID del deportista desde el objeto.
                    int idDeportista = registro.IdDeportista;

                    // 4. Abre el nuevo formulario y pásale el ID del deportista.
                    _frmprincipal.AbrirFormularioEnPanel(new FrmHistorialDeportista(idDeportista, _frmprincipal));
                    this.Close();
                }
            }
        }
    }
}
