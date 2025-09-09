using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
            CargarFuncionesPersonales();
        }

        public void CargarFuncionesPersonales()
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.AppendText("Creación de prototipos de alta fidelidad." + Environment.NewLine);
            richTextBox1.AppendText("Gestión y conexión de la base de datos local." + Environment.NewLine);
            richTextBox1.AppendText("Sincronización de la base de datos en la nube (Google Drive)." + Environment.NewLine);
            richTextBox1.AppendText("Generación del archivo ejecutable de la aplicación.");
            richTextBox1.SelectionBullet = false;

            richTextBox2.SelectionBullet = true;
            richTextBox2.AppendText("Planificación y distribución de tareas del equipo." + Environment.NewLine);
            richTextBox2.AppendText("Definición de la estructura del proyecto." + Environment.NewLine);
            richTextBox2.AppendText("Desarrollo de diversos formularios." + Environment.NewLine);
            richTextBox2.AppendText("Construcción de la base de datos (migracion de datos desde excel).");
            richTextBox2.SelectionBullet = false;

            richTextBox3.SelectionBullet = true;
            richTextBox3.AppendText("Desarrollo de los formularios principales y flujo de navegación." + Environment.NewLine);
            richTextBox3.AppendText("Programación del código backend para los formularios." + Environment.NewLine);
            richTextBox3.AppendText("Estructuración de clases, entidades y métodos para la interacción con la base de datos." + Environment.NewLine);
            richTextBox3.AppendText("Implementación de diseños adaptables a diferentes resoluciones de pantalla (diseño UI).");
            richTextBox3.SelectionBullet = false;

        }

    }
}
