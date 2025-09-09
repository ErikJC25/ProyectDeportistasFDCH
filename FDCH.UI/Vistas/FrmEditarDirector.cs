using FDCH.Logica;
using FDCH.Entidades;
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
    public partial class FrmEditarDirector : Form
    {
        Cls_Puente _puente = new Cls_Puente();
        FrmPrincipal _frmprincipal;
        Director _director;
        public FrmEditarDirector(FrmPrincipal principal)
        {
            InitializeComponent();

            _frmprincipal = principal;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preguntar si esta seguro de agregar el torneo
            var confirmResult = MessageBox.Show("¿Está seguro de guardar estos cambios?", "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return; // Si el usuario selecciona "No", se detiene el proceso
            }

            try
            {
                _director.titulo = txbTituloNuevo.Text?.Trim();
                _director.rol = txbRolNuevo.Text?.Trim();

                bool ok = _puente.ActualizarDirector(_director);
                if (ok)
                {
                    MessageBox.Show("Director actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    _frmprincipal.AbrirFormularioEnPanel(new FrmInicio(_frmprincipal));
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el director.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEditarDirector_Load(object sender, EventArgs e)
        {

            try
            {
                _director = _puente.ObtenerDirector() ?? new Director(); // si no existe, nuevo objeto
                txbTituloActual.Text = _director.titulo ?? "";
                txbRolActual.Text = _director.rol ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos del director: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmprincipal.AbrirFormularioEnPanel(new FrmInicio(_frmprincipal));
        }
    }
}
