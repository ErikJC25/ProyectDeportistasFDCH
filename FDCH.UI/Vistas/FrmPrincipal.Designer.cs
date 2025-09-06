namespace FDCH.UI.Vistas
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnGestionarEntidades = new System.Windows.Forms.Button();
            this.btnupdateDrive = new System.Windows.Forms.Button();
            this.btnActualizarbase = new System.Windows.Forms.Button();
            this.btnGetBloqueo = new System.Windows.Forms.Button();
            this.btnAddParticipa = new System.Windows.Forms.Button();
            this.btnAddTorneo = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.pnlOpcion = new System.Windows.Forms.Panel();
            this.lblUsuarioActivo = new System.Windows.Forms.Label();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlContenedorFrm = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Navy;
            this.pnlMenu.Controls.Add(this.btnAuditoria);
            this.pnlMenu.Controls.Add(this.btnGestionarEntidades);
            this.pnlMenu.Controls.Add(this.btnupdateDrive);
            this.pnlMenu.Controls.Add(this.btnActualizarbase);
            this.pnlMenu.Controls.Add(this.btnGetBloqueo);
            this.pnlMenu.Controls.Add(this.btnAddParticipa);
            this.pnlMenu.Controls.Add(this.btnAddTorneo);
            this.pnlMenu.Controls.Add(this.btnBusqueda);
            this.pnlMenu.Controls.Add(this.pnlOpcion);
            this.pnlMenu.Controls.Add(this.lblUsuarioActivo);
            this.pnlMenu.Controls.Add(this.btnInicio);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(241, 762);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditoria.Enabled = false;
            this.btnAuditoria.FlatAppearance.BorderSize = 0;
            this.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditoria.ForeColor = System.Drawing.Color.White;
            this.btnAuditoria.Image = global::FDCH.UI.Properties.Resources.auditoria;
            this.btnAuditoria.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuditoria.Location = new System.Drawing.Point(0, 435);
            this.btnAuditoria.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(241, 65);
            this.btnAuditoria.TabIndex = 15;
            this.btnAuditoria.Text = "Historial\r\nCambios";
            this.btnAuditoria.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAuditoria.UseVisualStyleBackColor = true;
            this.btnAuditoria.Click += new System.EventHandler(this.btnAuditoria_Click);
            // 
            // btnGestionarEntidades
            // 
            this.btnGestionarEntidades.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGestionarEntidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarEntidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarEntidades.Enabled = false;
            this.btnGestionarEntidades.FlatAppearance.BorderSize = 0;
            this.btnGestionarEntidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarEntidades.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarEntidades.ForeColor = System.Drawing.Color.White;
            this.btnGestionarEntidades.Image = global::FDCH.UI.Properties.Resources.gestionar_entidades;
            this.btnGestionarEntidades.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestionarEntidades.Location = new System.Drawing.Point(0, 370);
            this.btnGestionarEntidades.Margin = new System.Windows.Forms.Padding(2);
            this.btnGestionarEntidades.Name = "btnGestionarEntidades";
            this.btnGestionarEntidades.Size = new System.Drawing.Size(241, 65);
            this.btnGestionarEntidades.TabIndex = 14;
            this.btnGestionarEntidades.Text = "Gestionar\r\nEntidades";
            this.btnGestionarEntidades.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGestionarEntidades.UseVisualStyleBackColor = true;
            this.btnGestionarEntidades.Click += new System.EventHandler(this.btnGestionarEntidades_Click);
            // 
            // btnupdateDrive
            // 
            this.btnupdateDrive.BackColor = System.Drawing.Color.Navy;
            this.btnupdateDrive.BackgroundImage = global::FDCH.UI.Properties.Resources.subidaArchivoDrive;
            this.btnupdateDrive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnupdateDrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupdateDrive.Enabled = false;
            this.btnupdateDrive.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnupdateDrive.FlatAppearance.BorderSize = 0;
            this.btnupdateDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdateDrive.Location = new System.Drawing.Point(52, 531);
            this.btnupdateDrive.Margin = new System.Windows.Forms.Padding(4);
            this.btnupdateDrive.Name = "btnupdateDrive";
            this.btnupdateDrive.Size = new System.Drawing.Size(50, 50);
            this.btnupdateDrive.TabIndex = 13;
            this.btnupdateDrive.UseVisualStyleBackColor = false;
            this.btnupdateDrive.Click += new System.EventHandler(this.btnupdateDrive_Click);
            // 
            // btnActualizarbase
            // 
            this.btnActualizarbase.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnActualizarbase.BackgroundImage = global::FDCH.UI.Properties.Resources.actualizarBaseDatos;
            this.btnActualizarbase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualizarbase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarbase.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnActualizarbase.FlatAppearance.BorderSize = 0;
            this.btnActualizarbase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarbase.Location = new System.Drawing.Point(143, 531);
            this.btnActualizarbase.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizarbase.Name = "btnActualizarbase";
            this.btnActualizarbase.Size = new System.Drawing.Size(50, 50);
            this.btnActualizarbase.TabIndex = 12;
            this.btnActualizarbase.UseVisualStyleBackColor = false;
            this.btnActualizarbase.Click += new System.EventHandler(this.btnActualizarbase_Click);
            // 
            // btnGetBloqueo
            // 
            this.btnGetBloqueo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetBloqueo.BackColor = System.Drawing.Color.Crimson;
            this.btnGetBloqueo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetBloqueo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGetBloqueo.FlatAppearance.BorderSize = 0;
            this.btnGetBloqueo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetBloqueo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetBloqueo.ForeColor = System.Drawing.Color.White;
            this.btnGetBloqueo.Image = global::FDCH.UI.Properties.Resources.desbloqueado;
            this.btnGetBloqueo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetBloqueo.Location = new System.Drawing.Point(0, 608);
            this.btnGetBloqueo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetBloqueo.Name = "btnGetBloqueo";
            this.btnGetBloqueo.Size = new System.Drawing.Size(241, 60);
            this.btnGetBloqueo.TabIndex = 11;
            this.btnGetBloqueo.Text = "Obtener Bloqueo";
            this.btnGetBloqueo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetBloqueo.UseVisualStyleBackColor = false;
            this.btnGetBloqueo.Click += new System.EventHandler(this.btnGetBloqueo_Click);
            // 
            // btnAddParticipa
            // 
            this.btnAddParticipa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddParticipa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddParticipa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddParticipa.Enabled = false;
            this.btnAddParticipa.FlatAppearance.BorderSize = 0;
            this.btnAddParticipa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddParticipa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParticipa.ForeColor = System.Drawing.Color.White;
            this.btnAddParticipa.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAddParticipa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddParticipa.Location = new System.Drawing.Point(0, 305);
            this.btnAddParticipa.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddParticipa.Name = "btnAddParticipa";
            this.btnAddParticipa.Size = new System.Drawing.Size(241, 65);
            this.btnAddParticipa.TabIndex = 10;
            this.btnAddParticipa.Text = "Agregar\r\nParticipación";
            this.btnAddParticipa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddParticipa.UseVisualStyleBackColor = true;
            this.btnAddParticipa.Click += new System.EventHandler(this.btnAddParticipa_Click);
            // 
            // btnAddTorneo
            // 
            this.btnAddTorneo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddTorneo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTorneo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTorneo.Enabled = false;
            this.btnAddTorneo.FlatAppearance.BorderSize = 0;
            this.btnAddTorneo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTorneo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTorneo.ForeColor = System.Drawing.Color.White;
            this.btnAddTorneo.Image = global::FDCH.UI.Properties.Resources.torneo;
            this.btnAddTorneo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTorneo.Location = new System.Drawing.Point(0, 240);
            this.btnAddTorneo.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTorneo.Name = "btnAddTorneo";
            this.btnAddTorneo.Size = new System.Drawing.Size(241, 65);
            this.btnAddTorneo.TabIndex = 9;
            this.btnAddTorneo.Text = "Agregar\r\nTorneo";
            this.btnAddTorneo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddTorneo.UseVisualStyleBackColor = true;
            this.btnAddTorneo.Click += new System.EventHandler(this.btnAddTorneo_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBusqueda.FlatAppearance.BorderSize = 0;
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnBusqueda.Image = global::FDCH.UI.Properties.Resources.search;
            this.btnBusqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusqueda.Location = new System.Drawing.Point(0, 175);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(241, 65);
            this.btnBusqueda.TabIndex = 8;
            this.btnBusqueda.Text = "Busqueda";
            this.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // pnlOpcion
            // 
            this.pnlOpcion.BackColor = System.Drawing.Color.Crimson;
            this.pnlOpcion.Location = new System.Drawing.Point(0, 110);
            this.pnlOpcion.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOpcion.Name = "pnlOpcion";
            this.pnlOpcion.Size = new System.Drawing.Size(12, 65);
            this.pnlOpcion.TabIndex = 7;
            // 
            // lblUsuarioActivo
            // 
            this.lblUsuarioActivo.BackColor = System.Drawing.Color.Blue;
            this.lblUsuarioActivo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUsuarioActivo.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioActivo.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioActivo.Location = new System.Drawing.Point(0, 668);
            this.lblUsuarioActivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioActivo.Name = "lblUsuarioActivo";
            this.lblUsuarioActivo.Size = new System.Drawing.Size(241, 94);
            this.lblUsuarioActivo.TabIndex = 6;
            this.lblUsuarioActivo.Text = "Conectado";
            this.lblUsuarioActivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInicio
            // 
            this.btnInicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Image = global::FDCH.UI.Properties.Resources.home;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.Location = new System.Drawing.Point(0, 110);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(241, 65);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::FDCH.UI.Properties.Resources.Logo_FDCH1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlContenedorFrm
            // 
            this.pnlContenedorFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorFrm.Location = new System.Drawing.Point(241, 0);
            this.pnlContenedorFrm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedorFrm.Name = "pnlContenedorFrm";
            this.pnlContenedorFrm.Size = new System.Drawing.Size(1197, 712);
            this.pnlContenedorFrm.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(241, 712);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1197, 50);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1438, 762);
            this.Controls.Add(this.pnlContenedorFrm);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Federación Deportiva de Chimborazo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private System.Windows.Forms.Panel pnlContenedorFrm;
        private System.Windows.Forms.Panel pnlOpcion;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnAddTorneo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnAddParticipa;
        private System.Windows.Forms.Button btnGetBloqueo;
        private System.Windows.Forms.Button btnupdateDrive;
        private System.Windows.Forms.Button btnActualizarbase;
        private System.Windows.Forms.Button btnGestionarEntidades;
        private System.Windows.Forms.Button btnAuditoria;
    }
}