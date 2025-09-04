// ExportarWord.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;

namespace FDCH.UI
{
    /// <summary>
    /// ExportarWord: rellena plantilla Word con placeholders y construye tabla desde DataGridView.
    /// Plantilla esperada: Resources\TemplateCertificado.docx
    /// </summary>
    internal static class ExportarWord
    {
        // Nombre del archivo plantilla dentro de Resources
        private const string TemplateFileName = "TemplateCertificado.docx";

        /// <summary>
        /// Método principal que copia la plantilla y la rellena con los datos del DataGridView.
        /// </summary>
        public static async Task ExportarDesdePlantillaAsync(DataGridView dataGridView, Form parentForm, string titulo, string rol)
        {
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Documento Word|*.docx";
                    dlg.FileName = "CERTIFICADO RECORD DEPORTIVO.docx";
                    if (dlg.ShowDialog(parentForm) != DialogResult.OK) return;

                    string outputPath = dlg.FileName;

                    // 1) localizar plantilla (buscar Resources\TemplateCertificado.docx)
                    string plantillaPath = BuildPossibleResourcePaths("Resources", TemplateFileName).FirstOrDefault(File.Exists);
                    if (plantillaPath == null)
                    {
                        MessageBox.Show($"No se encontró la plantilla Resources\\{TemplateFileName}. Colócala en la carpeta Resources del proyecto.", "Plantilla no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2) copiar plantilla al destino (sobrescribir si existe)
                    File.Copy(plantillaPath, outputPath, true);

                    // 3) obtener valores desde dataGridView (primera fila no NewRow)
                    var firstDataRow = dataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => !r.IsNewRow);

                    string apellidos = GetCellValueSafe(firstDataRow, dataGridView, new[] { "APELLIDOS", "APELLIDO" }).ToUpperInvariant();
                    string nombres = GetCellValueSafe(firstDataRow, dataGridView, new[] { "NOMBRES", "NOMBRE", "NOMBRE_COMPLETO" }).ToUpperInvariant();
                    string cedula = GetCellValueSafe(firstDataRow, dataGridView, new[] { "CEDULA", "CI", "CÉDULA" });
                    string disciplina = GetCellValueSafe(firstDataRow, dataGridView, new[] { "DISCIPLINA", "DISCIPLINAS", "DEPORTE" }).ToUpperInvariant();

                    // 4) preparar placeholders (fecha por partes)
                    DateTime ahora = DateTime.Now;
                    string dia = ahora.Day.ToString("D2");
                    string mes = ahora.ToString("MMMM", new CultureInfo("es-ES")); // mes en palabras, en minúsculas según convención
                    string anio = ahora.Year.ToString();

                    // Marker único para luego reemplazar por tabla (se garantiza que es único)
                    string tablaMarker = "##__TABLA_RESULTADOS__##";

                    // Diccionario de placeholders (tabla se reemplaza por marker temporal)
                    var placeholders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "{{DIA}}", dia },
                        { "{{MES}}", mes },
                        { "{{ANIO}}", anio },
                        { "{{ROL}}", rol ?? "" },
                        { "{{APELLIDOS}}", apellidos },
                        { "{{NOMBRES}}", nombres },
                        { "{{CEDULA}}", string.IsNullOrWhiteSpace(cedula) ? "N/A" : cedula },
                        { "{{DISCIPLINA}}", string.IsNullOrWhiteSpace(disciplina) ? "NO ESPECIFICADA" : disciplina.ToUpperInvariant() },
                        { "{{TITULO}}", titulo ?? "" },
                        // Reemplazamos el placeholder de tabla por un marker temporal que luego buscaremos como Text único
                        { "{{TABLA_RESULTADOS}}", tablaMarker }
                    };

                    // 5) abrir copia de la plantilla y reemplazar placeholders
                    using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
                    {
                        // usar función robusta que reemplaza placeholders aunque estén partidas en varios runs
                        ReplacePlaceholdersRobust(doc, placeholders);

                        // 6) insertar la tabla en lugar del marker
                        bool tablaInsertada = ReplaceMarkerWithTable(doc, tablaMarker, dataGridView);

                        if (!tablaInsertada)
                        {
                            // Si no se insertó la tabla (no se encontró el marker), avisar, pero guardamos el documento de todas maneras.
                            MessageBox.Show("Advertencia: no se encontró el marcador {{TABLA_RESULTADOS}} en la plantilla; no se insertó la tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        doc.MainDocumentPart.Document.Save();
                    }

                    MessageBox.Show("Documento generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Reemplazo robusto de placeholders (maneja runs fragmentados)

        /// <summary>
        /// Reemplaza todos los placeholders del diccionario en el documento, incluso si
        /// los placeholders están fragmentados en varios runs dentro de un mismo párrafo.
        /// </summary>
        private static void ReplacePlaceholdersRobust(WordprocessingDocument doc, Dictionary<string, string> placeholders)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));
            var body = doc.MainDocumentPart.Document.Body;

            // Reemplazar en el cuerpo
            foreach (var para in body.Descendants<Paragraph>())
                ReplacePlaceholdersInParagraph(para, placeholders);

            // Reemplazar también en headers y footers (por si hay placeholders allí)
            if (doc.MainDocumentPart.HeaderParts != null)
                foreach (var hp in doc.MainDocumentPart.HeaderParts)
                    foreach (var para in hp.Header.Descendants<Paragraph>())
                        ReplacePlaceholdersInParagraph(para, placeholders);

            if (doc.MainDocumentPart.FooterParts != null)
                foreach (var fp in doc.MainDocumentPart.FooterParts)
                    foreach (var para in fp.Footer.Descendants<Paragraph>())
                        ReplacePlaceholdersInParagraph(para, placeholders);
        }

        /// <summary>
        /// Reemplaza placeholders dentro de un párrafo, incluso si el placeholder está repartido en varios Text nodes.
        /// Implementación: construye la cadena concatenada de los Text del párrafo, busca el placeholder,
        /// y lo sustituye por un nuevo Run (copiando formato del primer run implicado).
        /// </summary>
        private static void ReplacePlaceholdersInParagraph(Paragraph para, Dictionary<string, string> placeholders)
        {
            if (para == null) return;

            // obtener lista de Text en orden
            var textNodes = para.Descendants<Text>().ToList();
            if (!textNodes.Any()) return;

            // concatenar todo el texto del párrafo para buscar placeholders
            string concat = string.Concat(textNodes.Select(t => t.Text ?? ""));
            if (string.IsNullOrEmpty(concat)) return;

            // Para cada placeholder buscar sus apariciones en el párrafo
            foreach (var kv in placeholders)
            {
                string placeholder = kv.Key;
                string replacement = kv.Value ?? "";

                int searchIndex = 0;
                while (true)
                {
                    int idx = concat.IndexOf(placeholder, searchIndex, StringComparison.OrdinalIgnoreCase);
                    if (idx < 0) break;

                    // localizar inicio (text node index y offset)
                    int cum = 0;
                    int startTextIndex = -1, startOffset = 0;
                    for (int i = 0; i < textNodes.Count; i++)
                    {
                        int len = (textNodes[i].Text ?? "").Length;
                        if (cum + len > idx)
                        {
                            startTextIndex = i;
                            startOffset = idx - cum;
                            break;
                        }
                        cum += len;
                    }

                    // localizar fin
                    int endPos = idx + placeholder.Length; // posición posterior al placeholder
                    cum = 0;
                    int endTextIndex = -1, endOffset = 0;
                    for (int i = 0; i < textNodes.Count; i++)
                    {
                        int len = (textNodes[i].Text ?? "").Length;
                        if (cum + len >= endPos)
                        {
                            endTextIndex = i;
                            endOffset = endPos - cum;
                            break;
                        }
                        cum += len;
                    }

                    if (startTextIndex == -1 || endTextIndex == -1)
                        break; // no se pudo localizar correctamente

                    // Runs implicados
                    Run firstRun = textNodes[startTextIndex].Ancestors<Run>().FirstOrDefault();
                    Run lastRun = textNodes[endTextIndex].Ancestors<Run>().FirstOrDefault();

                    // Prefijo y sufijo
                    string firstText = textNodes[startTextIndex].Text ?? "";
                    string prefix = firstText.Substring(0, startOffset);
                    string lastText = textNodes[endTextIndex].Text ?? "";
                    string suffix = lastText.Substring(endOffset);

                    // Crear nuevo run con el texto de reemplazo, copiando RunProperties del primerRun si existe
                    Run newRun = new Run();
                    if (firstRun != null)
                    {
                        var rp = firstRun.RunProperties?.CloneNode(true) as RunProperties;
                        if (rp != null) newRun.RunProperties = rp;
                    }
                    // preservar espacios en blanco del replacement
                    newRun.AppendChild(new Text(replacement) { Space = SpaceProcessingModeValues.Preserve });

                    // Insertar prefijo si existe (con formato del firstRun)
                    if (!string.IsNullOrEmpty(prefix))
                    {
                        Run prefixRun = new Run();
                        if (firstRun?.RunProperties != null)
                            prefixRun.RunProperties = (RunProperties)firstRun.RunProperties.CloneNode(true);
                        prefixRun.AppendChild(new Text(prefix) { Space = SpaceProcessingModeValues.Preserve });
                        firstRun.Parent.InsertBefore(prefixRun, firstRun);
                    }

                    // Insertar newRun antes del firstRun
                    if (firstRun != null)
                        firstRun.Parent.InsertBefore(newRun, firstRun);
                    else
                        para.AppendChild(newRun);

                    // Insertar sufijo si existe (con formato del lastRun)
                    Run suffixRun = null;
                    if (!string.IsNullOrEmpty(suffix))
                    {
                        suffixRun = new Run();
                        if (lastRun?.RunProperties != null)
                            suffixRun.RunProperties = (RunProperties)lastRun.RunProperties.CloneNode(true);
                        suffixRun.AppendChild(new Text(suffix) { Space = SpaceProcessingModeValues.Preserve });
                    }

                    // Eliminar runs/Texts implicados (desde firstRun hasta lastRun inclusive)
                    var runs = para.Elements<Run>().ToList();
                    int startRunIndex = -1, endRunIndex = -1;
                    for (int i = 0; i < runs.Count; i++)
                    {
                        if (runs[i] == firstRun) startRunIndex = i;
                        if (runs[i] == lastRun) endRunIndex = i;
                    }
                    if (startRunIndex >= 0 && endRunIndex >= startRunIndex)
                    {
                        for (int i = endRunIndex; i >= startRunIndex; i--)
                            runs[i].Remove();
                    }
                    else
                    {
                        // fallback: eliminar los Text nodes directamente
                        for (int i = endTextIndex; i >= startTextIndex; i--)
                            textNodes[i].Parent.Remove();
                    }

                    // Insertar suffixRun después del newRun si aplica
                    if (suffixRun != null)
                        newRun.Parent.InsertAfter(suffixRun, newRun);

                    // Recalcular textNodes y concat para continuar buscando
                    textNodes = para.Descendants<Text>().ToList();
                    concat = string.Concat(textNodes.Select(t => t.Text ?? ""));

                    // Mover searchIndex para evitar ciclos (buscar después del replacement)
                    int posOfReplacement = concat.IndexOf(replacement, StringComparison.Ordinal);
                    searchIndex = (posOfReplacement >= 0) ? posOfReplacement + replacement.Length : 0;
                }
            }
        }

        #endregion

        #region Reemplazo del marcador por tabla

        /// <summary>
        /// Busca el marker en el documento (texto exacto que quedó por ReplacePlaceholdersRobust)
        /// y reemplaza el párrafo que lo contiene por una tabla creada desde el DataGridView.
        /// </summary>
        private static bool ReplaceMarkerWithTable(WordprocessingDocument doc, string marker, DataGridView grid)
        {
            // buscar Text node que contenga el marker en el cuerpo
            var textNode = doc.MainDocumentPart.Document.Body.Descendants<Text>().FirstOrDefault(t => (t.Text ?? "").Contains(marker));
            // si no está en cuerpo, intentar headers
            if (textNode == null)
            {
                foreach (var hp in doc.MainDocumentPart.HeaderParts)
                {
                    textNode = hp.Header.Descendants<Text>().FirstOrDefault(t => (t.Text ?? "").Contains(marker));
                    if (textNode != null)
                    {
                        // Si el marker estaba en header, reemplazamos en el header
                        var paragraph = textNode.Ancestors<Paragraph>().FirstOrDefault();
                        if (paragraph != null)
                        {
                            Table table = CreateTableFromDataGrid(grid);
                            paragraph.Parent.InsertAfter(table, paragraph);
                            paragraph.Remove();
                            return true;
                        }
                    }
                }
            }
            else
            {
                var paragraph = textNode.Ancestors<Paragraph>().FirstOrDefault();
                if (paragraph != null)
                {
                    Table table = CreateTableFromDataGrid(grid);
                    paragraph.Parent.InsertAfter(table, paragraph);
                    paragraph.Remove();
                    return true;
                }
            }

            return false;
        }

        #endregion

        private static readonly Dictionary<string, string> ColumnHeaderReplacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Ejemplo: si en el DataGrid viene "FECHA FIN" queremos mostrar "FECHA TERMINA"
            { "FechaFin", "FECHA TERMINA" },
            { "Modalidad", "INDIV / EQUIP" },
            { "Categoria", "CATEGORÍA" },
            { "Ubicacion", "UBIC" }
        };

        #region Creación de tabla desde DataGridView (exclusiones solicitadas)

        /// <summary>
        /// Crea una tabla OpenXML desde el DataGridView respetando exclusiones y omitiendo columnas vacías.
        /// Encabezado: Bahnschrift SemiLight Condensed, 7pt, negrita, celeste.
        /// Contenido: Bahnschrift SemiLight Condensed, 8pt.
        /// </summary>
        private static Table CreateTableFromDataGrid(DataGridView dataGridView)
        {
            // Columnas a excluir (ajusta si necesitas)
            HashSet<string> columnasExcluidas = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                 "NombreDisciplina", "DISCIPLINA", "MES", "MesInicioEvento", "CEDULA", "APELLIDOS", "NOMBRES", "AÑO TORNEO", "AnioInicioEvento",
                "GENERO", "NIVEL", "NivelEvento", "TECNICO", "NombreCompletoTecnico", "RECORD", "#PARTICIPANTES", "NumeroParticipantes", "TipoEvento",
                "TIPO DISCAPACIDAD", "TipoDiscapacidad", "OBSERVACIONES", "Editar", "colEditar",
                // Nuevas columnas pedidas para excluir
                "IdTecnico", "IdEvento", "IdDisciplina", "IdEspecialidad", "IdCompetencia", "IdDesempeno"

            };

            List<int> columnasValidas = new List<int>();

            for (int col = 0; col < dataGridView.Columns.Count; col++)
            {
                var columna = dataGridView.Columns[col];
                string id = !string.IsNullOrWhiteSpace(columna.Name) ? columna.Name.Trim() : (columna.HeaderText ?? "").Trim();

                if (columnasExcluidas.Contains(id))
                    continue;

                bool columnaVacia = true;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;
                    var val = row.Cells[col].Value;
                    if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                    {
                        columnaVacia = false;
                        break;
                    }
                }

                if (!columnaVacia)
                    columnasValidas.Add(col);
            }

            Table table = new Table();

            TableProperties tblProps = new TableProperties(
                new TableBorders(
                    new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                    new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
                )
            );
            tblProps.Append(new TableWidth() { Width = "9600", Type = TableWidthUnitValues.Dxa });
            table.AppendChild(tblProps);

            // Cabecera: Bahnschrift SemiLight Condensed 7pt, negrita, celeste
            TableRow headerRow = new TableRow();
            foreach (int col in columnasValidas)
            {
                var columna = dataGridView.Columns[col];

                // Preferimos HeaderText para mostrar; si no existe, usamos Name
                string headerTextOriginal = !string.IsNullOrWhiteSpace(columna.HeaderText) ? columna.HeaderText.Trim() : (columna.Name ?? "").Trim();

                // Aplicar reemplazo si hay una excepción definida, comprobando tanto HeaderText como Name
                string headerTextMostrar = headerTextOriginal;

                // 1) comprobar mapa por HeaderText
                if (ColumnHeaderReplacements.TryGetValue(headerTextOriginal, out var mappedByHeader))
                {
                    headerTextMostrar = mappedByHeader;
                }
                else
                {
                    // 2) comprobar mapa por Name (por si la columna tiene Name distinto)
                    string nameKey = (columna.Name ?? "").Trim();
                    if (!string.IsNullOrEmpty(nameKey) && ColumnHeaderReplacements.TryGetValue(nameKey, out var mappedByName))
                    {
                        headerTextMostrar = mappedByName;
                    }
                    else
                    {
                        // 3) también puedes comprobar versiones sin espacios, mayúsculas, etc., si lo deseas:
                        //    (ya está usando StringComparer.OrdinalIgnoreCase, así que "Fecha Fin" y "FECHA FIN" coincidirán)
                    }
                }

                TableCell cell = new TableCell();
                TableCellProperties cellProps = new TableCellProperties(
                    new Shading() { Color = "auto", Fill = "87CEEB", Val = ShadingPatternValues.Clear }
                );
                cell.AppendChild(cellProps);

                Paragraph para = new Paragraph();
                Run run = new Run();
                RunProperties rp = new RunProperties();
                rp.AppendChild(new Bold());
                rp.AppendChild(new RunFonts() { Ascii = "Bahnschrift SemiLight Condensed", HighAnsi = "Bahnschrift SemiLight Condensed" });
                rp.AppendChild(new FontSize() { Val = (7 * 2).ToString() }); // 7pt -> 14 half-points
                run.AppendChild(rp);
                run.AppendChild(new Text(headerTextMostrar ?? "") { Space = SpaceProcessingModeValues.Preserve });
                para.AppendChild(run);
                cell.AppendChild(para);

                headerRow.AppendChild(cell);
            }
            table.AppendChild(headerRow);

            // Filas de datos
            foreach (DataGridViewRow dgvRow in dataGridView.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                TableRow tr = new TableRow();
                foreach (int col in columnasValidas)
                {
                    string cellText = dgvRow.Cells[col].Value?.ToString() ?? "";

                    TableCell cell = new TableCell();
                    Paragraph p = new Paragraph();
                    Run r = new Run();
                    RunProperties rp = new RunProperties();
                    rp.AppendChild(new RunFonts() { Ascii = "Bahnschrift SemiLight Condensed", HighAnsi = "Bahnschrift SemiLight Condensed" });
                    rp.AppendChild(new FontSize() { Val = (8 * 2).ToString() }); // 8pt
                    r.AppendChild(rp);
                    r.AppendChild(new Text(cellText ?? "") { Space = SpaceProcessingModeValues.Preserve });
                    p.AppendChild(r);
                    cell.AppendChild(p);
                    tr.AppendChild(cell);
                }
                table.AppendChild(tr);
            }

            return table;
        }
        #endregion

        #region Utilidades

        /// <summary>
        /// Busca Resources\fileName subiendo desde AppDomain.CurrentDomain.BaseDirectory hasta 6 niveles.
        /// </summary>
        private static string[] BuildPossibleResourcePaths(string resourcesFolderName, string fileName)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var paths = new List<string>();
            paths.Add(Path.Combine(baseDir, resourcesFolderName, fileName));
            string current = baseDir;
            for (int i = 0; i < 6; i++)
            {
                paths.Add(Path.Combine(current, resourcesFolderName, fileName));
                current = Path.GetFullPath(Path.Combine(current, ".."));
            }
            return paths.Distinct().ToArray();
        }

        /// <summary>
        /// Lee el valor de la primera fila para una lista de nombres posibles de columna (Name o HeaderText).
        /// Si no encuentra, devuelve la primera celda no vacía.
        /// </summary>
        private static string GetCellValueSafe(DataGridViewRow row, DataGridView grid, IEnumerable<string> posiblesNombres)
        {
            if (row == null || grid == null) return string.Empty;

            foreach (var posible in posiblesNombres)
            {
                var col = grid.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.Name, posible, StringComparison.OrdinalIgnoreCase)
                                         || string.Equals(c.HeaderText, posible, StringComparison.OrdinalIgnoreCase));
                if (col != null)
                {
                    var val = row.Cells[col.Index].Value;
                    if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                        return val.ToString();
                }
            }

            // fallback: primera celda no vacía
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell?.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    return cell.Value.ToString();
            }

            return string.Empty;
        }

        #endregion
    }
}
