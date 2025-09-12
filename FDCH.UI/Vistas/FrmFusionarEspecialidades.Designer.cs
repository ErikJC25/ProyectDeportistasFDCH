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
            this.col_NombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Modalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.txtNuevaModalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnCancelar.Location = new System.Drawing.Point(15, 641);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(383, 49);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFusionar.BackColor = System.Drawing.Color.SandyBrown;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Location = new System.Drawing.Point(797, 641);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(383, 49);
            this.btnFusionar.TabIndex = 44;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNuevoNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNuevoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNuevoNombre, 3);
            this.txtNuevoNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNuevoNombre.Location = new System.Drawing.Point(15, 494);
            this.txtNuevoNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(1165, 30);
            this.txtNuevoNombre.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 455);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 35);
            this.label4.TabIndex = 42;
            this.label4.Text = "Nombre Especialidad:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SandyBrown;
            this.label3.Location = new System.Drawing.Point(15, 404);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(774, 51);
            this.label3.TabIndex = 41;
            this.label3.Text = "Creación de la disciplina fusionada";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewSeleccionados
            // 
            this.dataGridViewSeleccionados.AllowUserToAddRows = false;
            this.dataGridViewSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridViewSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_NombreEspecialidad,
            this.col_Modalidad,
            this.colIdEspecialidad,
            this.colIdDisciplina});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewSeleccionados, 3);
            this.dataGridViewSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeleccionados.Location = new System.Drawing.Point(15, 152);
            this.dataGridViewSeleccionados.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSeleccionados.Name = "dataGridViewSeleccionados";
            this.dataGridViewSeleccionados.ReadOnly = true;
            this.dataGridViewSeleccionados.RowHeadersWidth = 51;
            this.dataGridViewSeleccionados.Size = new System.Drawing.Size(1165, 248);
            this.dataGridViewSeleccionados.TabIndex = 40;
            // 
            // col_NombreEspecialidad
            // 
            this.col_NombreEspecialidad.HeaderText = "NOMBRE ESPECIALIDAD";
            this.col_NombreEspecialidad.MinimumWidth = 6;
            this.col_NombreEspecialidad.Name = "col_NombreEspecialidad";
            this.col_NombreEspecialidad.ReadOnly = true;
            // 
            // col_Modalidad
            // 
            this.col_Modalidad.HeaderText = "MODALIDAD";
            this.col_Modalidad.MinimumWidth = 6;
            this.col_Modalidad.Name = "col_Modalidad";
            this.col_Modalidad.ReadOnly = true;
            // 
            // colIdEspecialidad
            // 
            this.colIdEspecialidad.HeaderText = "colIdEspecialidad";
            this.colIdEspecialidad.MinimumWidth = 6;
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.ReadOnly = true;
            this.colIdEspecialidad.Visible = false;
            // 
            // colIdDisciplina
            // 
            this.colIdDisciplina.HeaderText = "colIdDisciplina";
            this.colIdDisciplina.MinimumWidth = 6;
            this.colIdDisciplina.Name = "colIdDisciplina";
            this.colIdDisciplina.ReadOnly = true;
            this.colIdDisciplina.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SandyBrown;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(774, 45);
            this.label2.TabIndex = 39;
            this.label2.Text = "Especialidades seleccionadas para fusionar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 5);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fusionar Especialidades";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisciplina.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblDisciplina.ForeColor = System.Drawing.Color.Black;
            this.lblDisciplina.Location = new System.Drawing.Point(15, 116);
            this.lblDisciplina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(383, 32);
            this.lblDisciplina.TabIndex = 46;
            this.lblDisciplina.Text = "Disciplina Origen";
            this.lblDisciplina.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNuevaModalidad
            // 
            this.txtNuevaModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNuevaModalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNuevaModalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNuevaModalidad, 3);
            this.txtNuevaModalidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNuevaModalidad.Location = new System.Drawing.Point(15, 580);
            this.txtNuevaModalidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtNuevaModalidad.Name = "txtNuevaModalidad";
            this.txtNuevaModalidad.Size = new System.Drawing.Size(1165, 30);
            this.txtNuevaModalidad.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 548);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(383, 28);
            this.label5.TabIndex = 47;
            this.label5.Text = "Modalidad:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.000249F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.66654F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.66654F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.66654F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.000125F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFusionar, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtNuevaModalidad, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDisciplina, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSeleccionados, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNuevoNombre, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.320225F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.494382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.95506F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.162921F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.91573F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.146068F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.932584F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.848314F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // FrmFusionarEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmFusionarEspecialidades";
            this.Text = "FrmFusionarEspecialidades";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.TextBox txtNuevoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewSeleccionados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.TextBox txtNuevaModalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Modalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDisciplina;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}