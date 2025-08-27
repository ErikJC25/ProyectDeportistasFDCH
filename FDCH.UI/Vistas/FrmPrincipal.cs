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
            AbrirFormularioEnPanel(new FrmInicio());

            this.FormClosing += FrmPrincipal_FormClosing;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioEnPanel(Form formulario)
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

            // Suscribir al evento FormClosed para abrir FrmInicio al cerrar el formulario hijo
            formulario.FormClosed += FormularioHijoCerrado;

            // Lógica de suscripción a eventos específicos de formularios
            if (formulario is FrmInicio frmInicio)
            {
                frmInicio.EventoPerfil += idDeportista =>
                {
                    AbrirFormularioEnPanel(new FrmHistorialDeportista(idDeportista));
                };

                frmInicio.EventoEditar += registroCompleto =>
                {
                    AbrirFormularioEnPanel(new FrmEditarRegistro(registroCompleto));
                };
            }
            else if (formulario is FrmAddTorneo frmAddTorneo)
            {
                frmAddTorneo.EventoAgregado += idNuevo =>
                {
                    // Abrir FrmAddDeportista desde FrmAddTorneo
                    AbrirFormularioEnPanel(new FrmAddDeportista(idNuevo));
                };
            }

            formulario.Show();
        }


        private void FormularioHijoCerrado(object sender, FormClosedEventArgs e)
        {
            // Remover la suscripción al evento para evitar fugas de memoria
            Form formularioCerrado = sender as Form;
            if (formularioCerrado != null)
            {
                formularioCerrado.FormClosed -= FormularioHijoCerrado;
            }

            // Abrir FrmInicio de nuevo en el panel principal
            AbrirFormularioEnPanel(new FrmInicio());
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
            AbrirFormularioEnPanel(new FrmAddTorneo());
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
            AbrirFormularioEnPanel(new FrmAddDeportista());
        }
    }
}
