namespace FDCH.UI.Vistas
{
    partial class FrmHistorialDeportista
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
            this.lblNombre = new System.Windows.Forms.Label();
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
            this.btnExportarDeportista = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 112);
            this.panel1.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(412, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(736, 69);
            this.lblNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registros del Deportista:";
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
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 526);
            this.dataGridView1.TabIndex = 1;
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
            // btnExportarDeportista
            // 
            this.btnExportarDeportista.BackColor = System.Drawing.Color.Red;
            this.btnExportarDeportista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarDeportista.FlatAppearance.BorderSize = 0;
            this.btnExportarDeportista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarDeportista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarDeportista.ForeColor = System.Drawing.Color.White;
            this.btnExportarDeportista.Image = global::FDCH.UI.Properties.Resources.dowload;
            this.btnExportarDeportista.Location = new System.Drawing.Point(1124, 641);
            this.btnExportarDeportista.Name = "btnExportarDeportista";
            this.btnExportarDeportista.Size = new System.Drawing.Size(60, 60);
            this.btnExportarDeportista.TabIndex = 2;
            this.btnExportarDeportista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarDeportista.UseVisualStyleBackColor = false;
            // 
            // FrmHistorialDeportista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 707);
            this.Controls.Add(this.btnExportarDeportista);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHistorialDeportista";
            this.Text = "FrmHistorialDeportista";
            this.Load += new System.EventHandler(this.FrmHistorialDeportista_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExportarDeportista;
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
    }
}