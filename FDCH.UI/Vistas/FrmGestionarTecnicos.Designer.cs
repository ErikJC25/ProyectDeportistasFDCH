namespace FDCH.UI.Vistas
{
    partial class FrmGestionarTecnicos
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
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnOrdenarAlfabeticamente = new System.Windows.Forms.Button();
            this.btnOrdenarId = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisciplinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnFusionar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 9);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Técnicos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreCompleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNombreCompleto, 2);
            this.txtNombreCompleto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreCompleto.Location = new System.Drawing.Point(10, 78);
            this.txtNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(529, 29);
            this.txtNombreCompleto.TabIndex = 20;
            this.txtNombreCompleto.Text = "NOMBRE COMPLETO";
            this.txtNombreCompleto.Enter += new System.EventHandler(this.txtNombreCompleto_Enter);
            this.txtNombreCompleto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCompleto_KeyPress);
            this.txtNombreCompleto.Leave += new System.EventHandler(this.txtNombreCompleto_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(546, 78);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 30);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiar.Location = new System.Drawing.Point(677, 78);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(47, 30);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnOrdenarAlfabeticamente
            // 
            this.btnOrdenarAlfabeticamente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenarAlfabeticamente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnOrdenarAlfabeticamente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarAlfabeticamente.FlatAppearance.BorderSize = 0;
            this.btnOrdenarAlfabeticamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarAlfabeticamente.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarAlfabeticamente.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarAlfabeticamente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarAlfabeticamente.Location = new System.Drawing.Point(788, 78);
            this.btnOrdenarAlfabeticamente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenarAlfabeticamente.Name = "btnOrdenarAlfabeticamente";
            this.btnOrdenarAlfabeticamente.Size = new System.Drawing.Size(196, 30);
            this.btnOrdenarAlfabeticamente.TabIndex = 23;
            this.btnOrdenarAlfabeticamente.Text = "Orden Alfabético";
            this.btnOrdenarAlfabeticamente.UseVisualStyleBackColor = false;
            this.btnOrdenarAlfabeticamente.Click += new System.EventHandler(this.btnOrdenarAlfabeticamente_Click);
            // 
            // btnOrdenarId
            // 
            this.btnOrdenarId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenarId.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnOrdenarId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarId.FlatAppearance.BorderSize = 0;
            this.btnOrdenarId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarId.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarId.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarId.Location = new System.Drawing.Point(990, 78);
            this.btnOrdenarId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenarId.Name = "btnOrdenarId";
            this.btnOrdenarId.Size = new System.Drawing.Size(196, 30);
            this.btnOrdenarId.TabIndex = 25;
            this.btnOrdenarId.Text = "Orden Agregación";
            this.btnOrdenarId.UseVisualStyleBackColor = false;
            this.btnOrdenarId.Click += new System.EventHandler(this.btnOrdenarId_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colNombreCompleto,
            this.colDisciplinas,
            this.colEditar,
            this.colIdTecnico});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 6);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(223, 126);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 3);
            this.dataGridView1.Size = new System.Drawing.Size(962, 582);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "SELECCIONAR";
            this.colSeleccionar.MinimumWidth = 6;
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.ReadOnly = true;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.HeaderText = "NOMBRE COMPLETO";
            this.colNombreCompleto.MinimumWidth = 6;
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.ReadOnly = true;
            // 
            // colDisciplinas
            // 
            this.colDisciplinas.HeaderText = "DISCIPLINAS DIRIGIDAS";
            this.colDisciplinas.MinimumWidth = 6;
            this.colDisciplinas.Name = "colDisciplinas";
            this.colDisciplinas.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "EDITAR";
            this.colEditar.MinimumWidth = 6;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colIdTecnico
            // 
            this.colIdTecnico.HeaderText = "colIdTecnico";
            this.colIdTecnico.MinimumWidth = 6;
            this.colIdTecnico.Name = "colIdTecnico";
            this.colIdTecnico.ReadOnly = true;
            this.colIdTecnico.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(9, 164);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(207, 50);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar Nuevo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFusionar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFusionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionar.Location = new System.Drawing.Point(9, 296);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(207, 50);
            this.btnFusionar.TabIndex = 28;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9998634F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.97537F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.20197F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9999313F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFusionar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenarId, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreCompleto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenarAlfabeticamente, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpiar, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.950617F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // FrmGestionarTecnicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmGestionarTecnicos";
            this.Text = "FrmGestionarTecnicos";
            this.Load += new System.EventHandler(this.FrmGestionarTecnicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnOrdenarAlfabeticamente;
        private System.Windows.Forms.Button btnOrdenarId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisciplinas;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTecnico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}