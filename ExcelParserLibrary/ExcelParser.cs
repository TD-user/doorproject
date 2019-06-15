using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Entities;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ExcelParserLibrary
{
    public class ExcelParser
    {
        public string FilePath { get; set; }

        TKMapping map = new TKMapping();

        public ExcelParser() { }

        public ExcelParser(string filePath)
        {
            this.FilePath = filePath;
        }

        private bool validateFile(Excel.Range xlRange)
        {
            if (!validateCell(xlRange, map.Mapping["TechnoCardValid"].I, map.Mapping["TechnoCardValid"].J))
                return false;
            else if (String.Compare(map.ValidationMap[map.Mapping["TechnoCardValid"]].Trim(),
                xlRange.Cells[map.Mapping["TechnoCardValid"].I, map.Mapping["TechnoCardValid"].J].Value.ToString().Trim(), true) != 0)
                return false;

            if (!validateCell(xlRange, map.Mapping["BlockValid"].I, map.Mapping["BlockValid"].J))
                return false;
            else if (String.Compare(map.ValidationMap[map.Mapping["BlockValid"]].Trim(),
                xlRange.Cells[map.Mapping["BlockValid"].I, map.Mapping["BlockValid"].J].Value.ToString().Trim(), true) != 0)
                return false;

            if (!validateCell(xlRange, map.Mapping["OrderValid"].I, map.Mapping["OrderValid"].J))
                return false;
            else if (String.Compare(map.ValidationMap[map.Mapping["OrderValid"]].Trim(),
                xlRange.Cells[map.Mapping["OrderValid"].I, map.Mapping["OrderValid"].J].Value.ToString().Trim(), true) != 0)
                return false;

            return true;
        }

        private bool validateCell(Excel.Range xlRange, int i, int j)
        {
            return xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value != null;
        }

        public TechnologicalCard ParseTechnoCard()
        {
            if (String.IsNullOrEmpty(this.FilePath)) return null;

            TechnologicalCard technologicalCard = null;
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;
            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(this.FilePath);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                if (!validateFile(xlRange)) throw new Exception();

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                technologicalCard = new TechnologicalCard();

                technologicalCard.Id = validateCell(xlRange, map.Mapping["Id"].I, map.Mapping["Id"].J)
                    ? xlRange.Cells[map.Mapping["Id"].I, map.Mapping["Id"].J].Value.ToString() : "";
                technologicalCard.Brigade = validateCell(xlRange, map.Mapping["Brigade"].I, map.Mapping["Brigade"].J)
                    ? xlRange.Cells[map.Mapping["Brigade"].I, map.Mapping["Brigade"].J].Value.ToString() : "";
                technologicalCard.Date = validateCell(xlRange, map.Mapping["Date"].I, map.Mapping["Date"].J)
                    ? xlRange.Cells[map.Mapping["Date"].I, map.Mapping["Date"].J].Value.ToString() : "";
                technologicalCard.OfficialPerson = validateCell(xlRange, map.Mapping["OfficialPerson"].I, map.Mapping["OfficialPerson"].J)
                    ? xlRange.Cells[map.Mapping["OfficialPerson"].I, map.Mapping["OfficialPerson"].J].Value.ToString() : "";
                technologicalCard.OfficialForPrinting = validateCell(xlRange, map.Mapping["OfficialForPrinting"].I, map.Mapping["OfficialForPrinting"].J)
                    ? xlRange.Cells[map.Mapping["OfficialForPrinting"].I, map.Mapping["OfficialForPrinting"].J].Value.ToString() : "";

                for (int i = map.Mapping["BlockId"].I; i <= rowCount; i++)
                {
                    Entities.Block block = new Entities.Block();
                    block.BlockId = validateCell(xlRange, i, map.Mapping["BlockId"].J)
                        ? xlRange.Cells[i, map.Mapping["BlockId"].J].Value.ToString() : "";
                    block.CuttingType = validateCell(xlRange, i, map.Mapping["CuttingType"].J)
                        ? xlRange.Cells[i, map.Mapping["CuttingType"].J].Value.ToString() : "";
                    block.AdditionalInfo = validateCell(xlRange, i, map.Mapping["AdditionalInfo"].J)
                        ? xlRange.Cells[i, map.Mapping["AdditionalInfo"].J].Value.ToString() : "";
                    block.Door1 = validateCell(xlRange, i, map.Mapping["Door1"].J)
                        ? xlRange.Cells[i, map.Mapping["Door1"].J].Value.ToString() : "";
                    block.Door2 = validateCell(xlRange, i, map.Mapping["Door2"].J)
                        ? xlRange.Cells[i, map.Mapping["Door2"].J].Value.ToString() : "";
                    block.DoorBox = validateCell(xlRange, i, map.Mapping["DoorBox"].J)
                        ? xlRange.Cells[i, map.Mapping["DoorBox"].J].Value.ToString() : "";
                    block.Hinge1 = validateCell(xlRange, i, map.Mapping["Hinge1"].J)
                        ? xlRange.Cells[i, map.Mapping["Hinge1"].J].Value.ToString() : "";
                    block.Hinge2 = validateCell(xlRange, i, map.Mapping["Hinge2"].J)
                        ? xlRange.Cells[i, map.Mapping["Hinge2"].J].Value.ToString() : "";
                    block.HingeCount = validateCell(xlRange, i, map.Mapping["HingeCount"].J)
                        ? xlRange.Cells[i, map.Mapping["HingeCount"].J].Value.ToString() : "";
                    block.LockType = validateCell(xlRange, i, map.Mapping["LockType"].J)
                        ? xlRange.Cells[i, map.Mapping["LockType"].J].Value.ToString() : "";
                    block.InsertingSecret = validateCell(xlRange, i, map.Mapping["InsertingSecret"].J)
                        ? xlRange.Cells[i, map.Mapping["InsertingSecret"].J].Value.ToString() : "";
                    block.DoorStep = validateCell(xlRange, i, map.Mapping["DoorStep"].J)
                        ? xlRange.Cells[i, map.Mapping["DoorStep"].J].Value.ToString() : "";
                    block.Note = validateCell(xlRange, i, map.Mapping["Note"].J)
                        ? xlRange.Cells[i, map.Mapping["Note"].J].Value.ToString() : "";
                    block.OrderNumber = validateCell(xlRange, i, map.Mapping["OrderNumber"].J)
                        ? xlRange.Cells[i, map.Mapping["OrderNumber"].J].Value.ToString() : "";
                    technologicalCard.Blocks.Add(block);
                }
            }
            catch
            {
                technologicalCard = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            return technologicalCard;
        }

        public static void KillProccess()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower().Contains("excel"))
                {
                    process.Kill();
                }
            }
        }
    }
}
