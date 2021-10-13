using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FairRent.ExcelDocuments
{
    class ExcelSheets
    {
        public static void createExcelDocuments(string sender, in DataGridView dataGridViewClients, in WorkSheetViewModel workSheetVM = null)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object missingValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(missingValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            if (sender == "FilterTechnicalExamination")
            {
                expiredTechnicalExamination(ref xlWorkSheet, dataGridViewClients);
            }
            else if(sender == "CarHistory")
            {
                serviceHistory(ref xlWorkSheet, workSheetVM);
            }

            xlWorkBook.Close(true, missingValue, missingValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private static void expiredTechnicalExamination(ref Excel.Worksheet xlWorkSheet, in DataGridView dataGridViewClients)
        {
            Excel.Range chartRange;

            chartRange = xlWorkSheet.get_Range("a1");
            chartRange.ColumnWidth = 11;
            chartRange = xlWorkSheet.get_Range("b1");
            chartRange.ColumnWidth = 24;
            chartRange = xlWorkSheet.get_Range("c1");
            chartRange.ColumnWidth = 18;
            chartRange = xlWorkSheet.get_Range("d1");
            chartRange.ColumnWidth = 16;
            chartRange = xlWorkSheet.get_Range("e1");
            chartRange.ColumnWidth = 12;

            xlWorkSheet.Cells[1, 1] = "Rendszám";
            xlWorkSheet.Cells[1, 2] = "Név";
            xlWorkSheet.Cells[1, 3] = "Telefon sz.";
            xlWorkSheet.Cells[1, 4] = "Gyártmány";
            xlWorkSheet.Cells[1, 5] = "Műszaki érv.";
            xlWorkSheet.Cells[1, 6] = "Értesítve";

            int rowCount = dataGridViewClients.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                xlWorkSheet.Cells[2 + i, 1] = dataGridViewClients[0, i].Value; ;
                xlWorkSheet.Cells[2 + i, 2] = dataGridViewClients[1, i].Value; ;
                xlWorkSheet.Cells[2 + i, 3] = dataGridViewClients[5, i].Value; ;
                xlWorkSheet.Cells[2 + i, 4] = dataGridViewClients[7, i].Value; ;
                xlWorkSheet.Cells[2 + i, 5] = dataGridViewClients[9, i].Value; ;
            }
        }

        private static void serviceHistory(ref Excel.Worksheet xlWorkSheet, in WorkSheetViewModel workSheetVM)
        {
            Excel.Range chartRange;

            const string DATE_LABEL = "Dátum:";
            const string KM_LABEL = "Kilóméter állás:";
            const string PARTS_LABEL = "Felhasznált alkatrész:";
            const string WORKS_LABEL = "Elvégzett munka:";

            chartRange = xlWorkSheet.get_Range("a1");
            chartRange.ColumnWidth = 2.36;

            chartRange = xlWorkSheet.get_Range("b2");
            chartRange.ColumnWidth = 22;
            chartRange.Font.Size = 16;
            chartRange.Font.Bold = true;

            chartRange = xlWorkSheet.get_Range("c2");
            chartRange.ColumnWidth = 18.55;
            chartRange.Font.Size = 16;
            chartRange.Font.Bold = true;

            xlWorkSheet.Cells[2, 2] = "Rendszám:";
            xlWorkSheet.Cells[2, 3] = workSheetVM.DisplayWorkSheet.PlateNumber;
            xlWorkSheet.Range["C:C"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            int rowNumber = 4;

            List<string> partsList = new List<string>();
            string parts = "";

            int partsNameInRow = 1;
            const int MAX_PARTS_NAME_IN_ROW = 6;

            List<string> worksList = new List<string>();
            string works = "";

            int worksNameInRow = 1;
            const int MAX_WORKS_NAME_IN_ROW = 6;

            foreach (WorkSheet workSheet in workSheetVM.WorkSheets)
            {
                xlWorkSheet.Cells[rowNumber, 2] = DATE_LABEL;
                xlWorkSheet.Cells[rowNumber, 3] = workSheet.CreateDate;
                rowNumber++;

                xlWorkSheet.Cells[rowNumber, 2] = KM_LABEL;
                xlWorkSheet.Cells[rowNumber, 3] = $"{workSheet.Odometer} km";
                rowNumber++;

                xlWorkSheet.Cells[rowNumber, 2] = PARTS_LABEL;
                xlWorkSheet.Cells[rowNumber, 2].Font.Size = 12;
                xlWorkSheet.Cells[rowNumber, 2].Font.Bold = true;
                rowNumber++;

                foreach (Part part in workSheet.Parts)
                {
                    if (part.PartName != String.Empty)
                    {
                        partsList.Add(part.PartName);
                    }
                }

                foreach (string part in partsList)
                {
                    if (partsNameInRow % MAX_PARTS_NAME_IN_ROW == 0)
                    {
                        xlWorkSheet.Cells[rowNumber, 2] = parts;

                        parts = "";
                        rowNumber++;
                    }

                    parts += $"{part}, ";

                    partsNameInRow++;
                }

                xlWorkSheet.Cells[rowNumber, 2] = parts;

                partsList.Clear();
                parts = "";
                partsNameInRow = 1;
                rowNumber++;

                xlWorkSheet.Cells[rowNumber, 2] = WORKS_LABEL;
                xlWorkSheet.Cells[rowNumber, 2].Font.Size = 12;
                xlWorkSheet.Cells[rowNumber, 2].Font.Bold = true;
                rowNumber++;

                foreach (WorkFee work in workSheet.WorkFees)
                {
                    if (work.WorkName != String.Empty)
                    {
                        worksList.Add(work.WorkName);
                    }
                }

                foreach (string work in worksList)
                {
                    if (worksNameInRow % MAX_WORKS_NAME_IN_ROW == 0)
                    {
                        xlWorkSheet.Cells[rowNumber, 2] = works;

                        works = "";
                        rowNumber++;
                    }

                    works += $"{work}, ";

                    worksNameInRow++;
                }

                xlWorkSheet.Cells[rowNumber, 2] = works;

                worksList.Clear();
                works = "";
                worksNameInRow = 1;
                rowNumber += 2;
            }
        }

            private static void releaseObject(object obj)
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
