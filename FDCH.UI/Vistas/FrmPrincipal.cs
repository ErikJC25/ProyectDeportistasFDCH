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
        private Usuario _usuarioAutenticado;

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioAutenticado = usuario;
            // Aquí puedes usar la información del usuario para personalizar la UI
            // Por ejemplo: lblUsuarioConectado.Text = "Conectado como: " + _usuarioAutenticado.NombreUsuario;
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
