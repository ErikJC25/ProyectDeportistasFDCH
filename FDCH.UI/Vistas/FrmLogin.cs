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
using FDCH.Logica;

namespace FDCH.UI.Vistas
{
    public partial class FrmLogin : Form
    {
        Cls_Puente objPuente = new Cls_Puente();

        public FrmLogin()
        {
            InitializeComponent();
            // Por defecto, la contraseña se muestra con asteriscos
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false; // Oculta el mensaje al iniciar el proceso de autenticación
            lblMensaje.Text = string.Empty; // Limpia el mensaje previo

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                lblMensaje.Text = "Por favor, ingrese su usuario y contraseña.";
                lblMensaje.ForeColor = Color.Yellow;
                lblMensaje.Visible = true;
                return;
            }

            Usuario usuarioAutenticado = objPuente.AutenticarUsuario(txtUsuario.Text, txtContrasena.Text);

            if (usuarioAutenticado != null)
            {
                lblMensaje.Text = "Autenticación exitosa. Cargando...";
                lblMensaje.ForeColor = Color.Lime;
                lblMensaje.Visible = true;
                // Permite que el usuario vea el mensaje antes de continuar
                Application.DoEvents();
                System.Threading.Thread.Sleep(800);

                this.Hide();
                FrmPrincipal objPrincipal = new FrmPrincipal(/*usuarioAutenticado*/);
                objPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos. Inténtelo de nuevo.";
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Visible = true;
            }
        }

        private void chBoxMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado, muestra la contraseña en texto plano
            // Si no, la muestra con asteriscos
            txtContrasena.UseSystemPasswordChar = !chBoxMostrarPassword.Checked;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón de Iniciar Sesión
                txtContrasena.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón de Iniciar Sesión
                btnIniciarSesion_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
