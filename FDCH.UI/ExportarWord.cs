using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WordColor = DocumentFormat.OpenXml.Wordprocessing.Color;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DW = DocumentFormat.OpenXml.Wordprocessing.Drawing;

namespace FDCH.UI
{
    internal static class ExportarWord
    {
        public static async Task ExportarAWordAsync(DataGridView dataGridView, Form parentForm, string titulo, string rol)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Documento Word|*.docx";
                    saveFileDialog.Title = "Guardar Certificado";
                    saveFileDialog.FileName = "Certificado.docx";

                    if (saveFileDialog.ShowDialog(parentForm) != DialogResult.OK)
                        return;

                    string filePath = saveFileDialog.FileName;

                    string nombreDeportista = "";
                    string cedulaDeportista = "";
                    string disciplinaDeportista = "";

                    if (dataGridView.Rows.Count > 1)
                    {
                        var row = dataGridView.Rows[0];
                        nombreDeportista = (row.Cells["NOMBRES"].Value?.ToString() ?? "").ToUpper() + " " +
                                           (row.Cells["APELLIDOS"].Value?.ToString() ?? "").ToUpper();
                        cedulaDeportista = row.Cells["CEDULA"].Value?.ToString() ?? "XXXXXXXXXX";
                        disciplinaDeportista = (row.Cells["DISCIPLINAS"].Value?.ToString() ?? "NO ESPECIFICADA").ToUpper();
                    }

                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                        Body body = mainPart.Document.Body;

                        SectionProperties sectionProps = new SectionProperties();
                        HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                        CrearEncabezadoConImagen(headerPart);
                        string headerPartId = mainPart.GetIdOfPart(headerPart);
                        HeaderReference headerReference = new HeaderReference() { Type = HeaderFooterValues.Default, Id = headerPartId };
                        sectionProps.Append(headerReference);

                        body.Append(sectionProps);

                        string fechaActual = DateTime.Now.ToString("dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
                        Paragraph fechaParrafo = CrearParrafo($"Riobamba, {fechaActual}", JustificationValues.Right, false, null, "Century Gothic", 22);
                        body.Append(fechaParrafo);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        Paragraph tituloParrafo = CrearParrafoConSubrayado("CERTIFICADO", JustificationValues.Center, true, "00008B", "Bodoni MT Black", 44);
                        body.Append(tituloParrafo);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        Paragraph rolParrafo = CrearParrafo(
                            $"QUIEN SUSCRIBE EN CALIDAD DE {rol.ToUpper()}, DE FEDERACIÓN DEPORTIVA DE CHIMBORAZO EN LEGAL Y DEBIDA FORMA CERTIFICO QUE:",
                            JustificationValues.Both, true, null, "Century Gothic", 22);
                        body.Append(rolParrafo);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        Paragraph deportistaParrafo = new Paragraph();
                        deportistaParrafo.AppendChild(new ParagraphProperties(new Justification() { Val = JustificationValues.Both }));
                        deportistaParrafo.Append(new Run(CrearRunProperties(false, "Century Gothic", 20), new Text("El deportista ")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(true, "Century Gothic", 20), new Text(nombreDeportista)));
                        deportistaParrafo.Append(new Run(CrearRunProperties(false, "Century Gothic", 20), new Text($" con cédula de identidad N° ")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(true, "Century Gothic", 20), new Text($"{cedulaDeportista}, se encuentra legalmente federado en la Matriz del Deporte Provincial en la disciplina de ")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(true, "Century Gothic", 20), new Text(disciplinaDeportista)));
                        deportistaParrafo.Append(new Run(CrearRunProperties(false, "Century Gothic", 20), new Text(" con la ficha No. ")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(true, "Century Gothic", 20), new Text("XXXX")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(false, "Century Gothic", 20), new Text(" desde el ")));
                        deportistaParrafo.Append(new Run(CrearRunProperties(true, "Century Gothic", 20), new Text("XX DE XXXX 20XX.")));

                        body.Append(deportistaParrafo);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        Paragraph resultadosParrafo = CrearParrafo("RESULTADOS OBTENIDOS", JustificationValues.Left, true, null, "Century Gothic", 22);
                        body.Append(resultadosParrafo);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        Table tabla = CrearTablaDesdeDataGrid(dataGridView);
                        body.Append(tabla);
                        body.Append(new Paragraph(new Run(new Text(""))));

                        body.Append(CrearParrafo("Es todo cuanto puedo certificar en honor a la verdad.", JustificationValues.Left, false, null, "Century Gothic", 20));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        body.Append(CrearParrafo("Atentamente,", JustificationValues.Center, false, null, "Verdana", 14));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(CrearParrafo("DEPORTE Y DISCIPLINA", JustificationValues.Center, true, null, "Verdana", 12));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        body.Append(CrearParrafo(titulo, JustificationValues.Center, false, null, "Script MT Bold", 28));
                        body.Append(CrearParrafo(rol.ToUpper(), JustificationValues.Center, true, null, "Century Gothic", 20));
                        body.Append(CrearParrafo("FEDERACIÓN DEPORTIVA DE CHIMBORAZO", JustificationValues.Center, true, null, "Century Gothic", 20));

                        mainPart.Document.Save();
                    }

                    MessageBox.Show("Documento generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el documento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Paragraph CrearParrafo(string texto, JustificationValues alineacion, bool negrita = false, string colorHex = null, string fontName = "Arial", int fontSize = 24)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.AppendChild(new ParagraphProperties(new Justification() { Val = alineacion }));
            Run run = new Run();
            run.AppendChild(CrearRunProperties(negrita, fontName, fontSize, colorHex));
            run.AppendChild(new Text(texto));
            paragraph.AppendChild(run);
            return paragraph;
        }

        private static RunProperties CrearRunProperties(bool negrita, string fontName, int fontSize, string colorHex = null)
        {
            RunProperties runProperties = new RunProperties();
            runProperties.Append(new RunFonts() { Ascii = fontName, HighAnsi = fontName });
            if (negrita) runProperties.Append(new Bold());
            if (!string.IsNullOrEmpty(colorHex)) runProperties.Append(new WordColor() { Val = colorHex });
            runProperties.Append(new FontSize() { Val = (fontSize * 2).ToString() });
            return runProperties;
        }

        private static Paragraph CrearParrafoConSubrayado(string texto, JustificationValues alineacion, bool negrita = false, string colorHex = null, string fontName = "Arial", int fontSize = 24)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.AppendChild(new ParagraphProperties(new Justification() { Val = alineacion }));
            Run run = new Run();
            RunProperties runProperties = CrearRunProperties(negrita, fontName, fontSize, colorHex);
            runProperties.Append(new Underline() { Val = UnderlineValues.Single });
            run.AppendChild(runProperties);
            run.AppendChild(new Text(texto));
            paragraph.AppendChild(run);
            return paragraph;
        }

        private static Table CrearTablaDesdeDataGrid(DataGridView dataGridView)
        {
            List<int> columnasValidas = new List<int>();

            List<string> columnasExcluidas = new List<string> {
                "DISCIPLINAS", "MES", "CEDULA", "APELLIDOS", "NOMBRES", "AÑO TORNEO",
                "GENERO", "NIVEL", "TECNICO", "RECORD", "#PARTICIPANTES",
                "TIPO DISCAPACIDAD", "OBSERVACIONES", "Editar"
            };

            for (int col = 0; col < dataGridView.Columns.Count; col++)
            {
                string headerText = dataGridView.Columns[col].HeaderText;
                bool debeExcluirse = columnasExcluidas.Any(excluida =>
                    headerText.Equals(excluida, StringComparison.OrdinalIgnoreCase));

                if (!debeExcluirse)
                {
                    bool columnaVacia = true;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[col].Value != null &&
                            !string.IsNullOrWhiteSpace(row.Cells[col].Value.ToString()))
                        {
                            columnaVacia = false;
                            break;
                        }
                    }

                    if (!columnaVacia)
                        columnasValidas.Add(col);
                }
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

            TableRow headerRow = new TableRow();
            foreach (int col in columnasValidas)
            {
                TableCell cell = new TableCell();
                TableCellProperties cellProps = new TableCellProperties(
                    new Shading() { Color = "auto", Fill = "87CEEB", Val = ShadingPatternValues.Clear }
                );
                cell.Append(cellProps);

                Paragraph para = new Paragraph(new Run(
                    CrearRunProperties(true, "Bahnschrift SemiLight Condensed", 14),
                    new Text(dataGridView.Columns[col].HeaderText)
                ));

                cell.Append(para);
                headerRow.Append(cell);
            }
            table.Append(headerRow);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                TableRow tableRow = new TableRow();
                foreach (int col in columnasValidas)
                {
                    string cellText = row.Cells[col].Value?.ToString() ?? "";

                    TableCell cell = new TableCell(new Paragraph(new Run(
                        CrearRunProperties(false, "Bahnschrift SemiLight Condensed", 16),
                        new Text(cellText)
                    )));
                    tableRow.Append(cell);
                }
                table.Append(tableRow);
            }

            return table;
        }

        private static void CrearEncabezadoConImagen(HeaderPart headerPart)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Fondo Certificado FDCH.png");

            if (!File.Exists(imagePath))
            {
                Header header = new Header(
                    new Paragraph(new Run(new Text("Imagen del encabezado no encontrada.")))
                );
                headerPart.Header = header;
                return;
            }

            Header headerWithImage = new Header();
            ImagePart imagePart = headerPart.AddImagePart(ImagePartType.Png);
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            long widthEmus = 14220000L;
            long heightEmus = 1270000L;

            // La clave aquí es asegurar que CADA clase tenga su prefijo.
            var element = new DW.Drawing(
                new DW.Inline(
                    new A.Extent() { Cx = widthEmus, Cy = heightEmus },
                    new A.EffectExtent() { Left = 0L, Top = 0L, Right = 0L, Bottom = 0L },
                    new DW.DocProperties() { Id = (UInt32Value)1U, Name = "FondoCertificado" },
                    new DW.NonVisualGraphicFrameDrawingProperties(
                        new A.GraphicFrameLocks() { NoChangeAspect = true }),
                    new A.Graphic(
                        new A.GraphicData(
                            new PIC.Picture(
                                new PIC.NonVisualPictureProperties(
                                    new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "FondoCertificado.png" },
                                    new PIC.NonVisualPictureDrawingProperties()),
                                new PIC.BlipFill(
                                    new A.Blip(
                                        new A.BlipExtensionList(
                                            new A.BlipExtension()
                                            {
                                                Uri = "{28A0092B-C50C-407E-A947-75A078AA6213}"
                                            })
                                    )
                                    { Embed = headerPart.GetIdOfPart(imagePart), CompressionState = A.BlipCompressionValues.Print },
                                    new A.Stretch(new A.FillRectangle())),
                                new PIC.ShapeProperties(
                                    new A.Transform2D(
                                        new A.Offset() { X = 0L, Y = 0L },
                                        new A.Extents() { Cx = widthEmus, Cy = heightEmus }),
                                    new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle }))
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                )
                { BehindDoc = true });

            headerWithImage.Append(new Paragraph(new Run(element)));
            headerPart.Header = headerWithImage;
        }
    }
}