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
        /// Por defecto ordena por NOMBRES (como pediste).
        /// </summary>
        private void CargarDatosIniciales()
        {
            try
            {
                // 1) traer deportistas
                _listaDeportistas = _puente.ObtenerTodosDeportistas() ?? new List<Deportista>();

                // 2) traer disciplinas por deportista (UNA sola consulta)
                _mapaDisciplinas = _puente.ObtenerDisciplinasPorDeportista() ?? new Dictionary<int, List<string>>();

                // 3) mostrar ordenados por nombres
                var ordenados = _listaDeportistas.OrderBy(d => d.nombres).ToList();
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
            string cedula = txbCedula.Text?.Trim();
            string apellidos = txbApellidos.Text?.Trim();
            string nombres = txbNombres.Text?.Trim();

            // Si todos vacíos -> advertir
            if (string.IsNullOrWhiteSpace(cedula) && string.IsNullOrWhiteSpace(apellidos) && string.IsNullOrWhiteSpace(nombres))
            {
                MessageBox.Show("Ingrese al menos un criterio para buscar.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            txbCedula.Text = "";
            txbApellidos.Text = "";
            txbNombres.Text = "";
            // restaurar lista completa
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.nombres).ToList());
        }

        private void btnOrdenarApellidos_Click(object sender, EventArgs e)
        {
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.apellidos).ToList());
        }

        private void btnOrdenarNombres_Click(object sender, EventArgs e)
        {
            PoblarDataGrid(_listaDeportistas.OrderBy(d => d.nombres).ToList());
        }


        private void btnFusionar_Click(object sender, EventArgs e)
        {
            var seleccionados = GetDeportistasSeleccionados();

            if (seleccionados.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos deportistas para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir FrmFusionarDeportistas pasando la lista. Se asume que existe un constructor aceptando List<Deportista> y FrmPrincipal
            var frm = new FrmFusionarDeportistas(seleccionados, _frmPrincipal);
            _frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }

        private void btnSeparar_Click(object sender, EventArgs e)
        {
            var seleccionados = GetDeportistasSeleccionados();

            if (seleccionados.Count != 1)
            {
                MessageBox.Show("Seleccione exactamente un deportista para separar.", "Separar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new FrmSepararDeportistas(seleccionados.First(), _frmPrincipal);
            _frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }


        /// <summary>
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

    }
}
