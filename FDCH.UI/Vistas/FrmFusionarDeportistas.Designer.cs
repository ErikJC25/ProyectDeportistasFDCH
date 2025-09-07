namespace FDCH.UI.Vistas
{
    partial class FrmFusionarDeportistas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSeleccionados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNombres = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbApellidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbGenero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbTipoDiscapacidad = new System.Windows.Forms.TextBox();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisciplinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Green;
            this.btnCancelar.Location = new System.Drawing.Point(320, 632);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(204, 50);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.BackColor = System.Drawing.Color.Green;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Location = new System.Drawing.Point(667, 632);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(204, 50);
            this.btnFusionar.TabIndex = 27;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 55);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fusionar Deportistas";
            // 
            // dataGridViewSeleccionados
            // 
            this.dataGridViewSeleccionados.AllowUserToAddRows = false;
            this.dataGridViewSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridViewSeleccionados.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCedula,
            this.colNombres,
            this.colApellidos,
            this.colDisciplinas,
            this.colGenero,
            this.colTipoDiscapacidad,
            this.colIdDeportista});
            this.dataGridViewSeleccionados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewSeleccionados.Location = new System.Drawing.Point(201, 103);
            this.dataGridViewSeleccionados.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSeleccionados.MultiSelect = false;
            this.dataGridViewSeleccionados.Name = "dataGridViewSeleccionados";
            this.dataGridViewSeleccionados.ReadOnly = true;
            this.dataGridViewSeleccionados.RowHeadersWidth = 51;
            this.dataGridViewSeleccionados.RowTemplate.Height = 24;
            this.dataGridViewSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeleccionados.Size = new System.Drawing.Size(797, 309);
            this.dataGridViewSeleccionados.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Deportistas seleccionados para fusionar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(30, 431);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 22);
            this.label3.TabIndex = 38;
            this.label3.Text = "Creación del deportista fusionado";
            // 
            // txbCedula
            // 
            this.txbCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbCedula.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCedula.ForeColor = System.Drawing.Color.Black;
            this.txbCedula.Location = new System.Drawing.Point(34, 503);
            this.txbCedula.Margin = new System.Windows.Forms.Padding(2);
            this.txbCedula.Name = "txbCedula";
            this.txbCedula.Size = new System.Drawing.Size(263, 26);
            this.txbCedula.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 469);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 22);
            this.label4.TabIndex = 54;
            this.label4.Text = "Cédula:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(316, 469);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 22);
            this.label5.TabIndex = 56;
            this.label5.Text = "Nombres:";
            // 
            // txbNombres
            // 
            this.txbNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNombres.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombres.ForeColor = System.Drawing.Color.Black;
            this.txbNombres.Location = new System.Drawing.Point(320, 503);
            this.txbNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txbNombres.Name = "txbNombres";
            this.txbNombres.Size = new System.Drawing.Size(263, 26);
            this.txbNombres.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(604, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 22);
            this.label6.TabIndex = 58;
            this.label6.Text = "Apellidos:";
            // 
            // txbApellidos
            // 
            this.txbApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbApellidos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApellidos.ForeColor = System.Drawing.Color.Black;
            this.txbApellidos.Location = new System.Drawing.Point(608, 503);
            this.txbApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txbApellidos.Name = "txbApellidos";
            this.txbApellidos.Size = new System.Drawing.Size(263, 26);
            this.txbApellidos.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(897, 469);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 60;
            this.label7.Text = "Género:";
            // 
            // txbGenero
            // 
            this.txbGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbGenero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbGenero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbGenero.ForeColor = System.Drawing.Color.Black;
            this.txbGenero.Location = new System.Drawing.Point(901, 503);
            this.txbGenero.Margin = new System.Windows.Forms.Padding(2);
            this.txbGenero.Name = "txbGenero";
            this.txbGenero.Size = new System.Drawing.Size(263, 26);
            this.txbGenero.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 551);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 22);
            this.label8.TabIndex = 62;
            this.label8.Text = "Tipo Discapacidad:";
            // 
            // txbTipoDiscapacidad
            // 
            this.txbTipoDiscapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbTipoDiscapacidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbTipoDiscapacidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTipoDiscapacidad.ForeColor = System.Drawing.Color.Black;
            this.txbTipoDiscapacidad.Location = new System.Drawing.Point(34, 585);
            this.txbTipoDiscapacidad.Margin = new System.Windows.Forms.Padding(2);
            this.txbTipoDiscapacidad.Name = "txbTipoDiscapacidad";
            this.txbTipoDiscapacidad.Size = new System.Drawing.Size(263, 26);
            this.txbTipoDiscapacidad.TabIndex = 61;
            // 
            // colCedula
            // 
            this.colCedula.DataPropertyName = "cedula";
            this.colCedula.HeaderText = "CEDULA";
            this.colCedula.Name = "colCedula";
            this.colCedula.ReadOnly = true;
            this.colCedula.Width = 110;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "nombres";
            this.colNombres.HeaderText = "NOMBRES";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            this.colNombres.Width = 160;
            // 
            // colApellidos
            // 
            this.colApellidos.DataPropertyName = "apellidos";
            this.colApellidos.HeaderText = "APELLIDOS";
            this.colApellidos.Name = "colApellidos";
            this.colApellidos.ReadOnly = true;
            this.colApellidos.Width = 160;
            // 
            // colDisciplinas
            // 
            this.colDisciplinas.HeaderText = "DISCIPLINAS PARTICIPADAS";
            this.colDisciplinas.Name = "colDisciplinas";
            this.colDisciplinas.ReadOnly = true;
            this.colDisciplinas.Width = 125;
            // 
            // colGenero
            // 
            this.colGenero.DataPropertyName = "tipo_discapacidad";
            this.colGenero.HeaderText = "GENERO";
            this.colGenero.Name = "colGenero";
            this.colGenero.ReadOnly = true;
            this.colGenero.Width = 80;
            // 
            // colTipoDiscapacidad
            // 
            this.colTipoDiscapacidad.DataPropertyName = "tipo_discapacidad";
            this.colTipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.colTipoDiscapacidad.Name = "colTipoDiscapacidad";
            this.colTipoDiscapacidad.ReadOnly = true;
            // 
            // colIdDeportista
            // 
            this.colIdDeportista.DataPropertyName = "id_deportista";
            this.colIdDeportista.HeaderText = "IdDeportista";
            this.colIdDeportista.Name = "colIdDeportista";
            this.colIdDeportista.ReadOnly = true;
            this.colIdDeportista.Visible = false;
            // 
            // FrmFusionarDeportistas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbTipoDiscapacidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbGenero);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbApellidos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbNombres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbCedula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewSeleccionados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFusionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFusionarDeportistas";
            this.Text = "FrmFusionarDeportistas";
            this.Load += new System.EventHandler(this.FrmFusionarDeportistas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSeleccionados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNombres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbApellidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbGenero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbTipoDiscapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisciplinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDiscapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDeportista;
    }
}