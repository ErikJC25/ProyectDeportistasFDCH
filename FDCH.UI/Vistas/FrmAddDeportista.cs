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
    public partial class FrmAddDeportista : Form
    {
        public FrmAddDeportista(int idTorneo)
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void txtGenero_Enter(object sender, EventArgs e)
        {
            if(txtGenero.Text == "Masculino / Femenino")
            {
                txtGenero.Text = "";
                txtGenero.ForeColor = Color.Black;
            }
        }

        private void txtGenero_Leave(object sender, EventArgs e)
        {
            if (txtGenero.Text == "")
            {
                txtGenero.Text = "Masculino / Femenino";
                txtGenero.ForeColor = Color.DarkGray;
            }
        }

        private void txtDisciplina_Enter(object sender, EventArgs e)
        {
            if (txtDisciplina.Text == "Atletismo")
            {
                txtDisciplina.Text = "";
                txtDisciplina.ForeColor = Color.Black;
            }
        }

        private void txtDisciplina_Leave(object sender, EventArgs e)
        {
            if (txtDisciplina.Text == "")
            {
                txtDisciplina.Text = "Atletismo";
                txtDisciplina.ForeColor = Color.DarkGray;
            }
        }

        private void txtEspecialidad_Enter(object sender, EventArgs e)
        {
            if (txtEspecialidad.Text == "Arranque")
            {
                txtEspecialidad.Text = "";
                txtEspecialidad.ForeColor = Color.Black;
            }
        }

        private void txtEspecialidad_Leave(object sender, EventArgs e)
        {
            if (txtEspecialidad.Text == "")
            {
                txtEspecialidad.Text = "Arranque";
                txtEspecialidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtModalidad_Enter(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "Individual / Equipo")
            {
                txtModalidad.Text = "";
                txtModalidad.ForeColor = Color.Black;
            }
        }

        private void txtModalidad_Leave(object sender, EventArgs e)
        {
            if (txtModalidad.Text == "")
            {
                txtModalidad.Text = "Individual / Equipo";
                txtModalidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtCategoria_Enter(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "Sub21 / Menor...")
            {
                txtCategoria.Text = "";
                txtCategoria.ForeColor = Color.Black;
            }
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "")
            {
                txtCategoria.Text = "Sub21 / Menor...";
                txtCategoria.ForeColor = Color.DarkGray;
            }
        }

        private void txtDivision_Enter(object sender, EventArgs e)
        {
            if (txtDivision.Text == "55 kg")
            {
                txtDivision.Text = "";
                txtDivision.ForeColor = Color.Black;
            }
        }

        private void txtDivision_Leave(object sender, EventArgs e)
        {
            if (txtDivision.Text == "")
            {
                txtDivision.Text = "55 kg";
                txtDivision.ForeColor = Color.DarkGray;
            }
        }

        private void txtParticipantes_Enter(object sender, EventArgs e)
        {
            if (txtParticipantes.Text == "12")
            {
                txtParticipantes.Text = "";
                txtParticipantes.ForeColor = Color.Black;
            }
        }

        private void txtParticipantes_Leave(object sender, EventArgs e)
        {
            if (txtParticipantes.Text == "")
            {
                txtParticipantes.Text = "12";
                txtParticipantes.ForeColor = Color.DarkGray;
            }
        }

        private void txtRecord_Enter(object sender, EventArgs e)
        {
            if (txtRecord.Text == "10")
            {
                txtRecord.Text = "";
                txtRecord.ForeColor = Color.Black;
            }
        }

        private void txtRecord_Leave(object sender, EventArgs e)
        {
            if (txtRecord.Text == "")
            {
                txtRecord.Text = "10";
                txtRecord.ForeColor = Color.DarkGray;
            }
        }

        private void txtPuntos_Enter(object sender, EventArgs e)
        {
            if (txtPuntos.Text == "5")
            {
                txtPuntos.Text = "";
                txtPuntos.ForeColor = Color.Black;
            }
        }

        private void txtPuntos_Leave(object sender, EventArgs e)
        {
            if (txtPuntos.Text == "")
            {
                txtPuntos.Text = "5";
                txtPuntos.ForeColor = Color.DarkGray;
            }
        }

        private void txtMedalla_Enter(object sender, EventArgs e)
        {
            if (txtMedalla.Text == "Oro / Plata / Bronce")
            {
                txtMedalla.Text = "";
                txtMedalla.ForeColor = Color.Black;
            }
        }

        private void txtMedalla_Leave(object sender, EventArgs e)
        {
            if (txtMedalla.Text == "")
            {
                txtMedalla.Text = "Oro / Plata / Bronce";
                txtMedalla.ForeColor = Color.DarkGray;
            }
        }

        private void txtUbicacion_Enter(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == "3")
            {
                txtUbicacion.Text = "";
                txtUbicacion.ForeColor = Color.Black;
            }
        }

        private void txtUbicacion_Leave(object sender, EventArgs e)
        {
            if (txtUbicacion.Text == "")
            {
                txtUbicacion.Text = "3";
                txtUbicacion.ForeColor = Color.DarkGray;
            }
        }

        private void txtTimeMarca_Enter(object sender, EventArgs e)
        {
            if (txtTimeMarca.Text == "55 seg / 120 kg")
            {
                txtTimeMarca.Text = "";
                txtTimeMarca.ForeColor = Color.Black;
            }
        }

        private void txtTimeMarca_Leave(object sender, EventArgs e)
        {
            if (txtTimeMarca.Text == "")
            {
                txtTimeMarca.Text = "55 seg / 120 kg";
                txtTimeMarca.ForeColor = Color.DarkGray;
            }
        }

        private void txtTecnico_Enter(object sender, EventArgs e)
        {
            if (txtTecnico.Text == "Nombre Apellido")
            {
                txtTecnico.Text = "";
                txtTecnico.ForeColor = Color.Black;
            }
        }

        private void txtTecnico_Leave(object sender, EventArgs e)
        {
            if (txtTecnico.Text == "")
            {
                txtTecnico.Text = "Nombre Apellido";
                txtTecnico.ForeColor = Color.DarkGray;
            }
        }

        private void txtDiscapacidad_Enter(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "Ninguna")
            {
                txtDiscapacidad.Text = "";
                txtDiscapacidad.ForeColor = Color.Black;
            }
        }

        private void txtDiscapacidad_Leave(object sender, EventArgs e)
        {
            if (txtDiscapacidad.Text == "")
            {
                txtDiscapacidad.Text = "Ninguna";
                txtDiscapacidad.ForeColor = Color.DarkGray;
            }
        }
    }
}
