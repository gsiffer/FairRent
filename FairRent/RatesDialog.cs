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
    public partial class RatesDialog : Form
    {
        private RatesViewModel ratesVM;
        public RatesDialog()
        {
            InitializeComponent();
        }

        private void SettingDialog_Load(object sender, EventArgs e)
        {
            try
            {
                ratesVM = new RatesViewModel();
                setBindings();
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
            textBoxTax.DataBindings.Add("Text", ratesVM, "DisplayRates.Tax");
            textBoxDiscount.DataBindings.Add("Text", ratesVM, "DisplayRates.Discount");
            textBoxWage.DataBindings.Add("Text", ratesVM, "DisplayRates.Wage",
                                          true, DataSourceUpdateMode.OnValidation,
                                          "0 ", "#,##0");
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Rates rates;
            int rowsAffected;

            try
            {
                rates = ratesVM.DisplayRates;

                rowsAffected = RatesValidation.UpdateRates(rates);

                if (validation(rowsAffected))
                {
                    DialogResult = DialogResult.OK;
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
                DisplayError(RatesValidation.ErrorMessage);
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
                errorProviderRates.SetError(buttonOk, message);
            }
        }
    }
}
