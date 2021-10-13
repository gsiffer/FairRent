using FairRent.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent.Data
{
    class WorkSheetRepository
    {
        private const string databaseFileName = "Contacts.mdb";

        private static readonly string connString = $@"Provider=Microsoft.Jet.OLEDB.4.0; 
                                                       Data Source = {Application.StartupPath}\{databaseFileName};
                                                       User Id = admin;
                                                       Password=;";

        public static WorkSheetList GetWorkSheets(string plateNumber)
        {
            WorkSheetList workSheets = new WorkSheetList();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"SELECT ID, tulajdonos, telefon, kedvezmeny, szorzo, email, gyartmany, tipus, muszaki,
                                            kilometer, datum, hibajelenseg, munkalapzart, mlafa, megnevezes01, darab01, nbeszer01,
                                            szazalekalk01, megnevezes02, darab02, nbeszer02, szazalekalk02, megnevezes03, darab03,
                                            nbeszer03, szazalekalk03, megnevezes04, darab04, nbeszer04, szazalekalk04, megnevezes05, 
                                            darab05, nbeszer05, szazalekalk05, megnevezes06, darab06, nbeszer06, szazalekalk06, 
                                            megnevezes07, darab07, nbeszer07, szazalekalk07, megnevezes08, darab08, nbeszer08,
                                            szazalekalk08, megnevezes09, darab09, nbeszer09, szazalekalk09, megnevezes10, darab10,
                                            nbeszer10, szazalekalk10, megnevezes11, darab11, nbeszer11, szazalekalk11, megnevezes12,
                                            darab12, nbeszer12, szazalekalk12, megnevezes13, darab13, nbeszer13, szazalekalk13,
                                            megnevezes14, darab14, nbeszer14, szazalekalk14, megnevezes15, darab15, nbeszer15,
                                            szazalekalk15, megnevezes16, darab16, nbeszer16, szazalekalk16, megnevezes17, darab17,
                                            nbeszer17, szazalekalk17, megnevezes18, darab18, nbeszer18, szazalekalk18, megnevezes19,
                                            darab19, nbeszer19, szazalekalk19, megnevezes20, darab20, nbeszer20, szazalekalk20,
                                            megnevezes21, darab21, nbeszer21, szazalekalk21, megnevezes22, darab22, nbeszer22,
                                            szazalekalk22, megnevezes23, darab23, nbeszer23, szazalekalk23, megnevezes24, darab24,
                                            nbeszer24, szazalekalk24, megnevezes25, darab25, nbeszer25, szazalekalk25, noradij,
                                            elvmunka01, munkaora01, szazalekmunk01, elvmunka02, munkaora02, szazalekmunk02, elvmunka03,
                                            munkaora03, szazalekmunk03, elvmunka04, munkaora04, szazalekmunk04, elvmunka05, munkaora05,
                                            szazalekmunk05, elvmunka06, munkaora06, szazalekmunk06, elvmunka07, munkaora07, szazalekmunk07,
                                            elvmunka08, munkaora08, szazalekmunk08, elvmunka09, munkaora09, szazalekmunk09, elvmunka10,
                                            munkaora10, szazalekmunk10, elvmunka11, munkaora11, szazalekmunk11, elvmunka12, munkaora12,
                                            szazalekmunk12, elvmunka13, munkaora13, szazalekmunk13, elvmunka14, munkaora14, szazalekmunk14,
                                            elvmunka15, munkaora15, szazalekmunk15, elvmunka16, munkaora16, szazalekmunk16, elvmunka17,
                                            munkaora17, szazalekmunk17, elvmunka18, munkaora18, szazalekmunk18, elvmunka19, munkaora19,
                                            szazalekmunk19, elvmunka20, munkaora20, szazalekmunk20, elvmunka21, munkaora21, szazalekmunk21,
                                            elvmunka22, munkaora22, szazalekmunk22, elvmunka23, munkaora23, szazalekmunk23, elvmunka24,
                                            munkaora24, szazalekmunk24, elvmunka25, munkaora25, szazalekmunk25, chkbox1, alvdij1, chkbox2,
                                            alvdij2, chkbox3, alvdij3, chkbox4, alvdij4, chkbox5, alvdij5, chkbox6, alvdij6, chkbox7, alvdij7,
                                            chkbox8, alvdij8, chkbox9, alvdij9, chkbox10, alvdij10, chkbox11, alvdij11, chkbox12, alvdij12,
                                            chkbox13, alvdij13, chkbox14, alvdij14, chkbox15, alvdij15, chkbox16, alvdij16, chkbox17, alvdij17,
                                            chkbox18, alvdij18, chkbox19, alvdij19, chkbox20, alvdij20, chkbox21, alvdij21, chkbox22, alvdij22,
                                            chkbox23, alvdij23, chkbox24, alvdij24, chkbox25, alvdij25
                                     FROM Munkalap
                                     WHERE rendszam = @plateNumber
                                     ORDER BY datum DESC";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("plateNumber", plateNumber);

                    conn.Open();

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int id, odometer;
                        int count = 1;
                        string clientName, phone, emailAddress, carManufacturer, carType, notes;
                        decimal discount, multiplier;
                        DateTime inspectionDate, createDate;
                        bool isActive;

                        //Parts
                        string partName1, partName2, partName3, partName4, partName5, partName6, partName7, partName8,
                            partName9, partName10, partName11, partName12, partName13, partName14, partName15, partName16,
                            partName17, partName18, partName19, partName20, partName21, partName22, partName23, partName24,
                            partName25;

                        int pieces1, pieces2, pieces3, pieces4, pieces5, pieces6, pieces7, pieces8, pieces9, pieces10,
                            pieces11, pieces12, pieces13, pieces14, pieces15, pieces16, pieces17, pieces18, pieces19, pieces20,
                            pieces21, pieces22, pieces23, pieces24, pieces25;

                        decimal netPrice1, netPrice2, netPrice3, netPrice4, netPrice5, netPrice6, netPrice7, netPrice8, netPrice9,
                            netPrice10, netPrice11, netPrice12, netPrice13, netPrice14, netPrice15, netPrice16, netPrice17, netPrice18,
                            netPrice19, netPrice20, netPrice21, netPrice22, netPrice23, netPrice24, netPrice25;

                        decimal partDiscount1, partDiscount2, partDiscount3, partDiscount4, partDiscount5, partDiscount6, partDiscount7,
                            partDiscount8, partDiscount9, partDiscount10, partDiscount11, partDiscount12, partDiscount13, partDiscount14,
                            partDiscount15, partDiscount16, partDiscount17, partDiscount18, partDiscount19, partDiscount20, partDiscount21,
                            partDiscount22, partDiscount23, partDiscount24, partDiscount25;

                        decimal tax;

                        // Work hours
                        string workName1, workName2, workName3, workName4, workName5, workName6, workName7, workName8, workName9, workName10,
                            workName11, workName12, workName13, workName14, workName15, workName16, workName17, workName18, workName19, workName20,
                            workName21, workName22, workName23, workName24, workName25;

                        decimal workHour1, workHour2, workHour3, workHour4, workHour5, workHour6, workHour7, workHour8, workHour9, workHour10,
                            workHour11, workHour12, workHour13, workHour14, workHour15, workHour16, workHour17, workHour18, workHour19, workHour20,
                            workHour21, workHour22, workHour23, workHour24, workHour25;

                        decimal workDiscount1, workDiscount2, workDiscount3, workDiscount4, workDiscount5, workDiscount6, workDiscount7, workDiscount8,
                            workDiscount9, workDiscount10, workDiscount11, workDiscount12, workDiscount13, workDiscount14, workDiscount15, workDiscount16,
                            workDiscount17, workDiscount18, workDiscount19, workDiscount20, workDiscount21, workDiscount22, workDiscount23, workDiscount24,
                            workDiscount25;

                        bool isContractor1, isContractor2, isContractor3, isContractor4, isContractor5, isContractor6, isContractor7, isContractor8,
                            isContractor9, isContractor10, isContractor11, isContractor12, isContractor13, isContractor14, isContractor15, isContractor16,
                            isContractor17, isContractor18, isContractor19, isContractor20, isContractor21, isContractor22, isContractor23, isContractor24,
                            isContractor25;

                        decimal contractorFee1, contractorFee2, contractorFee3, contractorFee4, contractorFee5, contractorFee6, contractorFee7, contractorFee8,
                            contractorFee9, contractorFee10, contractorFee11, contractorFee12, contractorFee13, contractorFee14, contractorFee15, contractorFee16,
                            contractorFee17, contractorFee18, contractorFee19, contractorFee20, contractorFee21, contractorFee22, contractorFee23, contractorFee24,
                            contractorFee25;

                        decimal netHourFee;

                        while (reader.Read())
                        {
                            PartsList parts = new PartsList();
                            WorkFeeList workFees = new WorkFeeList();

                            id = (int)reader["ID"];

                            odometer = Int32.TryParse((reader["kilometer"] as string).Replace(".", ""), out int _odometer) ? _odometer : default;

                            clientName = reader["tulajdonos"] as string;
                            phone = reader["telefon"] as string;
                            emailAddress = reader["email"] as string;
                            carManufacturer = reader["gyartmany"] as string;
                            carType = reader["tipus"] as string;
                            notes = reader["hibajelenseg"] as string;

                            discount = Decimal.TryParse(reader["kedvezmeny"] as string, out decimal _discount) ? _discount : default;
                            multiplier = Decimal.TryParse(reader["szorzo"] as string, out decimal _multiplier) ? _multiplier : default;

                            inspectionDate = DateTime.TryParse(reader["muszaki"] as string, out DateTime _inpectionDate) ? _inpectionDate : default;
                            createDate = DateTime.TryParse(reader["datum"] as string, out DateTime _createDate) ? _createDate : default;

                            isActive = bool.TryParse(reader["munkalapzart"] as string, out bool _isActive) && _isActive;

                            // Parts

                            partName1 = reader["megnevezes01"] as string;
                            partName2 = reader["megnevezes02"] as string;
                            partName3 = reader["megnevezes03"] as string;
                            partName4 = reader["megnevezes04"] as string;
                            partName5 = reader["megnevezes05"] as string;
                            partName6 = reader["megnevezes06"] as string;
                            partName7 = reader["megnevezes07"] as string;
                            partName8 = reader["megnevezes08"] as string;
                            partName9 = reader["megnevezes09"] as string;
                            partName10 = reader["megnevezes10"] as string;
                            partName11 = reader["megnevezes11"] as string;
                            partName12 = reader["megnevezes12"] as string;
                            partName13 = reader["megnevezes13"] as string;
                            partName14 = reader["megnevezes14"] as string;
                            partName15 = reader["megnevezes15"] as string;
                            partName16 = reader["megnevezes16"] as string;
                            partName17 = reader["megnevezes17"] as string;
                            partName18 = reader["megnevezes18"] as string;
                            partName19 = reader["megnevezes19"] as string;
                            partName20 = reader["megnevezes20"] as string;
                            partName21 = reader["megnevezes21"] as string;
                            partName22 = reader["megnevezes22"] as string;
                            partName23 = reader["megnevezes23"] as string;
                            partName24 = reader["megnevezes24"] as string;
                            partName25 = reader["megnevezes25"] as string;

                            pieces1 = Int32.TryParse(reader["darab01"] as string, out int _pieces1) ? _pieces1 : default;
                            pieces2 = Int32.TryParse(reader["darab02"] as string, out int _pieces2) ? _pieces2 : default;
                            pieces3 = Int32.TryParse(reader["darab03"] as string, out int _pieces3) ? _pieces3 : default;
                            pieces4 = Int32.TryParse(reader["darab04"] as string, out int _pieces4) ? _pieces4 : default;
                            pieces5 = Int32.TryParse(reader["darab05"] as string, out int _pieces5) ? _pieces5 : default;
                            pieces6 = Int32.TryParse(reader["darab06"] as string, out int _pieces6) ? _pieces6 : default;
                            pieces7 = Int32.TryParse(reader["darab07"] as string, out int _pieces7) ? _pieces7 : default;
                            pieces8 = Int32.TryParse(reader["darab08"] as string, out int _pieces8) ? _pieces8 : default;
                            pieces9 = Int32.TryParse(reader["darab09"] as string, out int _pieces9) ? _pieces9 : default;
                            pieces10 = Int32.TryParse(reader["darab10"] as string, out int _pieces10) ? _pieces10 : default;
                            pieces11 = Int32.TryParse(reader["darab11"] as string, out int _pieces11) ? _pieces11 : default;
                            pieces12 = Int32.TryParse(reader["darab12"] as string, out int _pieces12) ? _pieces12 : default;
                            pieces13 = Int32.TryParse(reader["darab13"] as string, out int _pieces13) ? _pieces13 : default;
                            pieces14 = Int32.TryParse(reader["darab14"] as string, out int _pieces14) ? _pieces14 : default;
                            pieces15 = Int32.TryParse(reader["darab15"] as string, out int _pieces15) ? _pieces15 : default;
                            pieces16 = Int32.TryParse(reader["darab16"] as string, out int _pieces16) ? _pieces16 : default;
                            pieces17 = Int32.TryParse(reader["darab17"] as string, out int _pieces17) ? _pieces17 : default;
                            pieces18 = Int32.TryParse(reader["darab18"] as string, out int _pieces18) ? _pieces18 : default;
                            pieces19 = Int32.TryParse(reader["darab19"] as string, out int _pieces19) ? _pieces19 : default;
                            pieces20 = Int32.TryParse(reader["darab20"] as string, out int _pieces20) ? _pieces20 : default;
                            pieces21 = Int32.TryParse(reader["darab21"] as string, out int _pieces21) ? _pieces21 : default;
                            pieces22 = Int32.TryParse(reader["darab22"] as string, out int _pieces22) ? _pieces22 : default;
                            pieces23 = Int32.TryParse(reader["darab23"] as string, out int _pieces23) ? _pieces23 : default;
                            pieces24 = Int32.TryParse(reader["darab24"] as string, out int _pieces24) ? _pieces24 : default;
                            pieces25 = Int32.TryParse(reader["darab25"] as string, out int _pieces25) ? _pieces25 : default;

                            netPrice1 = Decimal.TryParse((reader["nbeszer01"] as string)?.Replace(".", ""), out decimal _netPrice1) ? _netPrice1 : default;
                            netPrice2 = Decimal.TryParse((reader["nbeszer02"] as string)?.Replace(".", ""), out decimal _netPrice2) ? _netPrice2 : default;
                            netPrice3 = Decimal.TryParse((reader["nbeszer03"] as string)?.Replace(".", ""), out decimal _netPrice3) ? _netPrice3 : default;
                            netPrice4 = Decimal.TryParse((reader["nbeszer04"] as string)?.Replace(".", ""), out decimal _netPrice4) ? _netPrice4 : default;
                            netPrice5 = Decimal.TryParse((reader["nbeszer05"] as string)?.Replace(".", ""), out decimal _netPrice5) ? _netPrice5 : default;
                            netPrice6 = Decimal.TryParse((reader["nbeszer06"] as string)?.Replace(".", ""), out decimal _netPrice6) ? _netPrice6 : default;
                            netPrice7 = Decimal.TryParse((reader["nbeszer07"] as string)?.Replace(".", ""), out decimal _netPrice7) ? _netPrice7 : default;
                            netPrice8 = Decimal.TryParse((reader["nbeszer08"] as string)?.Replace(".", ""), out decimal _netPrice8) ? _netPrice8 : default;
                            netPrice9 = Decimal.TryParse((reader["nbeszer09"] as string)?.Replace(".", ""), out decimal _netPrice9) ? _netPrice9 : default;
                            netPrice10 = Decimal.TryParse((reader["nbeszer10"] as string)?.Replace(".", ""), out decimal _netPrice10) ? _netPrice10 : default;
                            netPrice11 = Decimal.TryParse((reader["nbeszer11"] as string)?.Replace(".", ""), out decimal _netPrice11) ? _netPrice11 : default;
                            netPrice12 = Decimal.TryParse((reader["nbeszer12"] as string)?.Replace(".", ""), out decimal _netPrice12) ? _netPrice12 : default;
                            netPrice13 = Decimal.TryParse((reader["nbeszer13"] as string)?.Replace(".", ""), out decimal _netPrice13) ? _netPrice13 : default;
                            netPrice14 = Decimal.TryParse((reader["nbeszer14"] as string)?.Replace(".", ""), out decimal _netPrice14) ? _netPrice14 : default;
                            netPrice15 = Decimal.TryParse((reader["nbeszer15"] as string)?.Replace(".", ""), out decimal _netPrice15) ? _netPrice15 : default;
                            netPrice16 = Decimal.TryParse((reader["nbeszer16"] as string)?.Replace(".", ""), out decimal _netPrice16) ? _netPrice16 : default;
                            netPrice17 = Decimal.TryParse((reader["nbeszer17"] as string)?.Replace(".", ""), out decimal _netPrice17) ? _netPrice17 : default;
                            netPrice18 = Decimal.TryParse((reader["nbeszer18"] as string)?.Replace(".", ""), out decimal _netPrice18) ? _netPrice18 : default;
                            netPrice19 = Decimal.TryParse((reader["nbeszer19"] as string)?.Replace(".", ""), out decimal _netPrice19) ? _netPrice19 : default;
                            netPrice20 = Decimal.TryParse((reader["nbeszer20"] as string)?.Replace(".", ""), out decimal _netPrice20) ? _netPrice20 : default;
                            netPrice21 = Decimal.TryParse((reader["nbeszer21"] as string)?.Replace(".", ""), out decimal _netPrice21) ? _netPrice21 : default;
                            netPrice22 = Decimal.TryParse((reader["nbeszer22"] as string)?.Replace(".", ""), out decimal _netPrice22) ? _netPrice22 : default;
                            netPrice23 = Decimal.TryParse((reader["nbeszer23"] as string)?.Replace(".", ""), out decimal _netPrice23) ? _netPrice23 : default;
                            netPrice24 = Decimal.TryParse((reader["nbeszer24"] as string)?.Replace(".", ""), out decimal _netPrice24) ? _netPrice24 : default;
                            netPrice25 = Decimal.TryParse((reader["nbeszer25"] as string)?.Replace(".", ""), out decimal _netPrice25) ? _netPrice25 : default;

                            partDiscount1 = Decimal.TryParse(reader["szazalekalk01"] as string, out decimal _partDiscount1) ? _partDiscount1 : default;
                            partDiscount2 = Decimal.TryParse(reader["szazalekalk02"] as string, out decimal _partDiscount2) ? _partDiscount2 : default;
                            partDiscount3 = Decimal.TryParse(reader["szazalekalk03"] as string, out decimal _partDiscount3) ? _partDiscount3 : default;
                            partDiscount4 = Decimal.TryParse(reader["szazalekalk04"] as string, out decimal _partDiscount4) ? _partDiscount4 : default;
                            partDiscount5 = Decimal.TryParse(reader["szazalekalk05"] as string, out decimal _partDiscount5) ? _partDiscount5 : default;
                            partDiscount6 = Decimal.TryParse(reader["szazalekalk06"] as string, out decimal _partDiscount6) ? _partDiscount6 : default;
                            partDiscount7 = Decimal.TryParse(reader["szazalekalk07"] as string, out decimal _partDiscount7) ? _partDiscount7 : default;
                            partDiscount8 = Decimal.TryParse(reader["szazalekalk08"] as string, out decimal _partDiscount8) ? _partDiscount8 : default;
                            partDiscount9 = Decimal.TryParse(reader["szazalekalk09"] as string, out decimal _partDiscount9) ? _partDiscount9 : default;
                            partDiscount10 = Decimal.TryParse(reader["szazalekalk10"] as string, out decimal _partDiscount10) ? _partDiscount10 : default;
                            partDiscount11 = Decimal.TryParse(reader["szazalekalk11"] as string, out decimal _partDiscount11) ? _partDiscount11 : default;
                            partDiscount12 = Decimal.TryParse(reader["szazalekalk12"] as string, out decimal _partDiscount12) ? _partDiscount12 : default;
                            partDiscount13 = Decimal.TryParse(reader["szazalekalk13"] as string, out decimal _partDiscount13) ? _partDiscount13 : default;
                            partDiscount14 = Decimal.TryParse(reader["szazalekalk14"] as string, out decimal _partDiscount14) ? _partDiscount14 : default;
                            partDiscount15 = Decimal.TryParse(reader["szazalekalk15"] as string, out decimal _partDiscount15) ? _partDiscount15 : default;
                            partDiscount16 = Decimal.TryParse(reader["szazalekalk16"] as string, out decimal _partDiscount16) ? _partDiscount16 : default;
                            partDiscount17 = Decimal.TryParse(reader["szazalekalk17"] as string, out decimal _partDiscount17) ? _partDiscount17 : default;
                            partDiscount18 = Decimal.TryParse(reader["szazalekalk18"] as string, out decimal _partDiscount18) ? _partDiscount18 : default;
                            partDiscount19 = Decimal.TryParse(reader["szazalekalk19"] as string, out decimal _partDiscount19) ? _partDiscount19 : default;
                            partDiscount20 = Decimal.TryParse(reader["szazalekalk20"] as string, out decimal _partDiscount20) ? _partDiscount20 : default;
                            partDiscount21 = Decimal.TryParse(reader["szazalekalk21"] as string, out decimal _partDiscount21) ? _partDiscount21 : default;
                            partDiscount22 = Decimal.TryParse(reader["szazalekalk22"] as string, out decimal _partDiscount22) ? _partDiscount22 : default;
                            partDiscount23 = Decimal.TryParse(reader["szazalekalk23"] as string, out decimal _partDiscount23) ? _partDiscount23 : default;
                            partDiscount24 = Decimal.TryParse(reader["szazalekalk24"] as string, out decimal _partDiscount24) ? _partDiscount24 : default;
                            partDiscount25 = Decimal.TryParse(reader["szazalekalk25"] as string, out decimal _partDiscount25) ? _partDiscount25 : default;

                            tax = Decimal.TryParse(reader["mlafa"] as string, out decimal _tax) ? _tax : default;

                            // Work hours

                            workName1 = reader["elvmunka01"] as string;
                            workName2 = reader["elvmunka02"] as string;
                            workName3 = reader["elvmunka03"] as string;
                            workName4 = reader["elvmunka04"] as string;
                            workName5 = reader["elvmunka05"] as string;
                            workName6 = reader["elvmunka06"] as string;
                            workName7 = reader["elvmunka07"] as string;
                            workName8 = reader["elvmunka08"] as string;
                            workName9 = reader["elvmunka09"] as string;
                            workName10 = reader["elvmunka10"] as string;
                            workName11 = reader["elvmunka11"] as string;
                            workName12 = reader["elvmunka12"] as string;
                            workName13 = reader["elvmunka13"] as string;
                            workName14 = reader["elvmunka14"] as string;
                            workName15 = reader["elvmunka15"] as string;
                            workName16 = reader["elvmunka16"] as string;
                            workName17 = reader["elvmunka17"] as string;
                            workName18 = reader["elvmunka18"] as string;
                            workName19 = reader["elvmunka19"] as string;
                            workName20 = reader["elvmunka20"] as string;
                            workName21 = reader["elvmunka21"] as string;
                            workName22 = reader["elvmunka22"] as string;
                            workName23 = reader["elvmunka23"] as string;
                            workName24 = reader["elvmunka24"] as string;
                            workName25 = reader["elvmunka25"] as string;

                            workHour1 = Decimal.TryParse((reader["munkaora01"] as string)?.Replace(",", "."), out decimal _workHour1) ? _workHour1 : default;
                            workHour2 = Decimal.TryParse((reader["munkaora02"] as string)?.Replace(",", "."), out decimal _workHour2) ? _workHour2 : default;
                            workHour3 = Decimal.TryParse((reader["munkaora03"] as string)?.Replace(",", "."), out decimal _workHour3) ? _workHour3 : default;
                            workHour4 = Decimal.TryParse((reader["munkaora04"] as string)?.Replace(",", "."), out decimal _workHour4) ? _workHour4 : default;
                            workHour5 = Decimal.TryParse((reader["munkaora05"] as string)?.Replace(",", "."), out decimal _workHour5) ? _workHour5 : default;
                            workHour6 = Decimal.TryParse((reader["munkaora06"] as string)?.Replace(",", "."), out decimal _workHour6) ? _workHour6 : default;
                            workHour7 = Decimal.TryParse((reader["munkaora07"] as string)?.Replace(",", "."), out decimal _workHour7) ? _workHour7 : default;
                            workHour8 = Decimal.TryParse((reader["munkaora08"] as string)?.Replace(",", "."), out decimal _workHour8) ? _workHour8 : default;
                            workHour9 = Decimal.TryParse((reader["munkaora09"] as string)?.Replace(",", "."), out decimal _workHour9) ? _workHour9 : default;
                            workHour10 = Decimal.TryParse((reader["munkaora10"] as string)?.Replace(",", "."), out decimal _workHour10) ? _workHour10 : default;
                            workHour11 = Decimal.TryParse((reader["munkaora11"] as string)?.Replace(",", "."), out decimal _workHour11) ? _workHour11 : default;
                            workHour12 = Decimal.TryParse((reader["munkaora12"] as string)?.Replace(",", "."), out decimal _workHour12) ? _workHour12 : default;
                            workHour13 = Decimal.TryParse((reader["munkaora13"] as string)?.Replace(",", "."), out decimal _workHour13) ? _workHour13 : default;
                            workHour14 = Decimal.TryParse((reader["munkaora14"] as string)?.Replace(",", "."), out decimal _workHour14) ? _workHour14 : default;
                            workHour15 = Decimal.TryParse((reader["munkaora15"] as string)?.Replace(",", "."), out decimal _workHour15) ? _workHour15 : default;
                            workHour16 = Decimal.TryParse((reader["munkaora16"] as string)?.Replace(",", "."), out decimal _workHour16) ? _workHour16 : default;
                            workHour17 = Decimal.TryParse((reader["munkaora17"] as string)?.Replace(",", "."), out decimal _workHour17) ? _workHour17 : default;
                            workHour18 = Decimal.TryParse((reader["munkaora18"] as string)?.Replace(",", "."), out decimal _workHour18) ? _workHour18 : default;
                            workHour19 = Decimal.TryParse((reader["munkaora19"] as string)?.Replace(",", "."), out decimal _workHour19) ? _workHour19 : default;
                            workHour20 = Decimal.TryParse((reader["munkaora20"] as string)?.Replace(",", "."), out decimal _workHour20) ? _workHour20 : default;
                            workHour21 = Decimal.TryParse((reader["munkaora21"] as string)?.Replace(",", "."), out decimal _workHour21) ? _workHour21 : default;
                            workHour22 = Decimal.TryParse((reader["munkaora22"] as string)?.Replace(",", "."), out decimal _workHour22) ? _workHour22 : default;
                            workHour23 = Decimal.TryParse((reader["munkaora23"] as string)?.Replace(",", "."), out decimal _workHour23) ? _workHour23 : default;
                            workHour24 = Decimal.TryParse((reader["munkaora24"] as string)?.Replace(",", "."), out decimal _workHour24) ? _workHour24 : default;
                            workHour25 = Decimal.TryParse((reader["munkaora25"] as string)?.Replace(",", "."), out decimal _workHour25) ? _workHour25 : default;

                            workDiscount1 = Decimal.TryParse(reader["szazalekmunk01"] as string, out decimal _workDiscount1) ? _workDiscount1 : default;
                            workDiscount2 = Decimal.TryParse(reader["szazalekmunk02"] as string, out decimal _workDiscount2) ? _workDiscount2 : default;
                            workDiscount3 = Decimal.TryParse(reader["szazalekmunk03"] as string, out decimal _workDiscount3) ? _workDiscount3 : default;
                            workDiscount4 = Decimal.TryParse(reader["szazalekmunk04"] as string, out decimal _workDiscount4) ? _workDiscount4 : default;
                            workDiscount5 = Decimal.TryParse(reader["szazalekmunk05"] as string, out decimal _workDiscount5) ? _workDiscount5 : default;
                            workDiscount6 = Decimal.TryParse(reader["szazalekmunk06"] as string, out decimal _workDiscount6) ? _workDiscount6 : default;
                            workDiscount7 = Decimal.TryParse(reader["szazalekmunk07"] as string, out decimal _workDiscount7) ? _workDiscount7 : default;
                            workDiscount8 = Decimal.TryParse(reader["szazalekmunk08"] as string, out decimal _workDiscount8) ? _workDiscount8 : default;
                            workDiscount9 = Decimal.TryParse(reader["szazalekmunk09"] as string, out decimal _workDiscount9) ? _workDiscount9 : default;
                            workDiscount10 = Decimal.TryParse(reader["szazalekmunk10"] as string, out decimal _workDiscount10) ? _workDiscount10 : default;
                            workDiscount11 = Decimal.TryParse(reader["szazalekmunk11"] as string, out decimal _workDiscount11) ? _workDiscount11 : default;
                            workDiscount12 = Decimal.TryParse(reader["szazalekmunk12"] as string, out decimal _workDiscount12) ? _workDiscount12 : default;
                            workDiscount13 = Decimal.TryParse(reader["szazalekmunk13"] as string, out decimal _workDiscount13) ? _workDiscount13 : default;
                            workDiscount14 = Decimal.TryParse(reader["szazalekmunk14"] as string, out decimal _workDiscount14) ? _workDiscount14 : default;
                            workDiscount15 = Decimal.TryParse(reader["szazalekmunk15"] as string, out decimal _workDiscount15) ? _workDiscount15 : default;
                            workDiscount16 = Decimal.TryParse(reader["szazalekmunk16"] as string, out decimal _workDiscount16) ? _workDiscount16 : default;
                            workDiscount17 = Decimal.TryParse(reader["szazalekmunk17"] as string, out decimal _workDiscount17) ? _workDiscount17 : default;
                            workDiscount18 = Decimal.TryParse(reader["szazalekmunk18"] as string, out decimal _workDiscount18) ? _workDiscount18 : default;
                            workDiscount19 = Decimal.TryParse(reader["szazalekmunk19"] as string, out decimal _workDiscount19) ? _workDiscount19 : default;
                            workDiscount20 = Decimal.TryParse(reader["szazalekmunk20"] as string, out decimal _workDiscount20) ? _workDiscount20 : default;
                            workDiscount21 = Decimal.TryParse(reader["szazalekmunk21"] as string, out decimal _workDiscount21) ? _workDiscount21 : default;
                            workDiscount22 = Decimal.TryParse(reader["szazalekmunk22"] as string, out decimal _workDiscount22) ? _workDiscount22 : default;
                            workDiscount23 = Decimal.TryParse(reader["szazalekmunk23"] as string, out decimal _workDiscount23) ? _workDiscount23 : default;
                            workDiscount24 = Decimal.TryParse(reader["szazalekmunk24"] as string, out decimal _workDiscount24) ? _workDiscount24 : default;
                            workDiscount25 = Decimal.TryParse(reader["szazalekmunk25"] as string, out decimal _workDiscount25) ? _workDiscount25 : default;

                            isContractor1 = bool.TryParse(reader["chkbox1"] as string, out bool _isContractor1) && _isContractor1;
                            isContractor2 = bool.TryParse(reader["chkbox2"] as string, out bool _isContractor2) && _isContractor2;
                            isContractor3 = bool.TryParse(reader["chkbox3"] as string, out bool _isContractor3) && _isContractor3;
                            isContractor4 = bool.TryParse(reader["chkbox4"] as string, out bool _isContractor4) && _isContractor4;
                            isContractor5 = bool.TryParse(reader["chkbox5"] as string, out bool _isContractor5) && _isContractor5;
                            isContractor6 = bool.TryParse(reader["chkbox6"] as string, out bool _isContractor6) && _isContractor6;
                            isContractor7 = bool.TryParse(reader["chkbox7"] as string, out bool _isContractor7) && _isContractor7;
                            isContractor8 = bool.TryParse(reader["chkbox8"] as string, out bool _isContractor8) && _isContractor8;
                            isContractor9 = bool.TryParse(reader["chkbox9"] as string, out bool _isContractor9) && _isContractor9;
                            isContractor10 = bool.TryParse(reader["chkbox10"] as string, out bool _isContractor10) && _isContractor10;
                            isContractor11 = bool.TryParse(reader["chkbox11"] as string, out bool _isContractor11) && _isContractor11;
                            isContractor12 = bool.TryParse(reader["chkbox12"] as string, out bool _isContractor12) && _isContractor12;
                            isContractor13 = bool.TryParse(reader["chkbox13"] as string, out bool _isContractor13) && _isContractor13;
                            isContractor14 = bool.TryParse(reader["chkbox14"] as string, out bool _isContractor14) && _isContractor14;
                            isContractor15 = bool.TryParse(reader["chkbox15"] as string, out bool _isContractor15) && _isContractor15;
                            isContractor16 = bool.TryParse(reader["chkbox16"] as string, out bool _isContractor16) && _isContractor16;
                            isContractor17 = bool.TryParse(reader["chkbox17"] as string, out bool _isContractor17) && _isContractor17;
                            isContractor18 = bool.TryParse(reader["chkbox18"] as string, out bool _isContractor18) && _isContractor18;
                            isContractor19 = bool.TryParse(reader["chkbox19"] as string, out bool _isContractor19) && _isContractor19;
                            isContractor20 = bool.TryParse(reader["chkbox20"] as string, out bool _isContractor20) && _isContractor20;
                            isContractor21 = bool.TryParse(reader["chkbox21"] as string, out bool _isContractor21) && _isContractor21;
                            isContractor22 = bool.TryParse(reader["chkbox22"] as string, out bool _isContractor22) && _isContractor22;
                            isContractor23 = bool.TryParse(reader["chkbox23"] as string, out bool _isContractor23) && _isContractor23;
                            isContractor24 = bool.TryParse(reader["chkbox24"] as string, out bool _isContractor24) && _isContractor24;
                            isContractor25 = bool.TryParse(reader["chkbox25"] as string, out bool _isContractor25) && _isContractor25;

                            contractorFee1 = Decimal.TryParse(reader["alvdij1"] as string, out decimal _contractorFee1) ? _contractorFee1 : default;
                            contractorFee2 = Decimal.TryParse(reader["alvdij2"] as string, out decimal _contractorFee2) ? _contractorFee2 : default;
                            contractorFee3 = Decimal.TryParse(reader["alvdij3"] as string, out decimal _contractorFee3) ? _contractorFee3 : default;
                            contractorFee4 = Decimal.TryParse(reader["alvdij4"] as string, out decimal _contractorFee4) ? _contractorFee4 : default;
                            contractorFee5 = Decimal.TryParse(reader["alvdij5"] as string, out decimal _contractorFee5) ? _contractorFee5 : default;
                            contractorFee6 = Decimal.TryParse(reader["alvdij6"] as string, out decimal _contractorFee6) ? _contractorFee6 : default;
                            contractorFee7 = Decimal.TryParse(reader["alvdij7"] as string, out decimal _contractorFee7) ? _contractorFee7 : default;
                            contractorFee8 = Decimal.TryParse(reader["alvdij8"] as string, out decimal _contractorFee8) ? _contractorFee8 : default;
                            contractorFee9 = Decimal.TryParse(reader["alvdij9"] as string, out decimal _contractorFee9) ? _contractorFee9 : default;
                            contractorFee10 = Decimal.TryParse(reader["alvdij10"] as string, out decimal _contractorFee10) ? _contractorFee10 : default;
                            contractorFee11 = Decimal.TryParse(reader["alvdij11"] as string, out decimal _contractorFee11) ? _contractorFee11 : default;
                            contractorFee12 = Decimal.TryParse(reader["alvdij12"] as string, out decimal _contractorFee12) ? _contractorFee12 : default;
                            contractorFee13 = Decimal.TryParse(reader["alvdij13"] as string, out decimal _contractorFee13) ? _contractorFee13 : default;
                            contractorFee14 = Decimal.TryParse(reader["alvdij14"] as string, out decimal _contractorFee14) ? _contractorFee14 : default;
                            contractorFee15 = Decimal.TryParse(reader["alvdij15"] as string, out decimal _contractorFee15) ? _contractorFee15 : default;
                            contractorFee16 = Decimal.TryParse(reader["alvdij16"] as string, out decimal _contractorFee16) ? _contractorFee16 : default;
                            contractorFee17 = Decimal.TryParse(reader["alvdij17"] as string, out decimal _contractorFee17) ? _contractorFee17 : default;
                            contractorFee18 = Decimal.TryParse(reader["alvdij18"] as string, out decimal _contractorFee18) ? _contractorFee18 : default;
                            contractorFee19 = Decimal.TryParse(reader["alvdij19"] as string, out decimal _contractorFee19) ? _contractorFee19 : default;
                            contractorFee20 = Decimal.TryParse(reader["alvdij20"] as string, out decimal _contractorFee20) ? _contractorFee20 : default;
                            contractorFee21 = Decimal.TryParse(reader["alvdij21"] as string, out decimal _contractorFee21) ? _contractorFee21 : default;
                            contractorFee22 = Decimal.TryParse(reader["alvdij22"] as string, out decimal _contractorFee22) ? _contractorFee22 : default;
                            contractorFee23 = Decimal.TryParse(reader["alvdij23"] as string, out decimal _contractorFee23) ? _contractorFee23 : default;
                            contractorFee24 = Decimal.TryParse(reader["alvdij24"] as string, out decimal _contractorFee24) ? _contractorFee24 : default;
                            contractorFee25 = Decimal.TryParse(reader["alvdij25"] as string, out decimal _contractorFee25) ? _contractorFee25 : default;

                            netHourFee = Decimal.TryParse((reader["noradij"] as string)?.Replace(".", ""), out decimal _netHourFee) ? _netHourFee : default;

                            parts.Add(new Part { PartID = count++, PartName = partName1, Pieces = pieces1, NetPrice = netPrice1, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount1 });
                            parts.Add(new Part { PartID = count++, PartName = partName2, Pieces = pieces2, NetPrice = netPrice2, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount2 });
                            parts.Add(new Part { PartID = count++, PartName = partName3, Pieces = pieces3, NetPrice = netPrice3, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount3 });
                            parts.Add(new Part { PartID = count++, PartName = partName4, Pieces = pieces4, NetPrice = netPrice4, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount4 });
                            parts.Add(new Part { PartID = count++, PartName = partName5, Pieces = pieces5, NetPrice = netPrice5, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount5 });
                            parts.Add(new Part { PartID = count++, PartName = partName6, Pieces = pieces6, NetPrice = netPrice6, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount6 });
                            parts.Add(new Part { PartID = count++, PartName = partName7, Pieces = pieces7, NetPrice = netPrice7, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount7 });
                            parts.Add(new Part { PartID = count++, PartName = partName8, Pieces = pieces8, NetPrice = netPrice8, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount8 });
                            parts.Add(new Part { PartID = count++, PartName = partName9, Pieces = pieces9, NetPrice = netPrice9, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount9 });
                            parts.Add(new Part { PartID = count++, PartName = partName10, Pieces = pieces10, NetPrice = netPrice10, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount10 });
                            parts.Add(new Part { PartID = count++, PartName = partName11, Pieces = pieces11, NetPrice = netPrice11, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount11 });
                            parts.Add(new Part { PartID = count++, PartName = partName12, Pieces = pieces12, NetPrice = netPrice12, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount12 });
                            parts.Add(new Part { PartID = count++, PartName = partName13, Pieces = pieces13, NetPrice = netPrice13, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount13 });
                            parts.Add(new Part { PartID = count++, PartName = partName14, Pieces = pieces14, NetPrice = netPrice14, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount14 });
                            parts.Add(new Part { PartID = count++, PartName = partName15, Pieces = pieces15, NetPrice = netPrice15, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount15 });
                            parts.Add(new Part { PartID = count++, PartName = partName16, Pieces = pieces16, NetPrice = netPrice16, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount16 });
                            parts.Add(new Part { PartID = count++, PartName = partName17, Pieces = pieces17, NetPrice = netPrice17, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount17 });
                            parts.Add(new Part { PartID = count++, PartName = partName18, Pieces = pieces18, NetPrice = netPrice18, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount18 });
                            parts.Add(new Part { PartID = count++, PartName = partName19, Pieces = pieces19, NetPrice = netPrice19, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount19 });
                            parts.Add(new Part { PartID = count++, PartName = partName20, Pieces = pieces20, NetPrice = netPrice20, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount20 });
                            parts.Add(new Part { PartID = count++, PartName = partName21, Pieces = pieces21, NetPrice = netPrice21, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount21 });
                            parts.Add(new Part { PartID = count++, PartName = partName22, Pieces = pieces22, NetPrice = netPrice22, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount22 });
                            parts.Add(new Part { PartID = count++, PartName = partName23, Pieces = pieces23, NetPrice = netPrice23, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount23 });
                            parts.Add(new Part { PartID = count++, PartName = partName24, Pieces = pieces24, NetPrice = netPrice24, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount24 });
                            parts.Add(new Part { PartID = count++, PartName = partName25, Pieces = pieces25, NetPrice = netPrice25, Multiplier = multiplier, Tax = tax, PartDiscount = partDiscount25 });

                            count = 1;

                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName1, WorkHour = workHour1, NetHourFee = netHourFee, WorkDiscount = workDiscount1, IsContractor = isContractor1, ContractorFee = contractorFee1 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName2, WorkHour = workHour2, NetHourFee = netHourFee, WorkDiscount = workDiscount2, IsContractor = isContractor2, ContractorFee = contractorFee2 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName3, WorkHour = workHour3, NetHourFee = netHourFee, WorkDiscount = workDiscount3, IsContractor = isContractor3, ContractorFee = contractorFee3 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName4, WorkHour = workHour4, NetHourFee = netHourFee, WorkDiscount = workDiscount4, IsContractor = isContractor4, ContractorFee = contractorFee4 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName5, WorkHour = workHour5, NetHourFee = netHourFee, WorkDiscount = workDiscount5, IsContractor = isContractor5, ContractorFee = contractorFee5 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName6, WorkHour = workHour6, NetHourFee = netHourFee, WorkDiscount = workDiscount6, IsContractor = isContractor6, ContractorFee = contractorFee6 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName7, WorkHour = workHour7, NetHourFee = netHourFee, WorkDiscount = workDiscount7, IsContractor = isContractor7, ContractorFee = contractorFee7 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName8, WorkHour = workHour8, NetHourFee = netHourFee, WorkDiscount = workDiscount8, IsContractor = isContractor8, ContractorFee = contractorFee8 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName9, WorkHour = workHour9, NetHourFee = netHourFee, WorkDiscount = workDiscount9, IsContractor = isContractor9, ContractorFee = contractorFee9 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName10, WorkHour = workHour10, NetHourFee = netHourFee, WorkDiscount = workDiscount10, IsContractor = isContractor10, ContractorFee = contractorFee10 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName11, WorkHour = workHour11, NetHourFee = netHourFee, WorkDiscount = workDiscount11, IsContractor = isContractor11, ContractorFee = contractorFee11 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName12, WorkHour = workHour12, NetHourFee = netHourFee, WorkDiscount = workDiscount12, IsContractor = isContractor12, ContractorFee = contractorFee12 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName13, WorkHour = workHour13, NetHourFee = netHourFee, WorkDiscount = workDiscount13, IsContractor = isContractor13, ContractorFee = contractorFee13 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName14, WorkHour = workHour14, NetHourFee = netHourFee, WorkDiscount = workDiscount14, IsContractor = isContractor14, ContractorFee = contractorFee14 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName15, WorkHour = workHour15, NetHourFee = netHourFee, WorkDiscount = workDiscount15, IsContractor = isContractor15, ContractorFee = contractorFee15 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName16, WorkHour = workHour16, NetHourFee = netHourFee, WorkDiscount = workDiscount16, IsContractor = isContractor16, ContractorFee = contractorFee16 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName17, WorkHour = workHour17, NetHourFee = netHourFee, WorkDiscount = workDiscount17, IsContractor = isContractor17, ContractorFee = contractorFee17 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName18, WorkHour = workHour18, NetHourFee = netHourFee, WorkDiscount = workDiscount18, IsContractor = isContractor18, ContractorFee = contractorFee18 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName19, WorkHour = workHour19, NetHourFee = netHourFee, WorkDiscount = workDiscount19, IsContractor = isContractor19, ContractorFee = contractorFee19 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName20, WorkHour = workHour20, NetHourFee = netHourFee, WorkDiscount = workDiscount20, IsContractor = isContractor20, ContractorFee = contractorFee20 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName21, WorkHour = workHour21, NetHourFee = netHourFee, WorkDiscount = workDiscount21, IsContractor = isContractor21, ContractorFee = contractorFee21 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName22, WorkHour = workHour22, NetHourFee = netHourFee, WorkDiscount = workDiscount22, IsContractor = isContractor22, ContractorFee = contractorFee22 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName23, WorkHour = workHour23, NetHourFee = netHourFee, WorkDiscount = workDiscount23, IsContractor = isContractor23, ContractorFee = contractorFee23 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName24, WorkHour = workHour24, NetHourFee = netHourFee, WorkDiscount = workDiscount24, IsContractor = isContractor24, ContractorFee = contractorFee24 });
                            workFees.Add(new WorkFee { WorkID = count++, WorkName = workName25, WorkHour = workHour25, NetHourFee = netHourFee, WorkDiscount = workDiscount25, IsContractor = isContractor25, ContractorFee = contractorFee25 });

                            count = 1;

                            workSheets.Add(new WorkSheet
                            {
                                ID = id,
                                PlateNumber = plateNumber,
                                ClientName = clientName,
                                Phone1 = phone,
                                Discount = discount,
                                Multiplier = multiplier,
                                EmailAddress = emailAddress,
                                CarManufacturer = carManufacturer,
                                CarType = carType,
                                InspectionDate = inspectionDate,
                                Odometer = odometer,
                                IsActive = isActive,
                                CreateDate = createDate,
                                Notes = notes,
                                NetHourFee = netHourFee,
                                Tax = tax,
                                Parts = parts,
                                WorkFees = workFees
                            });
                        }
                    }
                }
            }

            return workSheets;
        }

        public static int AddWorkSheet(WorkSheet workSheet)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"INSERT INTO Munkalap
                                           (rendszam, tulajdonos, telefon, kedvezmeny, szorzo, email, gyartmany, tipus, muszaki,
                                            kilometer, datum, hibajelenseg, munkalapzart, mlafa, megnevezes01, darab01, nbeszer01,
                                            szazalekalk01, megnevezes02, darab02, nbeszer02, szazalekalk02, megnevezes03, darab03,
                                            nbeszer03, szazalekalk03, megnevezes04, darab04, nbeszer04, szazalekalk04, megnevezes05, 
                                            darab05, nbeszer05, szazalekalk05, megnevezes06, darab06, nbeszer06, szazalekalk06, 
                                            megnevezes07, darab07, nbeszer07, szazalekalk07, megnevezes08, darab08, nbeszer08,
                                            szazalekalk08, megnevezes09, darab09, nbeszer09, szazalekalk09, megnevezes10, darab10,
                                            nbeszer10, szazalekalk10, megnevezes11, darab11, nbeszer11, szazalekalk11, megnevezes12,
                                            darab12, nbeszer12, szazalekalk12, megnevezes13, darab13, nbeszer13, szazalekalk13,
                                            megnevezes14, darab14, nbeszer14, szazalekalk14, megnevezes15, darab15, nbeszer15,
                                            szazalekalk15, megnevezes16, darab16, nbeszer16, szazalekalk16, megnevezes17, darab17,
                                            nbeszer17, szazalekalk17, megnevezes18, darab18, nbeszer18, szazalekalk18, megnevezes19,
                                            darab19, nbeszer19, szazalekalk19, megnevezes20, darab20, nbeszer20, szazalekalk20,
                                            megnevezes21, darab21, nbeszer21, szazalekalk21, megnevezes22, darab22, nbeszer22,
                                            szazalekalk22, megnevezes23, darab23, nbeszer23, szazalekalk23, megnevezes24, darab24,
                                            nbeszer24, szazalekalk24, megnevezes25, darab25, nbeszer25, szazalekalk25, noradij,
                                            elvmunka01, munkaora01, szazalekmunk01, elvmunka02, munkaora02, szazalekmunk02, elvmunka03,
                                            munkaora03, szazalekmunk03, elvmunka04, munkaora04, szazalekmunk04, elvmunka05, munkaora05,
                                            szazalekmunk05, elvmunka06, munkaora06, szazalekmunk06, elvmunka07, munkaora07, szazalekmunk07,
                                            elvmunka08, munkaora08, szazalekmunk08, elvmunka09, munkaora09, szazalekmunk09, elvmunka10,
                                            munkaora10, szazalekmunk10, elvmunka11, munkaora11, szazalekmunk11, elvmunka12, munkaora12,
                                            szazalekmunk12, elvmunka13, munkaora13, szazalekmunk13, elvmunka14, munkaora14, szazalekmunk14,
                                            elvmunka15, munkaora15, szazalekmunk15, elvmunka16, munkaora16, szazalekmunk16, elvmunka17,
                                            munkaora17, szazalekmunk17, elvmunka18, munkaora18, szazalekmunk18, elvmunka19, munkaora19,
                                            szazalekmunk19, elvmunka20, munkaora20, szazalekmunk20, elvmunka21, munkaora21, szazalekmunk21,
                                            elvmunka22, munkaora22, szazalekmunk22, elvmunka23, munkaora23, szazalekmunk23, elvmunka24,
                                            munkaora24, szazalekmunk24, elvmunka25, munkaora25, szazalekmunk25, chkbox1, alvdij1, chkbox2,
                                            alvdij2, chkbox3, alvdij3, chkbox4, alvdij4, chkbox5, alvdij5, chkbox6, alvdij6, chkbox7, alvdij7,
                                            chkbox8, alvdij8, chkbox9, alvdij9, chkbox10, alvdij10, chkbox11, alvdij11, chkbox12, alvdij12,
                                            chkbox13, alvdij13, chkbox14, alvdij14, chkbox15, alvdij15, chkbox16, alvdij16, chkbox17, alvdij17,
                                            chkbox18, alvdij18, chkbox19, alvdij19, chkbox20, alvdij20, chkbox21, alvdij21, chkbox22, alvdij22,
                                            chkbox23, alvdij23, chkbox24, alvdij24, chkbox25, alvdij25)
                                    VALUES (@rendszam, @tulajdonos, @telefon, @kedvezmeny, @szorzo, @email, @gyartmany, @tipus, @muszaki,
                                            @kilometer, @datum, @hibajelenseg, @munkalapzart, @mlafa, @megnevezes01, @darab01, @nbeszer01,
                                            @szazalekalk01, @megnevezes02, @darab02, @nbeszer02, @szazalekalk02, @megnevezes03, @darab03,
                                            @nbeszer03, @szazalekalk03, @megnevezes04, @darab04, @nbeszer04, @szazalekalk04, @megnevezes05, 
                                            @darab05, @nbeszer05, @szazalekalk05, @megnevezes06, @darab06, @nbeszer06, @szazalekalk06, 
                                            @megnevezes07, @darab07, @nbeszer07, @szazalekalk07, @megnevezes08, @darab08, @nbeszer08,
                                            @szazalekalk08, @megnevezes09, @darab09, @nbeszer09, @szazalekalk09, @megnevezes10, @darab10,
                                            @nbeszer10, @szazalekalk10, @megnevezes11, @darab11, @nbeszer11, @szazalekalk11, @megnevezes12,
                                            @darab12, @nbeszer12, @szazalekalk12, @megnevezes13, @darab13, @nbeszer13, @szazalekalk13,
                                            @megnevezes14, @darab14, @nbeszer14, @szazalekalk14, @megnevezes15, @darab15, @nbeszer15,
                                            @szazalekalk15, @megnevezes16, @darab16, @nbeszer16, @szazalekalk16, @megnevezes17, @darab17,
                                            @nbeszer17, @szazalekalk17, @megnevezes18, @darab18, @nbeszer18, @szazalekalk18, @megnevezes19,
                                            @darab19, @nbeszer19, @szazalekalk19, @megnevezes20, @darab20, @nbeszer20, @szazalekalk20,
                                            @megnevezes21, @darab21, @nbeszer21, @szazalekalk21, @megnevezes22, @darab22, @nbeszer22,
                                            @szazalekalk22, @megnevezes23, @darab23, @nbeszer23, @szazalekalk23, @megnevezes24, @darab24,
                                            @nbeszer24, @szazalekalk24, @megnevezes25, @darab25, @nbeszer25, @szazalekalk25, @noradij,
                                            @elvmunka01, @munkaora01, @szazalekmunk01, @elvmunka02, @munkaora02, @szazalekmunk02, @elvmunka03,
                                            @munkaora03, @szazalekmunk03, @elvmunka04, @munkaora04, @szazalekmunk04, @elvmunka05, @munkaora05,
                                            @szazalekmunk05, @elvmunka06, @munkaora06, @szazalekmunk06, @elvmunka07, @munkaora07, @szazalekmunk07,
                                            @elvmunka08, @munkaora08, @szazalekmunk08, @elvmunka09, @munkaora09, @szazalekmunk09, @elvmunka10,
                                            @munkaora10, @szazalekmunk10, @elvmunka11, @munkaora11, @szazalekmunk11, @elvmunka12, @munkaora12,
                                            @szazalekmunk12, @elvmunka13, @munkaora13, @szazalekmunk13, @elvmunka14, @munkaora14, @szazalekmunk14,
                                            @elvmunka15, @munkaora15, @szazalekmunk15, @elvmunka16, @munkaora16, @szazalekmunk16, @elvmunka17,
                                            @munkaora17, @szazalekmunk17, @elvmunka18, @munkaora18, @szazalekmunk18, @elvmunka19, @munkaora19,
                                            @szazalekmunk19, @elvmunka20, @munkaora20, @szazalekmunk20, @elvmunka21, @munkaora21, @szazalekmunk21,
                                            @elvmunka22, @munkaora22, @szazalekmunk22, @elvmunka23, @munkaora23, @szazalekmunk23, @elvmunka24,
                                            @munkaora24, @szazalekmunk24, @elvmunka25, @munkaora25, @szazalekmunk25, @chkbox1, @alvdij1, @chkbox2,
                                            @alvdij2, @chkbox3, @alvdij3, @chkbox4, @alvdij4, @chkbox5, @alvdij5, @chkbox6, @alvdij6, @chkbox7, @alvdij7,
                                            @chkbox8, @alvdij8, @chkbox9, @alvdij9, @chkbox10, @alvdij10, @chkbox11, @alvdij11, @chkbox12, @alvdij12,
                                            @chkbox13, @alvdij13, @chkbox14, @alvdij14, @chkbox15, @alvdij15, @chkbox16, @alvdij16, @chkbox17, @alvdij17,
                                            @chkbox18, @alvdij18, @chkbox19, @alvdij19, @chkbox20, @alvdij20, @chkbox21, @alvdij21, @chkbox22, @alvdij22,
                                            @chkbox23, @alvdij23, @chkbox24, @alvdij24, @chkbox25, @alvdij25)";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("rendszam", workSheet.PlateNumber);
                    cmd.Parameters.AddWithValue("tulajdonos", (object)workSheet.ClientName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("telefon", (object)workSheet.Phone1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("kedvezmeny", workSheet.Discount != default ? workSheet.Discount.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("szorzo", workSheet.Multiplier != default ? workSheet.Multiplier.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("email", (object)workSheet.EmailAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("gyartmany", (object)workSheet.CarManufacturer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("tipus", (object)workSheet.CarType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("muszaki", workSheet.InspectionDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("kilometer", workSheet.Odometer != default ? workSheet.Odometer.ToString() : string.Empty);
                    cmd.Parameters.AddWithValue("datum", workSheet.CreateDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("hibajelenseg", (object)workSheet.Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("munkalapzart", workSheet.IsActive.ToString());
                    cmd.Parameters.AddWithValue("mlafa", workSheet.Tax != default ? workSheet.Tax.ToString() : DBNull.Value);

                    int columnNameNumber = 0;

                    string partName;
                    string pieces;
                    string netPrice;
                    string partDiscount;


                    foreach (Part part in workSheet.Parts)
                    {
                        columnNameNumber++;

                        if (columnNameNumber < 10)
                        {
                            partName = "megnevezes0" + columnNameNumber;
                            pieces = "darab0" + columnNameNumber;
                            netPrice = "nbeszer0" + columnNameNumber;
                            partDiscount = "szazalekalk0" + columnNameNumber;
                        }
                        else
                        {
                            partName = "megnevezes" + columnNameNumber;
                            pieces = "darab" + columnNameNumber;
                            netPrice = "nbeszer" + columnNameNumber;
                            partDiscount = "szazalekalk" + columnNameNumber;
                        }

                        cmd.Parameters.AddWithValue($"{partName}", (object)part.PartName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"{pieces}", part.Pieces != default ? part.Pieces.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{netPrice}", part.NetPrice != default ? part.NetPrice.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{partDiscount}", part.PartDiscount != default ? part.PartDiscount.ToString() : DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("noradij", workSheet.NetHourFee != default ? workSheet.NetHourFee.ToString() : DBNull.Value);

                    columnNameNumber = 0;

                    string workName;
                    string workHour;
                    string workDiscount;

                    foreach (WorkFee workFee in workSheet.WorkFees)
                    {
                        columnNameNumber++;

                        if (columnNameNumber < 10)
                        {
                            workName = "elvmunka0" + columnNameNumber;
                            workHour = "munkaora0" + columnNameNumber;
                            workDiscount = "szazalekmunk0" + columnNameNumber;
                        }
                        else
                        {
                            workName = "elvmunka" + columnNameNumber;
                            workHour = "munkaora" + columnNameNumber;
                            workDiscount = "szazalekmunk" + columnNameNumber;
                        }

                        cmd.Parameters.AddWithValue($"{workName}", (object)workFee.WorkName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"{workHour}", workFee.WorkHour != default ? workFee.WorkHour.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{workDiscount}", workFee.WorkDiscount != default ? workFee.WorkDiscount.ToString() : DBNull.Value);
                    }

                    columnNameNumber = 0;

                    string isContractor;
                    string contractorFee;

                    foreach (WorkFee workFee in workSheet.WorkFees)
                    {
                        columnNameNumber++;

                        isContractor = "chkbox" + columnNameNumber;
                        contractorFee = "alvdij" + columnNameNumber;

                        cmd.Parameters.AddWithValue($"{isContractor}", workFee.IsContractor.ToString());
                        cmd.Parameters.AddWithValue($"{contractorFee}", workFee.ContractorFee != default ? workFee.ContractorFee.ToString() : DBNull.Value);
                    }

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery(); // For Update, Insert, and Delete statements, 
                                                          // the return value is the number of rows affected by the command
                }
            }

            return rowsAffected;
        }

        public static int UpdateWorkSheet(WorkSheet workSheet)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                //rendszam = @rendszam, tulajdonos = @tulajdonos, telefon = @telefon, kedvezmeny = @kedvezmeny, email = @email, 
                //gyartmany = @gyartmany, tipus = @tipus, muszaki = @muszaki, mlafa = @mlafa,

                string query = @"UPDATE Munkalap 
                                 SET szorzo = @szorzo, kilometer = @kilometer, datum = @datum, hibajelenseg = @hibajelenseg, 
                                     munkalapzart = @munkalapzart, megnevezes01 = @megnevezes01, darab01 = @darab01, nbeszer01 = @nbeszer01,
                                     szazalekalk01 = @szazalekalk01, megnevezes02 = @megnevezes02, darab02 = @darab02, nbeszer02 = @nbeszer02, 
                                     szazalekalk02 = @szazalekalk02, megnevezes03 = @megnevezes03, darab03 = @darab03, nbeszer03 = @nbeszer03, 
                                     szazalekalk03 = @szazalekalk03, megnevezes04 = @megnevezes04, darab04 = @darab04, nbeszer04 = @nbeszer04, 
                                     szazalekalk04 = @szazalekalk04, megnevezes05 = @megnevezes05, darab05 = @darab05, nbeszer05 = @nbeszer05, 
                                     szazalekalk05 = @szazalekalk05, megnevezes06 = @megnevezes06, darab06 = @darab06, nbeszer06 = @nbeszer06, 
                                     szazalekalk06 = @szazalekalk06, megnevezes07 = @megnevezes07, darab07 = @darab07, nbeszer07 = @nbeszer07, 
                                     szazalekalk07 = @szazalekalk07, megnevezes08 = @megnevezes08, darab08 = @darab08, nbeszer08 = @nbeszer08, 
                                     szazalekalk08 = @szazalekalk08, megnevezes09 = @megnevezes09, darab09 = @darab09, nbeszer09 = @nbeszer09, 
                                     szazalekalk09 = @szazalekalk09, megnevezes10 = @megnevezes10, darab10 = @darab10, nbeszer10 = @nbeszer10, 
                                     szazalekalk10 = @szazalekalk10, megnevezes11 = @megnevezes11, darab11 = @darab11, nbeszer11 = @nbeszer11, 
                                     szazalekalk11 = @szazalekalk11, megnevezes12 = @megnevezes12, darab12 = @darab12, nbeszer12 = @nbeszer12, 
                                     szazalekalk12 = @szazalekalk12, megnevezes13 = @megnevezes13, darab13 = @darab13, nbeszer13 = @nbeszer13, 
                                     szazalekalk13 = @szazalekalk13, megnevezes14 = @megnevezes14, darab14 = @darab14, nbeszer14 = @nbeszer14, 
                                     szazalekalk14 = @szazalekalk14, megnevezes15 = @megnevezes15, darab15 = @darab15, nbeszer15 = @nbeszer15,
                                     szazalekalk15 = @szazalekalk15, megnevezes16 = @megnevezes16, darab16 = @darab16, nbeszer16 = @nbeszer16, 
                                     szazalekalk16 = @szazalekalk16, megnevezes17 = @megnevezes17, darab17 = @darab17, nbeszer17 = @nbeszer17, 
                                     szazalekalk17 = @szazalekalk17, megnevezes18 = @megnevezes18, darab18 = @darab18, nbeszer18 = @nbeszer18, 
                                     szazalekalk18 = @szazalekalk18, megnevezes19 = @megnevezes19, darab19 = @darab19, nbeszer19 = @nbeszer19, 
                                     szazalekalk19 = @szazalekalk19, megnevezes20 = @megnevezes20, darab20 = @darab20, nbeszer20 = @nbeszer20, 
                                     szazalekalk20 = @szazalekalk20, megnevezes21 = @megnevezes21, darab21 = @darab21, nbeszer21 = @nbeszer21, 
                                     szazalekalk21 = @szazalekalk21, megnevezes22 = @megnevezes22, darab22 = @darab22, nbeszer22 = @nbeszer22,
                                     szazalekalk22 = @szazalekalk22, megnevezes23 = @megnevezes23, darab23 = @darab23, nbeszer23 = @nbeszer23, 
                                     szazalekalk23 = @szazalekalk23, megnevezes24 = @megnevezes24, darab24 = @darab24, nbeszer24 = @nbeszer24, 
                                     szazalekalk24 = @szazalekalk24, megnevezes25 = @megnevezes25, darab25 = @darab25, nbeszer25 = @nbeszer25, 
                                     szazalekalk25 = @szazalekalk25 
                                 WHERE ID = @ID";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("szorzo", workSheet.Multiplier != default ? workSheet.Multiplier.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("kilometer", workSheet.Odometer != default ? workSheet.Odometer.ToString() : string.Empty);
                    cmd.Parameters.AddWithValue("datum", workSheet.CreateDate.ToString("yyyy.MM.dd"));
                    cmd.Parameters.AddWithValue("hibajelenseg", (object)workSheet.Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("munkalapzart", workSheet.IsActive.ToString());

                    int columnNameNumber = 0;

                    string partName;
                    string pieces;
                    string netPrice;
                    string partDiscount;


                    foreach (Part part in workSheet.Parts)
                    {
                        columnNameNumber++;

                        if (columnNameNumber < 10)
                        {
                            partName = "megnevezes0" + columnNameNumber;
                            pieces = "darab0" + columnNameNumber;
                            netPrice = "nbeszer0" + columnNameNumber;
                            partDiscount = "szazalekalk0" + columnNameNumber;
                        }
                        else
                        {
                            partName = "megnevezes" + columnNameNumber;
                            pieces = "darab" + columnNameNumber;
                            netPrice = "nbeszer" + columnNameNumber;
                            partDiscount = "szazalekalk" + columnNameNumber;
                        }

                        cmd.Parameters.AddWithValue($"{partName}", (object)part.PartName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"{pieces}", part.Pieces != default ? part.Pieces.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{netPrice}", part.NetPrice != default ? part.NetPrice.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{partDiscount}", part.PartDiscount != default ? part.PartDiscount.ToString() : DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("ID", workSheet.ID);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"UPDATE Munkalap 
                                 SET noradij = @noradij, elvmunka01 = @elvmunka01, munkaora01 = @munkaora01, 
                                     szazalekmunk01 = @szazalekmunk01, elvmunka02 = @elvmunka02, munkaora02 = @munkaora02, 
                                     szazalekmunk02 = @szazalekmunk02, elvmunka03 = @elvmunka03, munkaora03 = @munkaora03, 
                                     szazalekmunk03 = @szazalekmunk03, elvmunka04 = @elvmunka04, munkaora04 = @munkaora04, 
                                     szazalekmunk04 = @szazalekmunk04, elvmunka05 = @elvmunka05, munkaora05 = @munkaora05,
                                     szazalekmunk05 = @szazalekmunk05, elvmunka06 = @elvmunka06, munkaora06 = @munkaora06, 
                                     szazalekmunk06 = @szazalekmunk06, elvmunka07 = @elvmunka07, munkaora07 = @munkaora07, 
                                     szazalekmunk07 = @szazalekmunk07, elvmunka08 = @elvmunka08, munkaora08 = @munkaora08, 
                                     szazalekmunk08 = @szazalekmunk08, elvmunka09 = @elvmunka09, munkaora09 = @munkaora09, 
                                     szazalekmunk09 = @szazalekmunk09, elvmunka10 = @elvmunka10, munkaora10 = @munkaora10, 
                                     szazalekmunk10 = @szazalekmunk10, elvmunka11 = @elvmunka11, munkaora11 = @munkaora11, 
                                     szazalekmunk11 = @szazalekmunk11, elvmunka12 = @elvmunka12, munkaora12 = @munkaora12,
                                     szazalekmunk12 = @szazalekmunk12, elvmunka13 = @elvmunka13, munkaora13 = @munkaora13,
                                     szazalekmunk13 = @szazalekmunk13, elvmunka14 = @elvmunka14, munkaora14 = @munkaora14, 
                                     szazalekmunk14 = @szazalekmunk14, elvmunka15 = @elvmunka15, munkaora15 = @munkaora15, 
                                     szazalekmunk15 = @szazalekmunk15, elvmunka16 = @elvmunka16, munkaora16 = @munkaora16, 
                                     szazalekmunk16 = @szazalekmunk16, elvmunka17 = @elvmunka17, munkaora17 = @munkaora17, 
                                     szazalekmunk17 = @szazalekmunk17, elvmunka18 = @elvmunka18, munkaora18 = @munkaora18, 
                                     szazalekmunk18 = @szazalekmunk18, elvmunka19 = @elvmunka19, munkaora19 = @munkaora19,
                                     szazalekmunk19 = @szazalekmunk19, elvmunka20 = @elvmunka20, munkaora20 = @munkaora20, 
                                     szazalekmunk20 = @szazalekmunk20, elvmunka21 = @elvmunka21, munkaora21 = @munkaora21, 
                                     szazalekmunk21 = @szazalekmunk21, elvmunka22 = @elvmunka22, munkaora22 = @munkaora22, 
                                     szazalekmunk22 = @szazalekmunk22, elvmunka23 = @elvmunka23, munkaora23 = @munkaora23, 
                                     szazalekmunk23 = @szazalekmunk23, elvmunka24 = @elvmunka24, munkaora24 = @munkaora24, 
                                     szazalekmunk24 = @szazalekmunk24, elvmunka25 = @elvmunka25, munkaora25 = @munkaora25, 
                                     szazalekmunk25 = @szazalekmunk25, chkbox1 = @chkbox1, alvdij1 = @alvdij1, chkbox2 = @chkbox2,
                                     alvdij2 = @alvdij2, chkbox3 = @chkbox3, alvdij3 = @alvdij3, chkbox4 = @chkbox4, alvdij4 = @alvdij4, chkbox5 = @chkbox5, 
                                     alvdij5 = @alvdij5, chkbox6 = @chkbox6, alvdij6 = @alvdij6, chkbox7 = @chkbox7, alvdij7 = @alvdij7, chkbox8 = @chkbox8, 
                                     alvdij8 = @alvdij8, chkbox9 = @chkbox9, alvdij9 = @alvdij9, chkbox10 = @chkbox10, alvdij10 = @alvdij10, chkbox11 = @chkbox11, 
                                     alvdij11 = @alvdij11, chkbox12 = @chkbox12, alvdij12 = @alvdij12, chkbox13 = @chkbox13, alvdij13 = @alvdij13, chkbox14 = @chkbox14, 
                                     alvdij14 = @alvdij14, chkbox15 = @chkbox15, alvdij15 = @alvdij15, chkbox16 = @chkbox16, alvdij16 = @alvdij16, chkbox17 = @chkbox17, 
                                     alvdij17 = @alvdij17, chkbox18 = @chkbox18, alvdij18 = @alvdij18, chkbox19 = @chkbox19, alvdij19 = @alvdij19, chkbox20 = @chkbox20, 
                                     alvdij20 = @alvdij20, chkbox21 = @chkbox21, alvdij21 = @alvdij21, chkbox22 = @chkbox22, alvdij22 = @alvdij22, chkbox23 = @chkbox23, 
                                     alvdij23 = @alvdij23, chkbox24 = @chkbox24, alvdij24 = @alvdij24, chkbox25 = @chkbox25, alvdij25 = @alvdij25
                                 WHERE ID = @ID";

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("noradij", workSheet.NetHourFee != default ? workSheet.NetHourFee.ToString() : DBNull.Value);

                    int columnNameNumber = 0;

                    string workName;
                    string workHour;
                    string workDiscount;

                    foreach (WorkFee workFee in workSheet.WorkFees)
                    {
                        columnNameNumber++;

                        if (columnNameNumber < 10)
                        {
                            workName = "elvmunka0" + columnNameNumber;
                            workHour = "munkaora0" + columnNameNumber;
                            workDiscount = "szazalekmunk0" + columnNameNumber;
                        }
                        else
                        {
                            workName = "elvmunka" + columnNameNumber;
                            workHour = "munkaora" + columnNameNumber;
                            workDiscount = "szazalekmunk" + columnNameNumber;
                        }

                        cmd.Parameters.AddWithValue($"{workName}", (object)workFee.WorkName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"{workHour}", workFee.WorkHour != default ? workFee.WorkHour.ToString() : DBNull.Value);
                        cmd.Parameters.AddWithValue($"{workDiscount}", workFee.WorkDiscount != default ? workFee.WorkDiscount.ToString() : DBNull.Value);
                    }

                    columnNameNumber = 0;

                    string isContractor;
                    string contractorFee;

                    foreach (WorkFee workFee in workSheet.WorkFees)
                    {
                        columnNameNumber++;

                        isContractor = "chkbox" + columnNameNumber;
                        contractorFee = "alvdij" + columnNameNumber;

                        cmd.Parameters.AddWithValue($"{isContractor}", workFee.IsContractor.ToString());
                        cmd.Parameters.AddWithValue($"{contractorFee}", workFee.ContractorFee != default ? workFee.ContractorFee.ToString() : DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("ID", workSheet.ID);

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static int DeleteWorkSheet(Client client)
        {
            int rowsAffected;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string query = @"DELETE FROM Munkalap
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
