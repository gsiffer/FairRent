using FairRent.Common;
using FairRent.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FairRent.Business
{
    class ClientValidation
    {
        // The ^ means that the match should start at the beginning of the input, the $ that it should end at the end of the input.
        // The * means that (only) 0 or more numbers or dashes should be there (use + instead for 1 or more).
        private static List<string> errors = new List<string>();
        private const string RegExPlateNumber = @"^[A-Z]{3}[-]\d{3}$";
        private const string RegExPostalCode = @"^[0-9]*$";
        private const string RegExPhone = @"^[0-9-+/]*$";

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
        // Add a new client to the Database
        public static int AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            if (validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            else
            {
                return -1;
            }
        }
        // Update a client in the database
        public static int UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteClient(Client client) => client != null ? ClientRepository.DeleteClient(client) : throw new ArgumentNullException();
        public static DataTable GetClients() => ClientRepository.GetClients();

        private static bool validate(Client client)
        {
            errors.Clear();

            if (string.IsNullOrWhiteSpace(client.PlateNumber))
            {
                errors.Add("Rendszám nem lehet üres");
            }
            else if (client.IsHungarian && !Regex.IsMatch(client.PlateNumber, RegExPlateNumber))
            {
                errors.Add("Rendszám formátuma AAA-000 kell legyen");
            }

            if (string.IsNullOrWhiteSpace(client.CarManufacturer))
            {
                errors.Add("Gyártmány nem lehet üres");
            }

            if (client.CubicCentimetre < 0)
            {
                errors.Add("Köbcenti nem lehet negatív szám");
            }

            if ((client.Year != 0 && client.Year < 1900) || client.Year > 2050)
            {
                errors.Add("Évjárat 1900 és 2050 között kell lennie");
            }

            if (client.KW < 0)
            {
                errors.Add("KW nem lehet negatív szám");
            }

            if (string.IsNullOrWhiteSpace(client.ClientName))
            {
                errors.Add("Ügyfél neve nem lehet üres");
            }

            if (!string.IsNullOrWhiteSpace(client.PostalCode) && !Regex.IsMatch(client.PostalCode, RegExPostalCode))
            {
                errors.Add("Irányítószám csak szám lehet");
            }

            if (string.IsNullOrWhiteSpace(client.Phone1))
            {
                errors.Add("Telefonszám1 nem lehet üres");
            }
            else if (!Regex.IsMatch(client.Phone1, RegExPhone))
            {
                errors.Add("Telefonszám1 formátuma helytelen (szám, '-, /, +')");
            }

            if (!string.IsNullOrWhiteSpace(client.Phone2) && !Regex.IsMatch(client.Phone2, RegExPhone))
            {
                errors.Add("Telefonszám2 formátuma helytelen (szám, '-, /, +')");
            }

            if (client.Discount < 0)
            {
                errors.Add("Kedvezmény nem lehet negatív szám");
            }

            if (client.InsuranceFee < 0)
            {
                errors.Add("Kötelező díj nem lehet negatív szám");
            }

            return errors.Count == 0;
        }
    }
}

