using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;

namespace FDCH.UI
{
    internal static class ExportarExcel
    {
        // Función principal que se llama desde el botón
        public static void ExportarAExcel(DataGridView dgv)
        {
            try
            {
                DataTable dt = ObtenerDataTableDelDataGridView(dgv);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivos Excel|*.xlsx", FileName = "Exportacion.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "DatosExportados");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Exportación completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportarAExcelGeneral(DataGridView dgv)
        {
            try
            {
                DataTable dt = ObtenerDataTableDelDataGridViewGeneral(dgv);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivos Excel|*.xlsx", FileName = "Exportacion.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "DatosExportados");
                            wb.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Exportación completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static DataTable ObtenerDataTableDelDataGridViewGeneral(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 🚀 Exportamos solo las 26 columnas intermedias (del índice 6 al 31 incluido)
            for (int i = 7; i < dgv.Columns.Count - 1; i++)
            {
                dt.Columns.Add(dgv.Columns[i].HeaderText);
            }

            // 🚀 Llenamos las filas con esas mismas columnas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 7; i < dgv.Columns.Count - 1; i++)
                    {
                        dr[i - 7] = row.Cells[i].Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        // Función auxiliar para convertir DataGridView a DataTable
        private static DataTable ObtenerDataTableDelDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 🚀 Exportamos solo las 26 columnas intermedias (del índice 6 al 31 incluido)
            for (int i = 6; i < dgv.Columns.Count - 1; i++)
            {
                dt.Columns.Add(dgv.Columns[i].HeaderText);
            }

            // 🚀 Llenamos las filas con esas mismas columnas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 6; i < dgv.Columns.Count - 1; i++)
                    {
                        dr[i - 6] = row.Cells[i].Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

    }
}