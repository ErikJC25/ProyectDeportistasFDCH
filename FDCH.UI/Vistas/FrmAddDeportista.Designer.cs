namespace FDCH.UI.Vistas
{
    partial class FrmAddDeportista
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
            this.cmbTorneo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModalidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTimeMarca = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMedalla = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtParticipantes = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDiscapacidad = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDivision = new System.Windows.Forms.TextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbApellidos = new System.Windows.Forms.ComboBox();
            this.cmbNombres = new System.Windows.Forms.ComboBox();
            this.cmbCedula = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmbTecnico = new System.Windows.Forms.ComboBox();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Deportista al Torneo:";
            // 
            // cmbTorneo
            // 
            this.cmbTorneo.BackColor = System.Drawing.Color.White;
            this.cmbTorneo.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTorneo.FormattingEnabled = true;
            this.cmbTorneo.IntegralHeight = false;
            this.cmbTorneo.Location = new System.Drawing.Point(409, 28);
            this.cmbTorneo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTorneo.MaxDropDownItems = 25;
            this.cmbTorneo.Name = "cmbTorneo";
            this.cmbTorneo.Size = new System.Drawing.Size(760, 35);
            this.cmbTorneo.TabIndex = 1;
            this.cmbTorneo.TextChanged += new System.EventHandler(this.cmbTorneo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cédula:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(815, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombres:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Apellidos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 27);
            this.label5.TabIndex = 2;
            this.label5.Text = "Genero";
            // 
            // txtGenero
            // 
            this.txtGenero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtGenero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGenero.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenero.ForeColor = System.Drawing.Color.DarkGray;
            this.txtGenero.Location = new System.Drawing.Point(25, 206);
            this.txtGenero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(335, 30);
            this.txtGenero.TabIndex = 5;
            this.txtGenero.Text = "MASCULINO / FEMENINO";
            this.txtGenero.Enter += new System.EventHandler(this.txtGenero_Enter);
            this.txtGenero.Leave += new System.EventHandler(this.txtGenero_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "Modalidad:";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtModalidad
            // 
            this.txtModalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtModalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModalidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModalidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtModalidad.Location = new System.Drawing.Point(25, 286);
            this.txtModalidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModalidad.Name = "txtModalidad";
            this.txtModalidad.Size = new System.Drawing.Size(335, 30);
            this.txtModalidad.TabIndex = 8;
            this.txtModalidad.Text = "INDIVIDUAL / EQUIPO";
            this.txtModalidad.Enter += new System.EventHandler(this.txtModalidad_Enter);
            this.txtModalidad.Leave += new System.EventHandler(this.txtModalidad_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(815, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "Especialidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(815, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 27);
            this.label8.TabIndex = 2;
            this.label8.Text = "Puntos:";
            // 
            // txtPuntos
            // 
            this.txtPuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPuntos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPuntos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntos.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPuntos.Location = new System.Drawing.Point(819, 367);
            this.txtPuntos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(351, 30);
            this.txtPuntos.TabIndex = 13;
            this.txtPuntos.Text = "5";
            this.txtPuntos.Enter += new System.EventHandler(this.txtPuntos_Enter);
            this.txtPuntos.Leave += new System.EventHandler(this.txtPuntos_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(404, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 27);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ubicación:";
            this.label9.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUbicacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUbicacion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtUbicacion.Location = new System.Drawing.Point(409, 448);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(351, 30);
            this.txtUbicacion.TabIndex = 15;
            this.txtUbicacion.Text = "3";
            this.txtUbicacion.Enter += new System.EventHandler(this.txtUbicacion_Enter);
            this.txtUbicacion.Leave += new System.EventHandler(this.txtUbicacion_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(815, 418);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 27);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tiempo / Marca:";
            // 
            // txtTimeMarca
            // 
            this.txtTimeMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTimeMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTimeMarca.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeMarca.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTimeMarca.Location = new System.Drawing.Point(819, 448);
            this.txtTimeMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimeMarca.Name = "txtTimeMarca";
            this.txtTimeMarca.Size = new System.Drawing.Size(351, 30);
            this.txtTimeMarca.TabIndex = 16;
            this.txtTimeMarca.Text = "55 SEG / 120 KG";
            this.txtTimeMarca.Enter += new System.EventHandler(this.txtTimeMarca_Enter);
            this.txtTimeMarca.Leave += new System.EventHandler(this.txtTimeMarca_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(407, 497);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 27);
            this.label11.TabIndex = 2;
            this.label11.Text = "Observaciones:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(405, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 27);
            this.label12.TabIndex = 2;
            this.label12.Text = "Categoría:";
            this.label12.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.ForeColor = System.Drawing.Color.DarkGray;
            this.txtCategoria.Location = new System.Drawing.Point(412, 286);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(351, 30);
            this.txtCategoria.TabIndex = 9;
            this.txtCategoria.Text = "SUB21 / MENOR...";
            this.txtCategoria.Enter += new System.EventHandler(this.txtCategoria_Enter);
            this.txtCategoria.Leave += new System.EventHandler(this.txtCategoria_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(405, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 27);
            this.label13.TabIndex = 2;
            this.label13.Text = "Disciplina:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 418);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 27);
            this.label14.TabIndex = 2;
            this.label14.Text = "Medalla:";
            // 
            // txtMedalla
            // 
            this.txtMedalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMedalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMedalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedalla.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMedalla.Location = new System.Drawing.Point(25, 448);
            this.txtMedalla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMedalla.Name = "txtMedalla";
            this.txtMedalla.Size = new System.Drawing.Size(335, 30);
            this.txtMedalla.TabIndex = 14;
            this.txtMedalla.Text = "ORO / PLATA / BRONCE";
            this.txtMedalla.Enter += new System.EventHandler(this.txtMedalla_Enter);
            this.txtMedalla.Leave += new System.EventHandler(this.txtMedalla_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 337);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(186, 27);
            this.label15.TabIndex = 2;
            this.label15.Text = "# Participantes:";
            this.label15.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtParticipantes
            // 
            this.txtParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtParticipantes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParticipantes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParticipantes.ForeColor = System.Drawing.Color.DarkGray;
            this.txtParticipantes.Location = new System.Drawing.Point(24, 367);
            this.txtParticipantes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtParticipantes.Name = "txtParticipantes";
            this.txtParticipantes.Size = new System.Drawing.Size(335, 30);
            this.txtParticipantes.TabIndex = 11;
            this.txtParticipantes.Text = "12";
            this.txtParticipantes.Enter += new System.EventHandler(this.txtParticipantes_Enter);
            this.txtParticipantes.Leave += new System.EventHandler(this.txtParticipantes_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 583);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 27);
            this.label16.TabIndex = 2;
            this.label16.Text = "Discapacidad:";
            // 
            // txtDiscapacidad
            // 
            this.txtDiscapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDiscapacidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDiscapacidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscapacidad.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDiscapacidad.Location = new System.Drawing.Point(25, 613);
            this.txtDiscapacidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscapacidad.Name = "txtDiscapacidad";
            this.txtDiscapacidad.Size = new System.Drawing.Size(335, 30);
            this.txtDiscapacidad.TabIndex = 18;
            this.txtDiscapacidad.Text = "NINGUNA";
            this.txtDiscapacidad.Enter += new System.EventHandler(this.txtDiscapacidad_Enter);
            this.txtDiscapacidad.Leave += new System.EventHandler(this.txtDiscapacidad_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(815, 255);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 27);
            this.label17.TabIndex = 2;
            this.label17.Text = "División:";
            // 
            // txtDivision
            // 
            this.txtDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDivision.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDivision.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDivision.Location = new System.Drawing.Point(820, 286);
            this.txtDivision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(351, 30);
            this.txtDivision.TabIndex = 10;
            this.txtDivision.Text = "55 KG";
            this.txtDivision.Enter += new System.EventHandler(this.txtDivision_Enter);
            this.txtDivision.Leave += new System.EventHandler(this.txtDivision_Leave);
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(409, 527);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(760, 78);
            this.txtObservacion.TabIndex = 19;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Crimson;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(409, 617);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(760, 34);
            this.btnAgregar.TabIndex = 20;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.Crimson;
            this.pnlCabecera.Controls.Add(this.cmbTorneo);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1196, 90);
            this.pnlCabecera.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(405, 337);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 27);
            this.label18.TabIndex = 2;
            this.label18.Text = "Record:";
            this.label18.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtRecord
            // 
            this.txtRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRecord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecord.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecord.ForeColor = System.Drawing.Color.DarkGray;
            this.txtRecord.Location = new System.Drawing.Point(411, 367);
            this.txtRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(351, 30);
            this.txtRecord.TabIndex = 12;
            this.txtRecord.Text = "10";
            this.txtRecord.Enter += new System.EventHandler(this.txtRecord_Enter);
            this.txtRecord.Leave += new System.EventHandler(this.txtRecord_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(20, 497);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 27);
            this.label19.TabIndex = 2;
            this.label19.Text = "Técnico:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbEspecialidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(819, 206);
            this.cmbEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEspecialidad.MaxDropDownItems = 22;
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(351, 31);
            this.cmbEspecialidad.TabIndex = 7;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            this.cmbEspecialidad.TextChanged += new System.EventHandler(this.cmbEspecialidad_TextChanged);
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbDisciplina.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.IntegralHeight = false;
            this.cmbDisciplina.Location = new System.Drawing.Point(412, 206);
            this.cmbDisciplina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDisciplina.MaxDropDownItems = 22;
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(351, 31);
            this.cmbDisciplina.TabIndex = 6;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            this.cmbDisciplina.TextChanged += new System.EventHandler(this.cmbDisciplina_TextChanged);
            // 
            // cmbApellidos
            // 
            this.cmbApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbApellidos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApellidos.FormattingEnabled = true;
            this.cmbApellidos.IntegralHeight = false;
            this.cmbApellidos.Location = new System.Drawing.Point(412, 130);
            this.cmbApellidos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbApellidos.MaxDropDownItems = 25;
            this.cmbApellidos.Name = "cmbApellidos";
            this.cmbApellidos.Size = new System.Drawing.Size(351, 31);
            this.cmbApellidos.TabIndex = 3;
            this.cmbApellidos.SelectedIndexChanged += new System.EventHandler(this.cmbApellidos_SelectedIndexChanged);
            this.cmbApellidos.TextChanged += new System.EventHandler(this.cmbApellidos_TextChanged);
            // 
            // cmbNombres
            // 
            this.cmbNombres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbNombres.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNombres.FormattingEnabled = true;
            this.cmbNombres.IntegralHeight = false;
            this.cmbNombres.Location = new System.Drawing.Point(819, 130);
            this.cmbNombres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNombres.MaxDropDownItems = 25;
            this.cmbNombres.Name = "cmbNombres";
            this.cmbNombres.Size = new System.Drawing.Size(351, 31);
            this.cmbNombres.TabIndex = 4;
            this.cmbNombres.SelectedIndexChanged += new System.EventHandler(this.cmbNombres_SelectedIndexChanged);
            this.cmbNombres.TextChanged += new System.EventHandler(this.cmbNombres_TextChanged);
            // 
            // cmbCedula
            // 
            this.cmbCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbCedula.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCedula.FormattingEnabled = true;
            this.cmbCedula.IntegralHeight = false;
            this.cmbCedula.Location = new System.Drawing.Point(25, 130);
            this.cmbCedula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCedula.MaxDropDownItems = 25;
            this.cmbCedula.Name = "cmbCedula";
            this.cmbCedula.Size = new System.Drawing.Size(335, 31);
            this.cmbCedula.TabIndex = 2;
            this.cmbCedula.SelectedIndexChanged += new System.EventHandler(this.cmbCedula_SelectedIndexChanged);
            this.cmbCedula.TextChanged += new System.EventHandler(this.cmbCedula_TextChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLimpiar.Location = new System.Drawing.Point(409, 658);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(760, 30);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmbTecnico
            // 
            this.cmbTecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbTecnico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTecnico.FormattingEnabled = true;
            this.cmbTecnico.IntegralHeight = false;
            this.cmbTecnico.Location = new System.Drawing.Point(25, 527);
            this.cmbTecnico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTecnico.Name = "cmbTecnico";
            this.cmbTecnico.Size = new System.Drawing.Size(335, 31);
            this.cmbTecnico.TabIndex = 17;
            this.cmbTecnico.TextChanged += new System.EventHandler(this.cmbTecnico_TextChanged);
            // 
            // FrmAddDeportista
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 706);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbNombres);
            this.Controls.Add(this.cmbTecnico);
            this.Controls.Add(this.cmbCedula);
            this.Controls.Add(this.cmbApellidos);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDiscapacidad);
            this.Controls.Add(this.txtTimeMarca);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.txtParticipantes);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtModalidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDivision);
            this.Controls.Add(this.txtMedalla);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAddDeportista";
            this.Text = "FrmAddDeportista";
            this.Shown += new System.EventHandler(this.FrmAddDeportista_Shown);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTorneo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModalidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTimeMarca;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMedalla;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtParticipantes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDiscapacidad;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDivision;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbApellidos;
        private System.Windows.Forms.ComboBox cmbNombres;
        private System.Windows.Forms.ComboBox cmbCedula;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmbTecnico;
    }
}