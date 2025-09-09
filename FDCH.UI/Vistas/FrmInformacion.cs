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
//
using System.Diagnostics;
using System.IO; // Necesario para Path

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Define el nombre de tu archivo PDF
            string nombreArchivoPdf = "ManualUsuario.pdf";

            // Obtiene la ruta del directorio donde se encuentra el ejecutable de tu aplicación
            // Esto es crucial para las rutas relativas.
            string rutaDirectorioApp = AppDomain.CurrentDomain.BaseDirectory;

            // Combina la ruta base, la subcarpeta y el nombre del archivo.
            string rutaCompletaPdf = Path.Combine(rutaDirectorioApp, "Archivos", nombreArchivoPdf);

            // Verifica si el archivo existe antes de intentar abrirlo
            if (File.Exists(rutaCompletaPdf))
            {
                try
                {
                    // Abre el archivo PDF usando el programa predeterminado del sistema
                    Process.Start(rutaCompletaPdf);
                }
                catch (Exception ex)
                {
                    // Maneja cualquier error que pueda ocurrir al intentar abrir el archivo
                    MessageBox.Show($"Error al intentar abrir el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"El archivo PDF '{nombreArchivoPdf}' no se encontró en la ruta esperada: '{rutaCompletaPdf}'", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
