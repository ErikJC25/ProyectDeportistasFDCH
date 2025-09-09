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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Técnicos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 53);
            this.panel1.TabIndex = 1;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreCompleto.Location = new System.Drawing.Point(12, 59);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(359, 25);
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
            this.btnBuscar.Location = new System.Drawing.Point(376, 60);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 24);
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
            this.btnLimpiar.Location = new System.Drawing.Point(474, 60);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnOrdenarAlfabeticamente
            // 
            this.btnOrdenarAlfabeticamente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarAlfabeticamente.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrdenarAlfabeticamente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarAlfabeticamente.FlatAppearance.BorderSize = 0;
            this.btnOrdenarAlfabeticamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarAlfabeticamente.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarAlfabeticamente.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarAlfabeticamente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarAlfabeticamente.Location = new System.Drawing.Point(588, 60);
            this.btnOrdenarAlfabeticamente.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarAlfabeticamente.Name = "btnOrdenarAlfabeticamente";
            this.btnOrdenarAlfabeticamente.Size = new System.Drawing.Size(147, 24);
            this.btnOrdenarAlfabeticamente.TabIndex = 23;
            this.btnOrdenarAlfabeticamente.Text = "Orden Alfabético";
            this.btnOrdenarAlfabeticamente.UseVisualStyleBackColor = false;
            this.btnOrdenarAlfabeticamente.Click += new System.EventHandler(this.btnOrdenarAlfabeticamente_Click);
            // 
            // btnOrdenarId
            // 
            this.btnOrdenarId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarId.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrdenarId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarId.FlatAppearance.BorderSize = 0;
            this.btnOrdenarId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarId.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarId.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarId.Location = new System.Drawing.Point(739, 60);
            this.btnOrdenarId.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarId.Name = "btnOrdenarId";
            this.btnOrdenarId.Size = new System.Drawing.Size(147, 24);
            this.btnOrdenarId.TabIndex = 25;
            this.btnOrdenarId.Text = "Orden Agregación";
            this.btnOrdenarId.UseVisualStyleBackColor = false;
            this.btnOrdenarId.Click += new System.EventHandler(this.btnOrdenarId_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colNombreCompleto,
            this.colDisciplinas,
            this.colEditar,
            this.colIdTecnico});
            this.dataGridView1.Location = new System.Drawing.Point(225, 348);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(660, 137);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "SELECCIONAR";
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.ReadOnly = true;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.HeaderText = "NOMBRE COMPLETO";
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.ReadOnly = true;
            this.colNombreCompleto.Width = 225;
            // 
            // colDisciplinas
            // 
            this.colDisciplinas.HeaderText = "DISCIPLINAS DIRIGIDAS";
            this.colDisciplinas.Name = "colDisciplinas";
            this.colDisciplinas.ReadOnly = true;
            this.colDisciplinas.Width = 200;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "EDITAR";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.Width = 75;
            // 
            // colIdTecnico
            // 
            this.colIdTecnico.HeaderText = "colIdTecnico";
            this.colIdTecnico.Name = "colIdTecnico";
            this.colIdTecnico.ReadOnly = true;
            this.colIdTecnico.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(12, 110);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(172, 41);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar Nuevo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFusionar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFusionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionar.Location = new System.Drawing.Point(12, 168);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(172, 41);
            this.btnFusionar.TabIndex = 28;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // FrmGestionarTecnicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 574);
            this.Controls.Add(this.btnFusionar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOrdenarId);
            this.Controls.Add(this.btnOrdenarAlfabeticamente);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionarTecnicos";
            this.Text = "FrmGestionarTecnicos";
            this.Load += new System.EventHandler(this.FrmGestionarTecnicos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
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
    }
}