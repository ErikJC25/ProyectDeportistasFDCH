using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Data;
using System.Windows.Forms;

namespace FDCH.UI
{
    internal static class ExportarWord
    {
        public static void ExportarAWord(DataGridView dgv)
        {
            try
            {
                // Convertir DataGridView a DataTable
                DataTable dt = ObtenerDataTableDelDataGridView(dgv);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar diálogo para guardar archivo
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivos Word|*.docx", FileName = "Exportacion.docx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Crear Word desde DataTable
                        CrearWordDesdeDataTable(dt, sfd.FileName);

                        MessageBox.Show("Exportación a Word completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Word: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataTable ObtenerDataTableDelDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Crear columnas
            foreach (DataGridViewColumn column in dgv.Columns)
                dt.Columns.Add(column.HeaderText);

            // Crear filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                        dr[i] = row.Cells[i].Value ?? DBNull.Value;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        // Aquí iría tu método reescrito CrearWordDesdeDataTable
        // (el que ya ajusta anchos, bordes, padding y formato)

        private static void CrearWordDesdeDataTable(DataTable dt, string ruta)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(ruta, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Calcular ancho aproximado de cada columna según el contenido
                int[] columnWidths = new int[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    int maxLength = dt.Columns[i].ColumnName.Length;
                    foreach (DataRow row in dt.Rows)
                    {
                        int len = row[i]?.ToString().Length ?? 0;
                        if (len > maxLength) maxLength = len;
                    }
                    columnWidths[i] = maxLength * 150; // Factor de escala para ancho en Word
                }

                // Crear tabla con bordes y ancho de página
                Table table = new Table(
                    new TableProperties(
                        new TableBorders(
                            new TopBorder { Val = BorderValues.Single, Size = 4 },
                            new BottomBorder { Val = BorderValues.Single, Size = 4 },
                            new LeftBorder { Val = BorderValues.Single, Size = 4 },
                            new RightBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                            new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                        ),
                        new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct }, // 100% ancho de página
                        new TableLayout { Type = TableLayoutValues.Fixed }, // Mantener anchos fijos
                        new TableCellMarginDefault(
                            new TopMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                            new BottomMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                            new LeftMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                            new RightMargin { Width = "100", Type = TableWidthUnitValues.Dxa }
                        )
                    )
                );

                // Encabezado con fondo gris y negrita
                TableRow headerRow = new TableRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    TableCell cell = new TableCell(
                        new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = columnWidths[i].ToString() },
                            new Shading { Color = "auto", Fill = "D3D3D3", Val = ShadingPatternValues.Clear },
                            new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                        ),
                        new Paragraph(
                            new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                            new Run(new RunProperties(new Bold()), new Text(dt.Columns[i].ColumnName))
                        )
                    );
                    headerRow.Append(cell);
                }
                table.Append(headerRow);

                // Filas de datos
                foreach (DataRow row in dt.Rows)
                {
                    TableRow dataRow = new TableRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        TableCell cell = new TableCell(
                            new TableCellProperties(
                                new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = columnWidths[i].ToString() },
                                new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                            ),
                            new Paragraph(
                                new ParagraphProperties(new Justification { Val = JustificationValues.Left }),
                                new Run(new Text(row[i]?.ToString() ?? ""))
                            )
                        );
                        dataRow.Append(cell);
                    }
                    table.Append(dataRow);
                }

                body.Append(table);
            }
        }

    }
}
