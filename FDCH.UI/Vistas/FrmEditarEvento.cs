using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmEditarEvento : Form
    {
        //Se guarda el objeto registro recibido, necesario para rellenar los textbox y combobox
        private readonly RegistroTotal _registro;
        //Se instancia la capa lógica
        private readonly Cls_Puente _puente = new Cls_Puente();
        // referencia opcional al frm principal (si se pasa)
        private readonly FrmPrincipal _frmprincipal;

        public FrmEditarEvento(RegistroTotal registroCompleto, FrmPrincipal parent = null)
        {
            InitializeComponent();

            // Guardar el registro (lanzará ArgumentNullException si es null para detectar errores temprano)
            _registro = registroCompleto ?? throw new ArgumentNullException(nameof(registroCompleto));

            // Suscribimos al Load para ejecutar la inicialización cuando los controles estén listos
            this.Load += FrmEditarRegistro_Load;

            // Aseguramos los manejadores de los botones (por si no están enlazados en el Designer)
            btnGuardar.Click -= btnGuardar_Click_1;
            btnGuardar.Click += btnGuardar_Click_1;

            btnCancelar.Click -= btnCancelar_Click_1;
            btnCancelar.Click += btnCancelar_Click_1;

            // Guardar la referencia si se pasó (si no, queda null y usaremos fallback)
            _frmprincipal = parent;
        }

        /// <summary>
        /// Se ejecuta cuando el formulario está cargado; aquí llenamos los controles con los datos del registro.
        /// </summary>
        private void FrmEditarRegistro_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarControlesConRegistro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Asigna los valores del objeto _registro a los controles del formulario.
        /// Las fechas se muestran tal cual si no pueden parsearse en el formato esperado.
        /// </summary>
        private void LlenarControlesConRegistro()
        {
            // Campos de texto simples
            txbNombre.Text = _registro.NombreEvento ?? string.Empty;
            txbLugar.Text = _registro.Lugar ?? string.Empty;
            txbTipoEvento.Text = _registro.TipoEvento ?? string.Empty;
            txbNivelEvento.Text = _registro.NivelEvento ?? string.Empty;

            // Fechas: como trabajas con TextBox, intentamos parsear para mostrar en formato dd/MM/yyyy;
            // si no parsea, mostramos el texto tal cual (evita perder información).
            if (DateTime.TryParseExact(_registro.FechaInicio ?? string.Empty,
                                       "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime fi))
            {
                txbFechaInicio.Text = fi.ToString("dd/MM/yyyy");
            }
            else
            {
                txbFechaInicio.Text = _registro.FechaInicio ?? string.Empty;
            }

            if (DateTime.TryParseExact(_registro.FechaFin ?? string.Empty,
                                       "dd/MM/yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime ff))
            {
                txbFechaFin.Text = ff.ToString("dd/MM/yyyy");
            }
            else
            {
                txbFechaFin.Text = _registro.FechaFin ?? string.Empty;
            }
        }

        // ---------------------------
        // Helpers y validadores
        // ---------------------------

        /// <summary>
        /// Intenta parsear la fecha introducida por el usuario aceptando varios formatos razonables.
        /// Devuelve true y la fecha parseada si uno de los formatos coincide.
        /// </summary>
        /// <param name="texto">Texto introducido por el usuario</param>
        /// <param name="fecha">Salida: fecha parseada</param>
        /// <returns>True si parseó correctamente</returns>
        private bool TryParseFechaUsuario(string texto, out DateTime fecha)
        {
            fecha = default;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            // Formatos aceptados; puedes añadir más si lo consideras necesario
            string[] formatos = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy-MM-dd" };

            // Intentamos parsear con la cultura española (para seguridad con separadores)
            return DateTime.TryParseExact(texto.Trim(), formatos, new CultureInfo("es-ES"),
                                         DateTimeStyles.None, out fecha);
        }

        /// <summary>
        /// Convierte una cadena a mayúsculas de forma segura respetando la cultura.
        /// Devuelve cadena vacía si input es null/whitespace.
        /// </summary>
        private string ToUpperSafe(string input, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            return input.Trim().ToUpper(culture);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void cmbTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handler del botón Guardar:
        /// - Valida campos obligatorios y formatos de fecha.
        /// - Convierte campos de texto a MAYÚSCULAS (cultura es-ES).
        /// - Construye un objeto Evento y llama a Cls_Puente para actualizar la BD.
        /// </summary>

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1) Validación mínima: nombre obligatorio
                if (string.IsNullOrWhiteSpace(txbNombre.Text))
                {
                    MessageBox.Show("El nombre del torneo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbNombre.Focus();
                    return;
                }

                // 2) Validar la fecha de inicio con formatos aceptados
                DateTime fechaInicio = default;
                bool tieneFechaInicio = false;
                if (!string.IsNullOrWhiteSpace(txbFechaInicio.Text))
                {
                    // Si el usuario puso texto, validamos que sea una fecha válida
                    if (!TryParseFechaUsuario(txbFechaInicio.Text, out fechaInicio))
                    {
                        MessageBox.Show("Fecha de inicio inválida. Use el formato dd/MM/yyyy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbFechaInicio.Focus();
                        return;
                    }
                    tieneFechaInicio = true;
                }

                // 3) Validar fecha fin (opcional: solo si el usuario colocó texto)
                DateTime fechaFin = default;
                bool tieneFechaFin = false;
                if (!string.IsNullOrWhiteSpace(txbFechaFin.Text))
                {
                    if (!TryParseFechaUsuario(txbFechaFin.Text, out fechaFin))
                    {
                        MessageBox.Show("Fecha fin inválida. Use el formato dd/MM/yyyy o déjela vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbFechaFin.Focus();
                        return;
                    }
                    tieneFechaFin = true;
                }

                // 4) Cultura para mayúsculas (respeta ñ y acentos)
                var culture = new CultureInfo("es-ES");

                // 5) Construcción del objeto Evento (con campos en MAYÚSCULAS)
                var evento = new Evento
                {
                    id_evento = _registro.IdEvento, // id para el UPDATE
                    nombre_evento = ToUpperSafe(txbNombre.Text, culture),
                    lugar = ToUpperSafe(txbLugar.Text, culture),
                    tipo_evento = ToUpperSafe(txbTipoEvento.Text, culture),
                    nivel_evento = ToUpperSafe(txbNivelEvento.Text, culture),
                    // Guardamos las fechas en formato dd/MM/yyyy
                    fecha_inicio = tieneFechaInicio ? fechaInicio.ToString("dd/MM/yyyy") : string.Empty,
                    fecha_fin = tieneFechaFin ? fechaFin.ToString("dd/MM/yyyy") : string.Empty
                };

                // 6) Llamada a la capa lógica para actualizar la BD
                bool actualizado = _puente.ActualizarEvento(evento);

                // 7) Resultado
                if (actualizado)
                {
                    MessageBox.Show("Evento actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si se pasó la referencia al FrmPrincipal, seguir exactamente el patrón usado en otros formularios:
                    if (_frmprincipal != null)
                    {
                        _frmprincipal.AbrirFormularioEnPanel(new FrmInicio(_frmprincipal));
                    }
                    else
                    {
                        // Fallback: intentar encontrar FrmPrincipal entre forms abiertos
                        var principal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
                        if (principal != null)
                        {
                            principal.AbrirFormularioEnPanel(new FrmInicio(principal));
                        }
                        // si tampoco se encuentra, simplemente no hacemos nada más (o podrías cerrar)
                    }

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada y la muestra al usuario
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handler del botón Cancelar: cierra el formulario sin guardar.
        /// </summary>
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            // Seguir el mismo patrón: usar _frmprincipal si existe, si no buscar un FrmPrincipal abierto.
            if (_frmprincipal != null)
            {
                _frmprincipal.AbrirFormularioEnPanel(new FrmInicio(_frmprincipal));
            }
            else
            {
                var principal = Application.OpenForms.OfType<FrmPrincipal>().FirstOrDefault();
                if (principal != null)
                {
                    principal.AbrirFormularioEnPanel(new FrmInicio(principal));
                }
            }

            this.Close();
        }
    }
}
