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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisciplinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOrdenarNombres = new System.Windows.Forms.Button();
            this.btnOrdenarApellidos = new System.Windows.Forms.Button();
            this.btnSeparar = new System.Windows.Forms.Button();
            this.btnFusionar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(150, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "o";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbNombres
            // 
            this.txbNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNombres.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombres.ForeColor = System.Drawing.Color.DarkGray;
            this.txbNombres.Location = new System.Drawing.Point(386, 74);
            this.txbNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txbNombres.Name = "txbNombres";
            this.txbNombres.Size = new System.Drawing.Size(209, 25);
            this.txbNombres.TabIndex = 11;
            this.txbNombres.Text = "NOMBRES";
            this.txbNombres.Enter += new System.EventHandler(this.txbNombres_Enter);
            this.txbNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNombres_KeyPress);
            this.txbNombres.Leave += new System.EventHandler(this.txbNombres_Leave);
            // 
            // txbApellidos
            // 
            this.txbApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbApellidos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApellidos.ForeColor = System.Drawing.Color.DarkGray;
            this.txbApellidos.Location = new System.Drawing.Point(173, 74);
            this.txbApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txbApellidos.Name = "txbApellidos";
            this.txbApellidos.Size = new System.Drawing.Size(209, 25);
            this.txbApellidos.TabIndex = 10;
            this.txbApellidos.Text = "APELLIDOS";
            this.txbApellidos.Enter += new System.EventHandler(this.txbApellidos_Enter);
            this.txbApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbApellidos_KeyPress);
            this.txbApellidos.Leave += new System.EventHandler(this.txbApellidos_Leave);
            // 
            // txbCedula
            // 
            this.txbCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txbCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbCedula.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCedula.ForeColor = System.Drawing.Color.DarkGray;
            this.txbCedula.Location = new System.Drawing.Point(15, 74);
            this.txbCedula.Margin = new System.Windows.Forms.Padding(2);
            this.txbCedula.Name = "txbCedula";
            this.txbCedula.Size = new System.Drawing.Size(131, 25);
            this.txbCedula.TabIndex = 9;
            this.txbCedula.Text = "CEDULA";
            this.txbCedula.Enter += new System.EventHandler(this.txbCedula_Enter);
            this.txbCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCedula_KeyPress);
            this.txbCedula.Leave += new System.EventHandler(this.txbCedula_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionar,
            this.colCedula,
            this.colNombres,
            this.colApellidos,
            this.colDisciplinas,
            this.colGenero,
            this.colDiscapacidad,
            this.colEditar,
            this.colIdDeportista});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(957, 396);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.HeaderText = "SELECCIONAR";
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.ReadOnly = true;
            this.colSeleccionar.Width = 90;
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
            // colDiscapacidad
            // 
            this.colDiscapacidad.DataPropertyName = "tipo_discapacidad";
            this.colDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.colDiscapacidad.Name = "colDiscapacidad";
            this.colDiscapacidad.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "EDITAR";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.Width = 70;
            // 
            // colIdDeportista
            // 
            this.colIdDeportista.DataPropertyName = "id_deportista";
            this.colIdDeportista.HeaderText = "IdDeportista";
            this.colIdDeportista.Name = "colIdDeportista";
            this.colIdDeportista.ReadOnly = true;
            this.colIdDeportista.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 55);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestionar Deportistas";
            // 
            // btnOrdenarNombres
            // 
            this.btnOrdenarNombres.BackColor = System.Drawing.Color.Green;
            this.btnOrdenarNombres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarNombres.FlatAppearance.BorderSize = 0;
            this.btnOrdenarNombres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarNombres.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarNombres.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarNombres.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarNombres.Location = new System.Drawing.Point(768, 59);
            this.btnOrdenarNombres.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarNombres.Name = "btnOrdenarNombres";
            this.btnOrdenarNombres.Size = new System.Drawing.Size(166, 24);
            this.btnOrdenarNombres.TabIndex = 19;
            this.btnOrdenarNombres.Text = "Ordenar por Nombre";
            this.btnOrdenarNombres.UseVisualStyleBackColor = false;
            this.btnOrdenarNombres.Click += new System.EventHandler(this.btnOrdenarNombres_Click);
            // 
            // btnOrdenarApellidos
            // 
            this.btnOrdenarApellidos.BackColor = System.Drawing.Color.Green;
            this.btnOrdenarApellidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenarApellidos.FlatAppearance.BorderSize = 0;
            this.btnOrdenarApellidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenarApellidos.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenarApellidos.ForeColor = System.Drawing.Color.White;
            this.btnOrdenarApellidos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrdenarApellidos.Location = new System.Drawing.Point(768, 87);
            this.btnOrdenarApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenarApellidos.Name = "btnOrdenarApellidos";
            this.btnOrdenarApellidos.Size = new System.Drawing.Size(166, 24);
            this.btnOrdenarApellidos.TabIndex = 20;
            this.btnOrdenarApellidos.Text = "Ordenar por Apellido";
            this.btnOrdenarApellidos.UseVisualStyleBackColor = false;
            this.btnOrdenarApellidos.Click += new System.EventHandler(this.btnOrdenarApellidos_Click);
            // 
            // btnSeparar
            // 
            this.btnSeparar.BackColor = System.Drawing.Color.Green;
            this.btnSeparar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeparar.FlatAppearance.BorderSize = 0;
            this.btnSeparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeparar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeparar.ForeColor = System.Drawing.Color.White;
            this.btnSeparar.Image = global::FDCH.UI.Properties.Resources.separar2;
            this.btnSeparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeparar.Location = new System.Drawing.Point(800, 518);
            this.btnSeparar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(134, 43);
            this.btnSeparar.TabIndex = 23;
            this.btnSeparar.Text = "Separar";
            this.btnSeparar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeparar.UseVisualStyleBackColor = false;
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnFusionar
            // 
            this.btnFusionar.BackColor = System.Drawing.Color.Green;
            this.btnFusionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFusionar.FlatAppearance.BorderSize = 0;
            this.btnFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusionar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusionar.ForeColor = System.Drawing.Color.White;
            this.btnFusionar.Image = global::FDCH.UI.Properties.Resources.fusionar2;
            this.btnFusionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFusionar.Location = new System.Drawing.Point(607, 518);
            this.btnFusionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFusionar.Name = "btnFusionar";
            this.btnFusionar.Size = new System.Drawing.Size(134, 43);
            this.btnFusionar.TabIndex = 22;
            this.btnFusionar.Text = "Fusionar";
            this.btnFusionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFusionar.UseVisualStyleBackColor = false;
            this.btnFusionar.Click += new System.EventHandler(this.btnFusionar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::FDCH.UI.Properties.Resources.mas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(11, 518);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(182, 40);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar Nuevo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = global::FDCH.UI.Properties.Resources.limpiar;
            this.btnLimpiar.Location = new System.Drawing.Point(706, 78);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(35, 24);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::FDCH.UI.Properties.Resources.busqueda;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(608, 78);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
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
            this.ClientSize = new System.Drawing.Size(957, 566);
            this.Controls.Add(this.btnSeparar);
            this.Controls.Add(this.btnFusionar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnOrdenarApellidos);
            this.Controls.Add(this.btnOrdenarNombres);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNombres);
            this.Controls.Add(this.txbApellidos);
            this.Controls.Add(this.txbCedula);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionarDeportistas";
            this.Text = "FrmGestionarDeportistas";
            this.Load += new System.EventHandler(this.FrmGestionarDeportistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNombres;
        private System.Windows.Forms.TextBox txbApellidos;
        private System.Windows.Forms.TextBox txbCedula;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisciplinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscapacidad;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDeportista;
        private System.Windows.Forms.Button btnOrdenarNombres;
        private System.Windows.Forms.Button btnOrdenarApellidos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnFusionar;
        private System.Windows.Forms.Button btnSeparar;
    }
}