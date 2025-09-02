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

        public FrmSeleccionEditor(string title, string message, string[] options, Action<Button, int> customizeButton = null)
        {
            if (options == null || options.Length == 0) throw new ArgumentException("Debe proveer al menos una opción", nameof(options));

            this.Text = title ?? "Seleccionar";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var mainPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(15)
            };

            var lblMessage = new Label
            {
                Text = message ?? string.Empty,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 15),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular)
            };
            mainPanel.Controls.Add(lblMessage);

            // 1. Calcular el tamaño preferido del botón con el texto más largo
            var tempBtn = new Button { Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            Size largestSize = Size.Empty;

            foreach (string option in options)
            {
                tempBtn.Text = option;
                // GetPreferredSize() calcula el tamaño mínimo necesario para mostrar el texto
                Size preferredSize = tempBtn.GetPreferredSize(Size.Empty);
                if (preferredSize.Width > largestSize.Width)
                {
                    largestSize.Width = preferredSize.Width;
                }
            }

            // Establecer un ancho mínimo para uniformar la apariencia y añadir un pequeño relleno
            int finalWidth = Math.Max(largestSize.Width + 20, 200);
            int buttonHeight = 40;

            // 2. Crear y añadir los botones con el mismo tamaño uniforme
            for (int i = 0; i < options.Length; i++)
            {
                var btn = new Button
                {
                    Text = options[i],
                    Tag = i,
                    Size = new Size(finalWidth, buttonHeight),
                    AutoSize = false, // Desactivamos el AutoSize individual para forzar el mismo tamaño
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                btn.Click += (s, e) =>
                {
                    SelectedIndex = (int)((Button)s).Tag;
                    SelectedText = ((Button)s).Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                customizeButton?.Invoke(btn, i);
                mainPanel.Controls.Add(btn);
            }

            this.Controls.Add(mainPanel);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
