using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDCH.Entidades;
using FDCH.Logica;

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
            try
            {
                // Placeholders actuales
                string placeholderNombre = "Torneo Canto...";
                string placeholderLugar = "Riobamba";
                string placeholderTipo = "Oficial";
                string placeholderNivel = "Regional, Cantonal, ...";

                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == placeholderNombre)
                {
                    MessageBox.Show("Ingrese el nombre del torneo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtLugar.Text) || txtLugar.Text == placeholderLugar)
                {
                    MessageBox.Show("Ingrese el lugar del torneo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLugar.Focus();
                    return;
                }
                if (dtpInicio.Value.Date > dtpFin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpInicio.Focus();
                    return;
                }

                // Crear el objeto Evento
                Evento evento = new Evento
                {
                    nombre_evento = txtNombre.Text,
                    lugar = txtLugar.Text,
                    fecha_inicio = dtpInicio.Value.Date,
                    fecha_fin = dtpFin.Value.Date,
                    tipo_evento = (txtTipo.Text == placeholderTipo) ? "" : txtTipo.Text,
                    nivel_evento = (txtNivel.Text == placeholderNivel) ? "" : txtNivel.Text
                };

                int resultado = puente.InsertarEvento(evento);

                if (resultado > 0)
                {
                    MessageBox.Show("Torneo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Abre el nuevo formulario y cierra el actual
                    EventoAgregado?.Invoke(resultado); // Notifica al principal
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el torneo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el torneo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
