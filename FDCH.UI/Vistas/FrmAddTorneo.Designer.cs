namespace FDCH.UI.Vistas
{
    partial class FrmAddTorneo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpbFecha = new System.Windows.Forms.GroupBox();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpbFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(696, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Torneo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(565, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(298, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fin:";
            // 
            // grpbFecha
            // 
            this.grpbFecha.BackColor = System.Drawing.Color.Transparent;
            this.grpbFecha.Controls.Add(this.txtFechaFin);
            this.grpbFecha.Controls.Add(this.txtFechaInicio);
            this.grpbFecha.Controls.Add(this.label3);
            this.grpbFecha.Controls.Add(this.label4);
            this.grpbFecha.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbFecha.Location = new System.Drawing.Point(570, 221);
            this.grpbFecha.Name = "grpbFecha";
            this.grpbFecha.Size = new System.Drawing.Size(558, 101);
            this.grpbFecha.TabIndex = 9;
            this.grpbFecha.TabStop = false;
            this.grpbFecha.Text = "Fecha";
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFechaFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaFin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFin.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFechaFin.Location = new System.Drawing.Point(359, 48);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(177, 30);
            this.txtFechaFin.TabIndex = 19;
            this.txtFechaFin.Text = "29/08/2025";
            this.txtFechaFin.Enter += new System.EventHandler(this.txtFechaFin_Enter);
            this.txtFechaFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaFin_KeyPress);
            this.txtFechaFin.Leave += new System.EventHandler(this.txtFechaFin_Leave);
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFechaInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaInicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFechaInicio.Location = new System.Drawing.Point(100, 48);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(177, 30);
            this.txtFechaInicio.TabIndex = 18;
            this.txtFechaInicio.Text = "04/08/2025";
            this.txtFechaInicio.Enter += new System.EventHandler(this.txtFechInicio_Enter);
            this.txtFechaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaInicio_KeyPress);
            this.txtFechaInicio.Leave += new System.EventHandler(this.txtFechaInicio_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(565, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lugar:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombre.Location = new System.Drawing.Point(570, 120);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(558, 72);
            this.txtNombre.TabIndex = 11;
            this.txtNombre.Text = "TORNEO CANTO...";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtLugar
            // 
            this.txtLugar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLugar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLugar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugar.ForeColor = System.Drawing.Color.DarkGray;
            this.txtLugar.Location = new System.Drawing.Point(570, 381);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(558, 30);
            this.txtLugar.TabIndex = 12;
            this.txtLugar.Text = "RIOBAMBA";
            this.txtLugar.Enter += new System.EventHandler(this.txtLugar_Enter_1);
            this.txtLugar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLugar_KeyPress);
            this.txtLugar.Leave += new System.EventHandler(this.txtLugar_Leave);
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTipo.Location = new System.Drawing.Point(570, 477);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(558, 30);
            this.txtTipo.TabIndex = 14;
            this.txtTipo.Text = "OFICIAL";
            this.txtTipo.Enter += new System.EventHandler(this.txtTipo_Enter);
            this.txtTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipo_KeyPress);
            this.txtTipo.Leave += new System.EventHandler(this.txtTipo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(565, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo Evento:";
            // 
            // txtNivel
            // 
            this.txtNivel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNivel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNivel.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNivel.Location = new System.Drawing.Point(570, 571);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(558, 30);
            this.txtNivel.TabIndex = 16;
            this.txtNivel.Text = "REGIONAL, CANTONAL, ...";
            this.txtNivel.Enter += new System.EventHandler(this.txtNivel_Enter);
            this.txtNivel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNivel_KeyPress);
            this.txtNivel.Leave += new System.EventHandler(this.txtNivel_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(565, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 27);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nivel Evento:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(569, 631);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(558, 44);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::FDCH.UI.Properties.Resources.torneo_frm;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 707);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAddTorneo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 707);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNivel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLugar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpbFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddTorneo";
            this.Text = "FrmAddTorneo";
            this.Load += new System.EventHandler(this.FrmAddTorneo_Load);
            this.grpbFecha.ResumeLayout(false);
            this.grpbFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpbFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.TextBox txtFechaInicio;
    }
}