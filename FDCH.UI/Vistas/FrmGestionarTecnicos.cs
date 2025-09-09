using FDCH.Entidades;
using FDCH.Logica;
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
    public partial class FrmGestionarTecnicos : Form
    {
        private readonly Cls_Puente _puente = new Cls_Puente();
        private readonly FrmPrincipal _frmPrincipal;
        // Cache
        private List<Tecnico> _listaTecnicos = new List<Tecnico>();
        // mapa id_tecnico -> lista de disciplinas (UN SOLO fetch)
        private Dictionary<int, List<string>> _mapaDisciplinasPorTecnico = new Dictionary<int, List<string>>();
        public FrmGestionarTecnicos(FrmPrincipal principal)
        {
            InitializeComponent();

            _frmPrincipal = principal ?? throw new ArgumentNullException(nameof(principal));
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FrmGestionarTecnicos_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }


        /// <summary>
        /// Carga inicial: lista de técnicos y mapa de disciplinas (en una sola consulta).
        /// Por defecto ordena por id_tecnico DESC (mayor->menor).
        /// </summary>
        private void CargarDatosIniciales()
        {
            try
            {
                // Traer técnicos
                _listaTecnicos = _puente.ObtenerTecnicos() ?? new List<Tecnico>();

                // Traer disciplinas por técnico, incluyendo técnicos sin disciplinas.
                // orderDesc = false aquí porque solo queremos el mapa; el orden real de visualización lo haces sobre la lista de técnicos.
                _mapaDisciplinasPorTecnico = _puente.ObtenerDisciplinasPorTecnico(orderDesc: false) ?? new Dictionary<int, List<string>>();

                // Por defecto mostrar ordenados por id descendente (más reciente primero)
                var ordenados = _listaTecnicos.OrderByDescending(t => t.id_tecnico).ToList();
                PoblarDataGrid(ordenados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando técnicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena el dataGridView con la lista suministrada.
        /// Se asume que las columnas están en el diseñador en este orden/with names.
        /// </summary>
        private void PoblarDataGrid(List<Tecnico> lista)
        {
            dataGridView1.Rows.Clear();

            foreach (var t in lista)
            {
                string disciplinasTexto = "";
                if (t != null && _mapaDisciplinasPorTecnico.TryGetValue(t.id_tecnico, out var listaDisc) && listaDisc.Any())
                {
                    disciplinasTexto = string.Join(", ", listaDisc.OrderBy(x => x));
                }

                // Crear DTO que guardamos en Tag para facilitar edición/fusión
                var dto = new TecnicoRowDto
                {
                    IdTecnico = t.id_tecnico,
                    NombreCompleto = t.nombre_completo ?? "",
                    DisciplinasDirigidas = disciplinasTexto
                };

                int rowIndex = dataGridView1.Rows.Add(false, // seleccionar checkbox
                                                     dto.NombreCompleto,
                                                     dto.DisciplinasDirigidas,
                                                     "Editar",
                                                     dto.IdTecnico);
                dataGridView1.Rows[rowIndex].Tag = dto;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string placeholder = "NOMBRE COMPLETO";
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text) || (txtNombreCompleto.Text == placeholder && txtNombreCompleto.ForeColor == Color.DarkGray))
            {
                MessageBox.Show("Ingrese un nombre para buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string criterio = (txtNombreCompleto.Text == placeholder && txtNombreCompleto.ForeColor == Color.DarkGray) ? "" : txtNombreCompleto.Text.Trim();

            var filtrados = _listaTecnicos.Where(t =>
                string.IsNullOrWhiteSpace(criterio)
                    || (t.nombre_completo ?? "").IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0
            ).OrderBy(t => t.nombre_completo).ToList();

            PoblarDataGrid(filtrados);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCompleto.Text = "NOMBRE COMPLETO";
            txtNombreCompleto.ForeColor = Color.DarkGray;
            PoblarDataGrid(_listaTecnicos.OrderByDescending(t => t.id_tecnico).ToList());
        }

        private void btnOrdenarAlfabeticamente_Click(object sender, EventArgs e)
        {
            txtNombreCompleto.Text = "NOMBRE COMPLETO";
            txtNombreCompleto.ForeColor = Color.DarkGray;
            PoblarDataGrid(_listaTecnicos.OrderBy(t => t.nombre_completo).ToList());
        }

        private void btnFusionar_Click(object sender, EventArgs e)
        {
            var seleccionados = GetSelectedRowsDto();

            if (seleccionados.Count < 2)
            {
                MessageBox.Show("Seleccione al menos dos técnicos para fusionar.", "Fusionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Abrir FrmFusionarTecnicos — asumo que existe y acepta la lista de DTOs y FrmPrincipal
            //var frm = new FrmFusionarTecnicos(seleccionados, _frmPrincipal);
            //_frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            var frm = new FrmAgregarNuevoTecnico(_frmPrincipal);
            _frmPrincipal.AbrirFormularioEnPanel(frm);
            this.Close();
        }

        /// <summary>
        /// Devuelve DTOs de las filas marcadas con checkbox.
        /// </summary>
        private List<TecnicoRowDto> GetSelectedRowsDto()
        {
            var lista = new List<TecnicoRowDto>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colSeleccionar"].Value is bool sel && sel)
                {
                    if (row.Tag is TecnicoRowDto tagDto)
                    {
                        lista.Add(tagDto);
                    }
                    else
                    {
                        int id = 0;
                        int.TryParse(row.Cells["colIdTecnico"].Value?.ToString(), out id);
                        var dto = new TecnicoRowDto
                        {
                            IdTecnico = id,
                            NombreCompleto = row.Cells["colNombreCompleto"].Value?.ToString() ?? "",
                            DisciplinasDirigidas = row.Cells["colDisciplinas"].Value?.ToString() ?? ""
                        };
                        lista.Add(dto);
                    }
                }
            }
            return lista;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colSeleccionar")
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells["colSeleccionar"];
                bool value = cell.Value is bool b && b;
                cell.Value = !value;
            }
            else if (colName == "colEditar")
            {
                var row = dataGridView1.Rows[e.RowIndex];

                TecnicoRowDto dto = null;
                if (row.Tag is TecnicoRowDto tagDto)
                {
                    dto = tagDto;
                }
                else
                {
                    int id = 0;
                    int.TryParse(row.Cells["colIdTecnico"].Value?.ToString(), out id);
                    dto = new TecnicoRowDto
                    {
                        IdTecnico = id,
                        NombreCompleto = row.Cells["colNombreCompleto"].Value?.ToString() ?? "",
                        DisciplinasDirigidas = row.Cells["colDisciplinas"].Value?.ToString() ?? ""
                    };
                }

                //Abrir formulario de edición de técnico: se asume que existe FrmEditarTecnico que acepta este DTO
                var frm = new FrmEditarTecnico(dto, _frmPrincipal);
                _frmPrincipal.AbrirFormularioEnPanel(frm);
                this.Close();
            }
        }

        private void txtNombreCompleto_Enter(object sender, EventArgs e)
        {
            if (txtNombreCompleto.Text == "NOMBRE COMPLETO" && txtNombreCompleto.ForeColor == Color.DarkGray)
            {
                txtNombreCompleto.Text = "";
                txtNombreCompleto.ForeColor = Color.Black;
            }
        }

        private void txtNombreCompleto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                txtNombreCompleto.Text = "NOMBRE COMPLETO";
                txtNombreCompleto.ForeColor = Color.DarkGray;
            }
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnOrdenarId_Click(object sender, EventArgs e)
        {
            txtNombreCompleto.Text = "NOMBRE COMPLETO";
            txtNombreCompleto.ForeColor = Color.DarkGray;
            PoblarDataGrid(_listaTecnicos.OrderByDescending(t => t.id_tecnico).ToList());
        }
    }
}
