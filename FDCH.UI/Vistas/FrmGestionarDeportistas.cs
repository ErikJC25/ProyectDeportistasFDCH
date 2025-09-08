using FDCH.Entidades;
using FDCH.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDCH.UI.Vistas
{
    public partial class FrmGestionarDeportistas : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;

        // Lista cacheada de deportistas (para buscar/ordenar fácilmente)
        private List<Deportista> _listaDeportistas = new List<Deportista>();

        // Diccionario: id_deportista -> lista de disciplinas
        private Dictionary<int, List<string>> _mapaDisciplinas = new Dictionary<int, List<string>>();
        public FrmGestionarDeportistas(FrmPrincipal principal)
        {
            InitializeComponent();

            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FrmGestionarDeportistas_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        /// <summary>
        /// Carga inicial: deportistas y mapa de disciplinas (en una sola consulta).
        /// Por defecto ahora ordena por id_deportista DESC (mayor -> menor).
        /// </summary>
        private void CargarDatosIniciales()
        {
            try
            {
                // 1) traer deportistas
                _listaDeportistas = _puente.ObtenerTodosDeportistas() ?? new List<Deportista>();

                // 2) traer disciplinas por deportista (UNA sola consulta)
                _mapaDisciplinas = _puente.ObtenerDisciplinasPorDeportista() ?? new Dictionary<int, List<string>>();

                // 3) mostrar ordenados por id (mayor -> menor) por defecto
                var ordenados = _listaDeportistas.OrderByDescending(d => d.id_deportista).ToList();
                PoblarDataGrid(ordenados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena el DataGridView usando la lista proporcionada.
        /// Asume que las columnas ya están definidas en el diseñador:
        /// colSeleccionar, colCedula, colNombres, colApellidos, colDisciplinas, colGenero, colTipoDiscapacidad, colEditar, colIdDeportista (oculta).
        /// </summary>
        private void PoblarDataGrid(List<Deportista> lista)
        {
            dataGridView1.Rows.Clear();

            foreach (var d in lista)
            {
                string disciplinasTexto = "";
                if (d != null && _mapaDisciplinas.TryGetValue(d.id_deportista, out var listDisc) && listDisc.Any())
                {
                    disciplinasTexto = string.Join(", ", listDisc.OrderBy(x => x));
                }

                // Añadir fila. El orden de columnas debe coincidir con el diseñador.
                int rowIndex = dataGridView1.Rows.Add(false, // seleccionar checkbox
                                                   d.cedula ?? "",
                                                   d.nombres ?? "",
                                                   d.apellidos ?? "",
                                                   disciplinasTexto,
                                                   d.genero ?? "",
                                                   d.tipo_discapacidad ?? "",
                                                   "Editar", // texto del botón
                                                   d.id_deportista); // columna oculta id
                // guardar objeto como Tag para uso futuro
                dataGridView1.Rows[rowIndex].Tag = d;
            }
        }


        // ----------------------
        // BUSCAR / LIMPIAR
        // ----------------------

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Definición de placeholders actuales
            string placeholderCedula = "CEDULA";
            string placeholderApellidos = "APELLIDOS";
            string placeholderNombres = "NOMBRES";

            // Validar que al menos uno de los campos de búsqueda tenga un valor.
            // Se elimina el espacio en blanco y se compara con el placeholder.
            if ((string.IsNullOrWhiteSpace(txbCedula.Text) || txbCedula.Text == placeholderCedula && txbCedula.ForeColor == Color.DarkGray) &&
                (string.IsNullOrWhiteSpace(txbApellidos.Text) || txbApellidos.Text == placeholderApellidos && txbApellidos.ForeColor == Color.DarkGray) &&
                (string.IsNullOrWhiteSpace(txbNombres.Text) || txbNombres.Text == placeholderNombres && txbNombres.ForeColor == Color.DarkGray))
            {
                MessageBox.Show("Por favor, ingrese al menos un valor en los campos Cédula, Apellidos o Nombres para realizar la búsqueda.",
                                "Campos de Búsqueda Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si la validación falla
            }

            string cedula;
            string apellidos;
            string nombres;

            if (!string.IsNullOrWhiteSpace(txbCedula.Text) && txbCedula.Text != placeholderCedula && txbCedula.ForeColor != Color.DarkGray)
            {
                cedula = txbCedula.Text?.Trim();
            }
            else 
            {
                cedula = "";
            }


            if (!string.IsNullOrWhiteSpace(txbApellidos.Text) && txbApellidos.Text != placeholderApellidos && txbApellidos.ForeColor != Color.DarkGray)
            {
                apellidos = txbApellidos.Text?.Trim();
            }
            else
            {
                apellidos = "";
            }

            if (!string.IsNullOrWhiteSpace(txbNombres.Text) && txbNombres.Text != placeholderNombres && txbNombres.ForeColor != Color.DarkGray)
            {
                nombres = txbNombres.Text?.Trim();
            }
            else
            {
                nombres = "";
            }


            // Filtrar en memoria (si tu BD es grande preferir filtro SQL en capa datos)
            var filtrados = _listaDeportistas.Where(d =>
                (string.IsNullOrWhiteSpace(cedula) || (d.cedula ?? "").IndexOf(cedula, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrWhiteSpace(apellidos) || (d.apellidos ?? "").IndexOf(apellidos, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrWhiteSpace(nombres) || (d.nombres ?? "").IndexOf(nombres, StringComparison.OrdinalIgnoreCase) >= 0)
            ).OrderBy(d => d.nombres).ToList();

            PoblarDataGrid(filtrados);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbCedula.Text = "CEDULA";
            txbCedula.ForeColor = Color.DarkGray;
            txbApellidos.Text = "APELLIDOS";
            txbApellidos.ForeColor = Color.DarkGray;
            txbNombres.Text = "NOMBRES";
            txbNombres.ForeColor = Color.DarkGray;
            // restaurar lista completa
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.nombres).ToList());
        }

        private void btnOrdenarApellidos_Click(object sender, EventArgs e)
        {
            txbCedula.Text = "CEDULA";
            txbCedula.ForeColor = Color.DarkGray;
            txbApellidos.Text = "APELLIDOS";
            txbApellidos.ForeColor = Color.DarkGray;
            txbNombres.Text = "NOMBRES";
            txbNombres.ForeColor = Color.DarkGray;
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.apellidos).ToList());
        }

        private void btnOrdenarNombres_Click(object sender, EventArgs e)
        {
            txbCedula.Text = "CEDULA";
            txbCedula.ForeColor = Color.DarkGray;
            txbApellidos.Text = "APELLIDOS";
            txbApellidos.ForeColor = Color.DarkGray;
            txbNombres.Text = "NOMBRES";
            txbNombres.ForeColor = Color.DarkGray;
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.nombres).ToList());
        }


        private void btnFusionar_Click(object sender, EventArgs e)
        {
            var seleccionados = GetSelectedRowsDto();

            if (seleccionados.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos deportistas para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new FrmFusionarDeportistas(seleccionados, _frmPrincipal);
            _frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }

        private void btnSeparar_Click(object sender, EventArgs e)
        {
            var seleccionados = GetSelectedRowsDto();

            if (seleccionados.Count != 1)
            {
                MessageBox.Show("Seleccione exactamente un deportista para separar.", "Separar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var frm = new FrmSepararDeportistas(seleccionados.First(), _frmPrincipal);
            //_frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }


        /*/// <summary>
        /// Devuelve la lista de Deportista marcados por checkbox en el datagrid.
        /// </summary>
        private List<Deportista> GetDeportistasSeleccionados()
        {
            var lista = new List<Deportista>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colSeleccionar"].Value is bool sel && sel)
                {
                    if (row.Tag is Deportista d) lista.Add(d);
                    else
                    {
                        // si no está el Tag, intentar obtener por columna id oculta
                        if (int.TryParse(row.Cells["colIdDeportista"].Value?.ToString(), out int id))
                        {
                            var deport = _listaDeportistas.FirstOrDefault(x => x.id_deportista == id);
                            if (deport != null) lista.Add(deport);
                        }
                    }
                }
            }
            return lista;
        }*/

        /// <summary>
        /// Devuelve la lista de DTOs con el contenido de las filas marcadas por checkbox en el datagrid.
        /// </summary>
        private List<SelectedRowDto> GetSelectedRowsDto()
        {
            var lista = new List<SelectedRowDto>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Si la columna colSeleccionar existe y su valor es true
                if (row.Cells["colSeleccionar"].Value is bool sel && sel)
                {
                    // Obtener cada celda según los nombres de columnas del diseñador
                    int id = 0;
                    int.TryParse(row.Cells["colIdDeportista"].Value?.ToString(), out id);

                    var dto = new SelectedRowDto
                    {
                        IdDeportista = id,
                        Cedula = row.Cells["colCedula"].Value?.ToString() ?? "",
                        Nombres = row.Cells["colNombres"].Value?.ToString() ?? "",
                        Apellidos = row.Cells["colApellidos"].Value?.ToString() ?? "",
                        DisciplinasParticipadas = row.Cells["colDisciplinas"].Value?.ToString() ?? "",
                        Genero = row.Cells["colGenero"].Value?.ToString() ?? "",
                        TipoDiscapacidad = row.Cells["colTipoDiscapacidad"].Value?.ToString() ?? ""
                    };

                    lista.Add(dto);
                }
            }
            return lista;
        }

        // ----------------------
        // Click en la columna Editar o checkbox
        // ----------------------
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colSeleccionar")
            {
                // Alternar el checkbox (por si UseColumnTextForButtonValue confunde)
                var cell = dataGridView1.Rows[e.RowIndex].Cells["colSeleccionar"];
                bool value = cell.Value is bool b && b;
                cell.Value = !value;
            }
            else if (colName == "colEditar")
            {
                // Al pulsar editar: abrir el formulario de edición correspondiente.
                // Aquí intentamos obtener el primer RegistroTotal de ese deportista para editar el desempeño.
                var row = dataGridView1.Rows[e.RowIndex];
                if (!int.TryParse(row.Cells["colIdDeportista"].Value?.ToString(), out int idDeportista))
                {
                    MessageBox.Show("No se pudo identificar el deportista a editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener registros completos de ese deportista. Usamos el primer registro como entrada.
                var registros = _puente.ObtenerRegistrosCompletosIdDeportista(idDeportista);
                if (registros == null || registros.Count == 0)
                {
                    MessageBox.Show("No existen participaciones (desempeños) para ese deportista.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Abrir FrmEditarCompetencia con el primer registro (si deseas permitir elegir registro,
                // podrías mostrar una lista de participaciones antes de abrir).
                var registro = registros.First();
                _frmPrincipal.AbrirFormularioEnPanel(new FrmEditarCompetencia(registro, _frmPrincipal));
                this.Close();
            }
        }

        private void txbCedula_Enter(object sender, EventArgs e)
        {
            if (txbCedula.Text == "CEDULA" && txbCedula.ForeColor == Color.DarkGray)
            {
                txbCedula.Text = "";
                txbCedula.ForeColor = Color.Black;
            }
        }

        private void txbCedula_Leave(object sender, EventArgs e)
        {

            if (txbCedula.Text == "")
            {
                txbCedula.Text = "CEDULA";
                txbCedula.ForeColor = Color.DarkGray;
            }
        }

        private void txbApellidos_Enter(object sender, EventArgs e)
        {
            if (txbApellidos.Text == "APELLIDOS" && txbApellidos.ForeColor == Color.DarkGray)
            {
                txbApellidos.Text = "";
                txbApellidos.ForeColor = Color.Black;
            }
        }

        private void txbApellidos_Leave(object sender, EventArgs e)
        {
            if (txbApellidos.Text == "")
            {
                txbApellidos.Text = "APELLIDOS";
                txbApellidos.ForeColor = Color.DarkGray;
            }
        }

        private void txbNombres_Enter(object sender, EventArgs e)
        {
            if (txbNombres.Text == "NOMBRES" && txbNombres.ForeColor == Color.DarkGray)
            {
                txbNombres.Text = "";
                txbNombres.ForeColor = Color.Black;
            }
        }

        private void txbNombres_Leave(object sender, EventArgs e)
        {
            if (txbNombres.Text == "")
            {
                txbNombres.Text = "NOMBRES";
                txbNombres.ForeColor = Color.DarkGray;
            }
        }

        private void txbCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnBuscar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el siguiente campos
                txbApellidos.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txbApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el siguiente campos
                txbNombres.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void txbNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método que maneja el clic del botón
                btnBuscar_Click(sender, e);

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Tab)
            {
                // Pone el foco de control en el boton Buscar
                btnBuscar.Focus();

                // Importante: establece e.Handled en true para evitar el sonido
                // y para que la tecla Enter / Tab no se procese como un carácter de entrada.
                e.Handled = true;
            }
        }

        private void btnOrdenarId_Click(object sender, EventArgs e)
        {
            txbCedula.Text = "CEDULA";
            txbCedula.ForeColor = Color.DarkGray;
            txbApellidos.Text = "APELLIDOS";
            txbApellidos.ForeColor = Color.DarkGray;
            txbNombres.Text = "NOMBRES";
            txbNombres.ForeColor = Color.DarkGray;

            PoblarDataGrid(_listaDeportistas.OrderByDescending(d => d.id_deportista).ToList());
        }

    }
}
