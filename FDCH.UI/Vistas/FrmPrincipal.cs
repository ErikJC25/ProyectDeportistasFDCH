using FDCH.Datos;
using FDCH.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FDCH.UI.Vistas
{
    public partial class FrmPrincipal : Form
    {
        // Carpeta principal de respaldos
        private readonly string folderRespaldo = "1xa2g-odHTRsxcfIHvFAIp0CO2__ep-s7";

        // Carpeta de respaldos automáticos por tiempo
        private readonly string folderRespaldoPorTiempo = "1n9nClQJDUljOIZoo-e6z2earBzHYsTPr";

        Usuario _usuarioAutenticado;
        Form formularioActivo = null; // Referencia al form actual

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioAutenticado = usuario;
            lblUsuarioActivo.Text = "Conectado como: " + _usuarioAutenticado.nombre_usuario;

            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInicio(this));

            respaldoTimer = new System.Windows.Forms.Timer();
            respaldoTimer.Interval = 150000; // 1 hora en milisegundos
            respaldoTimer.Tick += async (s, ev) => await HacerRespaldoAutomatico();
            respaldoTimer.Start();
        }

        public void AbrirFormularioEnPanel(Form formulario)
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


            formulario.Show();
        }



        private void btnInicio_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;
            AbrirFormularioEnPanel(new FrmInicio(this));
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnBusqueda.Height;
            pnlOpcion.Top = btnBusqueda.Top;
            AbrirFormularioEnPanel(new FrmBusqueda(this));
        }

        
        private void btnAddTorneo_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnAddTorneo.Height;
            pnlOpcion.Top = btnAddTorneo.Top;
            AbrirFormularioEnPanel(new FrmAddTorneo(this));
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
                return;
            }

            
        }


        private void btnAddParticipa_Click(object sender, EventArgs e)
        {
            pnlOpcion.Height = btnAddParticipa.Height;
            pnlOpcion.Top = btnAddParticipa.Top;
            AbrirFormularioEnPanel(new FrmAddDeportista(this));
        }

        private async void btnActualizarbase_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FDCH.Datos\Archivos\BDCompetencias.db")
                );

                SQLiteConnection.ClearAllPools();
                DbService.ForzarReconectar();

                string lastFileId = DriveServiceHelper.GetLastFileId();
                if (!string.IsNullOrEmpty(lastFileId))
                {
                    await DriveServiceHelper.DownloadFile(lastFileId, dbPath);

                    if (formularioActivo != null)
                    {
                        formularioActivo.Dispose();
                        AbrirFormularioEnPanel(new FrmInicio(this));
                    }

                    MessageBox.Show("Base de datos actualizada desde Drive. Conexiones reiniciadas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar BD: {ex.Message}");
            }
        }

        private async void btnupdateDrive_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Usamos DbService.DbPath
                string dbPath = DbService.GetDbPath();

                SQLiteConnection.ClearAllPools();
                DbService.ForzarReconectar();

                // Copiar a archivo temporal para evitar bloqueos
                string tempPath = Path.Combine(Path.GetDirectoryName(dbPath), "BDCompetencias_temp.db");
                File.Copy(dbPath, tempPath, true);

                string fileId = await DriveServiceHelper.UploadFile(dbPath, null);


                File.Delete(tempPath);

                MessageBox.Show($"Archivo subido con éxito. ID: {fileId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }

        private System.Windows.Forms.Timer respaldoTimer;

        

        private async Task HacerRespaldoAutomatico()
        {
            try
            {
                string dbPath = DbService.GetDbPath();
                string tempPath = Path.Combine(Path.GetDirectoryName(dbPath), "BDCompetencias_temp.db");

                // Copiar a archivo temporal para evitar bloqueos
                SQLiteConnection.ClearAllPools();
                DbService.ForzarReconectar();
                File.Copy(dbPath, tempPath, true);

                // Subir al Drive en la carpeta de respaldo por tiempo
                string fileId = await DriveServiceHelper.UploadFile(tempPath, folderRespaldoPorTiempo);

                // Eliminar temporal
                File.Delete(tempPath);

                // Eliminar respaldos viejos de 7 días
                DriveServiceHelper.DeleteOldBackups(folderRespaldoPorTiempo, 7);

                Console.WriteLine($"[Respaldo automático] Subido correctamente. ID: {fileId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en respaldo automático: {ex.Message}");
            }
        }

        

    }
}
