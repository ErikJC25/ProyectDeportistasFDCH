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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTargets = new System.Windows.Forms.DataGridView();
            this.colT_Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_TipoDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT_Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.btnAddRow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTargets)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 11);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Separar Deportistas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fila Seleccionada";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrigCedula
            // 
            this.txtOrigCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOrigCedula, 2);
            this.txtOrigCedula.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigCedula.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigCedula.Location = new System.Drawing.Point(136, 106);
            this.txtOrigCedula.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrigCedula.Name = "txtOrigCedula";
            this.txtOrigCedula.ReadOnly = true;
            this.txtOrigCedula.Size = new System.Drawing.Size(246, 30);
            this.txtOrigCedula.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 48);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cédula:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTargets
            // 
            this.dataGridViewTargets.AllowUserToAddRows = false;
            this.dataGridViewTargets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTargets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colT_Cedula,
            this.colT_Nombres,
            this.colT_Apellidos,
            this.colT_Genero,
            this.colT_TipoDiscapacidad,
            this.colT_Eliminar});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewTargets, 7);
            this.dataGridViewTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTargets.Location = new System.Drawing.Point(263, 322);
            this.dataGridViewTargets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewTargets.Name = "dataGridViewTargets";
            this.dataGridViewTargets.RowHeadersWidth = 51;
            this.dataGridViewTargets.Size = new System.Drawing.Size(920, 331);
            this.dataGridViewTargets.TabIndex = 1;
            this.dataGridViewTargets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTargets_CellContentClick);
            this.dataGridViewTargets.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTargets_CellEndEdit);
            this.dataGridViewTargets.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewTargets_EditingControlShowing);
            // 
            // colT_Cedula
            // 
            this.colT_Cedula.HeaderText = "CEDULA";
            this.colT_Cedula.MinimumWidth = 6;
            this.colT_Cedula.Name = "colT_Cedula";
            // 
            // colT_Nombres
            // 
            this.colT_Nombres.HeaderText = "NOMBRES";
            this.colT_Nombres.MinimumWidth = 6;
            this.colT_Nombres.Name = "colT_Nombres";
            // 
            // colT_Apellidos
            // 
            this.colT_Apellidos.HeaderText = "APELLIDOS";
            this.colT_Apellidos.MinimumWidth = 6;
            this.colT_Apellidos.Name = "colT_Apellidos";
            // 
            // colT_Genero
            // 
            this.colT_Genero.HeaderText = "GENERO";
            this.colT_Genero.MinimumWidth = 6;
            this.colT_Genero.Name = "colT_Genero";
            // 
            // colT_TipoDiscapacidad
            // 
            this.colT_TipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.colT_TipoDiscapacidad.MinimumWidth = 6;
            this.colT_TipoDiscapacidad.Name = "colT_TipoDiscapacidad";
            // 
            // colT_Eliminar
            // 
            this.colT_Eliminar.HeaderText = "ELIMINAR";
            this.colT_Eliminar.MinimumWidth = 6;
            this.colT_Eliminar.Name = "colT_Eliminar";
            this.colT_Eliminar.Text = "Eliminar";
            this.colT_Eliminar.UseColumnTextForButtonValue = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(390, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 48);
            this.label4.TabIndex = 6;
            this.label4.Text = "Género:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(759, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 48);
            this.label5.TabIndex = 8;
            this.label5.Text = "Discapacidad:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrigGenero
            // 
            this.txtOrigGenero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOrigGenero, 2);
            this.txtOrigGenero.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigGenero.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigGenero.Location = new System.Drawing.Point(499, 106);
            this.txtOrigGenero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrigGenero.Name = "txtOrigGenero";
            this.txtOrigGenero.ReadOnly = true;
            this.txtOrigGenero.Size = new System.Drawing.Size(252, 30);
            this.txtOrigGenero.TabIndex = 9;
            // 
            // txtOrigTipoDiscapacidad
            // 
            this.txtOrigTipoDiscapacidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigTipoDiscapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOrigTipoDiscapacidad, 2);
            this.txtOrigTipoDiscapacidad.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigTipoDiscapacidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigTipoDiscapacidad.Location = new System.Drawing.Point(937, 106);
            this.txtOrigTipoDiscapacidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrigTipoDiscapacidad.Name = "txtOrigTipoDiscapacidad";
            this.txtOrigTipoDiscapacidad.ReadOnly = true;
            this.txtOrigTipoDiscapacidad.Size = new System.Drawing.Size(246, 30);
            this.txtOrigTipoDiscapacidad.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 127);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombres:";
            // 
            // txtOrigNombres
            // 
            this.txtOrigNombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOrigNombres, 3);
            this.txtOrigNombres.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigNombres.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigNombres.Location = new System.Drawing.Point(136, 149);
            this.txtOrigNombres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrigNombres.Multiline = true;
            this.txtOrigNombres.Name = "txtOrigNombres";
            this.txtOrigNombres.ReadOnly = true;
            this.txtOrigNombres.Size = new System.Drawing.Size(355, 114);
            this.txtOrigNombres.TabIndex = 12;
            // 
            // txtOrigApellidos
            // 
            this.txtOrigApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOrigApellidos, 3);
            this.txtOrigApellidos.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrigApellidos.ForeColor = System.Drawing.Color.DarkGray;
            this.txtOrigApellidos.Location = new System.Drawing.Point(759, 149);
            this.txtOrigApellidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrigApellidos.Multiline = true;
            this.txtOrigApellidos.Name = "txtOrigApellidos";
            this.txtOrigApellidos.ReadOnly = true;
            this.txtOrigApellidos.Size = new System.Drawing.Size(424, 114);
            this.txtOrigApellidos.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(626, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 127);
            this.label7.TabIndex = 14;
            this.label7.Text = "Apellidos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 4);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Indigo;
            this.label8.Location = new System.Drawing.Point(10, 272);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(481, 46);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ingrese los deportistas individualmente";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSeparar
            // 
            this.btnSeparar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeparar.BackColor = System.Drawing.Color.Indigo;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSeparar, 2);
            this.btnSeparar.FlatAppearance.BorderSize = 0;
            this.btnSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeparar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeparar.ForeColor = System.Drawing.Color.White;
            this.btnSeparar.Location = new System.Drawing.Point(937, 664);
            this.btnSeparar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(246, 40);
            this.btnSeparar.TabIndex = 28;
            this.btnSeparar.Text = "Separar";
            this.btnSeparar.UseVisualStyleBackColor = false;
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancelar, 2);
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Indigo;
            this.btnCancelar.Location = new System.Drawing.Point(263, 664);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(228, 40);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.BackColor = System.Drawing.Color.Indigo;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAddRow, 2);
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRow.Location = new System.Drawing.Point(10, 465);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(245, 45);
            this.btnAddRow.TabIndex = 30;
            this.btnAddRow.Text = "Agregar nueva fila";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.009793F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.59611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.009697F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRow, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTargets, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOrigCedula, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOrigApellidos, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOrigNombres, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOrigGenero, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOrigTipoDiscapacidad, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSeparar, 8, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.092593F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.407407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.59877F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.098765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.31482F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.37385F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // FrmSepararDeportistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSepararDeportistas";
            this.Text = "FrmSepararDeportistas";
            this.Load += new System.EventHandler(this.FrmSepararDeportistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTargets)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}