using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Business
{
    class PartValidation
    {
        private static List<string> errors = new List<string>();
        private const int MAX_PART_NAME_LENGHT = 60;
        private const int MAX_PART_PIECES = 999;
        private const int MAX_NET_PRICE = 9999999;
        private const int MAX_PART_DISCOUNT = 100;
        private const int MAX_PART_MULTIPLIER = 9;
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

        public static bool AddPart(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException();
            }

            return validate(part);
        }

        private static bool validate(Part part)
        {
            errors.Clear();

            if (string.IsNullOrWhiteSpace(part.PartName))
            {
                errors.Add("Megnevezés nem lehet üres");
            }
            else if (part.PartName.Length > MAX_PART_NAME_LENGHT)
            {
                errors.Add(String.Format("Megnevezés nem lehet hosszabb mint {0} karakter", MAX_PART_NAME_LENGHT));
            }

            if (part.Pieces < 0)
            {
                errors.Add("Darbszám nem lehet negativ");
            }
            else if (part.Pieces > MAX_PART_PIECES)
            {
                errors.Add(String.Format("Darbszám nem lehet nagyobb mint {0:N0}", MAX_PART_PIECES));
            }

            if (part.NetPrice < 0)
            {
                errors.Add("Lista ár nem lehet negativ");
            }
            else if (part.NetPrice > MAX_NET_PRICE)
            {
                errors.Add(String.Format("Lista ár nem lehet nagyobb mint {0:N0}", MAX_NET_PRICE));
            }

            if (part.PartDiscount < 0)
            {
                errors.Add("Kedvezmény nem lehet negativ");
            }
            else if (part.PartDiscount > MAX_PART_DISCOUNT)
            {
                errors.Add(String.Format("Kedvezmény nem lehet nagyobb mint {0:N0}%", MAX_PART_DISCOUNT));
            }

            if(part.Multiplier < 0)
            {
                errors.Add("Szorzó nem lehet negativ");
            }
            else if (part.Multiplier > MAX_PART_MULTIPLIER)
            {
                errors.Add($"Szorzó nem lehet nagyobb mint {MAX_PART_MULTIPLIER}");
            }

            return errors.Count == 0;
        }
    }
}
