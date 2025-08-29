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

namespace FDCH.UI
{
    internal static class ExportarWord
    {
        // <summary>
        /// Método principal para exportar el certificado a Word con formato específico
        /// </summary>
        /// <param name="dataGridView">DataGridView con los datos a exportar</param>
        /// <param name="parentForm">Formulario padre para el diálogo</param>
        /// <param name="titulo">Título del certificado (persona que firma)</param>
        /// <param name="rol">Rol de la persona que certifica</param>
        public static async Task ExportarAWordAsync(DataGridView dataGridView, Form parentForm, string titulo, string rol)
        {
            try
            {
                // Abrir diálogo para guardar el archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Documento Word|*.docx";
                    saveFileDialog.Title = "Guardar Certificado";
                    saveFileDialog.FileName = "Certificado.docx";

                    if (saveFileDialog.ShowDialog(parentForm) != DialogResult.OK)
                        return;

                    string filePath = saveFileDialog.FileName;

                    // Crear el documento Word
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                    {
                        // Configurar las partes principales del documento
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                        Body body = mainPart.Document.Body;

                        // ========== CONFIGURACIÓN DE ENCABEZADO ==========
                        // Crear encabezado con espacio para imágenes (logos)
                        SectionProperties sectionProps = new SectionProperties();
                        HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                        string headerPartId = mainPart.GetIdOfPart(headerPart);

                        Header header = new Header();
                        // Aquí se pueden agregar las imágenes reales del encabezado
                        // Por ahora se dejan como placeholders de texto
                        header.Append(new Paragraph(new Run(new Text("[LOGO IZQUIERDA]"))));
                        header.Append(new Paragraph(new Run(new Text("[LOGO DERECHA]"))));

                        headerPart.Header = header;
                        HeaderReference headerReference = new HeaderReference() { Type = HeaderFooterValues.Default, Id = headerPartId };
                        sectionProps.Append(headerReference);

                        // ========== CONFIGURACIÓN DE PIE DE PÁGINA ==========
                        // Se configura antes para que sectionProps tenga todas las referencias
                        FooterPart footerPart = mainPart.AddNewPart<FooterPart>();
                        string footerPartId = mainPart.GetIdOfPart(footerPart);

                        Footer footer = new Footer(
                            CrearParrafo("Dirección: Av. Unidad Nacional y Carlos Zambrano - Telf: (03) 2961 812",
                                        JustificationValues.Center, true, null, 16)
                        );

                        footerPart.Footer = footer;
                        FooterReference footerReference = new FooterReference() { Type = HeaderFooterValues.Default, Id = footerPartId };
                        sectionProps.Append(footerReference);

                        // Agregar las propiedades de sección al final del body
                        body.Append(sectionProps);

                        // ========== FECHA DEL DOCUMENTO ==========
                        // Formatear fecha en español y alinear a la derecha
                        string fechaActual = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
                        Paragraph fechaParrafo = CrearParrafo($"Riobamba, {fechaActual}", JustificationValues.Right);
                        body.Append(fechaParrafo);

                        // Agregar espacios en blanco después de la fecha
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        // ========== TÍTULO PRINCIPAL "CERTIFICADO" ==========
                        // Título centrado, azul, en negrita y SUBRAYADO
                        Paragraph tituloParrafo = CrearParrafoConSubrayado("CERTIFICADO", JustificationValues.Center, true, "0000FF", 28);
                        body.Append(tituloParrafo);

                        // ========== PÁRRAFO INTRODUCTORIO CON ROL ==========
                        Paragraph rolParrafo = CrearParrafo(
                            $"QUIEN SUSCRIBE EN CALIDAD DE {rol.ToUpper()} DE FEDERACIÓN DEPORTIVA DE CHIMBORAZO EN LEGAL Y DEBIDA FORMA CERTIFICO QUE:",
                            JustificationValues.Both, true
                        );
                        body.Append(rolParrafo);

                        // ========== INFORMACIÓN DEL DEPORTISTA ==========
                        // TODO: Reemplazar XXXXX con datos reales del deportista
                        Paragraph deportistaParrafo = CrearParrafo(
                            "El deportista XXXXX con cédula de identidad N° XXXXXXXXXX ha obtenido los siguientes resultados",
                            JustificationValues.Both
                        );
                        body.Append(deportistaParrafo);

                        body.Append(new Paragraph(new Run(new Text(""))));

                        // ========== SUBTÍTULO "RESULTADOS OBTENIDOS" ==========
                        Paragraph resultadosParrafo = CrearParrafo("RESULTADOS OBTENIDOS", JustificationValues.Center, true);
                        body.Append(resultadosParrafo);

                        // ========== TABLA DE RESULTADOS ==========
                        // Crear tabla desde DataGridView con filtros y formato especial
                        Table tabla = CrearTablaDesdeDataGrid(dataGridView);
                        body.Append(tabla);

                        body.Append(new Paragraph(new Run(new Text(""))));

                        // ========== TEXTO DE CIERRE ==========
                        body.Append(CrearParrafo("Es todo cuanto puedo certificar en honor a la verdad.", JustificationValues.Both));

                        // Espacios para firma
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        // ========== SECCIÓN DE FIRMA ==========
                        body.Append(CrearParrafo("Atentamente,", JustificationValues.Center, false, null, 14));
                        body.Append(CrearParrafo("DEPORTE Y DISCIPLINA", JustificationValues.Center, false, null, 14));

                        // Más espacios para la firma física
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        // Información del firmante
                        body.Append(CrearParrafo(titulo.ToUpper(), JustificationValues.Center, true));
                        body.Append(CrearParrafo(rol.ToUpper(), JustificationValues.Center, true));
                        body.Append(CrearParrafo("FEDERACIÓN DEPORTIVA DE CHIMBORAZO", JustificationValues.Center, true));

                        // Guardar el documento
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

        // =================== MÉTODOS AUXILIARES ===================

        /// <summary>
        /// Crea un párrafo con formato específico
        /// </summary>
        /// <param name="texto">Texto del párrafo</param>
        /// <param name="alineacion">Alineación del texto</param>
        /// <param name="negrita">Si el texto debe estar en negrita</param>
        /// <param name="colorHex">Color del texto en hexadecimal (opcional)</param>
        /// <param name="fontSize">Tamaño de fuente en puntos</param>
        private static Paragraph CrearParrafo(string texto, JustificationValues alineacion,
                                              bool negrita = false, string colorHex = null, int fontSize = 24)
        {
            // Configurar propiedades del texto
            RunProperties runProperties = new RunProperties();
            if (negrita) runProperties.Append(new Bold());
            if (!string.IsNullOrEmpty(colorHex)) runProperties.Append(new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = colorHex });
            runProperties.Append(new FontSize() { Val = fontSize.ToString() });

            // Crear el run con el texto y sus propiedades
            Run run = new Run(runProperties, new Text(texto));
            Paragraph paragraph = new Paragraph(run);

            // Configurar propiedades del párrafo (alineación)
            ParagraphProperties pp = new ParagraphProperties(new Justification() { Val = alineacion });
            paragraph.PrependChild(pp);

            return paragraph;
        }

        /// <summary>
        /// Crea un párrafo con texto subrayado (específico para el título CERTIFICADO)
        /// </summary>
        private static Paragraph CrearParrafoConSubrayado(string texto, JustificationValues alineacion,
                                                         bool negrita = false, string colorHex = null, int fontSize = 24)
        {
            // Configurar propiedades del texto incluyendo subrayado
            RunProperties runProperties = new RunProperties();
            if (negrita) runProperties.Append(new Bold());
            if (!string.IsNullOrEmpty(colorHex)) runProperties.Append(new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = colorHex });
            runProperties.Append(new FontSize() { Val = fontSize.ToString() });

            // AGREGAR SUBRAYADO
            runProperties.Append(new Underline() { Val = UnderlineValues.Single });

            // Crear el run con el texto y sus propiedades
            Run run = new Run(runProperties, new Text(texto));
            Paragraph paragraph = new Paragraph(run);

            // Configurar propiedades del párrafo (alineación)
            ParagraphProperties pp = new ParagraphProperties(new Justification() { Val = alineacion });
            paragraph.PrependChild(pp);

            return paragraph;
        }

        /// <summary>
        /// Crea una tabla desde el DataGridView aplicando filtros específicos
        /// </summary>
        /// <param name="dataGridView">DataGridView fuente de datos</param>
        private static Table CrearTablaDesdeDataGrid(DataGridView dataGridView)
        {
            // ========== IDENTIFICAR COLUMNAS VÁLIDAS ==========
            // Lista para almacenar índices de columnas que se van a exportar
            List<int> columnasValidas = new List<int>();

            // Lista de nombres de columnas a excluir explícitamente
            List<string> columnasExcluidas = new List<string> { "Editar", "Genero", "Numero de participantes" };

            for (int col = 0; col < dataGridView.Columns.Count; col++)
            {
                // Verificar si la columna es visible para el usuario
                if (!dataGridView.Columns[col].Visible)
                    continue;

                // Verificar si la columna está en la lista de exclusión
                string headerText = dataGridView.Columns[col].HeaderText;
                bool debeExcluirse = columnasExcluidas.Any(excluida =>
                    headerText.Equals(excluida, StringComparison.OrdinalIgnoreCase));

                if (debeExcluirse)
                    continue;

                // Verificar que la columna no esté completamente vacía
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

                // Solo agregar columnas que tienen al menos un dato
                if (!columnaVacia)
                    columnasValidas.Add(col);
            }

            // ========== CREAR TABLA CON FORMATO ==========
            Table table = new Table();

            // Configurar propiedades de la tabla (bordes)
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
            table.AppendChild(tblProps);

            // ========== CREAR FILA DE ENCABEZADO CON FONDO CELESTE ==========
            TableRow headerRow = new TableRow();
            foreach (int col in columnasValidas)
            {
                // Crear celda con fondo celeste
                TableCell cell = new TableCell();

                // Configurar propiedades de la celda (fondo celeste)
                TableCellProperties cellProps = new TableCellProperties(
                    new Shading()
                    {
                        Color = "auto",
                        Fill = "87CEEB", // Color celeste en hexadecimal
                        Val = ShadingPatternValues.Clear
                    }
                );
                cell.Append(cellProps);

                // Crear párrafo con texto en negrita
                Paragraph para = new Paragraph(new Run(
                    new RunProperties(
                        new Bold(),                    // Texto en negrita
                        new FontSize() { Val = "16" }  // Tamaño de fuente
                    ),
                    new Text(dataGridView.Columns[col].HeaderText)
                ));

                cell.Append(para);
                headerRow.Append(cell);
            }
            table.Append(headerRow);

            // ========== CREAR FILAS DE DATOS ==========
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Saltar la fila nueva (última fila vacía del DataGridView)
                if (row.IsNewRow) continue;

                TableRow tableRow = new TableRow();
                foreach (int col in columnasValidas)
                {
                    // Obtener el valor de la celda, manejar valores nulos
                    string cellText = row.Cells[col].Value?.ToString() ?? "";

                    // Crear celda con el texto
                    TableCell cell = new TableCell(new Paragraph(new Run(
                        new RunProperties(new FontSize() { Val = "16" }), // Tamaño de fuente consistente
                        new Text(cellText)
                    )));
                    tableRow.Append(cell);
                }
                table.Append(tableRow);
            }

            return table;
        }















        /*
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

                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                        Body body = mainPart.Document.Body;

                        // === ENCABEZADO CON IMÁGENES ===
                        SectionProperties sectionProps = new SectionProperties();
                        HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                        string headerPartId = mainPart.GetIdOfPart(headerPart);

                        Header header = new Header();

                        // Aquí deberías insertar tus imágenes si las tienes en byte[] o paths
                        // Por ahora se deja como texto representativo
                        header.Append(new Paragraph(new Run(new Text("[LOGO IZQUIERDA]"))));
                        header.Append(new Paragraph(new Run(new Text("[LOGO DERECHA]"))));

                        headerPart.Header = header;

                        HeaderReference headerReference = new HeaderReference() { Type = HeaderFooterValues.Default, Id = headerPartId };
                        sectionProps.Append(headerReference);
                        body.Append(sectionProps);

                        // === FECHA ===
                        string fechaActual = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
                        Paragraph fechaParrafo = CrearParrafo($"Riobamba, {fechaActual}", JustificationValues.Right);
                        body.Append(fechaParrafo);

                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        // === TÍTULO CERTIFICADO ===
                        Paragraph tituloParrafo = CrearParrafo("CERTIFICADO", JustificationValues.Center, true, "0000FF", 28);
                        body.Append(tituloParrafo);

                        // === PÁRRAFO ROL ===
                        Paragraph rolParrafo = CrearParrafo(
                            $"QUIEN SUSCRIBE EN CALIDAD DE {rol.ToUpper()} DE FEDERACIÓN DEPORTIVA DE CHIMBORAZO EN LEGAL Y DEBIDA FORMA CERTIFICO QUE:",
                            JustificationValues.Both, true
                        );
                        body.Append(rolParrafo);

                        // === DATOS DEPORTISTA (ejemplo fijo, deberías reemplazar con tus datos reales) ===
                        Paragraph deportistaParrafo = CrearParrafo(
                            "El deportista XXXXX con cédula de identidad N° XXXXXXXXXX ha obtenido los siguientes resultados",
                            JustificationValues.Both
                        );
                        body.Append(deportistaParrafo);

                        body.Append(new Paragraph(new Run(new Text(""))));

                        // === SUBTÍTULO RESULTADOS ===
                        Paragraph resultadosParrafo = CrearParrafo("RESULTADOS OBTENIDOS", JustificationValues.Center, true);
                        body.Append(resultadosParrafo);

                        // === TABLA DE RESULTADOS ===
                        Table tabla = CrearTablaDesdeDataGrid(dataGridView);
                        body.Append(tabla);

                        body.Append(new Paragraph(new Run(new Text(""))));

                        // === TEXTO FINAL ===
                        body.Append(CrearParrafo("Es todo cuanto puedo certificar en honor a la verdad.", JustificationValues.Both));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        body.Append(CrearParrafo("Atentamente,", JustificationValues.Center, false, null, 14));
                        body.Append(CrearParrafo("DEPORTE Y DISCIPLINA", JustificationValues.Center, false, null, 14));

                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));
                        body.Append(new Paragraph(new Run(new Text(""))));

                        body.Append(CrearParrafo(titulo.ToUpper(), JustificationValues.Center, true));
                        body.Append(CrearParrafo(rol.ToUpper(), JustificationValues.Center, true));
                        body.Append(CrearParrafo("FEDERACIÓN DEPORTIVA DE CHIMBORAZO", JustificationValues.Center, true));

                        // === PIE DE PÁGINA ===
                        FooterPart footerPart = mainPart.AddNewPart<FooterPart>();
                        string footerPartId = mainPart.GetIdOfPart(footerPart);

                        Footer footer = new Footer(
                            CrearParrafo("Dirección: Av. Unidad Nacional y Carlos Zambrano - Telf: (03) 2961 812", JustificationValues.Center, true, null, 16)
                        );

                        footerPart.Footer = footer;

                        FooterReference footerReference = new FooterReference() { Type = HeaderFooterValues.Default, Id = footerPartId };
                        sectionProps.Append(footerReference);

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

        // =================== MÉTODOS AUXILIARES ===================

        private static Paragraph CrearParrafo(string texto, JustificationValues alineacion,
                                              bool negrita = false, string colorHex = null, int fontSize = 24)
        {
            RunProperties runProperties = new RunProperties();
            if (negrita) runProperties.Append(new Bold());
            if (!string.IsNullOrEmpty(colorHex)) runProperties.Append(new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = colorHex });
            runProperties.Append(new FontSize() { Val = fontSize.ToString() });

            Run run = new Run(runProperties, new Text(texto));
            Paragraph paragraph = new Paragraph(run);

            ParagraphProperties pp = new ParagraphProperties(new Justification() { Val = alineacion });
            paragraph.PrependChild(pp);

            return paragraph;
        }

        private static Table CrearTablaDesdeDataGrid(DataGridView dataGridView)
        {
            // Identificar columnas válidas (no vacías y distintas de "Editar")
            List<int> columnasValidas = new List<int>();

            for (int col = 0; col < dataGridView.Columns.Count; col++)
            {
                if (dataGridView.Columns[col].HeaderText == "Editar") continue;

                bool columnaVacia = true;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow && row.Cells[col].Value != null && !string.IsNullOrWhiteSpace(row.Cells[col].Value.ToString()))
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
            table.AppendChild(tblProps);

            // Fila de encabezado
            TableRow headerRow = new TableRow();
            foreach (int col in columnasValidas)
            {
                TableCell cell = new TableCell(new Paragraph(new Run(
                    new RunProperties(new Bold(), new FontSize() { Val = "16" }), // tamaño 8
                    new Text(dataGridView.Columns[col].HeaderText)
                )));
                headerRow.Append(cell);
            }
            table.Append(headerRow);

            // Filas de datos
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                TableRow tableRow = new TableRow();
                foreach (int col in columnasValidas)
                {
                    string cellText = row.Cells[col].Value?.ToString() ?? "";
                    TableCell cell = new TableCell(new Paragraph(new Run(
                        new RunProperties(new FontSize() { Val = "16" }), // tamaño 8
                        new Text(cellText)
                    )));
                    tableRow.Append(cell);
                }
                table.Append(tableRow);
            }

            return table;
        }

        */








        /*
        public static async Task ExportarAWordAsync(DataGridView dgv, Form parent, string titulo, string rol)
        {
            // 1) Cuadro de diálogo para elegir dónde guardar
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Documento Word|*.docx";
                saveDialog.Title = "Guardar Certificado";
                saveDialog.FileName = "Certificado_" + DateTime.Now.ToString("yyyyMMdd") + ".docx";

                if (saveDialog.ShowDialog(parent) != DialogResult.OK)
                    return; // usuario canceló

                string filePath = saveDialog.FileName;

                // 2) Crear el documento Word
                await Task.Run(() =>
                {
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());

                        Body body = mainPart.Document.Body;

                        //-------------------------------------------------
                        // ENCABEZADO: Dos imágenes (ejemplo de placeholders)
                        //-------------------------------------------------
                        HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();
                        string headerPartId = mainPart.GetIdOfPart(headerPart);

                        headerPart.Header = new Header(
                            new Paragraph(
                                new Run(
                                    new Text("<<Aquí iría la imagen izquierda>>")
                                )
                            ),
                            new Paragraph(
                                new Run(
                                    new Text("<<Aquí iría la imagen derecha>>")
                                )
                            )
                        );

                        SectionProperties sectionProps = new SectionProperties();
                        HeaderReference headerReference = new HeaderReference() { Type = HeaderFooterValues.Default, Id = headerPartId };
                        sectionProps.Append(headerReference);
                        body.Append(sectionProps);

                        //-------------------------------------------------
                        // FECHA alineada a la derecha
                        //-------------------------------------------------
                        body.Append(
                            CrearParrafo($"Riobamba, {DateTime.Now:dd 'de' MMMM 'de' yyyy}", JustificationValues.Right)
                        );

                        //-------------------------------------------------
                        // TÍTULO "CERTIFICADO" azul y centrado
                        //-------------------------------------------------
                        body.Append(
                            CrearParrafoConFormato("CERTIFICADO", true, "0000FF", 28, JustificationValues.Center)
                        );

                        //-------------------------------------------------
                        // PÁRRAFO CON ROL
                        //-------------------------------------------------
                        body.Append(
                            CrearParrafo($"QUIEN SUSCRIBE EN CALIDAD DE {rol.ToUpper()} DE FEDERACIÓN DEPORTIVA DE CHIMBORAZO EN LEGAL Y DEBIDA FORMA CERTIFICO QUE:",
                            JustificationValues.Both, true, true)
                        );

                        //-------------------------------------------------
                        // DATOS DEL DEPORTISTA (simulado, reemplazar en tu app)
                        //-------------------------------------------------
                        string nombre = "XXXXX";
                        string cedula = "XXXXXXXXXX";
                        body.Append(
                            CrearParrafo($"El deportista {nombre.ToUpper()} con cédula de identidad N° {cedula} ha obtenido los siguientes resultados", JustificationValues.Both)
                        );

                        //-------------------------------------------------
                        // SUBTÍTULO DE TABLA
                        //-------------------------------------------------
                        body.Append(
                            CrearParrafo("RESULTADOS OBTENIDOS", JustificationValues.Left, true, true)
                        );

                        //-------------------------------------------------
                        // TABLA A PARTIR DEL DATAGRIDVIEW
                        //-------------------------------------------------
                        Table table = new Table();

                        // Bordes de la tabla
                        TableProperties tblProp = new TableProperties(
                            new TableBorders(
                                new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                                new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                                new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                                new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                                new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 },
                                new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 4 }
                            )
                        );
                        table.AppendChild(tblProp);

                        // Encabezados
                        TableRow headerRow = new TableRow();
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.Visible && col.Name != "Editar") // excluir columna editar
                            {
                                TableCell cell = new TableCell(new Paragraph(new Run(new Text(col.HeaderText))));
                                cell.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                                headerRow.Append(cell);
                            }
                        }
                        table.Append(headerRow);

                        // Filas
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                TableRow tr = new TableRow();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Visible && dgv.Columns[cell.ColumnIndex].Name != "Editar")
                                    {
                                        string value = cell.Value?.ToString() ?? ""; // evita nulos
                                        TableCell tc = new TableCell(new Paragraph(new Run(new Text(value))));
                                        tc.Append(new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Auto }));
                                        tr.Append(tc);
                                    }
                                }
                                table.Append(tr);
                            }
                        }
                        body.Append(table);

                        //-------------------------------------------------
                        // TEXTO FINAL
                        //-------------------------------------------------
                        body.Append(
                            CrearParrafo("Es todo cuanto puedo certificar en honor a la verdad.", JustificationValues.Both)
                        );

                        // Espacios en blanco
                        body.Append(new Paragraph(new Run(new Text("\n\n\n"))));

                        // Firmas
                        body.Append(CrearParrafo("Atentamente,", JustificationValues.Center, false, false, 14));
                        body.Append(CrearParrafo("DEPORTE Y DISCIPLINA", JustificationValues.Center, false, false, 14));
                        body.Append(new Paragraph(new Run(new Text("\n\n\n\n\n\n"))));
                        body.Append(CrearParrafo(titulo, JustificationValues.Center, true, false, 14));
                        body.Append(CrearParrafo(rol, JustificationValues.Center, true, false, 14));
                        body.Append(CrearParrafo("FEDERACIÓN DEPORTIVA DE CHIMBORAZO", JustificationValues.Center, true, false, 14));

                        //-------------------------------------------------
                        // PIE DE PÁGINA
                        //-------------------------------------------------
                        body.Append(new Paragraph(new Run(new Text("\n"))));
                        body.Append(CrearParrafo("Dirección: Av. Unidad Nacional y Carlos Zambrano - Telf: (03) 2961 812",
                            JustificationValues.Center, false, false, 12));
                    }
                });

                // 3) Mensaje de éxito
                MessageBox.Show("Archivo Word generado correctamente en:\n" + filePath,
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        //-------------------------------------------------
        // MÉTODOS AUXILIARES PARA CREAR PÁRRAFOS
        //-------------------------------------------------
        private static Paragraph CrearParrafo(string texto,
            JustificationValues alineacion = JustificationValues.Left,
            bool negrita = false,
            bool mayuscula = false,
            int fontSize = 20)
        {
            RunProperties props = new RunProperties();
            if (negrita) props.Append(new Bold());
            if (mayuscula) props.Append(new Caps());
            props.Append(new FontSize() { Val = (fontSize * 2).ToString() });

            Run run = new Run();
            run.Append(props);
            run.Append(new Text(texto));

            ParagraphProperties pPr = new ParagraphProperties(new Justification() { Val = alineacion });
            Paragraph p = new Paragraph(pPr, run);

            return p;
        }

        private static Paragraph CrearParrafoConFormato(string texto, bool negrita, string colorHex, int fontSize, JustificationValues alineacion)
        {
            RunProperties props = new RunProperties();
            if (negrita) props.Append(new Bold());
            props.Append(new WordColor() { Val = colorHex });
            props.Append(new FontSize() { Val = (fontSize * 2).ToString() });

            Run run = new Run(props, new Text(texto));
            ParagraphProperties pPr = new ParagraphProperties(new Justification() { Val = alineacion });

            return new Paragraph(pPr, run);
        }*/






        /*
        /// <summary>
        /// Método público que muestra SaveFileDialog (UI) y lanza la creación del .docx.
        /// Llama a CrearWordDesdeDataTable en un hilo de trabajo para no bloquear la UI.
        /// </summary>
        public static async Task ExportarAWordAsync(DataGridView dgv, IWin32Window owner = null)
        {
            if (dgv == null) throw new ArgumentNullException(nameof(dgv));

            // Construir DataTable usando solo las columnas visibles del DataGridView,
            // excluyendo columnas de tipo botón/imagen y columnas vacías.
            DataTable dt = ObtenerDataTableDelDataGridViewSoloVisibles(dgv);

            if (dt.Columns.Count == 0 || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar (todas las columnas están vacías o no hay columnas exportables).",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivos Word|*.docx", FileName = $"Resultados_{DateTime.Now:yyyyMMdd_HHmmss}.docx" })
            {
                if (sfd.ShowDialog(owner) != DialogResult.OK) return;
                string ruta = sfd.FileName;

                try
                {
                    await Task.Run(() => CrearWordDesdeDataTable(dt, ruta));

                    var open = MessageBox.Show($"Exportación completada:\n{ruta}\n\n¿Desea abrir el archivo?", "Exportación correcta",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (open == DialogResult.Yes)
                    {
                        try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(ruta) { UseShellExecute = true }); }
                        catch { /* no crítico si falla abrir }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a Word: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Construye un DataTable a partir de las columnas visibles del DataGridView (respetando orden y header text).
        /// Excluye columnas de botones/imagenes y elimina las columnas que resulten totalmente vacías.
        /// </summary>
        private static DataTable ObtenerDataTableDelDataGridViewSoloVisibles(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 1) Seleccionar columnas visibles y filtrar tipos no exportables (botones, imágenes)
            var visibleColumns = dgv.Columns
                                     .Cast<DataGridViewColumn>()
                                     .Where(c => c.Visible) // solo visibles
                                     .OrderBy(c => c.DisplayIndex)
                                     .ToList();

            // Filtrar explícitamente columnas que no queremos exportar.
            // Ajusta los nombres si tu columna de editar tiene otro 'Name' distinto a "colEditar".
            var columnasFiltradas = visibleColumns
                .Where(c =>
                    // excluir DataGridViewButtonColumn (botones)
                    !(c is DataGridViewButtonColumn) &&
                    // excluir DataGridViewImageColumn (imagenes/íconos)
                    !(c is DataGridViewImageColumn) &&
                    // excluir por nombre de columna si tienes uno conocido (ej: "colEditar")
                    !string.Equals(c.Name, "colEditar", StringComparison.OrdinalIgnoreCase) &&
                    // excluir si la celda tipo es botón (caso raro)
                    c.CellType != typeof(DataGridViewButtonCell)
                )
                .ToList();

            // Si no quedan columnas exportables regresamos un DataTable vacío
            if (columnasFiltradas.Count == 0) return dt;

            // 2) Crear columnas en el DataTable con nombres seguros
            foreach (var column in columnasFiltradas)
            {
                string colName = string.IsNullOrWhiteSpace(column.HeaderText) ? column.Name : column.HeaderText;
                string safeName = colName;
                int suffix = 1;
                while (dt.Columns.Contains(safeName)) { safeName = $"{colName}_{suffix++}"; }
                dt.Columns.Add(safeName);
            }

            // 3) Rellenar filas desde el DataGridView (omitir NewRow)
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                var dr = dt.NewRow();
                for (int i = 0; i < columnasFiltradas.Count; i++)
                {
                    var dgvCol = columnasFiltradas[i];
                    object val = row.Cells[dgvCol.Index].Value;
                    dr[i] = val ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }

            // 4) Eliminar columnas totalmente vacías (todas las filas DBNull o string vacío)
            // Recorremos hacia atrás para no romper índices al eliminar
            for (int c = dt.Columns.Count - 1; c >= 0; c--)
            {
                bool allEmpty = true;
                foreach (DataRow r in dt.Rows)
                {
                    var v = r[c];
                    if (v != DBNull.Value && !string.IsNullOrWhiteSpace(v.ToString()))
                    {
                        allEmpty = false;
                        break;
                    }
                }
                if (allEmpty)
                {
                    dt.Columns.RemoveAt(c);
                }
            }

            return dt;
        }

        /// <summary>
        /// Crea un documento Word (.docx) desde el DataTable usando OpenXML.
        /// Métodos sincrónicos preparados para ejecutarse en background (Task.Run).
        /// </summary>
        private static void CrearWordDesdeDataTable(DataTable dt, string ruta)
        {
            if (dt == null) throw new ArgumentNullException(nameof(dt));
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentNullException(nameof(ruta));

            int columnas = dt.Columns.Count;
            int[] maxLens = new int[columnas];
            for (int c = 0; c < columnas; c++)
            {
                int max = dt.Columns[c].ColumnName.Length;
                foreach (DataRow r in dt.Rows)
                {
                    int len = (r[c]?.ToString()?.Length) ?? 0;
                    if (len > max) max = len;
                }
                maxLens[c] = Math.Max(3, max);
            }

            const int factor = 120;
            int[] widthsDxa = new int[columnas];
            for (int i = 0; i < columnas; i++)
            {
                int w = Math.Min(5000, Math.Max(500, maxLens[i] * factor));
                widthsDxa[i] = w;
            }

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(ruta, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Título centrado
                var title = new Paragraph(new Run(new RunProperties(new Bold()), new Text("Resultados de búsqueda")))
                {
                    ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center })
                };
                body.Append(title);
                body.Append(new Paragraph(new Run(new Text("")))); // salto

                Table table = new Table();
                TableProperties tblProps = new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 4 },
                        new BottomBorder { Val = BorderValues.Single, Size = 4 },
                        new LeftBorder { Val = BorderValues.Single, Size = 4 },
                        new RightBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                    ),
                    new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                    new TableLayout { Type = TableLayoutValues.Fixed }
                );
                table.AppendChild(tblProps);

                // Encabezado
                TableRow headerRow = new TableRow();
                for (int c = 0; c < columnas; c++)
                {
                    TableCellProperties tcp = new TableCellProperties(
                        new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = widthsDxa[c].ToString() },
                        new Shading { Color = "auto", Fill = "D3D3D3", Val = ShadingPatternValues.Clear },
                        new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                    );

                    var p = new Paragraph(new Run(new RunProperties(new Bold()), new Text(dt.Columns[c].ColumnName ?? "")));
                    p.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });

                    TableCell tc = new TableCell();
                    tc.Append(tcp);
                    tc.Append(p);
                    headerRow.Append(tc);
                }
                table.Append(headerRow);

                // Filas de datos
                foreach (DataRow dr in dt.Rows)
                {
                    TableRow tr = new TableRow();
                    for (int c = 0; c < columnas; c++)
                    {
                        TableCellProperties tcp = new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = widthsDxa[c].ToString() },
                            new TableCellVerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                        );

                        string text = dr[c] == DBNull.Value ? string.Empty : dr[c].ToString();

                        Paragraph p = new Paragraph(new Run(new Text(text)));
                        p.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Left });

                        TableCell tc = new TableCell();
                        tc.Append(tcp);
                        tc.Append(p);
                        tr.Append(tc);
                    }
                    table.Append(tr);
                }

                body.Append(table);
            }
        }*/

        /*public static void ExportarAWord(DataGridView dgv)
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
        }*/

    }
}
