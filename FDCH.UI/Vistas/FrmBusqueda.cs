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
        private FrmPrincipal _frmprincipal;


        public FrmBusqueda(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
            dataGridView1.AutoGenerateColumns = false;
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

            string condicionBusqueda = "WHERE ";
            int bandera = 0;

            if (!string.IsNullOrWhiteSpace(txtCedula.Text) && txtCedula.Text != placeholderCedula && txtCedula.ForeColor != Color.DarkGray)
            {
                condicionBusqueda += $"d.cedula LIKE '%{txtCedula.Text}%'"; // Usar LIKE para coincidencia parcial
                bandera += 1;
            }

            if(!string.IsNullOrWhiteSpace(txtApellidos.Text) && txtApellidos.Text != placeholderApellidos && txtApellidos.ForeColor != Color.DarkGray)
            {
                if (bandera > 0)
                {
                    condicionBusqueda += " AND ";
                }
                condicionBusqueda += $"d.apellidos LIKE '%{txtApellidos.Text}%'"; // Usar LIKE para coincidencia parcial
                bandera += 1;
            }

            if (!string.IsNullOrWhiteSpace(txtNombres.Text) && txtNombres.Text != placeholderNombres && txtNombres.ForeColor != Color.DarkGray)
            {
                if (bandera > 0)
                {
                    condicionBusqueda += " AND ";
                }
                condicionBusqueda += $"d.nombres LIKE '%{txtNombres.Text}%'"; // Usar LIKE para coincidencia parcial
                bandera += 1;
            }

            // Aquí se llamaría al método de búsqueda con la condición construida
            var resultados = puente.BuscarParticipacionesDeportista(condicionBusqueda);

            if (resultados == null || resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para los criterios de búsqueda proporcionados.",
                                "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = resultados;
        }



        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            _frmprincipal.AbrirFormularioEnPanel(new FrmFiltrar());
        }
    }
}
