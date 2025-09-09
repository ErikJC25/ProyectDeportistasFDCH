namespace FDCH.UI.Vistas
{
    partial class FrmEditarEspecialidad
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
            this.txtModalidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModalidad
            // 
            this.txtModalidad.AutoSize = true;
            this.txtModalidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModalidad.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtModalidad.ForeColor = System.Drawing.Color.Black;
            this.txtModalidad.Location = new System.Drawing.Point(4, 289);
            this.txtModalidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtModalidad.Name = "txtModalidad";
            this.txtModalidad.Size = new System.Drawing.Size(177, 62);
            this.txtModalidad.TabIndex = 64;
            this.txtModalidad.Text = "Modalidad:";
            this.txtModalidad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEspecialidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel2.SetColumnSpan(this.txtEspecialidad, 3);
            this.txtEspecialidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEspecialidad.Location = new System.Drawing.Point(4, 355);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(585, 30);
            this.txtEspecialidad.TabIndex = 63;
            this.txtEspecialidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.BackColor = System.Drawing.Color.White;
            this.lblDisciplina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisciplina.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblDisciplina.ForeColor = System.Drawing.Color.Black;
            this.lblDisciplina.Location = new System.Drawing.Point(366, 0);
            this.lblDisciplina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(223, 106);
            this.lblDisciplina.TabIndex = 62;
            this.lblDisciplina.Text = "Disciplina";
            this.lblDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarCambios.BackColor = System.Drawing.Color.SandyBrown;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(366, 503);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(223, 59);
            this.btnGuardarCambios.TabIndex = 61;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnCancelar.Location = new System.Drawing.Point(4, 503);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(177, 59);
            this.btnCancelar.TabIndex = 60;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 106);
            this.label3.TabIndex = 59;
            this.label3.Text = "Nombre Especialidad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreEspecialidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel2.SetColumnSpan(this.txtNombreEspecialidad, 3);
            this.txtNombreEspecialidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(4, 216);
            this.txtNombreEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(585, 30);
            this.txtNombreEspecialidad.TabIndex = 58;
            this.txtNombreEspecialidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEspecialidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SandyBrown;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 106);
            this.label2.TabIndex = 57;
            this.label2.Text = "Edición de la especialidad perteneciente a: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "Editar Especialidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SandyBrown;
            this.pictureBox1.BackgroundImage = global::FDCH.UI.Properties.Resources.disciplinas;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(598, 648);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel1.TabIndex = 65;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.01686F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.78584F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDisciplina, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGuardarCambios, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtEspecialidad, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtModalidad, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtNombreEspecialidad, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(601, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.56347F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.56347F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0743F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.752322F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.06502F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.98142F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(593, 642);
            this.tableLayoutPanel2.TabIndex = 66;
            // 
            // FrmEditarEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmEditarEspecialidad";
            this.Text = "FrmEditarEspecialidad";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtModalidad;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}