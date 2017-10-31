using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace LangSystem_Generator
{
    public class ExcelHandler
    {
        public Excel.Application XlApp;
        public Excel.Workbook XlWorkBook;
        public Excel.Worksheet XlActiveWorkSheet;
        private string _filePath;

        public ExcelHandler()
        {
        }

        public void NewWorkBook(string filePath)
        {
            this._filePath = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location) + filePath;
            this.XlApp = new Microsoft.Office.Interop.Excel.Application();
            if (this.XlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
            object misValue = System.Reflection.Missing.Value;
            this.XlApp.SheetsInNewWorkbook = 1; // one worksheet already added by default
            this.XlWorkBook = this.XlApp.Workbooks.Add(misValue);
            this.XlActiveWorkSheet = (Excel.Worksheet)this.XlWorkBook.Worksheets.Item[1];
        }

        private void SetDefaultWorkSheet()
        {
            this.XlActiveWorkSheet = (Excel.Worksheet)this.XlWorkBook.Worksheets.Item[1];
            this.XlActiveWorkSheet.Select();
        }

        private void AddNewWorkSheet()
        {
            Excel.Sheets worksheets = this.XlWorkBook.Worksheets;
            this.XlActiveWorkSheet = (Excel.Worksheet)this.XlWorkBook.Worksheets.Add(After: this.XlWorkBook.Sheets[this.XlWorkBook.Sheets.Count]);
            this.XlActiveWorkSheet.Select();
        }

        public void SetUpFirstWorkSheet()
        {
            this.XlActiveWorkSheet.Cells[1, 1] = "Czy przeprowadzenie audytu zaklocalo prace";
            this.XlActiveWorkSheet.Cells[1, 2] = "Czy lektor wyczerpujaco wyjasnil zadanie";
            this.XlActiveWorkSheet.Cells[1, 3] = "Czy audytor wyjasnial watpliwosci dotyczace pytan";
            this.XlActiveWorkSheet.Cells[1, 4] = "Obiektywizm";
            this.XlActiveWorkSheet.Cells[1, 5] = "Profesjonalizm";
            this.XlActiveWorkSheet.Cells[1, 6] = "Komunikatywnosc";
            this.XlActiveWorkSheet.Cells[1, 7] = "Znajomosc dzialalnosci";
            this.XlActiveWorkSheet.Cells[1, 8] = "Uwagi";
            this.XlActiveWorkSheet.Cells[1, 9] = "Srednia ocena lektora";
        }

        public void PutDataInCells(List<object> cellObjects, int row)
        {
            for (var i = 0; i < cellObjects.Count; i++)
            {
                this.XlActiveWorkSheet.Cells[1 + row, i + 1] = cellObjects[i];
            }
        }

        public void SaveDataInExcelFile()
        {
            object misValue = System.Reflection.Missing.Value;

            this.SetDefaultWorkSheet();
            XlWorkBook.SaveAs(this._filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            XlWorkBook.Close(true, misValue, misValue);
            XlApp.Quit();

            ReleaseObject(XlActiveWorkSheet);
            ReleaseObject(XlWorkBook);
            ReleaseObject(XlApp);

            MessageBox.Show("Excel file created , you can find the file " + this._filePath);
        }

        public void Release()
        {
            XlApp.Quit();

            ReleaseObject(XlActiveWorkSheet);
            ReleaseObject(XlWorkBook);
            ReleaseObject(XlApp);
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
