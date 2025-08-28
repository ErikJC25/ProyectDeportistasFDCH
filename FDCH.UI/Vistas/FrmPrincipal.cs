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
    public partial class FrmPrincipal : Form
    {
        Usuario _usuarioAutenticado;
        Form formularioActivo = null; // Referencia al form actual

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioAutenticado = usuario;
            lblUsuarioActivo.Text = "Conectado como: " + _usuarioAutenticado.nombre_usuario;

            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInicio(this));
        }

        public void AbrirFormularioEnPanel(Form formulario)
        {
            // Cierra el formulario actual si existe y no es el mismo que se va a abrir
            if (formularioActivo != null && formularioActivo.GetType() != formulario.GetType())
            {
                formularioActivo.Dispose();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlContenedorFrm.Controls.Clear();
            pnlContenedorFrm.Controls.Add(formulario);


            formulario.Show();
        }



        private void btnInicio_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            AbrirFormularioEnPanel(new FrmInicio(this));
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnBusqueda.Height;
            pnlOpcion.Top = btnBusqueda.Top;
            AbrirFormularioEnPanel(new FrmBusqueda(this));
        }

        
        private void btnAddTorneo_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnAddTorneo.Height;
            pnlOpcion.Top = btnAddTorneo.Top;
            AbrirFormularioEnPanel(new FrmAddTorneo(this));
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "¿Está seguro/a que desea salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnAddParticipa_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnAddParticipa.Height;
            pnlOpcion.Top = btnAddParticipa.Top;
            AbrirFormularioEnPanel(new FrmAddDeportista(this));
        }
    }
}
