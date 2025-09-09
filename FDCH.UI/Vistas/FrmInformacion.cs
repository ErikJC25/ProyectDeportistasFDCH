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
    public partial class FrmInformacion : Form
    {
        FrmPrincipal _frmPrincipal;
        
        public FrmInformacion(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmPrincipal = principal;
        }
    }
}
