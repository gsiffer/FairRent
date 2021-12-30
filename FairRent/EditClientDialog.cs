using FairRent.Business;
using FairRent.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FairRent
{
    partial class EditClientDialog : Form
    {
        private readonly ClientViewModel clientVM;
        private readonly bool isNew;
        public EditClientDialog(ClientViewModel clientVM, bool isNew)
        {
            InitializeComponent();
            this.clientVM = clientVM;
            this.isNew = isNew;
        }

        private void EditClientDialog_Load(object sender, EventArgs e)
        {
            SetControls();
            setBindings();
        }

        private void setBindings()
        {
            // set car details

            textBoxPlateNumber.DataBindings.Add("Text", clientVM, "DisplayClient.PlateNumber");
            comboBoxCarManufacturer.DataBindings.Add("Text", clientVM, "DisplayClient.CarManufacturer");
            comboBoxCarType.DataBindings.Add("Text", clientVM, "DisplayClient.CarType");
            textBoxCubicCentimetre.DataBindings.Add("Text", clientVM, "DisplayClient.CubicCentimetre",
                                                     true, DataSourceUpdateMode.OnValidation,
                                                     "0 ", "#,##0");

            dateTimePickerInspectionDate.DataBindings.Add("Value", clientVM, "DisplayClient.InspectionDate",
                                                           true, DataSourceUpdateMode.OnPropertyChanged);

            textBoxYear.DataBindings.Add("Text", clientVM, "DisplayClient.Year");
            comboBoxFuel.DataBindings.Add("Text", clientVM, "DisplayClient.Fuel");
            textBoxIdentificationNumber.DataBindings.Add("Text", clientVM, "DisplayClient.IdentificationNumber");
            textBoxEngineNumber.DataBindings.Add("Text", clientVM, "DisplayClient.EngineNumber");
            textBoxKw.DataBindings.Add("Text", clientVM, "DisplayClient.KW",
                                        true, DataSourceUpdateMode.OnValidation,
                                        "0 ", "#,##0");

            checkBoxFiltered.DataBindings.Add("Checked", clientVM, "DisplayClient.Filtered");
            checkBoxIsHungarian.DataBindings.Add("Checked", clientVM, "DisplayClient.IsHungarian");

            // set client details

            textBoxClientName.DataBindings.Add("Text", clientVM, "DisplayClient.ClientName");
            comboBoxPostalCode.DataBindings.Add("Text", clientVM, "DisplayClient.PostalCode");
            comboBoxCity.DataBindings.Add("Text", clientVM, "DisplayClient.City");
            textBoxAddress.DataBindings.Add("Text", clientVM, "DisplayClient.Address");
            textBoxPhone1.DataBindings.Add("Text", clientVM, "DisplayClient.Phone1");
            textBoxPhone2.DataBindings.Add("Text", clientVM, "DisplayClient.Phone2");
            textBoxEmailAddress.DataBindings.Add("Text", clientVM, "DisplayClient.EmailAddress");
            textBoxDiscount.DataBindings.Add("Text", clientVM, "DisplayClient.Discount");

            // set insurance details

            comboBoxInsuranceName.DataBindings.Add("Text", clientVM, "DisplayClient.InsuranceName");
            dateTimePickerInsuranceDate.DataBindings.Add("Value", clientVM, "DisplayClient.InsuranceDate",
                                                          true, DataSourceUpdateMode.OnPropertyChanged);

            textBoxInsuranceFee.DataBindings.Add("Text", clientVM, "DisplayClient.InsuranceFee",
                                                  true, DataSourceUpdateMode.OnValidation,
                                                  "0.00 ", "#,##0.00");

            comboBoxCascoName.DataBindings.Add("Text", clientVM, "DisplayClient.CascoName");
            textBoxCascoType.DataBindings.Add("Text", clientVM, "DisplayClient.CascoType");
            textBoxCascoDeduction.DataBindings.Add("Text", clientVM, "DisplayClient.CascoDeduction");
        }

        private void SetControls()
        {
            comboBoxCarManufacturer.DataSource = GetNoDuplicates("gyartmany").ToList();
            comboBoxCarManufacturer.SelectedIndex = -1;

            comboBoxCarType.DataSource = GetNoDuplicates("tipus").ToList();
            comboBoxCarType.SelectedIndex = -1;

            comboBoxFuel.DataSource = GetNoDuplicates("uzemanyag").ToList();
            comboBoxFuel.SelectedIndex = -1;

            comboBoxPostalCode.DataSource = GetNoDuplicates("iranyitosz").ToList();
            comboBoxPostalCode.SelectedIndex = -1;

            comboBoxCity.DataSource = GetNoDuplicates("varos").ToList();
            comboBoxCity.SelectedIndex = -1;

            comboBoxInsuranceName.DataSource = GetNoDuplicates("kotelezoneve").ToList();
            comboBoxInsuranceName.SelectedIndex = -1;

            comboBoxCascoName.DataSource = GetNoDuplicates("casconeve").ToList();
            comboBoxCascoName.SelectedIndex = -1;

            if (isNew)
            {
                this.Text = string.Format("{0} {1}", "New", this.Text);
                textBoxPlateNumber.Select();
            }
            else
            {
                this.Text = string.Format("{0} {1}", "Modify", this.Text);
                textBoxPlateNumber.ReadOnly = true;
                checkBoxIsHungarian.Enabled = false;
                comboBoxCarManufacturer.Select();
                textBoxPlateNumber.TabStop = false;
            }
        }

        private IEnumerable<string> GetNoDuplicates(string columnName)
        {
            StringList list = new StringList();
            foreach (DataRow row in clientVM.DtClients.Rows)
            {
                list.Add(row[columnName] as string);
            }
            return list.GetNoDuplicates();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Client client;
            int rowsAffected;

            try
            {
                client = clientVM.DisplayClient;

                if (isNew)
                {
                    rowsAffected = ClientValidation.AddClient(client);
                }
                else
                {
                    rowsAffected = ClientValidation.UpdateClient(client);
                }

                if (validation(rowsAffected))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    CellSelection();
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

        private bool validation(int rowsAffected)
        {
            bool valid = false;

            if (rowsAffected == 0)
            {
                DisplayError("No DB changes were made");
            }
            else if (rowsAffected < 0)
            {
                DisplayError(ClientValidation.ErrorMessage);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        private void DisplayError(string message, string header = null)
        {
            if (header != null)
            {
                MessageBox.Show(message,
                                header,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                errorProviderClient.SetError(buttonOk, message);
            }
        }
        // Select the first cell where the value was invalid
        private void CellSelection()
        {
            string errorMessage = ClientValidation.ErrorMessage;
            if (errorMessage == string.Empty) return;
            string firstWordInMessage = errorMessage.Substring(0, errorMessage.IndexOf(" "));

            switch (firstWordInMessage)
            {
                case "Rendszám":
                    tabControlEditClient.SelectTab(tabPageCarDetails);
                    textBoxPlateNumber.Select();
                    break;
                case "Gyártmány":
                    tabControlEditClient.SelectTab(tabPageCarDetails);
                    comboBoxCarManufacturer.Select();
                    break;
                case "Köbcenti":
                    tabControlEditClient.SelectTab(tabPageCarDetails);
                    textBoxCubicCentimetre.Select();
                    break;
                case "Évjárat":
                    tabControlEditClient.SelectTab(tabPageCarDetails);
                    textBoxYear.Select();
                    break;
                case "KW":
                    tabControlEditClient.SelectTab(tabPageCarDetails);
                    textBoxKw.Select();
                    break;
                case "Ügyfél":
                    tabControlEditClient.SelectTab(tabPageClientDetails);
                    textBoxClientName.Select();
                    break;
                case "Irányítószám":
                    tabControlEditClient.SelectTab(tabPageClientDetails);
                    comboBoxPostalCode.Select();
                    break;
                case "Telefonszám1":
                    tabControlEditClient.SelectTab(tabPageClientDetails);
                    textBoxPhone1.Select();
                    break;
                case "Telefonszám2":
                    tabControlEditClient.SelectTab(tabPageClientDetails);
                    textBoxPhone2.Select();
                    break;
                case "Kedvezmény":
                    tabControlEditClient.SelectTab(tabPageClientDetails);
                    textBoxDiscount.Select();
                    break;
                case "Kötelező":
                    tabControlEditClient.SelectTab(tabPageInsurance);
                    textBoxInsuranceFee.Select();
                    break;
                default:
                    break;
            }
        }

        private void tabControlEditClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControlEditClient.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 0:
                    if (textBoxPlateNumber.ReadOnly)
                    {
                        comboBoxCarManufacturer.SelectAll();
                        comboBoxCarManufacturer.Focus();
                    }
                    else
                    {
                        textBoxPlateNumber.SelectAll();
                        textBoxPlateNumber.Focus();
                    }
                    break;
                case 1:
                    textBoxClientName.SelectAll();
                    textBoxClientName.Focus();
                    break;
                case 2:
                    comboBoxInsuranceName.SelectAll();
                    comboBoxInsuranceName.Focus();
                    break;
                default:
                    break;
            }
        }

        private void tabControlEditClient_KeyDown(object sender, KeyEventArgs e)
        {
            int tabIndex = tabControlEditClient.SelectedIndex;

            if (e.KeyCode == Keys.Right)
            {
                if (tabIndex == 0 && !dateTimePickerInspectionDate.Focused)
                {
                    tabControlEditClient.SelectedIndex = 1;
                }

                if (tabIndex == 1)
                {
                    tabControlEditClient.SelectedIndex = 2;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (tabIndex == 2 && !dateTimePickerInsuranceDate.Focused)
                {
                    tabControlEditClient.SelectedIndex = 1;
                }

                if (tabIndex == 1)
                {
                    tabControlEditClient.SelectedIndex = 0;
                }
            }
        }
    }
}
