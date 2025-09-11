namespace FDCH.UI.Vistas
{
    partial class FrmGestionarDeportistas
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
            this.label2 = new System.Windows.Forms.Label();
            this.txbNombres = new System.Windows.Forms.TextBox();
            this.txbApellidos = new System.Windows.Forms.TextBox();
            this.txbCedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOrdenarNombres = new System.Windows.Forms.Button();
            this.btnOrdenarApellidos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSeparar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisciplinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnFusionar = new System.Windows.Forms.Button();
            this.btnOrdenarId = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(199, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "o";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbNombres
            // 
            this.txbNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNombres.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombres.ForeColor = System.Drawing.Color.DarkGray;
            this.txbNombres.Location = new System.Drawing.Point(421, 54);
            this.txbNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txbNombres.Name = "txbNombres";
            this.txbNombres.Size = new System.Drawing.Size(204, 25);
            this.txbNombres.TabIndex = 11;
            this.txbNombres.Text = "NOMBRES";
            this.txbNombres.Enter += new System.EventHandler(this.txbNombres_Enter);
            this.txbNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNombres_KeyPress);
            this.txbNombres.Leave += new System.EventHandler(this.txbNombres_Leave);
            // 
            // txbApellidos
            // 
            this.txbApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbApellidos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApellidos.ForeColor = System.Drawing.Color.DarkGray;
            this.txbApellidos.Location = new System.Drawing.Point(222, 54);
            this.txbApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txbApellidos.Name = "txbApellidos";
            this.txbApellidos.Size = new System.Drawing.Size(195, 25);
            this.txbApellidos.TabIndex = 10;
            this.txbApellidos.Text = "APELLIDOS";
            this.txbApellidos.Enter += new System.EventHandler(this.txbApellidos_Enter);
            this.txbApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbApellidos_KeyPress);
            this.txbApellidos.Leave += new System.EventHandler(this.txbApellidos_Leave);
            // 
            // txbCedula
            // 
            this.txbCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbCedula.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCedula.ForeColor = System.Drawing.Color.DarkGray;
            this.txbCedula.Location = new System.Drawing.Point(10, 54);
            this.txbCedula.Margin = new System.Windows.Forms.Padding(2);
            this.txbCedula.Name = "txbCedula";
            this.txbCedula.Size = new System.Drawing.Size(185, 25);
            this.txbCedula.TabIndex = 9;
            this.txbCedula.Text = "CEDULA";
            this.txbCedula.Enter += new System.EventHandler(this.txbCedula_Enter);
            this.txbCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCedula_KeyPress);
            this.txbCedula.Leave += new System.EventHandler(this.txbCedula_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Green;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 9);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(897, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Deportistas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrdenarNombres
            // 
            this.btnOrdenarNombres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarNombres.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrdenarNombres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarNombres.FlatAppearance.BorderSize = 0;
            this.btnOrdenarNombres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarNombres.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarNombres.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarNombres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarNombres.Location = new System.Drawing.Point(14, 83);
            this.btnOrdenarNombres.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarNombres.Name = "btnOrdenarNombres";
            this.btnOrdenarNombres.Size = new System.Drawing.Size(176, 24);
            this.btnOrdenarNombres.TabIndex = 19;
            this.btnOrdenarNombres.Text = "Ordenar por Nombre";
            this.btnOrdenarNombres.UseVisualStyleBackColor = false;
            this.btnOrdenarNombres.Click += new System.EventHandler(this.btnOrdenarNombres_Click);
            // 
            // btnOrdenarApellidos
            // 
            this.btnOrdenarApellidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarApellidos.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOrdenarApellidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarApellidos.FlatAppearance.BorderSize = 0;
            this.btnOrdenarApellidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarApellidos.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarApellidos.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarApellidos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarApellidos.Location = new System.Drawing.Point(231, 83);
            this.btnOrdenarApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarApellidos.Name = "btnOrdenarApellidos";
            this.btnOrdenarApellidos.Size = new System.Drawing.Size(176, 24);
            this.btnOrdenarApellidos.TabIndex = 20;
            this.btnOrdenarApellidos.Text = "Ordenar por Apellido";
            this.btnOrdenarApellidos.UseVisualStyleBackColor = false;
            this.btnOrdenarApellidos.Click += new System.EventHandler(this.btnOrdenarApellidos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.215115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.71314F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.3556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36291F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.217239F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSeparar, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregar, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnFusionar, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txbNombres, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbApellidos, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbCedula, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenarNombres, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenarApellidos, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOrdenarId, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpiar, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(897, 574);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // btnSeparar
            // 
            this.btnSeparar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSeparar.AutoSize = true;
            this.btnSeparar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSeparar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeparar.FlatAppearance.BorderSize = 0;
            this.btnSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeparar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeparar.ForeColor = System.Drawing.Color.White;
            this.btnSeparar.Image = global::FDCH.UI.Properties.Resources.separar2;
            this.btnSeparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeparar.Location = new System.Drawing.Point(455, 516);
            this.btnSeparar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(136, 56);
            this.btnSeparar.TabIndex = 23;
            this.btnSeparar.Text = "Separar";
            this.btnSeparar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeparar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeparar.UseVisualStyleBackColor = false;
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colCedula,
            this.colNombres,
            this.colApellidos,
            this.colDisciplinas,
            this.colGenero,
            this.colTipoDiscapacidad,
            this.colEditar,
            this.colIdDeportista});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 9);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 109);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(897, 405);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.FillWeight = 70.10712F;
            this.colSeleccionar.HeaderText = "SELECCIONAR";
            this.colSeleccionar.MinimumWidth = 6;
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.ReadOnly = true;
            // 
            // colCedula
            // 
            this.colCedula.DataPropertyName = "cedula";
            this.colCedula.FillWeight = 92.04057F;
            this.colCedula.HeaderText = "CEDULA";
            this.colCedula.MinimumWidth = 6;
            this.colCedula.Name = "colCedula";
            this.colCedula.ReadOnly = true;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "nombres";
            this.colNombres.FillWeight = 139.7024F;
            this.colNombres.HeaderText = "NOMBRES";
            this.colNombres.MinimumWidth = 6;
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            // 
            // colApellidos
            // 
            this.colApellidos.DataPropertyName = "apellidos";
            this.colApellidos.FillWeight = 138.1022F;
            this.colApellidos.HeaderText = "APELLIDOS";
            this.colApellidos.MinimumWidth = 6;
            this.colApellidos.Name = "colApellidos";
            this.colApellidos.ReadOnly = true;
            // 
            // colDisciplinas
            // 
            this.colDisciplinas.FillWeight = 106.837F;
            this.colDisciplinas.HeaderText = "DISCIPLINAS PARTICIPADAS";
            this.colDisciplinas.MinimumWidth = 6;
            this.colDisciplinas.Name = "colDisciplinas";
            this.colDisciplinas.ReadOnly = true;
            // 
            // colGenero
            // 
            this.colGenero.DataPropertyName = "tipo_discapacidad";
            this.colGenero.FillWeight = 70.1357F;
            this.colGenero.HeaderText = "GENERO";
            this.colGenero.MinimumWidth = 6;
            this.colGenero.Name = "colGenero";
            this.colGenero.ReadOnly = true;
            // 
            // colTipoDiscapacidad
            // 
            this.colTipoDiscapacidad.DataPropertyName = "tipo_discapacidad";
            this.colTipoDiscapacidad.FillWeight = 116.8041F;
            this.colTipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.colTipoDiscapacidad.MinimumWidth = 6;
            this.colTipoDiscapacidad.Name = "colTipoDiscapacidad";
            this.colTipoDiscapacidad.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.FillWeight = 66.27096F;
            this.colEditar.HeaderText = "EDITAR";
            this.colEditar.MinimumWidth = 6;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colIdDeportista
            // 
            this.colIdDeportista.DataPropertyName = "id_deportista";
            this.colIdDeportista.HeaderText = "IdDeportista";
            this.colIdDeportista.MinimumWidth = 6;
            this.colIdDeportista.Name = "colIdDeportista";
            this.colIdDeportista.ReadOnly = true;
            this.colIdDeportista.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(16, 516);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(173, 56);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar Nuevo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFusionar.AutoSize = true;
            this.btnFusionar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFusionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionar.Location = new System.Drawing.Point(248, 516);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(143, 56);
            this.btnFusionar.TabIndex = 22;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
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
            this.btnOrdenarId.Location = new System.Drawing.Point(435, 83);
            this.btnOrdenarId.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarId.Name = "btnOrdenarId";
            this.btnOrdenarId.Size = new System.Drawing.Size(176, 24);
            this.btnOrdenarId.TabIndex = 24;
            this.btnOrdenarId.Text = "Orden Agregación";
            this.btnOrdenarId.UseVisualStyleBackColor = false;
            this.btnOrdenarId.Click += new System.EventHandler(this.btnOrdenarId_Click);
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
            this.btnLimpiar.Location = new System.Drawing.Point(847, 68);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.tableLayoutPanel1.SetRowSpan(this.btnLimpiar, 2);
            this.btnLimpiar.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(749, 68);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.tableLayoutPanel1.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(94, 24);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmGestionarDeportistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 574);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionarDeportistas";
            this.Text = "FrmGestionarDeportistas";
            this.Load += new System.EventHandler(this.FrmGestionarDeportistas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNombres;
        private System.Windows.Forms.TextBox txbApellidos;
        private System.Windows.Forms.TextBox txbCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrdenarNombres;
        private System.Windows.Forms.Button btnOrdenarApellidos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.Button btnSeparar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOrdenarId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisciplinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDiscapacidad;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDeportista;
    }
}