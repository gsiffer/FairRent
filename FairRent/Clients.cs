
using FairRent.Business;
using FairRent.Common;
using FairRent.ExcelDocuments;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace FairRent
{
    public partial class Clients : Form
    {
        private ClientViewModel clientVM;
        private static Clients instance;      // declare private static field of form type
        private DateTime todayDate = DateTime.Today;
        private Rates rates;
        private string programEXEPath;

        const string EXCEL_FILE_NAME = "lejart_muszaki.xls";

        private Clients()                     // scope default ctor private
        {
            InitializeComponent();

            this.Size = new Size(1250, 610);
            this.MinimumSize = new Size(1250, 610);
            this.MaximumSize = new Size(1800, 1000);

            this.dataGridViewClients.Size = new Size(1070, 480);
            this.buttonNewClient.Location = new Point(1092, 62);
            this.buttonEditClient.Location = new Point(1092, 89);
            this.buttonDeleteClient.Location = new Point(1092, 116);
            this.buttonNewWorksheet.Location = new Point(1092, 157);
            this.buttonEditWorksheet.Location = new Point(1092, 184);
            this.checkBoxConfirmDeletion.Location = new Point(1092, 240);
            this.buttonClose.Location = new Point(1092, 520);   //355

            labelRowsCount.Text = "";
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            try
            {
                clientVM = new ClientViewModel();
                setBindings();
                rates = RatesValidation.GetRates();
                setupDataGridView();

                numberOfRows();
                programEXEPath = Application.StartupPath.ToString() + @"\";
            }
            catch (SqlException ex)
            {
                DisplayError(ex.Message, "DB Error");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void setBindings()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.DataSource = clientVM.DtClients;
        }

        private void setupDataGridView()
        {
            // configure for readonly 

            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.AllowUserToDeleteRows = false;
            dataGridViewClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewClients.AllowUserToOrderColumns = false;
            dataGridViewClients.AllowUserToResizeColumns = true;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            // add columns

            DataGridViewTextBoxColumn plateNumber = new DataGridViewTextBoxColumn();
            plateNumber.Name = "rendszam";
            plateNumber.DataPropertyName = "rendszam";
            plateNumber.HeaderText = "Frsz";
            plateNumber.Width = 70;
            plateNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewClients.Columns.Add(plateNumber);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "nev";
            name.DataPropertyName = "nev";
            name.HeaderText = "Név";
            name.Width = 160;
            name.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewClients.Columns.Add(name);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "iranyitosz";
            postalCode.DataPropertyName = "iranyitosz";
            postalCode.HeaderText = "Irányítósz";
            postalCode.Width = 70;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(postalCode);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "varos";
            city.DataPropertyName = "varos";
            city.HeaderText = "Város";
            city.Width = 70;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(city);

            DataGridViewTextBoxColumn address = new DataGridViewTextBoxColumn();
            address.Name = "cim";
            address.DataPropertyName = "cim";
            address.HeaderText = "Cím";
            address.Width = 140;
            address.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address);

            DataGridViewTextBoxColumn phone = new DataGridViewTextBoxColumn();
            phone.Name = "telefon1";
            phone.DataPropertyName = "telefon1";
            phone.HeaderText = "Telefon1";
            phone.Width = 100;
            phone.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(phone);

            DataGridViewTextBoxColumn email = new DataGridViewTextBoxColumn();
            email.Name = "emilcim";
            email.DataPropertyName = "emilcim";
            email.HeaderText = "Email cím";
            email.Width = 140;
            email.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(email);

            DataGridViewTextBoxColumn carManufacturer = new DataGridViewTextBoxColumn();
            carManufacturer.Name = "gyartmany";
            carManufacturer.DataPropertyName = "gyartmany";
            carManufacturer.HeaderText = "Gyártmány";
            carManufacturer.Width = 75;
            carManufacturer.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(carManufacturer);

            DataGridViewTextBoxColumn carType = new DataGridViewTextBoxColumn();
            carType.Name = "tipus";
            carType.DataPropertyName = "tipus";
            carType.HeaderText = "Típus";
            carType.Width = 75;
            carType.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(carType);

            DataGridViewTextBoxColumn technicalExamination = new DataGridViewTextBoxColumn();
            technicalExamination.Name = "muszakivizsga";
            technicalExamination.DataPropertyName = "muszakivizsga";
            technicalExamination.HeaderText = "Műszaki";
            technicalExamination.Width = 80;
            technicalExamination.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewClients.Columns.Add(technicalExamination);

            DataGridViewTextBoxColumn year = new DataGridViewTextBoxColumn();
            year.Name = "evjarat";
            year.DataPropertyName = "evjarat";
            year.HeaderText = "Gy.év";
            year.Width = 50;
            year.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            year.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            year.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(year);

            DataGridViewTextBoxColumn identificationNumber = new DataGridViewTextBoxColumn();
            identificationNumber.Name = "alvazszam";
            identificationNumber.DataPropertyName = "alvazszam";
            identificationNumber.HeaderText = "Alvázszám";
            identificationNumber.Width = 140;
            identificationNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewClients.Columns.Add(identificationNumber);

            DataGridViewTextBoxColumn engineNumber = new DataGridViewTextBoxColumn();
            engineNumber.Name = "motorszam";
            engineNumber.DataPropertyName = "motorszam";
            engineNumber.HeaderText = "Motorszám";
            engineNumber.Width = 140;
            engineNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(engineNumber);

            DataGridViewTextBoxColumn cubicCentimetre = new DataGridViewTextBoxColumn();
            cubicCentimetre.Name = "kobcenti";
            cubicCentimetre.DataPropertyName = "kobcenti";
            cubicCentimetre.HeaderText = "Cm3";
            cubicCentimetre.Width = 40;
            cubicCentimetre.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cubicCentimetre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cubicCentimetre.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(cubicCentimetre);

            DataGridViewTextBoxColumn kw = new DataGridViewTextBoxColumn();
            kw.Name = "kw";
            kw.DataPropertyName = "kw";
            kw.HeaderText = "KW";
            kw.Width = 40;
            kw.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            kw.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            kw.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(kw);

            DataGridViewTextBoxColumn fuel = new DataGridViewTextBoxColumn();
            fuel.Name = "uzemanyag";
            fuel.DataPropertyName = "uzemanyag";
            fuel.HeaderText = "Üzema.";
            fuel.Width = 50;
            fuel.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(fuel);

            DataGridViewCheckBoxColumn isFiltered = new DataGridViewCheckBoxColumn();
            isFiltered.Name = "szures";
            isFiltered.DataPropertyName = "szures";
            isFiltered.HeaderText = "Szűrés";
            isFiltered.Width = 60;
            isFiltered.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(isFiltered);
        }

        public static Clients CreateForm()   // create public static method with form type return
        {
            if (instance == null)
            {
                instance = new Clients();
            }

            return instance;
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null; // explicitly set form instance to null as form closes
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFilterPlateNum_TextChanged(object sender, EventArgs e)
        {
            textBoxFilterPlateNum.BackColor = textBoxFilterPlateNum.Text != string.Empty ? Color.LightYellow : Color.White;

            filterTable();
        }

        private void textBoxFilterName_TextChanged(object sender, EventArgs e)
        {
            textBoxFilterName.BackColor = textBoxFilterName.Text != string.Empty ? Color.LightYellow : Color.White;

            filterTable();
        }

        private void textBoxFilterIdentificationNumber_TextChanged(object sender, EventArgs e)
        {
            textBoxFilterIdentificationNumber.BackColor = textBoxFilterIdentificationNumber.Text != string.Empty ? Color.LightYellow : Color.White;

            filterTable();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            textBoxFilterName.Text = "";
            textBoxFilterPlateNum.Text = "";
            textBoxFilterIdentificationNumber.Text = "";
            checkBoxFilterTechnicalExamination.Checked = false;
            dataGridViewClients.Select();
        }

        private void filterTable() // the alvazszam could be NULL. For this reason, when we filter the textBoxFilterIdentificationNumber with empty string
        {                          // the rows with NULL cells value don't show in the table. I had to separate these events.
            if (checkBoxFilterTechnicalExamination.Checked && textBoxFilterIdentificationNumber.Text != string.Empty)
            {
                (dataGridViewClients.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("{0} LIKE '{1}%' AND {2} LIKE '{3}%' AND {4} LIKE '%{5}%' AND {6} <= #{7}# AND {8} LIKE 'true'", "rendszam", textBoxFilterPlateNum.Text,
                              "nev", textBoxFilterName.Text, "alvazszam", textBoxFilterIdentificationNumber.Text, "muszakivizsga", dateTimePickerTechnicalExamination.Value.Date, "szures");
            }
            else if (checkBoxFilterTechnicalExamination.Checked && textBoxFilterIdentificationNumber.Text == string.Empty)
            {
                (dataGridViewClients.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("{0} LIKE '{1}%' AND {2} LIKE '{3}%' AND {4} <= #{5}# AND {6} LIKE 'true'", "rendszam", textBoxFilterPlateNum.Text,
                              "nev", textBoxFilterName.Text, "muszakivizsga", dateTimePickerTechnicalExamination.Value.Date, "szures");
            }
            else if (!checkBoxFilterTechnicalExamination.Checked && textBoxFilterIdentificationNumber.Text != string.Empty)
            {
                (dataGridViewClients.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("{0} LIKE '{1}%' AND {2} LIKE '{3}%' AND {4} LIKE '%{5}%' AND {6} > #{7}#", "rendszam", textBoxFilterPlateNum.Text,
                              "nev", textBoxFilterName.Text, "alvazszam", textBoxFilterIdentificationNumber.Text, "muszakivizsga", DateTime.MinValue.Date);
            }
            else if(!checkBoxFilterTechnicalExamination.Checked && textBoxFilterIdentificationNumber.Text == string.Empty)
            {
                (dataGridViewClients.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("{0} LIKE '{1}%' AND {2} LIKE '{3}%' AND {4} > #{5}#", "rendszam", textBoxFilterPlateNum.Text,
                              "nev", textBoxFilterName.Text, "muszakivizsga", DateTime.MinValue.Date);
            }

            numberOfRows();
        }

        private void dataGridViewCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showEditClientDialog(sender);
        }

        private void dataGridViewClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridViewClients.Rows.Count > 0) showEditClientDialog(sender);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridViewClients.Rows.Count > 0) confirmDeletion();
            }
        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            showEditClientDialog(sender);
        }

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.Rows.Count > 0) showEditClientDialog(sender);
        }

        private void showEditClientDialog(object sender)
        {
            Client client;
            DataRow row = null;

            if (sender == buttonNewClient)
            {
                client = new Client();
                client.InspectionDate = todayDate; // Sets default date to today dates. DataTimePicer minDate is 1753-01-01 and 
                client.InsuranceDate = todayDate;  // the DateTime minDate 0001-1-1. Setting DateTime to default value causes error.
                client.Filtered = true;
                client.IsHungarian = true;
                client.Discount = rates.Discount;
            }
            else
            {
                client = setClient(row = selectedRow());

                //var result = clientVM.DtClients.AsEnumerable()
                //             .Where(myRow => myRow
                //             .Field<string>("rendszam") == plateNumber);

                //row = result.CopyToDataTable<DataRow>().Rows[0];

            }

            clientVM.DisplayClient = client;
            bool isNew = (client.PlateNumber == default);

            using (EditClientDialog dlg = new EditClientDialog(clientVM, isNew))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    client = clientVM.DisplayClient;

                    if (isNew)
                    {
                        DataRow newRow = clientVM.DtClients.NewRow();
                        setDataTableRow(ref newRow, client);
                        clientVM.DtClients.Rows.Add(newRow);

                        clientVM.DtClients.DefaultView.Sort = "rendszam";

                        foreach (DataGridViewRow rowSelect in dataGridViewClients.Rows)
                        {
                            if (rowSelect.Cells["rendszam"].Value.ToString().Equals(clientVM.DisplayClient.PlateNumber))
                            {
                                dataGridViewClients.CurrentCell = dataGridViewClients["rendszam", rowSelect.Index];
                                break;
                            }
                        }

                        numberOfRows();
                    }
                    else
                    {
                        setDataTableRow(ref row, client);
                    }
                }
                dataGridViewClients.Select();
            }
        }

        private DataRow selectedRow()
        {
            string plateNumber = dataGridViewClients.CurrentRow.Cells["rendszam"].Value as string;
            DataRow[] result = clientVM.DtClients.Select($"rendszam = '{plateNumber}'");

            return result[0];
        }

        private Client setClient(DataRow row)
        {
            Client client = new Client
            {
                PlateNumber = row["rendszam"] as string,
                ClientName = row["nev"] as string,
                PostalCode = row["iranyitosz"] as string,
                City = row["varos"] as string,
                Address = row["cim"] as string,
                Phone1 = row["telefon1"] as string,
                Phone2 = row["telefon2"] as string,
                EmailAddress = row["emilcim"] as string,
                Discount = Decimal.TryParse(row["kedvezmeny"] as string, out decimal discount) ? discount : default,
                CarManufacturer = row["gyartmany"] as string,
                CarType = row["tipus"] as string,
                InspectionDate = DateTime.TryParse(row["muszakivizsga"] as string, out DateTime inpectionDate) ? inpectionDate : todayDate,
                Year = Int32.TryParse(row["evjarat"] as string, out int year) ? year : default,
                IdentificationNumber = row["alvazszam"] as string,
                EngineNumber = row["motorszam"] as string,
                CubicCentimetre = Int32.TryParse(row["kobcenti"] as string, out int cubicCentimetre) ? cubicCentimetre : default,
                KW = Int32.TryParse(row["kw"] as string, out int kw) ? kw : default,
                Fuel = row["uzemanyag"] as string,
                InsuranceName = row["kotelezoneve"] as string,
                InsuranceDate = DateTime.TryParse(row["kotelezoevfordulo"] as string, out DateTime insuranceDate) ? insuranceDate : todayDate,
                InsuranceFee = Decimal.TryParse(row["kotelezodij"] as string, out decimal fee) ? fee : default,
                CascoName = row["casconeve"] as string,
                CascoType = row["cascomodozat"] as string,
                CascoDeduction = row["cascoonresz"] as string,
                Filtered = bool.TryParse(row["szures"] as string, out bool filtered) && filtered,
                IsHungarian = bool.TryParse(row["rdbmagyar"] as string, out bool isHungarian) && isHungarian
            };

            return client;
        }

        private void setDataTableRow(ref DataRow row, Client client)
        {
            row["rendszam"] = client.PlateNumber;
            row["nev"] = client.ClientName;
            row["iranyitosz"] = client.PostalCode;
            row["varos"] = client.City;
            row["cim"] = client.Address;
            row["telefon1"] = client.Phone1;
            row["telefon2"] = client.Phone2;
            row["emilcim"] = client.EmailAddress;
            row["kedvezmeny"] = client.Discount;
            row["gyartmany"] = client.CarManufacturer;
            row["tipus"] = client.CarType;
            row["muszakivizsga"] = client.InspectionDate.ToString("yyyy.MM.dd");
            row["evjarat"] = client.Year != 0 ? client.Year : string.Empty; // I add <LangVersion>9.0</LangVersion> to csproj file otherwise it doesn't work
            row["alvazszam"] = client.IdentificationNumber;
            row["motorszam"] = client.EngineNumber;
            row["kobcenti"] = client.CubicCentimetre != 0 ? client.CubicCentimetre : string.Empty;
            row["kw"] = client.KW != 0 ? client.KW : string.Empty;
            row["uzemanyag"] = client.Fuel;
            row["kotelezoneve"] = client.InsuranceName;
            row["kotelezoevfordulo"] = client.InsuranceDate;
            row["kotelezodij"] = client.InsuranceFee;
            row["casconeve"] = client.CascoName;
            row["cascomodozat"] = client.CascoType;
            row["cascoonresz"] = client.CascoDeduction;
            row["szures"] = client.Filtered;
            row["rdbmagyar"] = client.IsHungarian;

        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.Rows.Count > 0) confirmDeletion();
        }

        private void confirmDeletion()
        {
            DataRow row = selectedRow();

            if (checkBoxConfirmDeletion.Checked)
            {
                DialogResult dialogResult = MessageBox.Show($"Biztos hogy törölni szeretnéd a {row["rendszam"]} rendszámú ügyfelet?\n" +
                                                            $"A rendszámhoz tartozó munkapalok is törölve lesznek.",
                                                             "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    deleteRecord(row);
                }
            }
            else
            {
                deleteRecord(row);
            }

            //dataGridViewClients.Select();
        }

        // Deletes a record in the datbase
        private void deleteRecord(DataRow row)
        {
            Client client = setClient(row);

            try
            {
                //Delete the Product from the database
                int rowsAffected = ClientValidation.DeleteClient(client);

                //If the delete was succesful, remove the product from the list
                if (rowsAffected > 0)
                {
                    clientVM.DtClients.Rows.Remove(row);

                    //int index = dataGridViewClients.CurrentRow.Index;
                    //if (index > 0)
                    //{
                    //    dataGridViewClients.CurrentCell = dataGridViewClients["rendszam", index - 1];
                    //}

                    int rowsAffectedWorkSheet = WorkSheetValidation.DeleteWorkSheet(client);

                    numberOfRows();
                }
                else
                {
                    DisplayError($"Ez a rendszám ({row["rendszam"]}) már törölve lett korábban az adatbázisból.", "Processing Error");
                }
            }

            catch (SqlException ex)
            {
                DisplayError(ex.Message, "DB Error");
            }

            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void DisplayError(string message, string header)
        {
            MessageBox.Show(message,
                            header,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void buttonNewWorksheet_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.Rows.Count > 0) showWorkSheetDialog(sender);
        }
        private void buttonEditWorksheet_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.Rows.Count > 0) showWorkSheetDialog(sender);
        }

        private void showWorkSheetDialog(object sender)
        {
            Client client;
            WorkSheetViewModel workSheetVM;
            bool isNew = false;

            client = setClient(selectedRow());

            if (sender == buttonNewWorksheet)
            {
                workSheetVM = new WorkSheetViewModel();

                workSheetVM.DisplayWorkSheet = new WorkSheet
                {
                    PlateNumber = client.PlateNumber,
                    ClientName = client.ClientName,
                    Phone1 = client.Phone1,
                    Discount = client.Discount,
                    Multiplier = WorkSheetViewModel.DEFAULT_MULTIPLIER,
                    EmailAddress = client.EmailAddress,
                    CarManufacturer = client.CarManufacturer,
                    CarType = client.CarType,
                    InspectionDate = client.InspectionDate,
                    CreateDate = DateTime.Today,
                    NetHourFee = rates.Wage,
                    Tax = rates.Tax,
                    Parts = new PartsList(),
                    WorkFees = new WorkFeeList()
                };
                workSheetVM.PartViewModel();
                workSheetVM.WorkFeeViewModel();

                isNew = true;
            }
            else
            {
                workSheetVM = new WorkSheetViewModel(client.PlateNumber);
            }

            if (isNew || (!isNew && workSheetVM.DisplayWorkSheet.ID != 0))
            {
                using (WorkSheets dlg = new WorkSheets(ref workSheetVM, isNew))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (Message popUp = new Message())
                        {
                            popUp.ShowDialog();
                        }

                    }
                }
            }
            else
            {
                DisplayError(String.Format("{0} rendszámhoz még nem készült munkalap.", client.PlateNumber), "Processing Error");
            }
        }

        //private async void waitSomeTime(Form popUp)
        //{
        //    //await Task.Delay(3000);
        //    //popUp.Close();
        //}

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            ExcelSheets.createExcelDocuments("FilterTechnicalExamination", dataGridViewClients);

        }

        private void checkBoxFilterTechnicalExamination_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterTechnicalExamination.Checked)
            {
                buttonPrint.Enabled = true;
            }
            else
            {
                buttonPrint.Enabled = false;
            }

            filterTable();
        }

        private void dateTimePickerTechnicalExamination_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterTechnicalExamination.Checked)
            {
                filterTable();
            }
        }

        private void numberOfRows()
        {
            labelRowsCount.Text = dataGridViewClients.Rows.Count.ToString();
        }
    }
}


