using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Business
{
    class RatesValidation
    {
        private static List<string> errors = new List<string>();

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

        public static Rates GetRates() => RatesRepository.GetRates();
        public static int UpdateRates(Rates rates)
        {
            if (rates == null)
            {
                throw new ArgumentNullException();
            }

            if (validate(rates))
            {
                return RatesRepository.UpdateRates(rates);
            }
            else
            {
                return -1;
            }
        }

        private static bool validate(Rates rates)
        {
            errors.Clear();

            if (rates.Tax < 0 || rates.Tax > 100)
            {
                errors.Add("Az áfának 0 és 100 között kell lennie");
            }

            if (rates.Discount < 0 || rates.Discount > 100)
            {
                errors.Add("A kedvezménynek 0 és 100 között kell lennie");
            }

            if (rates.Wage < 0)
            {
                errors.Add("A munkadíj nem lehet negatív szám");
            }

            return errors.Count == 0;
        }
    }
}
