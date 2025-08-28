using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    /// <summary>
    /// Form modal pequeño y reutilizable que muestra un mensaje y N botones de opción.
    /// Devuelve SelectedIndex (0..N-1) si se pulsa una opción, o -1 si se cancela.
    /// </summary>
    public partial class FrmSeleccionEditor : Form
    {
        public int SelectedIndex { get; private set; } = -1;
        public string SelectedText { get; private set; } = null;

        /// <summary>
        /// Constructor principal.
        /// options: array con los textos de los botones (ordenados).
        /// optionally: puedes pasar un Action<Button,int> para personalizar cada botón (colores, icono, ...)
        /// </summary>
        public FrmSeleccionEditor(string title, string message, string[] options, Action<Button, int> customizeButton = null)
        {
            if (options == null || options.Length == 0) throw new ArgumentException("Debe proveer al menos una opción", nameof(options));

            InitializeComponent(); // <-- usa los controles creados por el Designer (lblMessage, pnlButtons, etc.)

            this.Text = title ?? "Seleccionar";
            lblMessage.Text = message ?? string.Empty;
            // Ajustes estéticos opcionales
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Limpiar y poblar panel de botones (pnlButtons debe existir en Designer)
            pnlButtons.Controls.Clear();

            for (int i = 0; i < options.Length; i++)
            {
                var btn = new Button
                {
                    Text = options[i],
                    Tag = i,
                    AutoSize = false,
                    Size = new Size(180, 36),
                    Margin = new Padding(6),
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular)
                };

                btn.Click += (s, e) =>
                {
                    SelectedIndex = (int)((Button)s).Tag;
                    SelectedText = ((Button)s).Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                customizeButton?.Invoke(btn, i);
                pnlButtons.Controls.Add(btn);
            }

            
        }
    }
}
