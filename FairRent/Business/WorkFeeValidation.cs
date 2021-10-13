using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Business
{
    class WorkFeeValidation
    {
        private static List<string> errors = new List<string>();
        private const int MAX_NAME_LENGHT = 60;
        private const int MAX_HOUR = 168;
        private const int MAX_HOUR_FEE = 100000;
        private const int MAX_TOTAL_FEE = 10000000;
        private const int MAX_DISCOUNT = 100;
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

        public static bool AddWorkFee(WorkFee workFee)
        {
            if (workFee == null)
            {
                throw new ArgumentNullException();
            }

            return validate(workFee);
        }

        private static bool validate(WorkFee workFee)
        {
            errors.Clear();

            if (string.IsNullOrWhiteSpace(workFee.WorkName))
            {
                errors.Add("Elvégzett munka nem lehet üres");
            }
            else if (workFee.WorkName.Length > MAX_NAME_LENGHT)
            {
                errors.Add(String.Format("Elvégzett munka nem lehet hosszabb mint {0} karakter", MAX_NAME_LENGHT));
            }

            if (workFee.WorkHour < 0)
            {
                errors.Add("Munkaóra nem lehet negativ");
            }
            else if (workFee.WorkHour > MAX_HOUR)
            {
                errors.Add(String.Format("Munkaóra nem lehet nagyobb mint {0:N0} óra", MAX_HOUR));
            }

            if (workFee.NetHourFee < 0)
            {
                errors.Add("Óradíj nem lehet negativ");
            }
            else if (workFee.NetHourFee > MAX_HOUR_FEE)
            {
                errors.Add(String.Format("Óradíj nem lehet nagyobb mint {0:N0} Ft", MAX_HOUR_FEE));
            }

            if (workFee.IsContractor)
            {
                if (workFee.NetTotalFee < 0)
                {
                    errors.Add("Alvállalkozói munkadíj nem lehet negativ");
                }
                else if (workFee.NetTotalFee > MAX_TOTAL_FEE)
                {
                    errors.Add(String.Format("Alvállalkozói munkadíj nem lehet nagyobb mint {0:N0} Ft", MAX_TOTAL_FEE));
                }
            }

            if (workFee.WorkDiscount < 0)
            {
                errors.Add("Kedvezmémy nem lehet negativ");
            }
            else if (workFee.WorkDiscount > MAX_DISCOUNT)
            {
                errors.Add($"Kedvezmémy nem lehet nagyobb mint {MAX_DISCOUNT}%");
            }

            return errors.Count == 0;
        }
    }
}
