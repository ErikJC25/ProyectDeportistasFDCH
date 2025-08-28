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
        public FrmFiltrar()
        {
            InitializeComponent();
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

        private void txtEdad_Enter(object sender, EventArgs e)
        {
            if (txtEdad.Text == "EDAD" && txtEdad.ForeColor == Color.DarkGray)
            {
                txtEdad.Text = "";
                txtEdad.ForeColor = Color.Black;
            }
        }

        private void txtEdad_Leave(object sender, EventArgs e)
        {
            if (txtEdad.Text == "")
            {
                txtEdad.Text = "EDAD";
                txtEdad.ForeColor = Color.DarkGray;
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
            string placeholderEdad = "EDAD";

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

            // Validar y añadir condición para la edad (asumiendo que es un campo numérico)
            if (!string.IsNullOrWhiteSpace(txtEdad.Text) && txtEdad.Text != placeholderEdad && txtEdad.ForeColor != Color.DarkGray)
            {
                if (int.TryParse(txtEdad.Text, out int edad))
                {
                    condiciones.Add("d.edad = @edad");
                    parametros.Add(new System.Data.SQLite.SQLiteParameter("@edad", edad));
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico válido para la Edad.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 2. Añadir condiciones para los CheckBox (Género)
            if (chkMasculino.Checked && !chkFemenino.Checked)
            {
                condiciones.Add("d.genero = 'Masculino'");
            }
            else if (chkFemenino.Checked && !chkMasculino.Checked)
            {
                condiciones.Add("d.genero = 'Femenino'");
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
                return;
            }

            // Actualizar el DataGridView con los resultados (asumiendo que está en este mismo formulario)
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
            txtEdad.Text = "EDAD";
            txtEdad.ForeColor = Color.DarkGray;

            chkAntiguoActual.Checked = false;
            chkMasculino.Checked = false;
            chkFemenino.Checked = false;
            chkAlfabeticamente.Checked = false;

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese el carácter
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e); // Llama al método que maneja el clic del botón
                e.Handled = true;
            }
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
                txtEdad.Focus(); // Mueve el foco al siguiente campo
                e.Handled = true;
            }
        }
    }
}
