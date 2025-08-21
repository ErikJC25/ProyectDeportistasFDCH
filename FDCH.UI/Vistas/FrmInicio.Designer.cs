namespace FDCH.UI.Vistas
{
    partial class FrmInicio
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.IdDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(4)))), ((int)(((byte)(74)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDeportista,
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
            this.Observaciones});
            this.dataGridView1.GridColor = System.Drawing.Color.Aqua;
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1136, 630);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(582, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registro de resultados de Participaciones";
            // 
            // IdDeportista
            // 
            this.IdDeportista.DataPropertyName = "IdDeportista";
            this.IdDeportista.HeaderText = "IdDeportista";
            this.IdDeportista.MinimumWidth = 6;
            this.IdDeportista.Name = "IdDeportista";
            this.IdDeportista.Visible = false;
            this.IdDeportista.Width = 125;
            // 
            // IdTecnico
            // 
            this.IdTecnico.DataPropertyName = "IdTecnico";
            this.IdTecnico.HeaderText = "IdTecnico";
            this.IdTecnico.MinimumWidth = 6;
            this.IdTecnico.Name = "IdTecnico";
            this.IdTecnico.Visible = false;
            this.IdTecnico.Width = 125;
            // 
            // IdEvento
            // 
            this.IdEvento.DataPropertyName = "IdEvento";
            this.IdEvento.HeaderText = "IdEvento";
            this.IdEvento.MinimumWidth = 6;
            this.IdEvento.Name = "IdEvento";
            this.IdEvento.Visible = false;
            this.IdEvento.Width = 125;
            // 
            // IdDisciplina
            // 
            this.IdDisciplina.DataPropertyName = "IdDisciplina";
            this.IdDisciplina.HeaderText = "IdDisciplina";
            this.IdDisciplina.MinimumWidth = 6;
            this.IdDisciplina.Name = "IdDisciplina";
            this.IdDisciplina.Visible = false;
            this.IdDisciplina.Width = 125;
            // 
            // IdEspecialidad
            // 
            this.IdEspecialidad.DataPropertyName = "IdEspecialidad";
            this.IdEspecialidad.HeaderText = "IdEspecialidad";
            this.IdEspecialidad.MinimumWidth = 6;
            this.IdEspecialidad.Name = "IdEspecialidad";
            this.IdEspecialidad.Visible = false;
            this.IdEspecialidad.Width = 125;
            // 
            // IdCompetencia
            // 
            this.IdCompetencia.DataPropertyName = "IdCompetencia";
            this.IdCompetencia.HeaderText = "IdCompetencia";
            this.IdCompetencia.MinimumWidth = 6;
            this.IdCompetencia.Name = "IdCompetencia";
            this.IdCompetencia.Visible = false;
            this.IdCompetencia.Width = 125;
            // 
            // IdDesempeno
            // 
            this.IdDesempeno.DataPropertyName = "IdDesempeno";
            this.IdDesempeno.HeaderText = "IdDesempeno";
            this.IdDesempeno.MinimumWidth = 6;
            this.IdDesempeno.Name = "IdDesempeno";
            this.IdDesempeno.Visible = false;
            this.IdDesempeno.Width = 125;
            // 
            // NombreDisciplina
            // 
            this.NombreDisciplina.DataPropertyName = "NombreDisciplina";
            this.NombreDisciplina.HeaderText = "DISCIPLINA";
            this.NombreDisciplina.MinimumWidth = 6;
            this.NombreDisciplina.Name = "NombreDisciplina";
            this.NombreDisciplina.Width = 125;
            // 
            // NombreEvento
            // 
            this.NombreEvento.DataPropertyName = "NombreEvento";
            this.NombreEvento.HeaderText = "TORNEO";
            this.NombreEvento.MinimumWidth = 6;
            this.NombreEvento.Name = "NombreEvento";
            this.NombreEvento.Width = 125;
            // 
            // MesInicioEvento
            // 
            this.MesInicioEvento.DataPropertyName = "MesInicioEvento";
            this.MesInicioEvento.HeaderText = "MES";
            this.MesInicioEvento.MinimumWidth = 6;
            this.MesInicioEvento.Name = "MesInicioEvento";
            this.MesInicioEvento.Width = 125;
            // 
            // Cedula
            // 
            this.Cedula.DataPropertyName = "Cedula";
            this.Cedula.HeaderText = "CEDULA";
            this.Cedula.MinimumWidth = 6;
            this.Cedula.Name = "Cedula";
            this.Cedula.Width = 125;
            // 
            // Apellidos
            // 
            this.Apellidos.DataPropertyName = "Apellidos";
            this.Apellidos.HeaderText = "APELLIDOS";
            this.Apellidos.MinimumWidth = 6;
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Width = 125;
            // 
            // Nombres
            // 
            this.Nombres.DataPropertyName = "Nombres";
            this.Nombres.HeaderText = "NOMBRES";
            this.Nombres.MinimumWidth = 6;
            this.Nombres.Name = "Nombres";
            this.Nombres.Width = 125;
            // 
            // AnioInicioEvento
            // 
            this.AnioInicioEvento.DataPropertyName = "AnioInicioEvento";
            this.AnioInicioEvento.HeaderText = "AÑO TORNEO";
            this.AnioInicioEvento.MinimumWidth = 6;
            this.AnioInicioEvento.Name = "AnioInicioEvento";
            this.AnioInicioEvento.Width = 125;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "FECHA INICIO";
            this.FechaInicio.MinimumWidth = 6;
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Width = 125;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "FECHA FIN";
            this.FechaFin.MinimumWidth = 6;
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Width = 125;
            // 
            // Lugar
            // 
            this.Lugar.DataPropertyName = "Lugar";
            this.Lugar.HeaderText = "LUGAR";
            this.Lugar.MinimumWidth = 6;
            this.Lugar.Name = "Lugar";
            this.Lugar.Width = 125;
            // 
            // Genero
            // 
            this.Genero.DataPropertyName = "Genero";
            this.Genero.HeaderText = "GENERO";
            this.Genero.MinimumWidth = 6;
            this.Genero.Name = "Genero";
            this.Genero.Width = 125;
            // 
            // NivelEvento
            // 
            this.NivelEvento.DataPropertyName = "NivelEvento";
            this.NivelEvento.HeaderText = "NIVEL";
            this.NivelEvento.MinimumWidth = 6;
            this.NivelEvento.Name = "NivelEvento";
            this.NivelEvento.Width = 125;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "CATEGORIA";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 125;
            // 
            // Division
            // 
            this.Division.DataPropertyName = "Division";
            this.Division.HeaderText = "DIVISION";
            this.Division.MinimumWidth = 6;
            this.Division.Name = "Division";
            this.Division.Width = 125;
            // 
            // NombreEspecialidad
            // 
            this.NombreEspecialidad.DataPropertyName = "NombreEspecialidad";
            this.NombreEspecialidad.HeaderText = "ESPECIALIDAD";
            this.NombreEspecialidad.MinimumWidth = 6;
            this.NombreEspecialidad.Name = "NombreEspecialidad";
            this.NombreEspecialidad.Width = 125;
            // 
            // Tiempo
            // 
            this.Tiempo.DataPropertyName = "Tiempo";
            this.Tiempo.HeaderText = "TIEMPO";
            this.Tiempo.MinimumWidth = 6;
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.Width = 125;
            // 
            // Record
            // 
            this.Record.DataPropertyName = "Record";
            this.Record.HeaderText = "RECORD";
            this.Record.MinimumWidth = 6;
            this.Record.Name = "Record";
            this.Record.Width = 125;
            // 
            // Ubicacion
            // 
            this.Ubicacion.DataPropertyName = "Ubicacion";
            this.Ubicacion.HeaderText = "UBICACION";
            this.Ubicacion.MinimumWidth = 6;
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.Width = 125;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "Puntos";
            this.Puntos.HeaderText = "PUNTOS";
            this.Puntos.MinimumWidth = 6;
            this.Puntos.Name = "Puntos";
            this.Puntos.Width = 125;
            // 
            // NumeroParticipantes
            // 
            this.NumeroParticipantes.DataPropertyName = "NumeroParticipantes";
            this.NumeroParticipantes.HeaderText = "#PARTICIPANTES";
            this.NumeroParticipantes.MinimumWidth = 6;
            this.NumeroParticipantes.Name = "NumeroParticipantes";
            this.NumeroParticipantes.Width = 125;
            // 
            // Medalla
            // 
            this.Medalla.DataPropertyName = "Medalla";
            this.Medalla.HeaderText = "MEDALLAS";
            this.Medalla.MinimumWidth = 6;
            this.Medalla.Name = "Medalla";
            this.Medalla.Width = 125;
            // 
            // TipoDiscapacidad
            // 
            this.TipoDiscapacidad.DataPropertyName = "TipoDiscapacidad";
            this.TipoDiscapacidad.HeaderText = "TIPO DISCAPACIDAD";
            this.TipoDiscapacidad.MinimumWidth = 6;
            this.TipoDiscapacidad.Name = "TipoDiscapacidad";
            this.TipoDiscapacidad.Width = 125;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "OBSERVACIONES";
            this.Observaciones.MinimumWidth = 6;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Width = 125;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(20)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1160, 707);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmInicio";
            this.Text = "FrmInicio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDeportista;
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
    }
}