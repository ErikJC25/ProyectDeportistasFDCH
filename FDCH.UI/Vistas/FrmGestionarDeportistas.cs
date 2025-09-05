using FDCH.Logica;
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
    public partial class FrmGestionarDeportistas : Form
    {
        Cls_Puente puente = new Cls_Puente();
        FrmPrincipal _frmprincipal;
        public FrmGestionarDeportistas(FrmPrincipal principal)
        {
            InitializeComponent();

            // Guardar la referencia si se pasó (si no, queda null y usaremos fallback)
            _frmprincipal = principal;
        }
    }
}
