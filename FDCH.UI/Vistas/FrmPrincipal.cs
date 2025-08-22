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

        public FrmPrincipal(/*Usuario usuario*/)
        {
            InitializeComponent();
            //_usuarioAutenticado = usuario;
            //lblUsuarioActivo.Text = "Conectado como: " + _usuarioAutenticado.nombre_usuario;

            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            AbrirFormularioEnPanel(new FrmInicio());

            this.FormClosing += FrmPrincipal_FormClosing;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            // Cierra el formulario actual si existe
            if (formularioActivo != null)
            {
                // No es necesario llamar a Close() si solo se va a limpiar el panel
                formularioActivo.Dispose();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlContenedorFrm.Controls.Clear();
            pnlContenedorFrm.Controls.Add(formulario);

            // Si el formulario que se abre es FrmInicio, suscribe los eventos
            if (formulario is FrmInicio)
            {
                var frmInicio = (FrmInicio)formulario;
                frmInicio.EventoPerfil += idDeportista =>
                {
                    AbrirFormularioEnPanel(new FrmHistorialDeportista(idDeportista));
                };

                frmInicio.EventoEditar += registroCompleto =>
                {
                    AbrirFormularioEnPanel(new FrmEditarRegistro(registroCompleto));
                };
            }
            formulario.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            AbrirFormularioEnPanel(new FrmInicio());
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnBusqueda.Height;
            pnlOpcion.Top = btnBusqueda.Top;
            // Abrir el formulario correspondiente a búsqueda
            // AbrirFormularioEnPanel(new FrmBusqueda());
        }

        
        private void btnAddTorneo_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnAddTorneo.Height;
            pnlOpcion.Top = btnAddTorneo.Top;
            var frmAddTorneo = new FrmAddTorneo();
            frmAddTorneo.EventoAgregado += idNuevo =>
            {
                AbrirFormularioEnPanel(new FrmAddDeportista(idNuevo));
            };
            AbrirFormularioEnPanel(frmAddTorneo);
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
            pnlOpcion.Height = btnAddTorneo.Height;
            pnlOpcion.Top = btnAddTorneo.Top;
            // Abrir el formulario correspondiente a agregar torneo
            // AbrirFormularioEnPanel(new FrmAddTorneo());
        }
    }
}
