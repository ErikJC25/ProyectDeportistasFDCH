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
            this.pnlOpcion = new System.Windows.Forms.Panel();
            this.lblUsuarioActivo = new System.Windows.Forms.Label();
            this.pnlContenedorFrm = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnGetBloqueo = new System.Windows.Forms.Button();
            this.btnAddParticipa = new System.Windows.Forms.Button();
            this.btnAddTorneo = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Navy;
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
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(241, 763);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlOpcion
            // 
            this.pnlOpcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.pnlOpcion.Location = new System.Drawing.Point(0, 110);
            this.pnlOpcion.Name = "pnlOpcion";
            this.pnlOpcion.Size = new System.Drawing.Size(12, 67);
            this.pnlOpcion.TabIndex = 7;
            // 
            // lblUsuarioActivo
            // 
            this.lblUsuarioActivo.BackColor = System.Drawing.Color.Blue;
            this.lblUsuarioActivo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUsuarioActivo.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioActivo.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioActivo.Location = new System.Drawing.Point(0, 669);
            this.lblUsuarioActivo.Name = "lblUsuarioActivo";
            this.lblUsuarioActivo.Size = new System.Drawing.Size(241, 94);
            this.lblUsuarioActivo.TabIndex = 6;
            this.lblUsuarioActivo.Text = "Conectado";
            this.lblUsuarioActivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContenedorFrm
            // 
            this.pnlContenedorFrm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContenedorFrm.Location = new System.Drawing.Point(241, 0);
            this.pnlContenedorFrm.Name = "pnlContenedorFrm";
            this.pnlContenedorFrm.Size = new System.Drawing.Size(1196, 707);
            this.pnlContenedorFrm.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.SlateBlue;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(241, 707);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(1196, 56);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGetBloqueo
            // 
            this.btnGetBloqueo.BackColor = System.Drawing.Color.Crimson;
            this.btnGetBloqueo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetBloqueo.FlatAppearance.BorderSize = 0;
            this.btnGetBloqueo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetBloqueo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetBloqueo.ForeColor = System.Drawing.Color.White;
            this.btnGetBloqueo.Image = global::FDCH.UI.Properties.Resources.desbloqueado;
            this.btnGetBloqueo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetBloqueo.Location = new System.Drawing.Point(0, 609);
            this.btnGetBloqueo.Name = "btnGetBloqueo";
            this.btnGetBloqueo.Size = new System.Drawing.Size(241, 60);
            this.btnGetBloqueo.TabIndex = 11;
            this.btnGetBloqueo.Text = "Obtener Bloqueo";
            this.btnGetBloqueo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetBloqueo.UseVisualStyleBackColor = false;
            // 
            // btnAddParticipa
            // 
            this.btnAddParticipa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddParticipa.FlatAppearance.BorderSize = 0;
            this.btnAddParticipa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddParticipa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParticipa.ForeColor = System.Drawing.Color.White;
            this.btnAddParticipa.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAddParticipa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddParticipa.Location = new System.Drawing.Point(12, 311);
            this.btnAddParticipa.Name = "btnAddParticipa";
            this.btnAddParticipa.Size = new System.Drawing.Size(229, 67);
            this.btnAddParticipa.TabIndex = 10;
            this.btnAddParticipa.Text = "Agregar\r\nParticipación";
            this.btnAddParticipa.UseVisualStyleBackColor = true;
            this.btnAddParticipa.Click += new System.EventHandler(this.btnAddParticipa_Click);
            // 
            // btnAddTorneo
            // 
            this.btnAddTorneo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTorneo.FlatAppearance.BorderSize = 0;
            this.btnAddTorneo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTorneo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTorneo.ForeColor = System.Drawing.Color.White;
            this.btnAddTorneo.Image = global::FDCH.UI.Properties.Resources.torneo;
            this.btnAddTorneo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTorneo.Location = new System.Drawing.Point(12, 244);
            this.btnAddTorneo.Name = "btnAddTorneo";
            this.btnAddTorneo.Size = new System.Drawing.Size(229, 67);
            this.btnAddTorneo.TabIndex = 9;
            this.btnAddTorneo.Text = "Agregar\r\nTorneo";
            this.btnAddTorneo.UseVisualStyleBackColor = true;
            this.btnAddTorneo.Click += new System.EventHandler(this.btnAddTorneo_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusqueda.FlatAppearance.BorderSize = 0;
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnBusqueda.Image = global::FDCH.UI.Properties.Resources.search;
            this.btnBusqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusqueda.Location = new System.Drawing.Point(12, 177);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(229, 67);
            this.btnBusqueda.TabIndex = 8;
            this.btnBusqueda.Text = "Busqueda";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Image = global::FDCH.UI.Properties.Resources.home;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(12, 110);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(229, 67);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::FDCH.UI.Properties.Resources.Logo_FDCH1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 763);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlContenedorFrm);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Federación Deportiva de Chimborazo";
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
    }
}