using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Business
{
    class WorkSheetValidation
    {
        private static List<string> errors = new List<string>();
        private const int MAX_ODOMETER = 999999;
        private const int MAX_NOTES_CHARACTER = 250;
        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string error in errors)
                {
                    message += error + "\r\n";
                }

                return message;
            }
        }
        // Add a new work sheet to the Database
        public static int AddWorkSheet(WorkSheet workSheet)
        {
            if (workSheet == null)
            {
                throw new ArgumentNullException();
            }

            if (validate(workSheet))
            {
                addEmptyRows(workSheet);
                int rowsAffected = WorkSheetRepository.AddWorkSheet(workSheet);
                return rowsAffected;
            }
            else
            {
                return -1;
            }
        }
        // Update a work sheet in the database
        public static int UpdateWorkSheet(WorkSheet workSheet)
        {
            if (workSheet == null)
            {
                throw new ArgumentNullException();
            }

            if (validate(workSheet))
            {
                addEmptyRows(workSheet);
                int rowsAffected = WorkSheetRepository.UpdateWorkSheet(workSheet);
                deleteEmptyRows(workSheet);

                return rowsAffected;
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteWorkSheet(Client client) => client != null ? WorkSheetRepository.DeleteWorkSheet(client) : throw new ArgumentNullException();
        public static WorkSheetList GetWorkSheets(string plateNumber) => WorkSheetRepository.GetWorkSheets(plateNumber);

        private static bool validate(WorkSheet workSheet)
        {
            errors.Clear();

            if (workSheet.Odometer < 0)
            {
                errors.Add("Km óra állása nem lehet negatív");
            }
            else if (workSheet.Odometer > MAX_ODOMETER)
            {
                errors.Add($"Km óra állása nem lehet nagyobb mint {MAX_ODOMETER}");
            }

            if (workSheet.Notes != null && workSheet.Notes.Length > MAX_NOTES_CHARACTER)
            {
                errors.Add($"Megrendelt munkák nem lehet hosszabb mint {MAX_NOTES_CHARACTER} karakter");
            }

            return errors.Count == 0;
        }

        private static void addEmptyRows(WorkSheet workSheet)
        {
            const int MAX_ROW_NUMBER = 25;

            // Add emmpty rows to the Parts and WorkFees until 25
            int partsRowCount = workSheet.Parts.Count;
            int workFeesRowCount = workSheet.WorkFees.Count;

            for (int i = 0; i < MAX_ROW_NUMBER - partsRowCount; i++)
            {
                workSheet.Parts.Add(new Part());
            }

            for (int i = 0; i < MAX_ROW_NUMBER - workFeesRowCount; i++)
            {
                workSheet.WorkFees.Add(new WorkFee());
            }
        }

        private static void deleteEmptyRows(WorkSheet workSheet)
        {
            workSheet.WorkFees.RemoveAll(item => string.IsNullOrWhiteSpace(item.WorkName));
            workSheet.Parts.RemoveAll(item => string.IsNullOrWhiteSpace(item.PartName));
        }
    }
}
