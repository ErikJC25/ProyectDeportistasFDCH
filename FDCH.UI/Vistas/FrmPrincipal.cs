using FDCH.Datos;
using FDCH.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FDCH.UI.DriveServiceHelper;

namespace FDCH.UI.Vistas
{
    public partial class FrmPrincipal : Form
    {
        // Carpeta principal de respaldos
        private readonly string folderLock = "1xa2g-odHTRsxcfIHvFAIp0CO2__ep-s7";

        // Carpeta de respaldos automáticos por tiempo
        private readonly string folderRespaldoPorTiempo = "1n9nClQJDUljOIZoo-e6z2earBzHYsTPr";

        Usuario _usuarioAutenticado;
        Form formularioActivo = null; // Referencia al form actual

        public bool bloqueoActivo = false;

        //Este va a servir para el boton de gestionar entidades
        FrmPrincipal _frmprincipal;

        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioAutenticado = usuario;
            lblUsuarioActivo.Text = "Conectado como: " + _usuarioAutenticado.nombre_usuario;

            pnlOpcion.Height = btnInicio.Height;
            pnlOpcion.Top = btnInicio.Top;

            if (_usuarioAutenticado.rol == "consultor")
            {
                btnAddTorneo.Visible = false;
                btnAddParticipa.Visible = false;
                btnupdateDrive.Visible = true;
                btnGetBloqueo.Visible = false;
                btnGestionarEntidades.Visible = false;
            }

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInicio(this));

            respaldoTimer = new System.Windows.Forms.Timer();
            respaldoTimer.Interval = 600000; // 1 hora en milisegundos
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



        private async void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Muestra el cuadro de diálogo de confirmación de salida
            var result = MessageBox.Show(
                "¿Está seguro/a que desea salir de la aplicación? Se liberará su bloqueo activo si lo tiene.",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela el cierre del formulario
                return;
            }

            // Si el usuario confirma la salida
            if (bloqueoActivo)
            {
                // Cancelar el cierre temporalmente para realizar la operación asíncrona
                e.Cancel = true;

                // Ejecuta la liberación del bloqueo
                await LiberarBloqueo();

                // Muestra un mensaje al usuario
                MessageBox.Show("Se ha liberado el bloqueo antes de salir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ahora sí, cierra la aplicación
                Application.Exit();
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
                // 1️⃣ Verificar si el usuario actual tiene el lock
                bool tieneLock = await DriveServiceHelper.CheckLock(_usuarioAutenticado.nombre_usuario, folderLock);

                if (!tieneLock)
                {
                    MessageBox.Show("❌ No tienes el bloqueo activo. Solicítalo primero antes de subir.");
                    return;
                }

                // 2️⃣ Preparar la BD para subir
                string dbPath = DbService.GetDbPath();

                SQLiteConnection.ClearAllPools();
                DbService.ForzarReconectar();

                string tempPath = Path.Combine(Path.GetDirectoryName(dbPath), "BDCompetencias_temp.db");
                File.Copy(dbPath, tempPath, true);

                // 3️⃣ Subir al Drive en la carpeta de respaldo principal
                string fileId = await DriveServiceHelper.UploadFile(tempPath, folderLock);

                File.Delete(tempPath);

                MessageBox.Show($"✅ Archivo subido con éxito. ID: {fileId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al subir la BD: {ex.Message}");
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

        private async void btnGetBloqueo_Click(object sender, EventArgs e)
        {
            if (bloqueoActivo)
            {
                await LiberarBloqueo();
                AbrirFormularioEnPanel(new FrmInicio(this));
                MessageBox.Show("🔓 Bloqueo liberado. Ya no puede editar registros ni subir la base de datos.");
                return;
            }

            // Intentar obtener bloqueo
            var lockResult = await DriveServiceHelper.TryLock(_usuarioAutenticado.nombre_usuario, folderLock);

            switch (lockResult)
            {
                case LockResult.AlreadyLocked:
                    MessageBox.Show("❌ Otro usuario ya tiene el bloqueo activo.");
                    return;

                case LockResult.Released:
                    MessageBox.Show("🔓 Ya tenía el bloqueo, pero fue liberado.");
                    bloqueoActivo = false;
                    lblEstado.Text = "Sin Bloqueo";
                    lblEstado.ForeColor = Color.Red;
                    btnGetBloqueo.BackColor = Color.Red;
                    btnGetBloqueo.Text = "Obtener Bloqueo";
                    btnGetBloqueo.Image = FDCH.UI.Properties.Resources.desbloqueado;
                    return;

                case LockResult.Granted:
                    MessageBox.Show("🔒 Bloqueo obtenido correctamente. Ahora puede editar registros y subir su base de datos a la nube.");

                    // Habilitar funcionalidad
                    btnAddTorneo.Enabled = true;
                    btnAddParticipa.Enabled = true;
                    btnGestionarEntidades.Enabled = true;
                    btnupdateDrive.Enabled = true;
                    btnupdateDrive.BackColor = Color.MediumSpringGreen;

                    // Actualizar el estado de la UI
                    bloqueoActivo = true;
                    lblEstado.Text = "Bloqueo Activo";
                    lblEstado.ForeColor = Color.SpringGreen;
                    btnGetBloqueo.BackColor = Color.SpringGreen;
                    btnGetBloqueo.Text = "Liberar Bloqueo";
                    btnGetBloqueo.Image = FDCH.UI.Properties.Resources.bloqueado;

                    AbrirFormularioEnPanel(new FrmInicio(this));
                    break;
            }
        }

        public async Task LiberarBloqueo()
        {
            // Llama a TryLock para liberar el bloqueo, ya que si el usuario es el mismo, libera el bloqueo y retorna false
            await DriveServiceHelper.TryLock(_usuarioAutenticado.nombre_usuario, folderLock);

            // Revertir la interfaz de usuario a su estado inicial
            btnAddTorneo.Enabled = false;
            btnAddParticipa.Enabled = false;
            btnGestionarEntidades.Enabled = false;
            btnupdateDrive.Enabled = false;
            btnupdateDrive.BackColor = Color.Navy;

            bloqueoActivo = false;
            lblEstado.Text = "Bloqueo Inactivo";
            lblEstado.ForeColor = Color.Red;
            btnGetBloqueo.BackColor = Color.Crimson;
            btnGetBloqueo.Text = "Obtener Bloqueo";
            btnGetBloqueo.Image = FDCH.UI.Properties.Resources.desbloqueado;

            
        }

        private void btnGestionarEntidades_Click(object sender, EventArgs e)
        {
            // Opciones personalizadas
            string[] opciones = new string[] { "Gestionar Deportistas", "Gestionar Técnicos", "Gestionar Disciplinas y Especialidades" };

            // Personalización de botones (opcional)
            Action<Button, int> customizer = (btn, idx) =>
            {
                if (idx == 0)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                else if (idx == 1)
                {
                    btn.BackColor = Color.Blue;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                else if (idx == 2)
                {
                    btn.BackColor = Color.Orange;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                }

                var t = new ToolTip();
                t.SetToolTip(btn, $"Abrir: {btn.Text}");
            };

            using (var dlg = new FrmSeleccionEditor("Gestión de Entidades", "Seleccione la entidad a gestionar", opciones, customizer))
            {
                var r = dlg.ShowDialog(this);
                if (r == DialogResult.OK)
                {
                    if (dlg.SelectedIndex == 0)
                    {
                        _frmprincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmprincipal));
                        this.Close();
                    }
                    else if (dlg.SelectedIndex == 1)
                    {
                        _frmprincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmprincipal));
                        this.Close();
                    }
                    else if (dlg.SelectedIndex == 2)
                    {
                        _frmprincipal.AbrirFormularioEnPanel(new FrmGestionarDeportistas(_frmprincipal));
                        this.Close();
                    }
                }
                else
                {
                    // Cancel: no hacer nada
                }
            }
        }
    }
}
