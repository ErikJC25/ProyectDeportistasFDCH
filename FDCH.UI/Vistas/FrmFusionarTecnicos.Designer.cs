namespace FDCH.UI.Vistas
{
    partial class FrmFusionarTecnicos
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
            this.dataGridViewSeleccionados = new System.Windows.Forms.DataGridView();
            this.col_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Disciplinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNuevoNombre = new System.Windows.Forms.TextBox();
            this.btnFusionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 5);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fusionar Técnicos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(117, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Técnicos seleccionados para fusionar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewSeleccionados
            // 
            this.dataGridViewSeleccionados.AllowUserToAddRows = false;
            this.dataGridViewSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridViewSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Nombre,
            this.col_Disciplinas,
            this.colIdTecnico});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewSeleccionados, 3);
            this.dataGridViewSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeleccionados.Location = new System.Drawing.Point(117, 120);
            this.dataGridViewSeleccionados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewSeleccionados.Name = "dataGridViewSeleccionados";
            this.dataGridViewSeleccionados.ReadOnly = true;
            this.dataGridViewSeleccionados.RowHeadersWidth = 51;
            this.dataGridViewSeleccionados.Size = new System.Drawing.Size(961, 340);
            this.dataGridViewSeleccionados.TabIndex = 2;
            // 
            // col_Nombre
            // 
            this.col_Nombre.HeaderText = "NOMBRE COMPLETO";
            this.col_Nombre.MinimumWidth = 6;
            this.col_Nombre.Name = "col_Nombre";
            this.col_Nombre.ReadOnly = true;
            // 
            // col_Disciplinas
            // 
            this.col_Disciplinas.HeaderText = "DISCIPLINAS DIRIGIDAS";
            this.col_Disciplinas.MinimumWidth = 6;
            this.col_Disciplinas.Name = "col_Disciplinas";
            this.col_Disciplinas.ReadOnly = true;
            // 
            // colIdTecnico
            // 
            this.colIdTecnico.HeaderText = "id_tecnico";
            this.colIdTecnico.MinimumWidth = 6;
            this.colIdTecnico.Name = "colIdTecnico";
            this.colIdTecnico.ReadOnly = true;
            this.colIdTecnico.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(117, 464);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(638, 52);
            this.label3.TabIndex = 3;
            this.label3.Text = "Creación del técnico fusionado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(117, 516);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 34);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre Completo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNuevoNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNuevoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNuevoNombre, 3);
            this.txtNuevoNombre.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNuevoNombre.Location = new System.Drawing.Point(117, 554);
            this.txtNuevoNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(961, 30);
            this.txtNuevoNombre.TabIndex = 5;
            this.txtNuevoNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevoNombre_KeyPress);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFusionar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Location = new System.Drawing.Point(763, 635);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(315, 49);
            this.btnFusionar.TabIndex = 28;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.Location = new System.Drawing.Point(117, 635);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(315, 49);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.459459F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.02703F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.02703F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.02703F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.459459F));
            this.tableLayoutPanel1.Controls.Add(this.btnFusionar, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSeleccionados, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNuevoNombre, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.024692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.7037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.024692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.246913F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.796296F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.94716F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // FrmFusionarTecnicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmFusionarTecnicos";
            this.Text = "FrmFusionarTecnicos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewSeleccionados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNuevoNombre;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Disciplinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTecnico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}