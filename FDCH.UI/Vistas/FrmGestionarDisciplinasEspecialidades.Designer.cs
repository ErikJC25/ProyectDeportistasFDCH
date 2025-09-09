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
            this.dgvDisciplinas = new System.Windows.Forms.DataGridView();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.btnOrdenarId = new System.Windows.Forms.Button();
            this.btnOrdenarAlfabeticamente = new System.Windows.Forms.Button();
            this.btnFusionarEspecialidades = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarDisc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeleccionarEsp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarEsp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDiscRelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDisciplinas
            // 
            this.dgvDisciplinas.AllowUserToAddRows = false;
            this.dgvDisciplinas.AllowUserToDeleteRows = false;
            this.dgvDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.colNombreDisciplina,
            this.colEditarDisc,
            this.colIdDisciplina});
            this.dgvDisciplinas.Location = new System.Drawing.Point(190, 94);
            this.dgvDisciplinas.MultiSelect = false;
            this.dgvDisciplinas.Name = "dgvDisciplinas";
            this.dgvDisciplinas.ReadOnly = true;
            this.dgvDisciplinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisciplinas.Size = new System.Drawing.Size(498, 177);
            this.dgvDisciplinas.TabIndex = 0;
            this.dgvDisciplinas.SelectionChanged += new System.EventHandler(this.dgvDisciplinas_SelectionChanged);
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
            this.dgvEspecialidades.Size = new System.Drawing.Size(567, 200);
            this.dgvEspecialidades.TabIndex = 1;
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick);
            this.dgvEspecialidades.SelectionChanged += new System.EventHandler(this.dgvEspecialidades_SelectionChanged);
            // 
            // btnOrdenarId
            // 
            this.btnOrdenarId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarId.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenarId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarId.FlatAppearance.BorderSize = 0;
            this.btnOrdenarId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarId.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarId.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenarId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarId.Location = new System.Drawing.Point(857, 136);
            this.btnOrdenarId.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarId.Name = "btnOrdenarId";
            this.btnOrdenarId.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenarId.TabIndex = 25;
            this.btnOrdenarId.Text = "Orden Agregación";
            this.btnOrdenarId.UseVisualStyleBackColor = false;
            this.btnOrdenarId.Click += new System.EventHandler(this.btnOrdenarId_Click);
            // 
            // btnOrdenarAlfabeticamente
            // 
            this.btnOrdenarAlfabeticamente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOrdenarAlfabeticamente.BackColor = System.Drawing.SystemColors.Control;
            this.btnOrdenarAlfabeticamente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarAlfabeticamente.FlatAppearance.BorderSize = 0;
            this.btnOrdenarAlfabeticamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarAlfabeticamente.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarAlfabeticamente.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnOrdenarAlfabeticamente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarAlfabeticamente.Location = new System.Drawing.Point(708, 136);
            this.btnOrdenarAlfabeticamente.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarAlfabeticamente.Name = "btnOrdenarAlfabeticamente";
            this.btnOrdenarAlfabeticamente.Size = new System.Drawing.Size(145, 28);
            this.btnOrdenarAlfabeticamente.TabIndex = 26;
            this.btnOrdenarAlfabeticamente.Text = "Orden Alfabético";
            this.btnOrdenarAlfabeticamente.UseVisualStyleBackColor = false;
            this.btnOrdenarAlfabeticamente.Click += new System.EventHandler(this.btnOrdenarAlfabeticamente_Click);
            // 
            // btnFusionarEspecialidades
            // 
            this.btnFusionarEspecialidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFusionarEspecialidades.BackColor = System.Drawing.SystemColors.Control;
            this.btnFusionarEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionarEspecialidades.FlatAppearance.BorderSize = 0;
            this.btnFusionarEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionarEspecialidades.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionarEspecialidades.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnFusionarEspecialidades.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionarEspecialidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionarEspecialidades.Location = new System.Drawing.Point(791, 347);
            this.btnFusionarEspecialidades.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionarEspecialidades.Name = "btnFusionarEspecialidades";
            this.btnFusionarEspecialidades.Size = new System.Drawing.Size(211, 41);
            this.btnFusionarEspecialidades.TabIndex = 27;
            this.btnFusionarEspecialidades.Text = "Fusionar Esp.";
            this.btnFusionarEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionarEspecialidades.UseVisualStyleBackColor = false;
            this.btnFusionarEspecialidades.Click += new System.EventHandler(this.btnFusionarEspecialidades_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvDisciplinas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 295);
            this.panel1.TabIndex = 28;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SandyBrown;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.btnLimpiar);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtNombreCompleto);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvEspecialidades);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnOrdenarId);
            this.panel2.Controls.Add(this.btnOrdenarAlfabeticamente);
            this.panel2.Controls.Add(this.btnFusionarEspecialidades);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 413);
            this.panel2.TabIndex = 29;
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
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.SandyBrown;
            this.btnAgregar.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(791, 292);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(211, 41);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.Text = "Agregar Nueva Esp.";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
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
            this.btnLimpiar.Location = new System.Drawing.Point(653, 138);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
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
            this.btnBuscar.Location = new System.Drawing.Point(555, 138);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 24);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombreCompleto.Location = new System.Drawing.Point(191, 137);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(359, 25);
            this.txtNombreCompleto.TabIndex = 31;
            this.txtNombreCompleto.Text = "NOMBRE ESPECIALIDAD";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.button1.Location = new System.Drawing.Point(653, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 24);
            this.button1.TabIndex = 36;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(555, 50);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 24);
            this.button2.TabIndex = 35;
            this.button2.Text = "Buscar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox1.Location = new System.Drawing.Point(190, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 25);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = "NOMBRE DISCIPLINA";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.SandyBrown;
            this.button3.Image = global::FDCH.UI.Properties.Resources.mas;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(791, 156);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 41);
            this.button3.TabIndex = 40;
            this.button3.Text = "Agregar Nueva Dis.";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.SandyBrown;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(857, 50);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 28);
            this.button4.TabIndex = 37;
            this.button4.Text = "Orden Agregación";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.SandyBrown;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(708, 50);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 28);
            this.button5.TabIndex = 38;
            this.button5.Text = "Orden Alfabético";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.SandyBrown;
            this.button6.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(791, 211);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(211, 41);
            this.button6.TabIndex = 39;
            this.button6.Text = "Fusionar Dis.";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(190, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(550, 26);
            this.comboBox1.TabIndex = 34;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "SELECCIONAR";
            this.checkbox.Name = "checkbox";
            this.checkbox.ReadOnly = true;
            this.checkbox.Width = 150;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDisciplinas;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.Button btnOrdenarId;
        private System.Windows.Forms.Button btnOrdenarAlfabeticamente;
        private System.Windows.Forms.Button btnFusionarEspecialidades;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreDisciplina;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDisciplina;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModalidad;
        private System.Windows.Forms.DataGridViewButtonColumn colEditarEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDiscRelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
    }
}