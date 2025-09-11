namespace FDCH.UI.Vistas
{
    partial class FrmFiltrar
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCompetencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDesempeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreDisciplina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesInicioEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioInicioEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NivelEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompletoTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Division = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroParticipantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDiscapacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.chkAntiguoActual = new System.Windows.Forms.CheckBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.chkFemenino = new System.Windows.Forms.CheckBox();
            this.chkAlfabeticamente = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportarWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 11);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1196, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar Información";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTecnico,
            this.IdEvento,
            this.IdDisciplina,
            this.IdEspecialidad,
            this.IdCompetencia,
            this.IdDesempeno,
            this.NombreDisciplina,
            this.NombreEvento,
            this.MesInicioEvento,
            this.Cedula,
            this.Apellidos,
            this.Nombres,
            this.AnioInicioEvento,
            this.FechaInicio,
            this.FechaFin,
            this.Lugar,
            this.Genero,
            this.NivelEvento,
            this.Modalidad,
            this.NombreCompletoTecnico,
            this.TipoEvento,
            this.Categoria,
            this.Division,
            this.NombreEspecialidad,
            this.Tiempo,
            this.Record,
            this.Ubicacion,
            this.Puntos,
            this.NumeroParticipantes,
            this.Medalla,
            this.TipoDiscapacidad,
            this.Observaciones,
            this.colEditar});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 11);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 141);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 567);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IdTecnico
            // 
            this.IdTecnico.DataPropertyName = "IdTecnico";
            this.IdTecnico.HeaderText = "IdTecnico";
            this.IdTecnico.MinimumWidth = 6;
            this.IdTecnico.Name = "IdTecnico";
            this.IdTecnico.ReadOnly = true;
            this.IdTecnico.Visible = false;
            this.IdTecnico.Width = 125;
            // 
            // IdEvento
            // 
            this.IdEvento.DataPropertyName = "IdEvento";
            this.IdEvento.HeaderText = "IdEvento";
            this.IdEvento.MinimumWidth = 6;
            this.IdEvento.Name = "IdEvento";
            this.IdEvento.ReadOnly = true;
            this.IdEvento.Visible = false;
            this.IdEvento.Width = 125;
            // 
            // IdDisciplina
            // 
            this.IdDisciplina.DataPropertyName = "IdDisciplina";
            this.IdDisciplina.HeaderText = "IdDisciplina";
            this.IdDisciplina.MinimumWidth = 6;
            this.IdDisciplina.Name = "IdDisciplina";
            this.IdDisciplina.ReadOnly = true;
            this.IdDisciplina.Visible = false;
            this.IdDisciplina.Width = 125;
            // 
            // IdEspecialidad
            // 
            this.IdEspecialidad.DataPropertyName = "IdEspecialidad";
            this.IdEspecialidad.HeaderText = "IdEspecialidad";
            this.IdEspecialidad.MinimumWidth = 6;
            this.IdEspecialidad.Name = "IdEspecialidad";
            this.IdEspecialidad.ReadOnly = true;
            this.IdEspecialidad.Visible = false;
            this.IdEspecialidad.Width = 125;
            // 
            // IdCompetencia
            // 
            this.IdCompetencia.DataPropertyName = "IdCompetencia";
            this.IdCompetencia.HeaderText = "IdCompetencia";
            this.IdCompetencia.MinimumWidth = 6;
            this.IdCompetencia.Name = "IdCompetencia";
            this.IdCompetencia.ReadOnly = true;
            this.IdCompetencia.Visible = false;
            this.IdCompetencia.Width = 125;
            // 
            // IdDesempeno
            // 
            this.IdDesempeno.DataPropertyName = "IdDesempeno";
            this.IdDesempeno.HeaderText = "IdDesempeno";
            this.IdDesempeno.MinimumWidth = 6;
            this.IdDesempeno.Name = "IdDesempeno";
            this.IdDesempeno.ReadOnly = true;
            this.IdDesempeno.Visible = false;
            this.IdDesempeno.Width = 125;
            // 
            // NombreDisciplina
            // 
            this.NombreDisciplina.DataPropertyName = "NombreDisciplina";
            this.NombreDisciplina.HeaderText = "DISCIPLINA";
            this.NombreDisciplina.MinimumWidth = 6;
            this.NombreDisciplina.Name = "NombreDisciplina";
            this.NombreDisciplina.ReadOnly = true;
            this.NombreDisciplina.Width = 125;
            // 
            // NombreEvento
            // 
            this.NombreEvento.DataPropertyName = "NombreEvento";
            this.NombreEvento.HeaderText = "JUEGOS Y CAMPEONATOS";
            this.NombreEvento.MinimumWidth = 6;
            this.NombreEvento.Name = "NombreEvento";
            this.NombreEvento.ReadOnly = true;
            this.NombreEvento.Width = 125;
            // 
            // MesInicioEvento
            // 
            this.MesInicioEvento.DataPropertyName = "MesInicioEvento";
            this.MesInicioEvento.HeaderText = "MES";
            this.MesInicioEvento.MinimumWidth = 6;
            this.MesInicioEvento.Name = "MesInicioEvento";
            this.MesInicioEvento.ReadOnly = true;
            this.MesInicioEvento.Width = 125;
            // 
            // Cedula
            // 
            this.Cedula.DataPropertyName = "Cedula";
            this.Cedula.HeaderText = "CEDULA";
            this.Cedula.MinimumWidth = 6;
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 125;
            // 
            // Apellidos
            // 
            this.Apellidos.DataPropertyName = "Apellidos";
            this.Apellidos.HeaderText = "APELLIDOS";
            this.Apellidos.MinimumWidth = 6;
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            this.Apellidos.Width = 125;
            // 
            // Nombres
            // 
            this.Nombres.DataPropertyName = "Nombres";
            this.Nombres.HeaderText = "NOMBRES";
            this.Nombres.MinimumWidth = 6;
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Width = 125;
            // 
            // AnioInicioEvento
            // 
            this.AnioInicioEvento.DataPropertyName = "AnioInicioEvento";
            this.AnioInicioEvento.HeaderText = "AÑO TORNEO";
            this.AnioInicioEvento.MinimumWidth = 6;
            this.AnioInicioEvento.Name = "AnioInicioEvento";
            this.AnioInicioEvento.ReadOnly = true;
            this.AnioInicioEvento.Width = 125;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "FECHA INICIO";
            this.FechaInicio.MinimumWidth = 6;
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 125;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "FECHA FIN";
            this.FechaFin.MinimumWidth = 6;
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 125;
            // 
            // Lugar
            // 
            this.Lugar.DataPropertyName = "Lugar";
            this.Lugar.HeaderText = "LUGAR";
            this.Lugar.MinimumWidth = 6;
            this.Lugar.Name = "Lugar";
            this.Lugar.ReadOnly = true;
            this.Lugar.Width = 125;
            // 
            // Genero
            // 
            this.Genero.DataPropertyName = "Genero";
            this.Genero.HeaderText = "GENERO";
            this.Genero.MinimumWidth = 6;
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            this.Genero.Width = 125;
            // 
            // NivelEvento
            // 
            this.NivelEvento.DataPropertyName = "NivelEvento";
            this.NivelEvento.HeaderText = "NIVEL";
            this.NivelEvento.MinimumWidth = 6;
            this.NivelEvento.Name = "NivelEvento";
            this.NivelEvento.ReadOnly = true;
            this.NivelEvento.Width = 125;
            // 
            // Modalidad
            // 
            this.Modalidad.DataPropertyName = "Modalidad";
            this.Modalidad.HeaderText = "MODALIDAD";
            this.Modalidad.MinimumWidth = 6;
            this.Modalidad.Name = "Modalidad";
            this.Modalidad.ReadOnly = true;
            this.Modalidad.Width = 125;
            // 
            // NombreCompletoTecnico
            // 
            this.NombreCompletoTecnico.DataPropertyName = "NombreCompletoTecnico";
            this.NombreCompletoTecnico.HeaderText = "TECNICO";
            this.NombreCompletoTecnico.MinimumWidth = 6;
            this.NombreCompletoTecnico.Name = "NombreCompletoTecnico";
            this.NombreCompletoTecnico.ReadOnly = true;
            this.NombreCompletoTecnico.Width = 125;
            // 
            // TipoEvento
            // 
            this.TipoEvento.DataPropertyName = "TipoEvento";
            this.TipoEvento.HeaderText = "TIPO";
            this.TipoEvento.MinimumWidth = 6;
            this.TipoEvento.Name = "TipoEvento";
            this.TipoEvento.ReadOnly = true;
            this.TipoEvento.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "CATEGORIA";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 125;
            // 
            // Division
            // 
            this.Division.DataPropertyName = "Division";
            this.Division.HeaderText = "DIVISION";
            this.Division.MinimumWidth = 6;
            this.Division.Name = "Division";
            this.Division.ReadOnly = true;
            this.Division.Width = 125;
            // 
            // NombreEspecialidad
            // 
            this.NombreEspecialidad.DataPropertyName = "NombreEspecialidad";
            this.NombreEspecialidad.HeaderText = "ESPECIALIDAD";
            this.NombreEspecialidad.MinimumWidth = 6;
            this.NombreEspecialidad.Name = "NombreEspecialidad";
            this.NombreEspecialidad.ReadOnly = true;
            this.NombreEspecialidad.Width = 125;
            // 
            // Tiempo
            // 
            this.Tiempo.DataPropertyName = "Tiempo";
            this.Tiempo.HeaderText = "TIEMPO / MARCA";
            this.Tiempo.MinimumWidth = 6;
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 125;
            // 
            // Record
            // 
            this.Record.DataPropertyName = "Record";
            this.Record.HeaderText = "RECORD";
            this.Record.MinimumWidth = 6;
            this.Record.Name = "Record";
            this.Record.ReadOnly = true;
            this.Record.Width = 125;
            // 
            // Ubicacion
            // 
            this.Ubicacion.DataPropertyName = "Ubicacion";
            this.Ubicacion.HeaderText = "UBICACION";
            this.Ubicacion.MinimumWidth = 6;
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Width = 125;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "Puntos";
            this.Puntos.HeaderText = "PUNTOS";
            this.Puntos.MinimumWidth = 6;
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            this.Puntos.Width = 125;
            // 
            // NumeroParticipantes
            // 
            this.NumeroParticipantes.DataPropertyName = "NumeroParticipantes";
            this.NumeroParticipantes.HeaderText = "#PARTICIPANTES";
            this.NumeroParticipantes.MinimumWidth = 6;
            this.NumeroParticipantes.Name = "NumeroParticipantes";
            this.NumeroParticipantes.ReadOnly = true;
            this.NumeroParticipantes.Width = 125;
            // 
            // Medalla
            // 
            this.Medalla.DataPropertyName = "Medalla";
            this.Medalla.HeaderText = "MEDALLAS";
            this.Medalla.MinimumWidth = 6;
            this.Medalla.Name = "Medalla";
            this.Medalla.ReadOnly = true;
            this.Medalla.Width = 125;
            // 
            // TipoDiscapacidad
            // 
            this.TipoDiscapacidad.DataPropertyName = "TipoDiscapacidad";
            this.TipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.TipoDiscapacidad.MinimumWidth = 6;
            this.TipoDiscapacidad.Name = "TipoDiscapacidad";
            this.TipoDiscapacidad.ReadOnly = true;
            this.TipoDiscapacidad.Width = 125;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "OBSERVACIONES";
            this.Observaciones.MinimumWidth = 6;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Width = 125;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.MinimumWidth = 6;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.Width = 125;
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNombres.Location = new System.Drawing.Point(574, 72);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(296, 28);
            this.txtNombres.TabIndex = 3;
            this.txtNombres.Text = "NOMBRES";
            this.txtNombres.Enter += new System.EventHandler(this.txtNombres_Enter);
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            this.txtNombres.Leave += new System.EventHandler(this.txtNombres_Leave);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtApellidos, 2);
            this.txtApellidos.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.ForeColor = System.Drawing.Color.DarkGray;
            this.txtApellidos.Location = new System.Drawing.Point(270, 72);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(300, 28);
            this.txtApellidos.TabIndex = 2;
            this.txtApellidos.Text = "APELLIDOS";
            this.txtApellidos.Enter += new System.EventHandler(this.txtApellidos_Enter);
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);
            this.txtApellidos.Leave += new System.EventHandler(this.txtApellidos_Leave);
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCedula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCedula, 2);
            this.txtCedula.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.Color.DarkGray;
            this.txtCedula.Location = new System.Drawing.Point(10, 72);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(2);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(256, 28);
            this.txtCedula.TabIndex = 1;
            this.txtCedula.Text = "CEDULA";
            this.txtCedula.Enter += new System.EventHandler(this.txtCedula_Enter);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            this.txtCedula.Leave += new System.EventHandler(this.txtCedula_Leave);
            // 
            // chkAntiguoActual
            // 
            this.chkAntiguoActual.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkAntiguoActual, 2);
            this.chkAntiguoActual.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAntiguoActual.ForeColor = System.Drawing.Color.DarkGray;
            this.chkAntiguoActual.Location = new System.Drawing.Point(458, 111);
            this.chkAntiguoActual.Margin = new System.Windows.Forms.Padding(2);
            this.chkAntiguoActual.Name = "chkAntiguoActual";
            this.chkAntiguoActual.Size = new System.Drawing.Size(159, 23);
            this.chkAntiguoActual.TabIndex = 8;
            this.chkAntiguoActual.Text = "Antiguo a Actual";
            this.chkAntiguoActual.UseVisualStyleBackColor = true;
            this.chkAntiguoActual.CheckedChanged += new System.EventHandler(this.chkAntiguoActual_CheckedChanged);
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMasculino.ForeColor = System.Drawing.Color.DarkGray;
            this.chkMasculino.Location = new System.Drawing.Point(10, 111);
            this.chkMasculino.Margin = new System.Windows.Forms.Padding(2);
            this.chkMasculino.Name = "chkMasculino";
            this.chkMasculino.Size = new System.Drawing.Size(109, 23);
            this.chkMasculino.TabIndex = 5;
            this.chkMasculino.Text = "Masculino";
            this.chkMasculino.UseVisualStyleBackColor = true;
            this.chkMasculino.CheckedChanged += new System.EventHandler(this.chkMasculino_CheckedChanged);
            // 
            // chkFemenino
            // 
            this.chkFemenino.AutoSize = true;
            this.chkFemenino.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFemenino.ForeColor = System.Drawing.Color.DarkGray;
            this.chkFemenino.Location = new System.Drawing.Point(140, 111);
            this.chkFemenino.Margin = new System.Windows.Forms.Padding(2);
            this.chkFemenino.Name = "chkFemenino";
            this.chkFemenino.Size = new System.Drawing.Size(107, 23);
            this.chkFemenino.TabIndex = 6;
            this.chkFemenino.Text = "Femenino";
            this.chkFemenino.UseVisualStyleBackColor = true;
            this.chkFemenino.CheckedChanged += new System.EventHandler(this.chkFemenino_CheckedChanged);
            // 
            // chkAlfabeticamente
            // 
            this.chkAlfabeticamente.AutoSize = true;
            this.chkAlfabeticamente.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlfabeticamente.ForeColor = System.Drawing.Color.DarkGray;
            this.chkAlfabeticamente.Location = new System.Drawing.Point(270, 111);
            this.chkAlfabeticamente.Margin = new System.Windows.Forms.Padding(2);
            this.chkAlfabeticamente.Name = "chkAlfabeticamente";
            this.chkAlfabeticamente.Size = new System.Drawing.Size(155, 23);
            this.chkAlfabeticamente.TabIndex = 7;
            this.chkAlfabeticamente.Text = "Alfabeticamente";
            this.chkAlfabeticamente.UseVisualStyleBackColor = true;
            this.chkAlfabeticamente.CheckedChanged += new System.EventHandler(this.chkAlfabeticamente_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8097726F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06084F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.03034F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.91812F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67904F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.11456F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.58253F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8048092F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpiar, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombres, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAntiguoActual, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkAlfabeticamente, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkFemenino, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkMasculino, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCedula, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtApellidos, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExportarWord, 9, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.127809F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.091292F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.7809F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1196, 708);
            this.tableLayoutPanel1.TabIndex = 11;
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
            this.btnLimpiar.Location = new System.Drawing.Point(1103, 87);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.tableLayoutPanel1.SetRowSpan(this.btnLimpiar, 2);
            this.btnLimpiar.Size = new System.Drawing.Size(44, 30);
            this.btnLimpiar.TabIndex = 10;
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
            this.btnBuscar.Location = new System.Drawing.Point(989, 87);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.tableLayoutPanel1.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportarWord
            // 
            this.btnExportarWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarWord.BackColor = System.Drawing.SystemColors.Window;
            this.btnExportarWord.BackgroundImage = global::FDCH.UI.Properties.Resources.exportar;
            this.btnExportarWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportarWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarWord.FlatAppearance.BorderSize = 0;
            this.btnExportarWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarWord.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarWord.ForeColor = System.Drawing.Color.White;
            this.btnExportarWord.Location = new System.Drawing.Point(1151, 86);
            this.btnExportarWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportarWord.Name = "btnExportarWord";
            this.tableLayoutPanel1.SetRowSpan(this.btnExportarWord, 2);
            this.btnExportarWord.Size = new System.Drawing.Size(32, 32);
            this.btnExportarWord.TabIndex = 11;
            this.btnExportarWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarWord.UseVisualStyleBackColor = false;
            this.btnExportarWord.Click += new System.EventHandler(this.btnExportarWord_Click);
            // 
            // FrmFiltrar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1196, 708);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFiltrar";
            this.Text = "FrmFiltrar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDisciplina;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCompetencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDesempeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreDisciplina;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesInicioEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioInicioEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn NivelEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompletoTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Division;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Record;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroParticipantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDiscapacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.CheckBox chkAntiguoActual;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.CheckBox chkFemenino;
        private System.Windows.Forms.CheckBox chkAlfabeticamente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExportarWord;
    }
}