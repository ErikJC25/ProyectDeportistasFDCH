namespace FDCH.UI.Vistas
{
    partial class FrmEditarEvento
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txbFechaInicio = new System.Windows.Forms.TextBox();
            this.txbFechaFin = new System.Windows.Forms.TextBox();
            this.grpbFecha = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbLugar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTipoEvento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbNivelEvento = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpbFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 75);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(365, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edición de Torneo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Coral;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(947, 628);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(204, 50);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Coral;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::FDCH.UI.Properties.Resources.torneo_frm;
            this.pictureBox1.Location = new System.Drawing.Point(0, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 631);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(567, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 27);
            this.label17.TabIndex = 18;
            this.label17.Text = "Nombre:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(308, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 27);
            this.label16.TabIndex = 7;
            this.label16.Text = "Fin:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(13, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 27);
            this.label15.TabIndex = 5;
            this.label15.Text = "Inicio:";
            // 
            // txbFechaInicio
            // 
            this.txbFechaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbFechaInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbFechaInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFechaInicio.ForeColor = System.Drawing.Color.DarkGray;
            this.txbFechaInicio.Location = new System.Drawing.Point(95, 48);
            this.txbFechaInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbFechaInicio.Name = "txbFechaInicio";
            this.txbFechaInicio.Size = new System.Drawing.Size(187, 30);
            this.txbFechaInicio.TabIndex = 1;
            this.txbFechaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbFechaFin
            // 
            this.txbFechaFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbFechaFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbFechaFin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFechaFin.ForeColor = System.Drawing.Color.DarkGray;
            this.txbFechaFin.Location = new System.Drawing.Point(364, 48);
            this.txbFechaFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbFechaFin.Name = "txbFechaFin";
            this.txbFechaFin.Size = new System.Drawing.Size(187, 30);
            this.txbFechaFin.TabIndex = 2;
            this.txbFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpbFecha
            // 
            this.grpbFecha.BackColor = System.Drawing.Color.Transparent;
            this.grpbFecha.Controls.Add(this.txbFechaFin);
            this.grpbFecha.Controls.Add(this.txbFechaInicio);
            this.grpbFecha.Controls.Add(this.label15);
            this.grpbFecha.Controls.Add(this.label16);
            this.grpbFecha.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbFecha.Location = new System.Drawing.Point(572, 229);
            this.grpbFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbFecha.Name = "grpbFecha";
            this.grpbFecha.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbFecha.Size = new System.Drawing.Size(579, 101);
            this.grpbFecha.TabIndex = 21;
            this.grpbFecha.TabStop = false;
            this.grpbFecha.Text = "Fecha";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(567, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 27);
            this.label10.TabIndex = 22;
            this.label10.Text = "Lugar:";
            // 
            // txbNombre
            // 
            this.txbNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombre.ForeColor = System.Drawing.Color.DarkGray;
            this.txbNombre.Location = new System.Drawing.Point(572, 135);
            this.txbNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNombre.Multiline = true;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(577, 72);
            this.txbNombre.TabIndex = 16;
            // 
            // txbLugar
            // 
            this.txbLugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbLugar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbLugar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLugar.ForeColor = System.Drawing.Color.DarkGray;
            this.txbLugar.Location = new System.Drawing.Point(572, 379);
            this.txbLugar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbLugar.Name = "txbLugar";
            this.txbLugar.Size = new System.Drawing.Size(577, 30);
            this.txbLugar.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(567, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 27);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tipo Evento:";
            // 
            // txbTipoEvento
            // 
            this.txbTipoEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbTipoEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbTipoEvento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTipoEvento.ForeColor = System.Drawing.Color.DarkGray;
            this.txbTipoEvento.Location = new System.Drawing.Point(572, 475);
            this.txbTipoEvento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTipoEvento.Name = "txbTipoEvento";
            this.txbTipoEvento.Size = new System.Drawing.Size(577, 30);
            this.txbTipoEvento.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(567, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nivel Evento:";
            // 
            // txbNivelEvento
            // 
            this.txbNivelEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbNivelEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNivelEvento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNivelEvento.ForeColor = System.Drawing.Color.DarkGray;
            this.txbNivelEvento.Location = new System.Drawing.Point(572, 569);
            this.txbNivelEvento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNivelEvento.Name = "txbNivelEvento";
            this.txbNivelEvento.Size = new System.Drawing.Size(577, 30);
            this.txbNivelEvento.TabIndex = 20;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Coral;
            this.btnCancelar.Location = new System.Drawing.Point(580, 628);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(204, 50);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // FrmEditarEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbNivelEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTipoEvento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbLugar);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grpbFecha);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEditarEvento";
            this.Text = "FrmEditarRegistro";
            this.Load += new System.EventHandler(this.FrmEditarRegistro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpbFecha.ResumeLayout(false);
            this.grpbFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbFechaInicio;
        private System.Windows.Forms.TextBox txbFechaFin;
        private System.Windows.Forms.GroupBox grpbFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbLugar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTipoEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNivelEvento;
        private System.Windows.Forms.Button btnCancelar;
    }
}