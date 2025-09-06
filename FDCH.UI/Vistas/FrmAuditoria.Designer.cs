namespace FDCH.UI.Vistas
{
    partial class FrmAuditoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_log = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabla_afectada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_registro_afectado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_cambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historial de Cambios";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_log,
            this.id_usuario,
            this.tabla_afectada,
            this.id_registro_afectado,
            this.accion,
            this.fecha_cambio});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1197, 642);
            this.dataGridView1.TabIndex = 1;
            // 
            // id_log
            // 
            this.id_log.DataPropertyName = "Id";
            this.id_log.HeaderText = "ID";
            this.id_log.MinimumWidth = 6;
            this.id_log.Name = "id_log";
            this.id_log.ReadOnly = true;
            // 
            // id_usuario
            // 
            this.id_usuario.DataPropertyName = "NombreUsuario";
            this.id_usuario.HeaderText = "USUARIO";
            this.id_usuario.MinimumWidth = 6;
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.ReadOnly = true;
            // 
            // tabla_afectada
            // 
            this.tabla_afectada.DataPropertyName = "TablaAfectada";
            this.tabla_afectada.HeaderText = "TABLA AFECTADA";
            this.tabla_afectada.MinimumWidth = 6;
            this.tabla_afectada.Name = "tabla_afectada";
            this.tabla_afectada.ReadOnly = true;
            // 
            // id_registro_afectado
            // 
            this.id_registro_afectado.DataPropertyName = "NombreRegistro";
            this.id_registro_afectado.HeaderText = "NOMBRE REGISTRO";
            this.id_registro_afectado.MinimumWidth = 6;
            this.id_registro_afectado.Name = "id_registro_afectado";
            this.id_registro_afectado.ReadOnly = true;
            // 
            // accion
            // 
            this.accion.DataPropertyName = "Accion";
            this.accion.HeaderText = "ACCION";
            this.accion.MinimumWidth = 6;
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            // 
            // fecha_cambio
            // 
            this.fecha_cambio.DataPropertyName = "FechaHora";
            this.fecha_cambio.HeaderText = "FECHA CAMBIO";
            this.fecha_cambio.MinimumWidth = 6;
            this.fecha_cambio.Name = "fecha_cambio";
            this.fecha_cambio.ReadOnly = true;
            // 
            // FrmAuditoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 706);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAuditoria";
            this.Text = "FrmAuditoria";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_log;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabla_afectada;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_registro_afectado;
        private System.Windows.Forms.DataGridViewTextBoxColumn accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_cambio;
    }
}