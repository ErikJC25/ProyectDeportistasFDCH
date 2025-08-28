using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmAddTorneo : Form
    {
        Cls_Puente puente = new Cls_Puente();
        FrmPrincipal _frmprincipal;

        public FrmAddTorneo(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
        }

        private void FrmAddTorneo_Load(object sender, EventArgs e)
        {

        }


        private void txtLugar_Enter_1(object sender, EventArgs e)
        {
            if(txtLugar.Text == "RIOBAMBA" && txtLugar.ForeColor == Color.DarkGray)
            {
                txtLugar.Text = "";
                txtLugar.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "TORNEO CANTO..." && txtNombre.ForeColor == Color.DarkGray)
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtTipo_Enter(object sender, EventArgs e)
        {
            if (txtTipo.Text == "OFICIAL" && txtTipo.ForeColor == Color.DarkGray)
            {
                txtTipo.Text = "";
                txtTipo.ForeColor = Color.Black;
            }
        }

        private void txtNivel_Enter(object sender, EventArgs e)
        {
            if (txtNivel.Text == "REGIONAL, CANTONAL, ..." && txtNivel.ForeColor == Color.DarkGray)
            {
                txtNivel.Text = "";
                txtNivel.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "TORNEO CANTO...";
                txtNombre.ForeColor = Color.DarkGray;
            }
        }

        private void txtLugar_Leave(object sender, EventArgs e)
        {
            if (txtLugar.Text == "")
            {
                txtLugar.Text = "RIOBAMBA";
                txtLugar.ForeColor = Color.DarkGray;
            }
        }

        private void txtTipo_Leave(object sender, EventArgs e)
        {
            if (txtTipo.Text == "")
            {
                txtTipo.Text = "OFICIAL";
                txtTipo.ForeColor = Color.DarkGray;
            }
        }

        private void txtNivel_Leave(object sender, EventArgs e)
        {
            if (txtNivel.Text == "")
            {
                txtNivel.Text = "REGIONAL, CANTONAL, ...";
                txtNivel.ForeColor = Color.DarkGray;
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Definición de placeholders actuales
            string placeholderNombre = "TORNEO CANTO...";
            string placeholderFechaIncio = "04/08/2025";
            string placeholderFechaFin = "29/08/2025";

            // --- 1. Validación de nombre (obligatorio) ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == placeholderNombre && txtNombre.ForeColor == Color.DarkGray)
            {
                MessageBox.Show("El campo 'Nombre del torneo' es obligatorio.", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // --- 2. Validar y convertir fechas si se ingresaron
            DateTime fechaInicioDT = DateTime.MinValue;
            DateTime fechaFinDT = DateTime.MinValue;

            // Validar la fecha de inicio si el campo no está vacío
            if (!string.IsNullOrWhiteSpace(txtFechaInicio.Text) && txtFechaInicio.Text != placeholderFechaIncio && txtFechaInicio.ForeColor != Color.DarkGray)
            {
                if (!DateTime.TryParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicioDT))
                {
                    MessageBox.Show("El formato de la fecha de inicio es incorrecto. Use dd/MM/yyyy.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaInicio.Focus();
                    return;
                }
            }

            // Validar la fecha de fin si el campo no está vacío
            if (!string.IsNullOrWhiteSpace(txtFechaFin.Text) && txtFechaFin.Text != placeholderFechaFin && txtFechaFin.ForeColor != Color.DarkGray)
            {
                if (!DateTime.TryParseExact(txtFechaFin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinDT))
                {
                    MessageBox.Show("El formato de la fecha de fin es incorrecto. Use dd/MM/yyyy.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaFin.Focus();
                    return;
                }
            }


            // Preguntar si esta seguro de agregar el torneo
            var confirmResult = MessageBox.Show("¿Está seguro de agregar este torneo?", "Confirmar Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return; // Si el usuario selecciona "No", se detiene el proceso
            }



            // --- 3. Validación de lógica de fechas (si ambas son válidas) ---
            // Solo se valida si ambas fechas tienen un valor real
            if (fechaInicioDT != DateTime.MinValue && fechaFinDT != DateTime.MinValue)
            {
                if (fechaInicioDT > fechaFinDT)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Fechas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaInicio.Focus();
                    return;
                }
            }

            // Crear el objeto Evento
            Evento evento = new Evento
            {
                nombre_evento = txtNombre.Text.Trim(),
                lugar = (txtLugar.Text == "RIOBAMBA" && txtLugar.ForeColor == Color.DarkGray) ? "" : txtLugar.Text.Trim(),
                // Guardar las fechas como STRING, tal como lo solicitaste
                fecha_inicio = (txtFechaInicio.Text == placeholderFechaIncio && txtFechaInicio.ForeColor == Color.DarkGray) ? "" : txtFechaInicio.Text.Trim(),
                fecha_fin = (txtFechaFin.Text == placeholderFechaFin && txtFechaFin.ForeColor == Color.DarkGray) ? "" : txtFechaFin.Text.Trim(),
                tipo_evento = (txtTipo.Text == "OFICIAL" && txtTipo.ForeColor == Color.DarkGray) ? "" : txtTipo.Text.Trim(),
                nivel_evento = (txtNivel.Text == "REGIONAL, CANTONAL, ..." && txtNivel.ForeColor == Color.DarkGray) ? "" : txtNivel.Text.Trim()
            };

            int resultado = puente.InsertarEvento(evento);

            if (resultado > 0)
            {
                MessageBox.Show("Torneo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _frmprincipal.AbrirFormularioEnPanel(new FrmAddDeportista(resultado, _frmprincipal));
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el torneo. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFechInicio_Enter(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text == "04/08/2025" && txtFechaInicio.ForeColor == Color.DarkGray)
            {
                txtFechaInicio.Text = "";
                txtFechaInicio.ForeColor = Color.Black;
            }

        }

        private void txtFechaInicio_Leave(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text == "")
            {
                txtFechaInicio.Text = "04/08/2025";
                txtFechaInicio.ForeColor = Color.DarkGray;
            }
        }

        private void txtFechaFin_Enter(object sender, EventArgs e)
        {
            if (txtFechaFin.Text == "29/08/2025" && txtFechaFin.ForeColor == Color.DarkGray)
            {
                txtFechaFin.Text = "";
                txtFechaFin.ForeColor = Color.Black;
            }
        }

        private void txtFechaFin_Leave(object sender, EventArgs e)
        {
            if (txtFechaFin.Text == "")
            {
                txtFechaFin.Text = "29/08/2025";
                txtFechaFin.ForeColor = Color.DarkGray;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtFechaInicio.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtFechaFin.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtLugar.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtTipo.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                txtNivel.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter si no es letra, control o espacio
            }

            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Llama al método que maneja el clic del botón
                btnAgregar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }
    }
}
