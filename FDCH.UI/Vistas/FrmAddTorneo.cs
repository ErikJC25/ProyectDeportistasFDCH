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
        public FrmAddTorneo()
        {
            InitializeComponent();
        }

        private void FrmAddTorneo_Load(object sender, EventArgs e)
        {

        }


        private void txtLugar_Enter_1(object sender, EventArgs e)
        {
            if(txtLugar.Text == "Riobamba")
            {
                txtLugar.Text = "";
                txtLugar.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Torneo Canto...")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtTipo_Enter(object sender, EventArgs e)
        {
            if (txtTipo.Text == "Oficial")
            {
                txtTipo.Text = "";
                txtTipo.ForeColor = Color.Black;
            }
        }

        private void txtNivel_Enter(object sender, EventArgs e)
        {
            if (txtNivel.Text == "Regional, Cantonal, ...")
            {
                txtNivel.Text = "";
                txtNivel.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Torneo Canto...";
                txtNombre.ForeColor = Color.DarkGray;
            }
        }

        private void txtLugar_Leave(object sender, EventArgs e)
        {
            if (txtLugar.Text == "")
            {
                txtLugar.Text = "Riobamba";
                txtLugar.ForeColor = Color.DarkGray;
            }
        }

        private void txtTipo_Leave(object sender, EventArgs e)
        {
            if (txtTipo.Text == "")
            {
                txtTipo.Text = "Oficial";
                txtTipo.ForeColor = Color.DarkGray;
            }
        }

        private void txtNivel_Leave(object sender, EventArgs e)
        {
            if (txtNivel.Text == "")
            {
                txtNivel.Text = "Regional, Cantonal, ...";
                txtNivel.ForeColor = Color.DarkGray;
            }
        }

        Cls_Puente puente = new Cls_Puente();
        public event Action<int> EventoAgregado;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Definición de placeholders actuales
            string placeholderNombre = "Torneo Canto...";
            string placeholderLugar = "Riobamba";
            string placeholderTipo = "Oficial";
            string placeholderNivel = "Regional, Cantonal, ...";
            string placeholderFecha = "dd/MM/yyyy";

            // --- 1. Validación de nombre (obligatorio) ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == placeholderNombre)
            {
                MessageBox.Show("El campo 'Nombre del torneo' es obligatorio.", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // --- 2. Validación y conversión de fechas ---
            DateTime fechaInicio, fechaFin;
            bool fechaInicioValida = true, fechaFinValida = true;

            if (!string.IsNullOrWhiteSpace(txtFechaInicio.Text) && txtFechaInicio.Text != placeholderFecha)
            {
                if (!DateTime.TryParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio))
                {
                    MessageBox.Show("El formato de la fecha de inicio es incorrecto. Use dd/MM/yyyy.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaInicio.Focus();
                    fechaInicioValida = false;
                    return;
                }
            }
            else
            {
                fechaInicio = DateTime.MinValue; // Si no se ingresa, se asigna un valor por defecto
            }

            if (!string.IsNullOrWhiteSpace(txtFechaFin.Text) && txtFechaFin.Text != placeholderFecha)
            {
                if (!DateTime.TryParseExact(txtFechaFin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFin))
                {
                    MessageBox.Show("El formato de la fecha de fin es incorrecto. Use dd/MM/yyyy.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaFin.Focus();
                    fechaFinValida = false;
                    return;
                }
            }
            else
            {
                fechaFin = DateTime.MinValue;
            }

            // --- 3. Validación de lógica de fechas (si ambas son válidas) ---
            if (fechaInicioValida && fechaFinValida && fechaInicio != DateTime.MinValue && fechaFin != DateTime.MinValue)
            {
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Fechas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFechaInicio.Focus();
                    return;
                }
            }

            // Crear el objeto Evento con los datos validados
            Evento evento = new Evento
            {
                nombre_evento = txtNombre.Text.Trim(),
                lugar = (txtLugar.Text == placeholderLugar) ? "" : txtLugar.Text.Trim(),
                fecha_inicio = fechaInicio,
                fecha_fin = fechaFin,
                tipo_evento = (txtTipo.Text == placeholderTipo) ? "" : txtTipo.Text.Trim(),
                nivel_evento = (txtNivel.Text == placeholderNivel) ? "" : txtNivel.Text.Trim()
            };

            int resultado = puente.InsertarEvento(evento);

            if (resultado > 0)
            {
                MessageBox.Show("Torneo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EventoAgregado?.Invoke(resultado);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el torneo. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFechInicio_Enter(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text == "04/08/2025")
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
            if (txtFechaFin.Text == "29/08/2025")
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
    }
}
