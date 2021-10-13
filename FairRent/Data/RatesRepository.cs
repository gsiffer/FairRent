using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace FairRent.Data
{
    class RatesRepository
    {
        private const string databaseFileName = "Contacts.mdb";

        private static readonly string connString = $@"Provider=Microsoft.Jet.OLEDB.4.0; 
                                                       Data Source = {Application.StartupPath}\{databaseFileName};
                                                       User Id = admin;
                                                       Password=;";
        public static Rates GetRates()
        {
            Rates rates = new Rates();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT Afa, kedvezmeny, munkadij
                                     FROM System";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        decimal tax, discount, wage;

                        while (reader.Read())
                        {
                            tax = Decimal.TryParse(reader["Afa"] as string, out decimal _tax) ? _tax : default;
                            discount = Decimal.TryParse(reader["kedvezmeny"] as string, out decimal _discount) ? _discount : default;
                            wage = Decimal.TryParse(reader["munkadij"] as string, out decimal _wage) ? _wage : default;

                            rates = new Rates
                            {
                                Tax = tax,
                                Discount = discount,
                                Wage = wage
                            };
                        }
                    }
                }
            }

            return rates;
        }

        public static int UpdateRates(Rates rates)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"UPDATE System 
                                 SET Afa = @afa, 
                                     kedvezmeny = @kedvezmeny,
                                     munkadij = @munkadij";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("afa", rates.Tax.ToString());
                    cmd.Parameters.AddWithValue("kedvezmeny", rates.Discount.ToString());
                    cmd.Parameters.AddWithValue("munkadij", rates.Wage.ToString());

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}

