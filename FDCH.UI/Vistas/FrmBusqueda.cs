using FDCH.Logica;
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
            _frmprincipal.AbrirFormularioEnPanel(new FrmFiltrar(this));
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

            string titulo = "Lic. Santiago Buenaño";
            string rol = "DIRECTOR TÉCNICO METODOLÓGICO (E)";

            try
            {
                // Llamada al generador pasando la tabla, el form, el rol y el título
                await FDCH.UI.ExportarWord.ExportarAWordAsync(dataGridView1, this, titulo, rol);
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
