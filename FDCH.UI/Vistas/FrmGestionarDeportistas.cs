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
        //Se instancia la capa lógica
        private readonly Cls_Puente _puente = new Cls_Puente();
        // referencia opcional al frm principal (si se pasa)
        private readonly FrmPrincipal _frmprincipal;
        public FrmGestionarDeportistas(FrmPrincipal parent = null)
        {
            InitializeComponent();

            // Guardar la referencia si se pasó (si no, queda null y usaremos fallback)
            _frmprincipal = parent;
        }
    }
}
