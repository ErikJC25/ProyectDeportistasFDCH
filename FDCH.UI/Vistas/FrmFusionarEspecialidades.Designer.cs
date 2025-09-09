namespace FDCH.UI.Vistas
{
    partial class FrmFusionarEspecialidades
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFusionar = new System.Windows.Forms.Button();
            this.txtNuevoNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewSeleccionados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.txtNuevaModalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.col_NombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Modalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnCancelar.Location = new System.Drawing.Point(310, 625);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(204, 40);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFusionar.BackColor = System.Drawing.Color.SandyBrown;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Location = new System.Drawing.Point(697, 625);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(204, 40);
            this.btnFusionar.TabIndex = 44;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNuevoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNuevoNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNuevoNombre.Location = new System.Drawing.Point(310, 472);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(591, 26);
            this.txtNuevoNombre.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(306, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "Nombre Especialidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SandyBrown;
            this.label3.Location = new System.Drawing.Point(306, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 22);
            this.label3.TabIndex = 41;
            this.label3.Text = "Creación de la disciplina fusionada";
            // 
            // dataGridViewSeleccionados
            // 
            this.dataGridViewSeleccionados.AllowUserToAddRows = false;
            this.dataGridViewSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridViewSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_NombreEspecialidad,
            this.col_Modalidad,
            this.colIdEspecialidad,
            this.colIdDisciplina});
            this.dataGridViewSeleccionados.Location = new System.Drawing.Point(310, 165);
            this.dataGridViewSeleccionados.Name = "dataGridViewSeleccionados";
            this.dataGridViewSeleccionados.ReadOnly = true;
            this.dataGridViewSeleccionados.Size = new System.Drawing.Size(544, 210);
            this.dataGridViewSeleccionados.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SandyBrown;
            this.label2.Location = new System.Drawing.Point(306, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 22);
            this.label2.TabIndex = 39;
            this.label2.Text = "Especialidades seleccionadas para fusionar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 65);
            this.panel1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(443, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fusionar Especialidades";
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblDisciplina.ForeColor = System.Drawing.Color.Black;
            this.lblDisciplina.Location = new System.Drawing.Point(306, 122);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(169, 22);
            this.lblDisciplina.TabIndex = 46;
            this.lblDisciplina.Text = "Disciplina Origen";
            // 
            // txtNuevaModalidad
            // 
            this.txtNuevaModalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNuevaModalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNuevaModalidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNuevaModalidad.Location = new System.Drawing.Point(310, 559);
            this.txtNuevaModalidad.Name = "txtNuevaModalidad";
            this.txtNuevaModalidad.Size = new System.Drawing.Size(591, 26);
            this.txtNuevaModalidad.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(306, 522);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 47;
            this.label5.Text = "Modalidad:";
            // 
            // col_NombreEspecialidad
            // 
            this.col_NombreEspecialidad.HeaderText = "NOMBRE ESPECIALIDAD";
            this.col_NombreEspecialidad.Name = "col_NombreEspecialidad";
            this.col_NombreEspecialidad.ReadOnly = true;
            this.col_NombreEspecialidad.Width = 300;
            // 
            // col_Modalidad
            // 
            this.col_Modalidad.HeaderText = "MODALIDAD";
            this.col_Modalidad.Name = "col_Modalidad";
            this.col_Modalidad.ReadOnly = true;
            this.col_Modalidad.Width = 175;
            // 
            // colIdEspecialidad
            // 
            this.colIdEspecialidad.HeaderText = "colIdEspecialidad";
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.ReadOnly = true;
            this.colIdEspecialidad.Visible = false;
            // 
            // colIdDisciplina
            // 
            this.colIdDisciplina.HeaderText = "colIdDisciplina";
            this.colIdDisciplina.Name = "colIdDisciplina";
            this.colIdDisciplina.ReadOnly = true;
            this.colIdDisciplina.Visible = false;
            // 
            // FrmFusionarEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.txtNuevaModalidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFusionar);
            this.Controls.Add(this.txtNuevoNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewSeleccionados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFusionarEspecialidades";
            this.Text = "FrmFusionarEspecialidades";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.TextBox txtNuevoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewSeleccionados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.TextBox txtNuevaModalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Modalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDisciplina;
    }
}