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
    public partial class FrmAuditoria : Form
    {
        Cls_Puente puente = new Cls_Puente(); // Instancia de Cls_Puente
        FrmPrincipal _frmprincipal;

        public FrmAuditoria(FrmPrincipal principal)
        {
            InitializeComponent();
            _frmprincipal = principal;
            dataGridView1.AutoGenerateColumns = false;
            CargarDatos();
        }

        public void CargarDatos()
        {
            var listaHistorial = puente.ObtenerHistorialParaVista();
            dataGridView1.DataSource = listaHistorial;
    }
}
