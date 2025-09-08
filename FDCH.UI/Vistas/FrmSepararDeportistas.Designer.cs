namespace FDCH.UI.Vistas
{
    partial class FrmSepararDeportistas
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTargets = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrigGenero = new System.Windows.Forms.TextBox();
            this.txtOrigTipoDiscapacidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrigNombres = new System.Windows.Forms.TextBox();
            this.txtOrigApellidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSeparar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.colT_Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_TipoDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTargets)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(417, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Separar Deportistas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fila Seleccionada";
            // 
            // txtOrigCedula
            // 
            this.txtOrigCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrigCedula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigCedula.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigCedula.Location = new System.Drawing.Point(108, 106);
            this.txtOrigCedula.Name = "txtOrigCedula";
            this.txtOrigCedula.ReadOnly = true;
            this.txtOrigCedula.Size = new System.Drawing.Size(256, 26);
            this.txtOrigCedula.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cédula:";
            // 
            // dataGridViewTargets
            // 
            this.dataGridViewTargets.AllowUserToAddRows = false;
            this.dataGridViewTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTargets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colT_Cedula,
            this.colT_Nombres,
            this.colT_Apellidos,
            this.colT_Genero,
            this.colT_TipoDiscapacidad,
            this.colT_Eliminar});
            this.dataGridViewTargets.Location = new System.Drawing.Point(260, 279);
            this.dataGridViewTargets.Name = "dataGridViewTargets";
            this.dataGridViewTargets.Size = new System.Drawing.Size(906, 352);
            this.dataGridViewTargets.TabIndex = 1;
            this.dataGridViewTargets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTargets_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(385, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Género:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(761, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Discapacidad:";
            // 
            // txtOrigGenero
            // 
            this.txtOrigGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrigGenero.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigGenero.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigGenero.Location = new System.Drawing.Point(476, 105);
            this.txtOrigGenero.Name = "txtOrigGenero";
            this.txtOrigGenero.ReadOnly = true;
            this.txtOrigGenero.Size = new System.Drawing.Size(256, 26);
            this.txtOrigGenero.TabIndex = 9;
            // 
            // txtOrigTipoDiscapacidad
            // 
            this.txtOrigTipoDiscapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrigTipoDiscapacidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigTipoDiscapacidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigTipoDiscapacidad.Location = new System.Drawing.Point(910, 106);
            this.txtOrigTipoDiscapacidad.Name = "txtOrigTipoDiscapacidad";
            this.txtOrigTipoDiscapacidad.ReadOnly = true;
            this.txtOrigTipoDiscapacidad.Size = new System.Drawing.Size(256, 26);
            this.txtOrigTipoDiscapacidad.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombres:";
            // 
            // txtOrigNombres
            // 
            this.txtOrigNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrigNombres.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigNombres.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigNombres.Location = new System.Drawing.Point(125, 136);
            this.txtOrigNombres.Multiline = true;
            this.txtOrigNombres.Name = "txtOrigNombres";
            this.txtOrigNombres.ReadOnly = true;
            this.txtOrigNombres.Size = new System.Drawing.Size(454, 93);
            this.txtOrigNombres.TabIndex = 12;
            // 
            // txtOrigApellidos
            // 
            this.txtOrigApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrigApellidos.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigApellidos.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigApellidos.Location = new System.Drawing.Point(712, 136);
            this.txtOrigApellidos.Multiline = true;
            this.txtOrigApellidos.Name = "txtOrigApellidos";
            this.txtOrigApellidos.ReadOnly = true;
            this.txtOrigApellidos.Size = new System.Drawing.Size(454, 93);
            this.txtOrigApellidos.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(603, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Apellidos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(20, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(375, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ingrese los deportistas individualmente";
            // 
            // btnSeparar
            // 
            this.btnSeparar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSeparar.BackColor = System.Drawing.Color.Green;
            this.btnSeparar.FlatAppearance.BorderSize = 0;
            this.btnSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeparar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeparar.ForeColor = System.Drawing.Color.White;
            this.btnSeparar.Location = new System.Drawing.Point(962, 646);
            this.btnSeparar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(204, 40);
            this.btnSeparar.TabIndex = 28;
            this.btnSeparar.Text = "Separar";
            this.btnSeparar.UseVisualStyleBackColor = false;
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Green;
            this.btnCancelar.Location = new System.Drawing.Point(260, 646);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(204, 40);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // colT_Cedula
            // 
            this.colT_Cedula.HeaderText = "CEDULA";
            this.colT_Cedula.Name = "colT_Cedula";
            this.colT_Cedula.Width = 132;
            // 
            // colT_Nombres
            // 
            this.colT_Nombres.HeaderText = "NOMBRES";
            this.colT_Nombres.Name = "colT_Nombres";
            this.colT_Nombres.Width = 200;
            // 
            // colT_Apellidos
            // 
            this.colT_Apellidos.HeaderText = "APELLIDOS";
            this.colT_Apellidos.Name = "colT_Apellidos";
            this.colT_Apellidos.Width = 200;
            // 
            // colT_Genero
            // 
            this.colT_Genero.HeaderText = "GENERO";
            this.colT_Genero.Name = "colT_Genero";
            this.colT_Genero.Width = 125;
            // 
            // colT_TipoDiscapacidad
            // 
            this.colT_TipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.colT_TipoDiscapacidad.Name = "colT_TipoDiscapacidad";
            this.colT_TipoDiscapacidad.Width = 125;
            // 
            // colT_Eliminar
            // 
            this.colT_Eliminar.HeaderText = "ELIMINAR";
            this.colT_Eliminar.Name = "colT_Eliminar";
            this.colT_Eliminar.Text = "Eliminar";
            this.colT_Eliminar.UseColumnTextForButtonValue = true;
            this.colT_Eliminar.Width = 75;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddRow.BackColor = System.Drawing.Color.Green;
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRow.Location = new System.Drawing.Point(12, 435);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(230, 40);
            this.btnAddRow.TabIndex = 30;
            this.btnAddRow.Text = "Agregar nueva fila";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // FrmSepararDeportistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeparar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrigApellidos);
            this.Controls.Add(this.txtOrigNombres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrigTipoDiscapacidad);
            this.Controls.Add(this.txtOrigGenero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrigCedula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewTargets);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSepararDeportistas";
            this.Text = "FrmSepararDeportistas";
            this.Load += new System.EventHandler(this.FrmSepararDeportistas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTargets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrigCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewTargets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrigGenero;
        private System.Windows.Forms.TextBox txtOrigTipoDiscapacidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrigNombres;
        private System.Windows.Forms.TextBox txtOrigApellidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSeparar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT_Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT_Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT_Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT_Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT_TipoDiscapacidad;
        private System.Windows.Forms.DataGridViewButtonColumn colT_Eliminar;
        private System.Windows.Forms.Button btnAddRow;
    }
}