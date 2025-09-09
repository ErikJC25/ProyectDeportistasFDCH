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
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.colSeleccionarEsp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarEsp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDiscRelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrdenAgregacionEspecialidad = new System.Windows.Forms.Button();
            this.btnOrdenAlfabeticoEspecialidad = new System.Windows.Forms.Button();
            this.btnFusionarEspecialidad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarDisciplina = new System.Windows.Forms.Button();
            this.btnOrdenAgregacionDisciplinas = new System.Windows.Forms.Button();
            this.btnOrdenAlfabeticoDisciplinas = new System.Windows.Forms.Button();
            this.btnFusionarDisciplina = new System.Windows.Forms.Button();
            this.btnLimpiarDisciplina = new System.Windows.Forms.Button();
            this.btnBuscarDisciplina = new System.Windows.Forms.Button();
            this.txtNombreDisciplina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDisciplinas = new System.Windows.Forms.DataGridView();
            this.colSeleccionarDisc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarDisc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDisciplinas = new System.Windows.Forms.ComboBox();
            this.btnLimpiarEspecialidad = new System.Windows.Forms.Button();
            this.btnBuscarEspecialidad = new System.Windows.Forms.Button();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionarEsp,
            this.colNombreEspecialidad,
            this.colModalidad,
            this.colEditarEsp,
            this.colIdDiscRelacion,
            this.colIdEspecialidad});
            this.dgvEspecialidades.Location = new System.Drawing.Point(191, 188);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersVisible = false;
            this.dgvEspecialidades.Size = new System.Drawing.Size(567, 200);
            this.dgvEspecialidades.TabIndex = 1;
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick);
            this.dgvEspecialidades.SelectionChanged += new System.EventHandler(this.dgvEspecialidades_SelectionChanged);
            // 
            // colSeleccionarEsp
            // 
            this.colSeleccionarEsp.HeaderText = "SELECCIONAR";
            this.colSeleccionarEsp.Name = "colSeleccionarEsp";
            this.colSeleccionarEsp.ReadOnly = true;
            // 
            // colNombreEspecialidad
            // 
            this.colNombreEspecialidad.HeaderText = "NOMBRE ESPECIALIDAD";
            this.colNombreEspecialidad.Name = "colNombreEspecialidad";
            this.colNombreEspecialidad.ReadOnly = true;
            this.colNombreEspecialidad.Width = 175;
            // 
            // colModalidad
            // 
            this.colModalidad.HeaderText = "MODALIDAD";
            this.colModalidad.Name = "colModalidad";
            this.colModalidad.ReadOnly = true;
            this.colModalidad.Width = 150;
            // 
            // colEditarEsp
            // 
            this.colEditarEsp.HeaderText = "EDITAR";
            this.colEditarEsp.Name = "colEditarEsp";
            this.colEditarEsp.ReadOnly = true;
            this.colEditarEsp.Text = "Editar";
            this.colEditarEsp.UseColumnTextForButtonValue = true;
            this.colEditarEsp.Width = 75;
            // 
            // colIdDiscRelacion
            // 
            this.colIdDiscRelacion.HeaderText = "colIdDiscRelacion";
            this.colIdDiscRelacion.Name = "colIdDiscRelacion";
            this.colIdDiscRelacion.ReadOnly = true;
            this.colIdDiscRelacion.Visible = false;
            // 
            // colIdEspecialidad
            // 
            this.colIdEspecialidad.HeaderText = "colIdEspecialidad";
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.ReadOnly = true;
            this.colIdEspecialidad.Visible = false;
            // 
            // btnOrdenAgregacionEspecialidad
            // 
            this.btnOrdenAgregacionEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenAgregacionEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAgregacionEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAgregacionEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnOrdenAgregacionEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAgregacionEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAgregacionEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenAgregacionEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAgregacionEspecialidad.Location = new System.Drawing.Point(857, 136);
            this.btnOrdenAgregacionEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenAgregacionEspecialidad.Name = "btnOrdenAgregacionEspecialidad";
            this.btnOrdenAgregacionEspecialidad.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenAgregacionEspecialidad.TabIndex = 25;
            this.btnOrdenAgregacionEspecialidad.Text = "Orden Agregación";
            this.btnOrdenAgregacionEspecialidad.UseVisualStyleBackColor = false;
            this.btnOrdenAgregacionEspecialidad.Click += new System.EventHandler(this.btnOrdenarId_Click);
            // 
            // btnOrdenAlfabeticoEspecialidad
            // 
            this.btnOrdenAlfabeticoEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenAlfabeticoEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAlfabeticoEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAlfabeticoEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnOrdenAlfabeticoEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAlfabeticoEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAlfabeticoEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenAlfabeticoEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAlfabeticoEspecialidad.Location = new System.Drawing.Point(708, 136);
            this.btnOrdenAlfabeticoEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenAlfabeticoEspecialidad.Name = "btnOrdenAlfabeticoEspecialidad";
            this.btnOrdenAlfabeticoEspecialidad.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenAlfabeticoEspecialidad.TabIndex = 26;
            this.btnOrdenAlfabeticoEspecialidad.Text = "Orden Alfabético";
            this.btnOrdenAlfabeticoEspecialidad.UseVisualStyleBackColor = false;
            this.btnOrdenAlfabeticoEspecialidad.Click += new System.EventHandler(this.btnOrdenarAlfabeticamente_Click);
            // 
            // btnFusionarEspecialidad
            // 
            this.btnFusionarEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFusionarEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnFusionarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnFusionarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionarEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnFusionarEspecialidad.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionarEspecialidad.Location = new System.Drawing.Point(791, 347);
            this.btnFusionarEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionarEspecialidad.Name = "btnFusionarEspecialidad";
            this.btnFusionarEspecialidad.Size = new System.Drawing.Size(211, 41);
            this.btnFusionarEspecialidad.TabIndex = 27;
            this.btnFusionarEspecialidad.Text = "Fusionar Esp.";
            this.btnFusionarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionarEspecialidad.UseVisualStyleBackColor = false;
            this.btnFusionarEspecialidad.Click += new System.EventHandler(this.btnFusionarEspecialidades_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.btnAgregarDisciplina);
            this.panel1.Controls.Add(this.btnOrdenAgregacionDisciplinas);
            this.panel1.Controls.Add(this.btnOrdenAlfabeticoDisciplinas);
            this.panel1.Controls.Add(this.btnFusionarDisciplina);
            this.panel1.Controls.Add(this.btnLimpiarDisciplina);
            this.panel1.Controls.Add(this.btnBuscarDisciplina);
            this.panel1.Controls.Add(this.txtNombreDisciplina);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvDisciplinas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 295);
            this.panel1.TabIndex = 28;
            // 
            // btnAgregarDisciplina
            // 
            this.btnAgregarDisciplina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarDisciplina.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnAgregarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDisciplina.ForeColor = System.Drawing.Color.Tomato;
            this.btnAgregarDisciplina.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDisciplina.Location = new System.Drawing.Point(791, 176);
            this.btnAgregarDisciplina.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarDisciplina.Name = "btnAgregarDisciplina";
            this.btnAgregarDisciplina.Size = new System.Drawing.Size(211, 41);
            this.btnAgregarDisciplina.TabIndex = 40;
            this.btnAgregarDisciplina.Text = "Agregar Nueva Dis.";
            this.btnAgregarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDisciplina.UseVisualStyleBackColor = false;
            this.btnAgregarDisciplina.Click += new System.EventHandler(this.btnAgregarDisciplina_Click);
            // 
            // btnOrdenAgregacionDisciplinas
            // 
            this.btnOrdenAgregacionDisciplinas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenAgregacionDisciplinas.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAgregacionDisciplinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAgregacionDisciplinas.FlatAppearance.BorderSize = 0;
            this.btnOrdenAgregacionDisciplinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAgregacionDisciplinas.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAgregacionDisciplinas.ForeColor = System.Drawing.Color.Tomato;
            this.btnOrdenAgregacionDisciplinas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAgregacionDisciplinas.Location = new System.Drawing.Point(857, 50);
            this.btnOrdenAgregacionDisciplinas.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenAgregacionDisciplinas.Name = "btnOrdenAgregacionDisciplinas";
            this.btnOrdenAgregacionDisciplinas.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenAgregacionDisciplinas.TabIndex = 37;
            this.btnOrdenAgregacionDisciplinas.Text = "Orden Agregación";
            this.btnOrdenAgregacionDisciplinas.UseVisualStyleBackColor = false;
            this.btnOrdenAgregacionDisciplinas.Click += new System.EventHandler(this.btnOrdenAgregacionDisciplinas_Click);
            // 
            // btnOrdenAlfabeticoDisciplinas
            // 
            this.btnOrdenAlfabeticoDisciplinas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenAlfabeticoDisciplinas.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenAlfabeticoDisciplinas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAlfabeticoDisciplinas.FlatAppearance.BorderSize = 0;
            this.btnOrdenAlfabeticoDisciplinas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAlfabeticoDisciplinas.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenAlfabeticoDisciplinas.ForeColor = System.Drawing.Color.Tomato;
            this.btnOrdenAlfabeticoDisciplinas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenAlfabeticoDisciplinas.Location = new System.Drawing.Point(708, 50);
            this.btnOrdenAlfabeticoDisciplinas.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenAlfabeticoDisciplinas.Name = "btnOrdenAlfabeticoDisciplinas";
            this.btnOrdenAlfabeticoDisciplinas.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenAlfabeticoDisciplinas.TabIndex = 38;
            this.btnOrdenAlfabeticoDisciplinas.Text = "Orden Alfabético";
            this.btnOrdenAlfabeticoDisciplinas.UseVisualStyleBackColor = false;
            this.btnOrdenAlfabeticoDisciplinas.Click += new System.EventHandler(this.btnOrdenAlfabeticoDisciplinas_Click);
            // 
            // btnFusionarDisciplina
            // 
            this.btnFusionarDisciplina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFusionarDisciplina.BackColor = System.Drawing.SystemColors.Control;
            this.btnFusionarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnFusionarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionarDisciplina.ForeColor = System.Drawing.Color.Tomato;
            this.btnFusionarDisciplina.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionarDisciplina.Location = new System.Drawing.Point(791, 230);
            this.btnFusionarDisciplina.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionarDisciplina.Name = "btnFusionarDisciplina";
            this.btnFusionarDisciplina.Size = new System.Drawing.Size(211, 41);
            this.btnFusionarDisciplina.TabIndex = 39;
            this.btnFusionarDisciplina.Text = "Fusionar Dis.";
            this.btnFusionarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionarDisciplina.UseVisualStyleBackColor = false;
            this.btnFusionarDisciplina.Click += new System.EventHandler(this.btnFusionarDisciplina_Click);
            // 
            // btnLimpiarDisciplina
            // 
            this.btnLimpiarDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarDisciplina.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnLimpiarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarDisciplina.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarDisciplina.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiarDisciplina.Location = new System.Drawing.Point(653, 50);
            this.btnLimpiarDisciplina.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarDisciplina.Name = "btnLimpiarDisciplina";
            this.btnLimpiarDisciplina.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiarDisciplina.TabIndex = 36;
            this.btnLimpiarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarDisciplina.UseVisualStyleBackColor = false;
            this.btnLimpiarDisciplina.Click += new System.EventHandler(this.btnLimpiarDisciplina_Click);
            // 
            // btnBuscarDisciplina
            // 
            this.btnBuscarDisciplina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarDisciplina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarDisciplina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDisciplina.FlatAppearance.BorderSize = 0;
            this.btnBuscarDisciplina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDisciplina.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDisciplina.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDisciplina.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscarDisciplina.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarDisciplina.Location = new System.Drawing.Point(555, 50);
            this.btnBuscarDisciplina.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarDisciplina.Name = "btnBuscarDisciplina";
            this.btnBuscarDisciplina.Size = new System.Drawing.Size(94, 24);
            this.btnBuscarDisciplina.TabIndex = 35;
            this.btnBuscarDisciplina.Text = "Buscar";
            this.btnBuscarDisciplina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarDisciplina.UseVisualStyleBackColor = false;
            this.btnBuscarDisciplina.Click += new System.EventHandler(this.btnBuscarDisciplina_Click);
            // 
            // txtNombreDisciplina
            // 
            this.txtNombreDisciplina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreDisciplina.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreDisciplina.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreDisciplina.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreDisciplina.Location = new System.Drawing.Point(190, 49);
            this.txtNombreDisciplina.Name = "txtNombreDisciplina";
            this.txtNombreDisciplina.Size = new System.Drawing.Size(360, 25);
            this.txtNombreDisciplina.TabIndex = 34;
            this.txtNombreDisciplina.Text = "NOMBRE DISCIPLINA";
            this.txtNombreDisciplina.Enter += new System.EventHandler(this.txtNombreDisciplina_Enter);
            this.txtNombreDisciplina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreDisciplina_KeyPress);
            this.txtNombreDisciplina.Leave += new System.EventHandler(this.txtNombreDisciplina_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(458, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Disciplinas";
            // 
            // dgvDisciplinas
            // 
            this.dgvDisciplinas.AllowUserToAddRows = false;
            this.dgvDisciplinas.AllowUserToDeleteRows = false;
            this.dgvDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionarDisc,
            this.colNombreDisciplina,
            this.colEditarDisc,
            this.colIdDisciplina});
            this.dgvDisciplinas.Location = new System.Drawing.Point(190, 94);
            this.dgvDisciplinas.MultiSelect = false;
            this.dgvDisciplinas.Name = "dgvDisciplinas";
            this.dgvDisciplinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisciplinas.Size = new System.Drawing.Size(459, 177);
            this.dgvDisciplinas.TabIndex = 0;
            this.dgvDisciplinas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisciplinas_CellContentClick);
            this.dgvDisciplinas.SelectionChanged += new System.EventHandler(this.dgvDisciplinas_SelectionChanged);
            // 
            // colSeleccionarDisc
            // 
            this.colSeleccionarDisc.HeaderText = "SELECCIONAR";
            this.colSeleccionarDisc.Name = "colSeleccionarDisc";
            this.colSeleccionarDisc.ReadOnly = true;
            // 
            // colNombreDisciplina
            // 
            this.colNombreDisciplina.HeaderText = "NOMBRE DISCIPLINA";
            this.colNombreDisciplina.Name = "colNombreDisciplina";
            this.colNombreDisciplina.ReadOnly = true;
            this.colNombreDisciplina.Width = 200;
            // 
            // colEditarDisc
            // 
            this.colEditarDisc.HeaderText = "EDITAR";
            this.colEditarDisc.Name = "colEditarDisc";
            this.colEditarDisc.ReadOnly = true;
            this.colEditarDisc.Text = "Editar";
            this.colEditarDisc.UseColumnTextForButtonValue = true;
            this.colEditarDisc.Width = 75;
            // 
            // colIdDisciplina
            // 
            this.colIdDisciplina.HeaderText = "colIdDisciplina";
            this.colIdDisciplina.Name = "colIdDisciplina";
            this.colIdDisciplina.ReadOnly = true;
            this.colIdDisciplina.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SandyBrown;
            this.panel2.Controls.Add(this.cmbDisciplinas);
            this.panel2.Controls.Add(this.btnLimpiarEspecialidad);
            this.panel2.Controls.Add(this.btnBuscarEspecialidad);
            this.panel2.Controls.Add(this.txtNombreEspecialidad);
            this.panel2.Controls.Add(this.btnAgregarEspecialidad);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvEspecialidades);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnOrdenAgregacionEspecialidad);
            this.panel2.Controls.Add(this.btnOrdenAlfabeticoEspecialidad);
            this.panel2.Controls.Add(this.btnFusionarEspecialidad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 413);
            this.panel2.TabIndex = 29;
            // 
            // cmbDisciplinas
            // 
            this.cmbDisciplinas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplinas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.cmbDisciplinas.FormattingEnabled = true;
            this.cmbDisciplinas.Location = new System.Drawing.Point(190, 83);
            this.cmbDisciplinas.Name = "cmbDisciplinas";
            this.cmbDisciplinas.Size = new System.Drawing.Size(550, 26);
            this.cmbDisciplinas.TabIndex = 34;
            this.cmbDisciplinas.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplinas_SelectedIndexChanged);
            // 
            // btnLimpiarEspecialidad
            // 
            this.btnLimpiarEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarEspecialidad.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnLimpiarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarEspecialidad.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiarEspecialidad.Location = new System.Drawing.Point(653, 138);
            this.btnLimpiarEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarEspecialidad.Name = "btnLimpiarEspecialidad";
            this.btnLimpiarEspecialidad.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiarEspecialidad.TabIndex = 33;
            this.btnLimpiarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiarEspecialidad.UseVisualStyleBackColor = false;
            this.btnLimpiarEspecialidad.Click += new System.EventHandler(this.btnLimpiarEspecialidad_Click);
            // 
            // btnBuscarEspecialidad
            // 
            this.btnBuscarEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnBuscarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEspecialidad.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarEspecialidad.Location = new System.Drawing.Point(555, 138);
            this.btnBuscarEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarEspecialidad.Name = "btnBuscarEspecialidad";
            this.btnBuscarEspecialidad.Size = new System.Drawing.Size(94, 24);
            this.btnBuscarEspecialidad.TabIndex = 32;
            this.btnBuscarEspecialidad.Text = "Buscar";
            this.btnBuscarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarEspecialidad.UseVisualStyleBackColor = false;
            this.btnBuscarEspecialidad.Click += new System.EventHandler(this.btnBuscarEspecialidad_Click);
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreEspecialidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreEspecialidad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreEspecialidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(191, 137);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(359, 25);
            this.txtNombreEspecialidad.TabIndex = 31;
            this.txtNombreEspecialidad.Text = "NOMBRE ESPECIALIDAD";
            this.txtNombreEspecialidad.Enter += new System.EventHandler(this.txtNombreEspecialidad_Enter);
            this.txtNombreEspecialidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEspecialidad_KeyPress);
            this.txtNombreEspecialidad.Leave += new System.EventHandler(this.txtNombreEspecialidad_Leave);
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarEspecialidad.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnAgregarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEspecialidad.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEspecialidad.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnAgregarEspecialidad.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregarEspecialidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(791, 292);
            this.btnAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(211, 41);
            this.btnAgregarEspecialidad.TabIndex = 30;
            this.btnAgregarEspecialidad.Text = "Agregar Nueva Esp.";
            this.btnAgregarEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = false;
            this.btnAgregarEspecialidad.Click += new System.EventHandler(this.btnAgregarEspecialidad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(186, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(554, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seleccione una disciplina para mostrar sus especialidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(447, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestionar Especialidades";
            // 
            // FrmGestionarDisciplinasEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionarDisciplinasEspecialidades";
            this.Text = "FrmGestionarDisciplinasEspecialidades";
            this.Load += new System.EventHandler(this.FrmGestionarDisciplinasEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.Button btnOrdenAgregacionEspecialidad;
        private System.Windows.Forms.Button btnOrdenAlfabeticoEspecialidad;
        private System.Windows.Forms.Button btnFusionarEspecialidad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.Button btnLimpiarEspecialidad;
        private System.Windows.Forms.Button btnBuscarEspecialidad;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Button btnLimpiarDisciplina;
        private System.Windows.Forms.Button btnBuscarDisciplina;
        private System.Windows.Forms.TextBox txtNombreDisciplina;
        private System.Windows.Forms.Button btnAgregarDisciplina;
        private System.Windows.Forms.Button btnOrdenAgregacionDisciplinas;
        private System.Windows.Forms.Button btnOrdenAlfabeticoDisciplinas;
        private System.Windows.Forms.Button btnFusionarDisciplina;
        private System.Windows.Forms.ComboBox cmbDisciplinas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModalidad;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDiscRelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridView dgvDisciplinas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionarDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreDisciplina;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDisciplina;
    }
}