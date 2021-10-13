using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent.Data
{
    public class ClientRepository
    {
        private const string databaseFileName = "Contacts.mdb";

        private static readonly string connString = $@"Provider=Microsoft.Jet.OLEDB.4.0; 
                                                       Data Source = {Application.StartupPath}\{databaseFileName};
                                                       User Id = admin;
                                                       Password=;";

        public static DataTable GetClients()
        {
            DataTable dtClients = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT rendszam, nev, iranyitosz, varos, cim, telefon1, telefon2, emilcim, kedvezmeny, 
                                            gyartmany, tipus, muszakivizsga, evjarat, alvazszam, motorszam, kobcenti, kw,
                                            uzemanyag, kotelezoneve, kotelezoevfordulo, kotelezodij, casconeve, cascomodozat,
                                            cascoonresz, szures, rdbmagyar
                                     FROM Contacts
                                     ORDER BY rendszam";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dtClients);
                    }
                }
            }

            return dtClients;
        }

        public static int AddClient(Client client)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"INSERT INTO Contacts
                                        (rendszam, nev, iranyitosz, varos, cim, telefon1, telefon2, emilcim, kedvezmeny, gyartmany, tipus,
                                         muszakivizsga, evjarat, alvazszam, motorszam, kobcenti, kw, uzemanyag, kotelezoneve, kotelezoevfordulo,
                                         kotelezodij, casconeve, cascomodozat, cascoonresz, szures, rdbmagyar) 
                                 VALUES (@rendszam, @nev, @iranyitosz, @varos, @cim, @telefon1, @telefon2, @emilcim, @kedvezmeny,
                                         @gyartmany, @tipus, @muszakivizsga, @evjarat, @alvazszam, @motorszam, @kobcenti, @kw, @uzemanyag, @kotelezoneve, 
                                         @kotelezoevfordulo, @kotelezodij, @casconeve, @cascomodozat, @cascoonresz, @szures, @rdbmagyar)";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("rendszam", client.PlateNumber);
                    cmd.Parameters.AddWithValue("nev", (object)client.ClientName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("iranyitosz", (object)client.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("varos", (object)client.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cim", (object)client.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("telefon1", (object)client.Phone1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("telefon2", (object)client.Phone2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("emilcim", (object)client.EmailAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kedvezmeny", client.Discount != default ? client.Discount.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("gyartmany", (object)client.CarManufacturer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("tipus", (object)client.CarType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("muszakivizsga", client.InspectionDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("evjarat", client.Year != default ? client.Year.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("alvazszam", (object)client.IdentificationNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("motorszam", (object)client.EngineNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kobcenti", client.CubicCentimetre != default ? client.CubicCentimetre.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("kw", client.KW != default ? client.KW.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("uzemanyag", (object)client.Fuel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kotelezoneve", (object)client.InsuranceName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kotelezoevfordulo", client.InsuranceDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("kotelezodij", client.InsuranceFee != default ? client.InsuranceFee.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("casconeve", (object)client.CascoName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cascomodozat", (object)client.CascoType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cascoonresz", (object)client.CascoDeduction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("szures", client.Filtered.ToString());
                    cmd.Parameters.AddWithValue("rdbmagyar", client.IsHungarian.ToString());

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static int UpdateClient(Client client)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"UPDATE Contacts 
                                 SET nev = @nev, 
                                     iranyitosz = @iranyitosz,
                                     varos = @varos,
                                     cim = @cim, 
                                     telefon1 = @telefon1, 
                                     telefon2 = @telefon2, 
                                     emilcim = @emilcim, 
                                     kedvezmeny = @kedvezmeny, 
                                     gyartmany = @gyartmany, 
                                     tipus = @tipus, 
                                     muszakivizsga = @muszakivizsga, 
                                     evjarat = @evjarat, 
                                     alvazszam = @alvazszam, 
                                     motorszam = @motorszam, 
                                     kobcenti = @kobcenti, 
                                     kw = @kw, 
                                     uzemanyag = @uzemanyag,
                                     kotelezoneve = @kotelezoneve, 
                                     kotelezoevfordulo = @kotelezoevfordulo, 
                                     kotelezodij = @kotelezodij, 
                                     casconeve = @casconeve, 
                                     cascomodozat = @cascomodozat, 
                                     cascoonresz = @cascoonresz,
                                     szures = @szures 
                                 WHERE rendszam = @rendszam";


                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("nev", (object)client.ClientName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("iranyitosz", (object)client.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("varos", (object)client.City ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cim", (object)client.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("telefon1", (object)client.Phone1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("telefon2", (object)client.Phone2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("emilcim", (object)client.EmailAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kedvezmeny", client.Discount != default ? client.Discount.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("gyartmany", (object)client.CarManufacturer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("tipus", (object)client.CarType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("muszakivizsga", client.InspectionDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("evjarat", client.Year != default ? client.Year.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("alvazszam", (object)client.IdentificationNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("motorszam", (object)client.EngineNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kobcenti", client.CubicCentimetre != default ? client.CubicCentimetre.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("kw", client.KW != default ? client.KW.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("uzemanyag", (object)client.Fuel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kotelezoneve", (object)client.InsuranceName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kotelezoevfordulo", client.InsuranceDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("kotelezodij", client.InsuranceFee != default ? client.InsuranceFee.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("casconeve", (object)client.CascoName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cascomodozat", (object)client.CascoType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("cascoonresz", (object)client.CascoDeduction ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("szures", client.Filtered.ToString());
                    cmd.Parameters.AddWithValue("rendszam", client.PlateNumber);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public static int DeleteClient(Client client)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"DELETE FROM Contacts
                                 WHERE rendszam = @rendszam";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("rendszam", client.PlateNumber);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}
