namespace FDCH.UI.Vistas
{
    partial class FrmGestionarDisciplinasEspecialidades
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
            this.btnFusionarEspecialidad = new System.Windows.Forms.Button();
            this.btnOrdenAlfabeticoEspecialidad = new System.Windows.Forms.Button();
            this.btnOrdenAgregacionEspecialidad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.colSeleccionarEsp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarEsp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDiscRelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.btnBuscarEspecialidad = new System.Windows.Forms.Button();
            this.btnLimpiarEspecialidad = new System.Windows.Forms.Button();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFusionarDisciplina = new System.Windows.Forms.Button();
            this.btnAgregarDisciplina = new System.Windows.Forms.Button();
            this.txtNombreDisciplina = new System.Windows.Forms.TextBox();
            this.btnOrdenAgregacionDisciplinas = new System.Windows.Forms.Button();
            this.dgvDisciplinas = new System.Windows.Forms.DataGridView();
            this.colSeleccionarDisc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarDisc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscarDisciplina = new System.Windows.Forms.Button();
            this.btnOrdenAlfabeticoDisciplinas = new System.Windows.Forms.Button();
            this.btnLimpiarDisciplina = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFusionarEspecialidad
            // 
            this.btnFusionarEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFusionarEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnFusionarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnFusionarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionarEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnFusionarEspecialidad.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionarEspecialidad.Location = new System.Drawing.Point(976, 329);
            this.btnFusionarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFusionarEspecialidad.Name = "btnFusionarEspecialidad";
            this.btnFusionarEspecialidad.Size = new System.Drawing.Size(218, 48);
            this.btnFusionarEspecialidad.TabIndex = 27;
            this.btnFusionarEspecialidad.Text = "Fusionar Esp.";
            this.btnFusionarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionarEspecialidad.UseVisualStyleBackColor = false;
            this.btnFusionarEspecialidad.Click += new System.EventHandler(this.btnFusionarEspecialidades_Click);
            // 
            // btnOrdenAlfabeticoEspecialidad
            // 
            this.btnOrdenAlfabeticoEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenAlfabeticoEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAlfabeticoEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAlfabeticoEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnOrdenAlfabeticoEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAlfabeticoEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAlfabeticoEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenAlfabeticoEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAlfabeticoEspecialidad.Location = new System.Drawing.Point(753, 106);
            this.btnOrdenAlfabeticoEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenAlfabeticoEspecialidad.Name = "btnOrdenAlfabeticoEspecialidad";
            this.btnOrdenAlfabeticoEspecialidad.Size = new System.Drawing.Size(217, 30);
            this.btnOrdenAlfabeticoEspecialidad.TabIndex = 26;
            this.btnOrdenAlfabeticoEspecialidad.Text = "Orden Alfabético";
            this.btnOrdenAlfabeticoEspecialidad.UseVisualStyleBackColor = false;
            this.btnOrdenAlfabeticoEspecialidad.Click += new System.EventHandler(this.btnOrdenarAlfabeticamente_Click);
            // 
            // btnOrdenAgregacionEspecialidad
            // 
            this.btnOrdenAgregacionEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenAgregacionEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAgregacionEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAgregacionEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnOrdenAgregacionEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAgregacionEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAgregacionEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenAgregacionEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAgregacionEspecialidad.Location = new System.Drawing.Point(976, 106);
            this.btnOrdenAgregacionEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenAgregacionEspecialidad.Name = "btnOrdenAgregacionEspecialidad";
            this.btnOrdenAgregacionEspecialidad.Size = new System.Drawing.Size(218, 30);
            this.btnOrdenAgregacionEspecialidad.TabIndex = 25;
            this.btnOrdenAgregacionEspecialidad.Text = "Orden Agregación";
            this.btnOrdenAgregacionEspecialidad.UseVisualStyleBackColor = false;
            this.btnOrdenAgregacionEspecialidad.Click += new System.EventHandler(this.btnOrdenarId_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 6);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1197, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestionar Especialidades";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionarEsp,
            this.colNombreEspecialidad,
            this.colModalidad,
            this.colEditarEsp,
            this.colIdDiscRelacion,
            this.colIdEspecialidad});
            this.tableLayoutPanel2.SetColumnSpan(this.dgvEspecialidades, 5);
            this.dgvEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEspecialidades.Location = new System.Drawing.Point(4, 144);
            this.dgvEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersVisible = false;
            this.dgvEspecialidades.RowHeadersWidth = 51;
            this.tableLayoutPanel2.SetRowSpan(this.dgvEspecialidades, 3);
            this.dgvEspecialidades.Size = new System.Drawing.Size(965, 248);
            this.dgvEspecialidades.TabIndex = 1;
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick);
            this.dgvEspecialidades.SelectionChanged += new System.EventHandler(this.dgvEspecialidades_SelectionChanged);
            // 
            // colSeleccionarEsp
            // 
            this.colSeleccionarEsp.HeaderText = "SELECCIONAR";
            this.colSeleccionarEsp.MinimumWidth = 6;
            this.colSeleccionarEsp.Name = "colSeleccionarEsp";
            this.colSeleccionarEsp.ReadOnly = true;
            // 
            // colNombreEspecialidad
            // 
            this.colNombreEspecialidad.HeaderText = "NOMBRE ESPECIALIDAD";
            this.colNombreEspecialidad.MinimumWidth = 6;
            this.colNombreEspecialidad.Name = "colNombreEspecialidad";
            this.colNombreEspecialidad.ReadOnly = true;
            // 
            // colModalidad
            // 
            this.colModalidad.HeaderText = "MODALIDAD";
            this.colModalidad.MinimumWidth = 6;
            this.colModalidad.Name = "colModalidad";
            this.colModalidad.ReadOnly = true;
            // 
            // colEditarEsp
            // 
            this.colEditarEsp.HeaderText = "EDITAR";
            this.colEditarEsp.MinimumWidth = 6;
            this.colEditarEsp.Name = "colEditarEsp";
            this.colEditarEsp.ReadOnly = true;
            this.colEditarEsp.Text = "Editar";
            this.colEditarEsp.UseColumnTextForButtonValue = true;
            // 
            // colIdDiscRelacion
            // 
            this.colIdDiscRelacion.HeaderText = "colIdDiscRelacion";
            this.colIdDiscRelacion.MinimumWidth = 6;
            this.colIdDiscRelacion.Name = "colIdDiscRelacion";
            this.colIdDiscRelacion.ReadOnly = true;
            this.colIdDiscRelacion.Visible = false;
            // 
            // colIdEspecialidad
            // 
            this.colIdEspecialidad.HeaderText = "colIdEspecialidad";
            this.colIdEspecialidad.MinimumWidth = 6;
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.ReadOnly = true;
            this.colIdEspecialidad.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 4);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(742, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seleccione una disciplina para mostrar sus especialidades";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnAgregarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnAgregarEspecialidad.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(976, 243);
            this.btnAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(218, 48);
            this.btnAgregarEspecialidad.TabIndex = 30;
            this.btnAgregarEspecialidad.Text = "Agregar Nueva Esp.";
            this.btnAgregarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = false;
            this.btnAgregarEspecialidad.Click += new System.EventHandler(this.btnAgregarEspecialidad_Click);
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreEspecialidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreEspecialidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreEspecialidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(4, 107);
            this.txtNombreEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(515, 29);
            this.txtNombreEspecialidad.TabIndex = 31;
            this.txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
            this.txtNombreEspecialidad.Enter += new System.EventHandler(this.txtNombreEspecialidad_Enter);
            this.txtNombreEspecialidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEspecialidad_KeyPress);
            this.txtNombreEspecialidad.Leave += new System.EventHandler(this.txtNombreEspecialidad_Leave);
            // 
            // btnBuscarEspecialidad
            // 
            this.btnBuscarEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnBuscarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEspecialidad.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarEspecialidad.Location = new System.Drawing.Point(526, 106);
            this.btnBuscarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarEspecialidad.Name = "btnBuscarEspecialidad";
            this.btnBuscarEspecialidad.Size = new System.Drawing.Size(125, 30);
            this.btnBuscarEspecialidad.TabIndex = 32;
            this.btnBuscarEspecialidad.Text = "Buscar";
            this.btnBuscarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarEspecialidad.UseVisualStyleBackColor = false;
            this.btnBuscarEspecialidad.Click += new System.EventHandler(this.btnBuscarEspecialidad_Click);
            // 
            // btnLimpiarEspecialidad
            // 
            this.btnLimpiarEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiarEspecialidad.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnLimpiarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarEspecialidad.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiarEspecialidad.Location = new System.Drawing.Point(657, 106);
            this.btnLimpiarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarEspecialidad.Name = "btnLimpiarEspecialidad";
            this.btnLimpiarEspecialidad.Size = new System.Drawing.Size(50, 30);
            this.btnLimpiarEspecialidad.TabIndex = 33;
            this.btnLimpiarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarEspecialidad.UseVisualStyleBackColor = false;
            this.btnLimpiarEspecialidad.Click += new System.EventHandler(this.btnLimpiarEspecialidad_Click);
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplinas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(4, 69);
            this.cmbDisciplinas.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(515, 30);
            this.cmbDisciplinas.TabIndex = 34;
            this.cmbDisciplinas.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplinas_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Tomato;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.84057F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.000044F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.07969F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.07969F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFusionarDisciplina, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarDisciplina, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreDisciplina, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenAgregacionDisciplinas, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDisciplinas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarDisciplina, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenAlfabeticoDisciplinas, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpiarDisciplina, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 316);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 6);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Disciplinas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFusionarDisciplina
            // 
            this.btnFusionarDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFusionarDisciplina.BackColor = System.Drawing.SystemColors.Control;
            this.btnFusionarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnFusionarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionarDisciplina.ForeColor = System.Drawing.Color.Tomato;
            this.btnFusionarDisciplina.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionarDisciplina.Location = new System.Drawing.Point(976, 251);
            this.btnFusionarDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFusionarDisciplina.Name = "btnFusionarDisciplina";
            this.btnFusionarDisciplina.Size = new System.Drawing.Size(218, 48);
            this.btnFusionarDisciplina.TabIndex = 39;
            this.btnFusionarDisciplina.Text = "Fusionar Dis.";
            this.btnFusionarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionarDisciplina.UseVisualStyleBackColor = false;
            this.btnFusionarDisciplina.Click += new System.EventHandler(this.btnFusionarDisciplina_Click);
            // 
            // btnAgregarDisciplina
            // 
            this.btnAgregarDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarDisciplina.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnAgregarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDisciplina.ForeColor = System.Drawing.Color.Tomato;
            this.btnAgregarDisciplina.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDisciplina.Location = new System.Drawing.Point(976, 171);
            this.btnAgregarDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarDisciplina.Name = "btnAgregarDisciplina";
            this.btnAgregarDisciplina.Size = new System.Drawing.Size(218, 48);
            this.btnAgregarDisciplina.TabIndex = 40;
            this.btnAgregarDisciplina.Text = "Agregar Nueva Dis.";
            this.btnAgregarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDisciplina.UseVisualStyleBackColor = false;
            this.btnAgregarDisciplina.Click += new System.EventHandler(this.btnAgregarDisciplina_Click);
            // 
            // txtNombreDisciplina
            // 
            this.txtNombreDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreDisciplina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreDisciplina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreDisciplina.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreDisciplina.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreDisciplina.Location = new System.Drawing.Point(4, 42);
            this.txtNombreDisciplina.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreDisciplina.Name = "txtNombreDisciplina";
            this.txtNombreDisciplina.Size = new System.Drawing.Size(515, 29);
            this.txtNombreDisciplina.TabIndex = 34;
            this.txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
            this.txtNombreDisciplina.Enter += new System.EventHandler(this.txtNombreDisciplina_Enter);
            this.txtNombreDisciplina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreDisciplina_KeyPress);
            this.txtNombreDisciplina.Leave += new System.EventHandler(this.txtNombreDisciplina_Leave);
            // 
            // btnOrdenAgregacionDisciplinas
            // 
            this.btnOrdenAgregacionDisciplinas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenAgregacionDisciplinas.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAgregacionDisciplinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAgregacionDisciplinas.FlatAppearance.BorderSize = 0;
            this.btnOrdenAgregacionDisciplinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAgregacionDisciplinas.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAgregacionDisciplinas.ForeColor = System.Drawing.Color.Tomato;
            this.btnOrdenAgregacionDisciplinas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAgregacionDisciplinas.Location = new System.Drawing.Point(976, 41);
            this.btnOrdenAgregacionDisciplinas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenAgregacionDisciplinas.Name = "btnOrdenAgregacionDisciplinas";
            this.btnOrdenAgregacionDisciplinas.Size = new System.Drawing.Size(218, 30);
            this.btnOrdenAgregacionDisciplinas.TabIndex = 37;
            this.btnOrdenAgregacionDisciplinas.Text = "Orden Agregación";
            this.btnOrdenAgregacionDisciplinas.UseVisualStyleBackColor = false;
            this.btnOrdenAgregacionDisciplinas.Click += new System.EventHandler(this.btnOrdenAgregacionDisciplinas_Click);
            // 
            // dgvDisciplinas
            // 
            this.dgvDisciplinas.AllowUserToAddRows = false;
            this.dgvDisciplinas.AllowUserToDeleteRows = false;
            this.dgvDisciplinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionarDisc,
            this.colNombreDisciplina,
            this.colEditarDisc,
            this.colIdDisciplina});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvDisciplinas, 5);
            this.dgvDisciplinas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisciplinas.Location = new System.Drawing.Point(4, 79);
            this.dgvDisciplinas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDisciplinas.MultiSelect = false;
            this.dgvDisciplinas.Name = "dgvDisciplinas";
            this.dgvDisciplinas.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dgvDisciplinas, 3);
            this.dgvDisciplinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisciplinas.Size = new System.Drawing.Size(965, 233);
            this.dgvDisciplinas.TabIndex = 0;
            this.dgvDisciplinas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisciplinas_CellContentClick);
            this.dgvDisciplinas.SelectionChanged += new System.EventHandler(this.dgvDisciplinas_SelectionChanged);
            // 
            // colSeleccionarDisc
            // 
            this.colSeleccionarDisc.HeaderText = "SELECCIONAR";
            this.colSeleccionarDisc.MinimumWidth = 6;
            this.colSeleccionarDisc.Name = "colSeleccionarDisc";
            this.colSeleccionarDisc.ReadOnly = true;
            // 
            // colNombreDisciplina
            // 
            this.colNombreDisciplina.HeaderText = "NOMBRE DISCIPLINA";
            this.colNombreDisciplina.MinimumWidth = 6;
            this.colNombreDisciplina.Name = "colNombreDisciplina";
            this.colNombreDisciplina.ReadOnly = true;
            // 
            // colEditarDisc
            // 
            this.colEditarDisc.HeaderText = "EDITAR";
            this.colEditarDisc.MinimumWidth = 6;
            this.colEditarDisc.Name = "colEditarDisc";
            this.colEditarDisc.ReadOnly = true;
            this.colEditarDisc.Text = "Editar";
            this.colEditarDisc.UseColumnTextForButtonValue = true;
            // 
            // colIdDisciplina
            // 
            this.colIdDisciplina.HeaderText = "colIdDisciplina";
            this.colIdDisciplina.MinimumWidth = 6;
            this.colIdDisciplina.Name = "colIdDisciplina";
            this.colIdDisciplina.ReadOnly = true;
            this.colIdDisciplina.Visible = false;
            // 
            // btnBuscarDisciplina
            // 
            this.btnBuscarDisciplina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarDisciplina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnBuscarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDisciplina.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDisciplina.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarDisciplina.Location = new System.Drawing.Point(526, 41);
            this.btnBuscarDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarDisciplina.Name = "btnBuscarDisciplina";
            this.btnBuscarDisciplina.Size = new System.Drawing.Size(125, 30);
            this.btnBuscarDisciplina.TabIndex = 35;
            this.btnBuscarDisciplina.Text = "Buscar";
            this.btnBuscarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarDisciplina.UseVisualStyleBackColor = false;
            this.btnBuscarDisciplina.Click += new System.EventHandler(this.btnBuscarDisciplina_Click);
            // 
            // btnOrdenAlfabeticoDisciplinas
            // 
            this.btnOrdenAlfabeticoDisciplinas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrdenAlfabeticoDisciplinas.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAlfabeticoDisciplinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAlfabeticoDisciplinas.FlatAppearance.BorderSize = 0;
            this.btnOrdenAlfabeticoDisciplinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAlfabeticoDisciplinas.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAlfabeticoDisciplinas.ForeColor = System.Drawing.Color.Tomato;
            this.btnOrdenAlfabeticoDisciplinas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAlfabeticoDisciplinas.Location = new System.Drawing.Point(753, 41);
            this.btnOrdenAlfabeticoDisciplinas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdenAlfabeticoDisciplinas.Name = "btnOrdenAlfabeticoDisciplinas";
            this.btnOrdenAlfabeticoDisciplinas.Size = new System.Drawing.Size(217, 30);
            this.btnOrdenAlfabeticoDisciplinas.TabIndex = 38;
            this.btnOrdenAlfabeticoDisciplinas.Text = "Orden Alfabético";
            this.btnOrdenAlfabeticoDisciplinas.UseVisualStyleBackColor = false;
            this.btnOrdenAlfabeticoDisciplinas.Click += new System.EventHandler(this.btnOrdenAlfabeticoDisciplinas_Click);
            // 
            // btnLimpiarDisciplina
            // 
            this.btnLimpiarDisciplina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiarDisciplina.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDisciplina.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarDisciplina.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiarDisciplina.Location = new System.Drawing.Point(657, 41);
            this.btnLimpiarDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarDisciplina.Name = "btnLimpiarDisciplina";
            this.btnLimpiarDisciplina.Size = new System.Drawing.Size(50, 30);
            this.btnLimpiarDisciplina.TabIndex = 36;
            this.btnLimpiarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDisciplina.UseVisualStyleBackColor = false;
            this.btnLimpiarDisciplina.Click += new System.EventHandler(this.btnLimpiarDisciplina_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.SandyBrown;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.84F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.08F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.08F));
            this.tableLayoutPanel2.Controls.Add(this.dgvEspecialidades, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnAgregarEspecialidad, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnFusionarEspecialidad, 5, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnLimpiarEspecialidad, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbDisciplinas, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnOrdenAgregacionEspecialidad, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnBuscarEspecialidad, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnOrdenAlfabeticoEspecialidad, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNombreEspecialidad, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 316);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1197, 396);
            this.tableLayoutPanel2.TabIndex = 42;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1197, 712);
            this.tableLayoutPanel3.TabIndex = 43;
            // 
            // FrmGestionarDisciplinasEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 712);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGestionarDisciplinasEspecialidades";
            this.Text = "FrmGestionarDisciplinasEspecialidades";
            this.Load += new System.EventHandler(this.FrmGestionarDisciplinasEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFusionarEspecialidad;
        private System.Windows.Forms.Button btnOrdenAlfabeticoEspecialidad;
        private System.Windows.Forms.Button btnOrdenAgregacionEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModalidad;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDiscRelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.Button btnLimpiarEspecialidad;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.Button btnBuscarEspecialidad;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFusionarDisciplina;
        private System.Windows.Forms.Button btnAgregarDisciplina;
        private System.Windows.Forms.TextBox txtNombreDisciplina;
        private System.Windows.Forms.Button btnOrdenAgregacionDisciplinas;
        private System.Windows.Forms.DataGridView dgvDisciplinas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionarDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreDisciplina;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDisciplina;
        private System.Windows.Forms.Button btnBuscarDisciplina;
        private System.Windows.Forms.Button btnOrdenAlfabeticoDisciplinas;
        private System.Windows.Forms.Button btnLimpiarDisciplina;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}