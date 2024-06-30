using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FMGAPP
{
    public class ExportToExcel
    {
        public static void ExcelExport(DataGridView dataGridView, string worksheetName)
        {
            if (dataGridView.Rows.Count > 0)
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = worksheetName;

                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                    Excel.Range headerRange = worksheet.Cells[1, i];
                    headerRange.Font.Bold = true;
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();

                        // Setting number format and font color based on condition
                        Excel.Range dataRange = worksheet.Cells[i + 2, j + 1];
                        if (decimal.TryParse(dataGridView.Rows[i].Cells[1].Value?.ToString(), out decimal value) && value < 750)
                        {
                            dataRange.Rows.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        }
                        // Treats content as text
                        dataRange.NumberFormat = "@"; 
                    }
                }

                worksheet.Columns.AutoFit();

                // Release COM objects
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Data Exported Successfully");
            }
            else
            {
                MessageBox.Show("No Record To Export");
            }
        }
    }
}
