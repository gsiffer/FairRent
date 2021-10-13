using FairRent.Business;
using FairRent.Common;
using FairRent.Data;
using FairRent.ExcelDocuments;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace FairRent
{
    partial class WorkSheets : Form
    {
        private readonly WorkSheetViewModel workSheetVM;
        private readonly bool isNew;
        private readonly int countWorkSheets;
        private int counter;
        private int rowIndex;
        private bool isModification = false;

        //private bool firstOpened = true;
        private bool workSheetSaved;

        private const int MAX_ROW_NUMBER = 25;
        public WorkSheets(ref WorkSheetViewModel workSheetVM, bool isNew)
        {
            InitializeComponent();
            this.workSheetVM = workSheetVM;
            this.isNew = isNew;
            countWorkSheets = workSheetVM.WorkSheets.Count;
            counter = 0;
        }

        private void WorkSheets_Load(object sender, EventArgs e)
        {
            this.Text = isNew ? "Új munkalap" : "Munkalap módosítása";
            labelWorkSheetCount.Text = ($"{countWorkSheets} / {countWorkSheets}");

            errorProviderAddPartAndWorkFee.SetIconPadding(this.buttonAdd, -18);
            errorProviderModifyPartAndWorkFee.SetIconPadding(this.buttonModify, -18);
            errorProviderWorkSheet.SetIconPadding(this.buttonSave, -20);

            this.Size = new Size(1120, 670);

            labelCoverPrompt.Text = "";

            //textBoxNotes.Select();

            try
            {
                displayPartRow();
                //setupControls();
                setupDataGridViewParts();
                setupDataGridViewWorkFees();
                setBtnBackNext();
                setBindings();
                workSheetIsSaved();
            }
            catch (SqlException ex)
            {
                DisplayError(ex.Message, "DB Error");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }

            textBoxNotes.Select();
        }

        private void setupControls()
        {
            //textBoxMultiplier.Text = "1";
            //buttonModify.Enabled = false;
            //buttonDelete.Enabled = false;
        }

        private void setBindings()
        {
            // Worksheet main information

            textBoxPlateNumber.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.PlateNumber");
            textBoxClientName.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.ClientName");
            textBoxPhone1.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.Phone1");
            textBoxDiscount.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.Discount");
            textBoxEmailAddress.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.EmailAddress");
            textBoxCarManufacturer.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.CarManufacturer");
            textBoxCarType.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.CarType");
            textBoxMultiplier.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.Multiplier",
                                                true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxInspectionDate.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.InspectionDate",
                                                    true, DataSourceUpdateMode.OnValidation, "", "yyyy-MM-dd");
            textBoxOdometer.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.Odometer",
                                             true, DataSourceUpdateMode.OnValidation);
            dateTimePickerCreateDate.DataBindings.Add("Value", workSheetVM, "DisplayWorkSheet.CreateDate",
                                                      true, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxIsActive.DataBindings.Add("Checked", workSheetVM, "DisplayWorkSheet.IsActive");
            textBoxNotes.DataBindings.Add("Text", workSheetVM, "DisplayWorkSheet.Notes");

            // Parts informations

            textBoxPartName.DataBindings.Add("Text", workSheetVM, "DisplayPart.PartName");
            textBoxPieces.DataBindings.Add("Text", workSheetVM, "DisplayPart.Pieces");
            textBoxNetPrice.DataBindings.Add("Text", workSheetVM, "DisplayPart.NetPrice",
                                             true, DataSourceUpdateMode.OnPropertyChanged,
                                             "0", "#,##0;(#,##0);0");

            textBoxGrossTotal.DataBindings.Add("Text", workSheetVM, "DisplayPart.GrossTotal",
                                                true, DataSourceUpdateMode.OnPropertyChanged,
                                                "0", "#,##0;(#,##0);0");

            textBoxPartDiscount.DataBindings.Add("Text", workSheetVM, "DisplayPart.PartDiscount");

            textBoxPartTotal.DataBindings.Add("Text", workSheetVM, "DisplayPart.PartTotal",
                                               true, DataSourceUpdateMode.OnPropertyChanged,
                                               "0", "#,##0;(#,##0);0");

            //textBoxMultiplier.DataBindings.Add("Text", workSheetVM, "DisplayPart.Multiplier");

            // Work fee informations

            textBoxWorkName.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.WorkName");
            textBoxWorkHour.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.WorkHour",
                                             true, DataSourceUpdateMode.OnPropertyChanged,
                                             "0.00", "0.00");
            textBoxNetHourFee.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.NetHourFee",
                                               true, DataSourceUpdateMode.OnPropertyChanged,
                                               "0", "#,##0;(#,##0);0");
            textBoxNetTotalFee.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.NetTotalFee",
                                                true, DataSourceUpdateMode.OnPropertyChanged,
                                                "0", "#,##0;(#,##0);0");
            textBoxWorkDiscount.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.WorkDiscount");
            textBoxWorkTotal.DataBindings.Add("Text", workSheetVM, "DisplayWorkFee.WorkTotal",
                                              true, DataSourceUpdateMode.OnPropertyChanged,
                                              "0", "#,##0;(#,##0);0");

            //checkBoxIsContractor.DataBindings.Add("Checked", workSheetVM, "DisplayWorkFee.IsContractor",
            //                                      true, DataSourceUpdateMode.OnPropertyChanged);

            // Common 

            labelPartsTotal.DataBindings.Add("Text", workSheetVM, "TotalParts",
                                            true, DataSourceUpdateMode.OnValidation,
                                            "0 Ft", "#,##0 Ft;(#,##0 Ft);0 Ft");

            labelWorkTotal.DataBindings.Add("Text", workSheetVM, "WorkTotal",
                                            true, DataSourceUpdateMode.OnValidation,
                                            "0 Ft", "#,##0 Ft;(#,##0 Ft);0 Ft");

            labelTotal.DataBindings.Add("Text", workSheetVM, "Total",
                                            true, DataSourceUpdateMode.OnValidation,
                                            "0 Ft", "#,##0 Ft;(#,##0 Ft);0 Ft");

            dataGridViewParts.DataSource = workSheetVM.PartsSource;
            dataGridViewWorkFees.DataSource = workSheetVM.WorkFeesSource;
        }

        private void setupDataGridViewParts()
        {
            // configure for readonly 
            dataGridViewParts.AutoGenerateColumns = false;
            dataGridViewParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewParts.MultiSelect = false;
            dataGridViewParts.AllowUserToAddRows = false;
            dataGridViewParts.AllowUserToDeleteRows = false;
            dataGridViewParts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewParts.AllowUserToOrderColumns = false;
            dataGridViewParts.AllowUserToResizeColumns = true;
            dataGridViewParts.AllowUserToResizeRows = false;
            dataGridViewParts.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            // add columns
            DataGridViewTextBoxColumn partID = new DataGridViewTextBoxColumn();
            partID.Name = "partID";
            partID.DataPropertyName = "PartID";
            partID.HeaderText = "Sorsz";
            partID.Width = 40;
            partID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partID.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(partID);

            DataGridViewTextBoxColumn partName = new DataGridViewTextBoxColumn();
            partName.Name = "partName";
            partName.DataPropertyName = "PartName";
            partName.HeaderText = "Megnevezés";
            partName.Width = 360;
            partName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(partName);

            DataGridViewTextBoxColumn pieces = new DataGridViewTextBoxColumn();
            pieces.Name = "pieces";
            pieces.DataPropertyName = "Pieces";
            pieces.HeaderText = "Darab/L";
            pieces.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pieces.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            pieces.Width = 100;
            pieces.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(pieces);

            DataGridViewTextBoxColumn netPrice = new DataGridViewTextBoxColumn();
            netPrice.Name = "netPrice";
            netPrice.DataPropertyName = "NetPrice";
            netPrice.HeaderText = "Lista ár";
            netPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            netPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            netPrice.DefaultCellStyle.Format = "#,##0";
            netPrice.Width = 130;
            netPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(netPrice);

            DataGridViewTextBoxColumn grossTotal = new DataGridViewTextBoxColumn();
            grossTotal.Name = "grossTotal";
            grossTotal.DataPropertyName = "GrossTotal";
            grossTotal.HeaderText = "Alkatrész ár össz.";
            grossTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grossTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grossTotal.DefaultCellStyle.Format = "#,##0";
            grossTotal.Width = 130;
            grossTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(grossTotal);

            DataGridViewTextBoxColumn partDiscount = new DataGridViewTextBoxColumn();
            partDiscount.Name = "partDiscount";
            partDiscount.DataPropertyName = "PartDiscount";
            partDiscount.HeaderText = "Kedvezmény(%)";
            partDiscount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partDiscount.Width = 100;
            partDiscount.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(partDiscount);

            DataGridViewTextBoxColumn partTotal = new DataGridViewTextBoxColumn();
            partTotal.Name = "partTotal";
            partTotal.DataPropertyName = "PartTotal";
            partTotal.HeaderText = "Fizetendő ár (Ft)";
            partTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            partTotal.DefaultCellStyle.Format = "#,##0";
            partTotal.Width = 140;
            partTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewParts.Columns.Add(partTotal);
        }

        private void setupDataGridViewWorkFees()
        {
            // configure for readonly 
            dataGridViewWorkFees.AutoGenerateColumns = false;
            dataGridViewWorkFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewWorkFees.MultiSelect = false;
            dataGridViewWorkFees.AllowUserToAddRows = false;
            dataGridViewWorkFees.AllowUserToDeleteRows = false;
            dataGridViewWorkFees.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewWorkFees.AllowUserToOrderColumns = false;
            dataGridViewWorkFees.AllowUserToResizeColumns = true;
            dataGridViewWorkFees.AllowUserToResizeRows = false;
            dataGridViewWorkFees.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            // add columns
            DataGridViewTextBoxColumn workID = new DataGridViewTextBoxColumn();
            workID.Name = "workID";
            workID.DataPropertyName = "WorkID";
            workID.HeaderText = "Sorsz";
            workID.Width = 40;
            workID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workID.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(workID);

            DataGridViewTextBoxColumn workName = new DataGridViewTextBoxColumn();
            workName.Name = "workName";
            workName.DataPropertyName = "WorkName";
            workName.HeaderText = "Elvégzett munka";
            workName.Width = 360;
            workName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(workName);

            DataGridViewTextBoxColumn workHour = new DataGridViewTextBoxColumn();
            workHour.Name = "workHour";
            workHour.DataPropertyName = "WorkHour";
            workHour.HeaderText = "Munkaóra";
            workHour.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workHour.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            workHour.DefaultCellStyle.Format = "N2";
            workHour.Width = 90;
            workHour.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(workHour);

            DataGridViewTextBoxColumn netHourFee = new DataGridViewTextBoxColumn();
            netHourFee.Name = "netHourFee";
            netHourFee.DataPropertyName = "NetHourFee";
            netHourFee.HeaderText = "Nettó óradíj";
            netHourFee.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            netHourFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            netHourFee.DefaultCellStyle.Format = "#,##0";
            netHourFee.Width = 120;
            netHourFee.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(netHourFee);

            DataGridViewTextBoxColumn netTotalFee = new DataGridViewTextBoxColumn();
            netTotalFee.Name = "netTotalFee";
            netTotalFee.DataPropertyName = "NetTotalFee";
            netTotalFee.HeaderText = "Nettó munkadíj";
            netTotalFee.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            netTotalFee.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            netTotalFee.DefaultCellStyle.Format = "#,##0";
            netTotalFee.Width = 130;
            netTotalFee.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(netTotalFee);

            DataGridViewTextBoxColumn workDiscount = new DataGridViewTextBoxColumn();
            workDiscount.Name = "workDiscount";
            workDiscount.DataPropertyName = "WorkDiscount";
            workDiscount.HeaderText = "Kedvezmény(%)";
            workDiscount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workDiscount.Width = 100;
            workDiscount.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(workDiscount);

            DataGridViewTextBoxColumn workTotal = new DataGridViewTextBoxColumn();
            workTotal.Name = "workTotal";
            workTotal.DataPropertyName = "WorkTotal";
            workTotal.HeaderText = "Nettó munkadíj össz.";
            workTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            workTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            workTotal.DefaultCellStyle.Format = "#,##0";
            workTotal.Width = 140;
            workTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(workTotal);

            DataGridViewCheckBoxColumn isContractor = new DataGridViewCheckBoxColumn();
            isContractor.Name = "isContractor";
            isContractor.DataPropertyName = "IsContractor";
            isContractor.HeaderText = "Alv.";
            isContractor.Width = 40;
            isContractor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            isContractor.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewWorkFees.Columns.Add(isContractor);
        }

        private void setBtnBackNext()
        {
            if (!isNew)
            {
                if (countWorkSheets > 1)
                {
                    buttonBack.Enabled = true;
                    buttonNext.Enabled = true;
                    buttonBackFast.Enabled = true;
                    buttonNextForward.Enabled = true;
                    labelWorkSheetCount.Visible = true;
                }
            }
            else
            {
                buttonBack.Visible = false;
                buttonNext.Visible = false;
                buttonBackFast.Visible = false;
                buttonNextForward.Visible = false;
                labelWorkSheetCount.Visible = false;
            }
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
                errorProviderWorkSheet.SetError(buttonSave, message);
            }

        }

        private void buttonBack_Click(object sender, EventArgs e) // button next and back and fast forwards
        {
            if (workSheetSaved)
            {
                if (sender == buttonNext)
                {
                    if (counter != 0)
                    {
                        workSheetVM.DisplayWorkSheet = workSheetVM.WorkSheets[--counter];
                        nextWorkSheet();
                    }
                }
                else if (sender == buttonNextForward)
                {
                    counter = 0;
                    workSheetVM.DisplayWorkSheet = workSheetVM.WorkSheets[counter];
                    nextWorkSheet();
                }
                else if (sender == buttonBack)
                {
                    if (countWorkSheets - 1 > counter)
                    {
                        workSheetVM.DisplayWorkSheet = workSheetVM.WorkSheets[++counter];
                        nextWorkSheet();
                    }
                }
                else
                {
                    counter = countWorkSheets - 1;
                    workSheetVM.DisplayWorkSheet = workSheetVM.WorkSheets[counter];
                    nextWorkSheet();
                }

                workSheetIsSaved(true);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("A módosításokat előbb el kell menteni!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nextWorkSheet()
        {
            labelWorkSheetCount.Text = ($"{countWorkSheets} / {countWorkSheets - counter}");

            try
            {
                workSheetVM.PartViewModel();
                dataGridViewParts.DataSource = workSheetVM.PartsSource;
                workSheetVM.WorkFeeViewModel();
                dataGridViewWorkFees.DataSource = workSheetVM.WorkFeesSource;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                addPart();
            }
            else
            {
                addWorkFee();
            }

        }

        private void addPart()
        {
            try
            {
                Part newPart = workSheetVM.DisplayPart;

                if (PartValidation.AddPart(newPart))
                {
                    addNewPart(newPart);
                }
                else
                {
                    string errorMessage = PartValidation.ErrorMessage;
                    errorProviderAddPartAndWorkFee.SetError(buttonAdd, errorMessage);
                    cellSelectionPart(errorMessage);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void addNewPart(Part newPart)
        {
            if (workSheetVM.PartsSource.Count < MAX_ROW_NUMBER)
            {
                newPart.PartID = workSheetVM.PartsSource.Count + 1;
                workSheetVM.PartsSource.Add(newPart);

                defaultPartControlSetting();
                workSheetIsNotSaved();
                //defaultPart();
                //errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
                //textBoxPartName.Select();
            }
            else
            {
                errorProviderAddPartAndWorkFee.SetError(buttonAdd, String.Format("Maximum {0} sort lehet hozzáadni az alkatrészekhez", MAX_ROW_NUMBER));
            }
        }

        private void defaultPart()
        {
            Part part = new Part
            {
                Multiplier = workSheetVM.DisplayWorkSheet.Multiplier,
                PartDiscount = workSheetVM.DisplayWorkSheet.Discount,
                Tax = workSheetVM.DisplayWorkSheet.Tax
            };

            workSheetVM.DisplayPart = part;
        }

        private void cellSelectionPart(string errorMessage)
        {
            string firstWordInMessage = errorMessage.Substring(0, errorMessage.IndexOf(" "));

            switch (firstWordInMessage)
            {
                case "Megnevezés":
                    textBoxPartName.Select();
                    break;
                case "Darbszám":
                    textBoxPieces.Select();
                    break;
                case "Lista":
                    textBoxNetPrice.Select();
                    break;
                case "Kedvezmény":
                    textBoxPartDiscount.Select();
                    break;
                default:
                    break;
            }
        }

        private void labelDisplayMultiplierPrompt_Click(object sender, EventArgs e)
        {
            if (labelCoverPrompt.Visible)
            {
                labelCoverPrompt.Visible = false;
            }
            else
            {
                labelCoverPrompt.Visible = true;
            }
        }

        private void dataGridViewParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectPart();
            changeButtonsEnabled();
        }

        private void dataGridViewParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridViewParts.Rows.Count > 0)
                {
                    selectPart();
                    changeButtonsEnabled();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void selectPart()
        {
            Part part;

            rowIndex = dataGridViewParts.CurrentRow.Index;
            part = (Part)workSheetVM.PartsSource[rowIndex];
            workSheetVM.DisplayPart = part;

            textBoxPartName.Select();
            errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
            errorProviderModifyPartAndWorkFee.SetError(buttonModify, "");
        }

        private void changeButtonsEnabled(bool isModified = false)
        {
            if (!isModified)
            {
                buttonAdd.Enabled = false;
                buttonModify.Enabled = true;
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
                buttonModify.Enabled = false;
                buttonDelete.Enabled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                defaultPartControlSetting();
            }
            else
            {
                defaultWorkFeeControlSetting();
            }
        }

        private void defaultPartControlSetting(bool isNavigationButtonClicked = false)
        {
            defaultPart();
            changeButtonsEnabled(true);
            errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
            errorProviderModifyPartAndWorkFee.SetError(buttonModify, "");
            if (!isNavigationButtonClicked) textBoxPartName.Select(); // if a user is navigating between worksheets PatrName text box won't be selected every time when cliks on the button
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                modifyPart();
            }
            else
            {
                modifyWorkFee();
            }
        }

        private void modifyPart()
        {
            try
            {
                Part modifiedPart = workSheetVM.DisplayPart;

                if (PartValidation.AddPart(modifiedPart))
                {
                    workSheetVM.PartsSource[rowIndex] = modifiedPart;
                    defaultPartControlSetting();
                    workSheetIsNotSaved();
                }
                else
                {
                    string errorMessage = PartValidation.ErrorMessage;
                    errorProviderModifyPartAndWorkFee.SetError(buttonModify, errorMessage);
                    cellSelectionPart(errorMessage);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                if (dataGridViewParts.Rows.Count > 0)
                {
                    deletePart();
                    workSheetIsNotSaved();
                }
            }
            else
            {
                if (dataGridViewWorkFees.Rows.Count > 0)
                {
                    deleteWorkFee();
                    workSheetIsNotSaved();
                }
            }
        }

        private void deletePart()
        {
            int count = 0;
            int rowIndex;
            Part part;

            try
            {
                rowIndex = dataGridViewParts.CurrentRow.Index;
                part = (Part)workSheetVM.PartsSource[rowIndex];
                workSheetVM.PartsSource.Remove(part);

                foreach (Part _part in workSheetVM.PartsSource)
                {
                    _part.PartID = ++count;
                }

                defaultPartControlSetting();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void tabControlWorkSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                defaultWorkFeeControlSetting();
                displayPartRow();
                textBoxPartName.Select();
            }
            else
            {
                defaultPartControlSetting();
                displayWorkFeeRow();
                textBoxWorkName.Select();
            }
        }

        private void displayPartRow()
        {
            labelPartNamePrompt.Visible = true;
            textBoxPartName.Visible = true;
            labelPiecesPrompt.Visible = true;
            textBoxPieces.Visible = true;
            labelPricePrompt.Visible = true;
            textBoxNetPrice.Visible = true;
            labelGrossTotalPrompt.Visible = true;
            textBoxGrossTotal.Visible = true;
            labelDiscount.Visible = true;
            textBoxPartDiscount.Visible = true;
            labelPartTotalPrompt.Visible = true;
            textBoxPartTotal.Visible = true;
            labelDisplayMultiplierPrompt.Visible = true;

            labelWorkNamePrompt.Visible = false;
            textBoxWorkName.Visible = false;
            labelWorkHourPrompt.Visible = false;
            textBoxWorkHour.Visible = false;
            labelNetHourFeePrompt.Visible = false;
            textBoxNetHourFee.Visible = false;
            labelNetTotalFeePrompt.Visible = false;
            textBoxNetTotalFee.Visible = false;
            labelWorkDiscountPrompt.Visible = false;
            textBoxWorkDiscount.Visible = false;
            labelWorkTotalPrompt.Visible = false;
            textBoxWorkTotal.Visible = false;
            checkBoxIsContractor.Visible = false;
        }

        private void displayWorkFeeRow()
        {
            labelPartNamePrompt.Visible = false;
            textBoxPartName.Visible = false;
            labelPiecesPrompt.Visible = false;
            textBoxPieces.Visible = false;
            labelPricePrompt.Visible = false;
            textBoxNetPrice.Visible = false;
            labelGrossTotalPrompt.Visible = false;
            textBoxGrossTotal.Visible = false;
            labelDiscount.Visible = false;
            textBoxPartDiscount.Visible = false;
            labelPartTotalPrompt.Visible = false;
            textBoxPartTotal.Visible = false;
            labelDisplayMultiplierPrompt.Visible = false;
            textBoxMultiplier.Visible = false;

            labelWorkNamePrompt.Visible = true;
            textBoxWorkName.Visible = true;
            labelWorkHourPrompt.Visible = true;
            textBoxWorkHour.Visible = true;
            labelNetHourFeePrompt.Visible = true;
            textBoxNetHourFee.Visible = true;
            labelNetTotalFeePrompt.Visible = true;
            textBoxNetTotalFee.Visible = true;
            labelWorkDiscountPrompt.Visible = true;
            textBoxWorkDiscount.Visible = true;
            labelWorkTotalPrompt.Visible = true;
            textBoxWorkTotal.Visible = true;
            checkBoxIsContractor.Visible = true;
        }

        private void textBoxPieces_Leave(object sender, EventArgs e)
        {
            workSheetVM.updatePartsTotals();
        }

        private void textBoxNetPrice_Leave(object sender, EventArgs e)
        {
            workSheetVM.updatePartsTotals();
        }

        private void textBoxPartDiscount_Leave(object sender, EventArgs e)
        {
            workSheetVM.updatePartsTotals();
        }

        private void textBoxMultiplier_Leave(object sender, EventArgs e)
        {

            multiplierChanged();
            workSheetVM.updatePartsTotals();
        }

        private void multiplierChanged()
        {
            decimal multiplier = workSheetVM.DisplayWorkSheet.Multiplier;

            workSheetVM.DisplayPart.Multiplier = multiplier;

            foreach (Part part in workSheetVM.PartsSource)
            {
                part.Multiplier = multiplier;
            }

            workSheetVM.PartsSource.ResetBindings(false);
        }

        private void checkBoxIsContractor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsContractor.Checked)
            {
                workSheetVM.DisplayWorkFee = new WorkFee
                {
                    WorkID = isModification ? workSheetVM.DisplayWorkFee.WorkID : default,
                    WorkName = workSheetVM.DisplayWorkFee.WorkName,
                    IsContractor = true
                };

                textBoxWorkHour.ReadOnly = true;
                textBoxWorkHour.TabStop = false;
                //textBoxNetHourFee.ReadOnly = true;
                //textBoxNetHourFee.TabStop = false;
                textBoxWorkDiscount.ReadOnly = true;
                textBoxWorkDiscount.TabStop = false;

                textBoxNetTotalFee.ReadOnly = false;
                textBoxNetTotalFee.TabStop = true;

                textBoxWorkName.Select();
            }
            else
            {
                defaultWorkFee();
                textBoxWorkName.Select();
            }
        }

        private void defaultWorkFee()
        {
            workSheetVM.DisplayWorkFee = new WorkFee
            {
                WorkID = isModification ? workSheetVM.DisplayWorkFee.WorkID : default,
                NetHourFee = workSheetVM.DisplayWorkSheet.NetHourFee,
                WorkDiscount = workSheetVM.DisplayWorkSheet.Discount,
                IsContractor = false
            };

            checkBoxIsContractor.Checked = workSheetVM.DisplayWorkFee.IsContractor;

            textBoxWorkHour.ReadOnly = false;
            textBoxWorkHour.TabStop = true;
            //textBoxNetHourFee.ReadOnly = false;
            //textBoxNetHourFee.TabStop = true;
            textBoxWorkDiscount.ReadOnly = false;
            textBoxWorkDiscount.TabStop = true;

            textBoxNetTotalFee.ReadOnly = true;
            textBoxNetTotalFee.TabStop = false;
        }

        private void textBoxNetTotalFee_Leave(object sender, EventArgs e)
        {
            if (checkBoxIsContractor.Checked)
            {
                workSheetVM.updateWorkFeesTotals();
            }
        }

        private void textBoxWorkHour_Leave(object sender, EventArgs e)
        {
            if (!checkBoxIsContractor.Checked)
            {
                workSheetVM.updateWorkFeesTotals();
            }
        }

        private void textBoxWorkHour_TextChanged(object sender, EventArgs e)
        {
            calculateNetTotalFee();
        }

        private void textBoxNetHourFee_Leave(object sender, EventArgs e)
        {
            if (!checkBoxIsContractor.Checked)
            {
                workSheetVM.updateWorkFeesTotals();
            }
        }

        private void textBoxNetHourFee_TextChanged(object sender, EventArgs e)
        {
            calculateNetTotalFee();
        }

        private void textBoxWorkDiscount_Leave(object sender, EventArgs e)
        {
            workSheetVM.updateWorkFeesTotals();
        }

        private void calculateNetTotalFee()
        {
            workSheetVM.DisplayWorkFee.NetTotalFee = workSheetVM.DisplayWorkFee.WorkHour * workSheetVM.DisplayWorkFee.NetHourFee;
        }

        private void addWorkFee()
        {
            try
            {
                WorkFee newWorkFee = workSheetVM.DisplayWorkFee;

                if (WorkFeeValidation.AddWorkFee(newWorkFee))
                {
                    addNewWorkFee(newWorkFee);
                }
                else
                {
                    string errorMessage = WorkFeeValidation.ErrorMessage;
                    errorProviderAddPartAndWorkFee.SetError(buttonAdd, errorMessage);
                    cellSelectionWorkFee(errorMessage);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void addNewWorkFee(WorkFee newWorkFee)
        {
            if (workSheetVM.WorkFeesSource.Count < MAX_ROW_NUMBER)
            {
                newWorkFee.WorkID = workSheetVM.WorkFeesSource.Count + 1;

                if (newWorkFee.IsContractor)
                {
                    newWorkFee.ContractorFee = newWorkFee.NetTotalFee;
                    workSheetVM.WorkFeesSource.Add(newWorkFee);
                }
                else
                {
                    workSheetVM.WorkFeesSource.Add(newWorkFee);
                }

                defaultWorkFeeControlSetting();
                workSheetIsNotSaved();
                //defaultWorkFee();
                //errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
                //textBoxWorkName.Select();
            }
            else
            {
                errorProviderAddPartAndWorkFee.SetError(buttonAdd, String.Format("Maximum {0} sort lehet hozzáadni a táblázathoz", MAX_ROW_NUMBER));
            }
        }

        private void cellSelectionWorkFee(string errorMessage)
        {
            string firstWordInMessage = errorMessage.Substring(0, errorMessage.IndexOf(" "));

            switch (firstWordInMessage)
            {
                case "Elvégzett":
                    textBoxWorkName.Select();
                    break;
                case "Munkaóra":
                    textBoxWorkHour.Select();
                    break;
                case "Óradíj":
                    textBoxNetHourFee.Select();
                    break;
                case "Alvállalkozói":
                    textBoxNetTotalFee.Select();
                    break;
                case "Kedvezmémy":
                    textBoxWorkDiscount.Select();
                    break;
                default:
                    break;
            }
        }

        private void defaultWorkFeeControlSetting(bool isNavigationButtonClicked = false)
        {
            defaultWorkFee();
            changeButtonsEnabled(true);
            errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
            errorProviderModifyPartAndWorkFee.SetError(buttonModify, "");
            isModification = false;
            if (!isNavigationButtonClicked) textBoxWorkName.Select();
        }

        private void dataGridViewWorkFees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectWorkFee();
            changeButtonsEnabled();
            isModification = true;
        }

        private void dataGridViewWorkFees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridViewWorkFees.Rows.Count > 0)
                {
                    selectWorkFee();
                    changeButtonsEnabled();
                    isModification = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void selectWorkFee()
        {
            WorkFee workFee;

            rowIndex = dataGridViewWorkFees.CurrentRow.Index;
            workFee = (WorkFee)workSheetVM.WorkFeesSource[rowIndex];
            checkBoxIsContractor.Checked = workFee.IsContractor;
            workSheetVM.DisplayWorkFee = workFee;

            textBoxWorkName.Select();
            errorProviderAddPartAndWorkFee.SetError(buttonAdd, "");
            errorProviderModifyPartAndWorkFee.SetError(buttonModify, "");
        }

        private void modifyWorkFee()
        {
            try
            {
                WorkFee modifiedWorkFee = workSheetVM.DisplayWorkFee;

                if (WorkFeeValidation.AddWorkFee(modifiedWorkFee))
                {
                    if (modifiedWorkFee.IsContractor)
                    {
                        modifiedWorkFee.ContractorFee = modifiedWorkFee.NetTotalFee;
                        workSheetVM.WorkFeesSource[rowIndex] = modifiedWorkFee;
                    }
                    else
                    {
                        workSheetVM.WorkFeesSource[rowIndex] = modifiedWorkFee;
                    }

                    defaultWorkFeeControlSetting();
                    workSheetIsNotSaved();
                }
                else
                {
                    string errorMessage = WorkFeeValidation.ErrorMessage;
                    errorProviderModifyPartAndWorkFee.SetError(buttonModify, errorMessage);
                    cellSelectionWorkFee(errorMessage);
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void deleteWorkFee()
        {
            int count = 0;
            int rowIndex;
            WorkFee workFee;

            try
            {
                rowIndex = dataGridViewWorkFees.CurrentRow.Index;
                workFee = (WorkFee)workSheetVM.WorkFeesSource[rowIndex];
                workSheetVM.WorkFeesSource.Remove(workFee);

                foreach (WorkFee _workFee in workSheetVM.WorkFeesSource)
                {
                    _workFee.WorkID = ++count;
                }

                defaultWorkFeeControlSetting();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message, "Processing Error");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            WorkSheet workSheet;
            int rowsAffected;

            try
            {
                workSheet = workSheetVM.DisplayWorkSheet;

                if (isNew)
                {
                    rowsAffected = WorkSheetValidation.AddWorkSheet(workSheet);
                }
                else
                {
                    rowsAffected = WorkSheetValidation.UpdateWorkSheet(workSheet);
                }

                if (validation(rowsAffected))
                {
                    if (isNew)
                    {
                        workSheetSaved = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        workSheetIsSaved();

                        using (Message popUp = new Message())
                        {
                            popUp.ShowDialog();
                        }

                        updateActualWorkSheetHeaderData();
                    }
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
                string errorMessage = WorkSheetValidation.ErrorMessage;
                DisplayError(errorMessage);
                cellSelectionWorkSheet(errorMessage);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        private void cellSelectionWorkSheet(string errorMessage)
        {
            string firstWordInMessage = errorMessage.Substring(0, errorMessage.IndexOf(" "));

            switch (firstWordInMessage)
            {
                case "Km":
                    textBoxOdometer.Select();
                    break;
                case "Megrendelt":
                    textBoxNotes.Select();
                    break;
                default:
                    break;
            }
        }

        private void WorkSheets_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!workSheetSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Biztos hogy ki akarsz lépni a változások mentése nélkül?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void textBoxNotes_TextChanged(object sender, EventArgs e)
        {
            workSheetIsNotSaved();
        }

        private void textBoxMultiplier_TextChanged(object sender, EventArgs e)
        {
            workSheetIsNotSaved();
        }

        private void textBoxOdometer_TextChanged(object sender, EventArgs e)
        {
            workSheetIsNotSaved();
        }

        private void dateTimePickerCreateDate_ValueChanged(object sender, EventArgs e)
        {
            workSheetIsNotSaved();
        }

        private void checkBoxIsActive_CheckedChanged(object sender, EventArgs e)
        {
            workSheetIsNotSaved();
        }

        private void workSheetIsNotSaved()
        {
            workSheetSaved = false;
            buttonSave.Enabled = true;
            buttonPrintHistory.Enabled = false;
        }

        private void workSheetIsSaved(bool isNavigationButtonClicked = false)
        {
            workSheetSaved = true;
            buttonSave.Enabled = false;
            buttonPrintHistory.Enabled = true;

            errorProviderWorkSheet.SetError(buttonSave, "");

            if (tabControlWorkSheet.SelectedIndex == 0)
            {
                defaultPartControlSetting(isNavigationButtonClicked);
            }
            else
            {
                defaultWorkFeeControlSetting(isNavigationButtonClicked);
            }
        }

        private void updateActualWorkSheetHeaderData()
        {
            workSheetVM.WorkSheets[counter].Notes = workSheetVM.DisplayWorkSheet.Notes;
            workSheetVM.WorkSheets[counter].Multiplier = workSheetVM.DisplayWorkSheet.Multiplier;
            workSheetVM.WorkSheets[counter].Odometer = workSheetVM.DisplayWorkSheet.Odometer;
            workSheetVM.WorkSheets[counter].CreateDate = workSheetVM.DisplayWorkSheet.CreateDate;
            workSheetVM.WorkSheets[counter].IsActive = workSheetVM.DisplayWorkSheet.IsActive;
        }

        private void buttonPrintHistory_Click(object sender, EventArgs e)
        {
            ExcelSheets.createExcelDocuments("CarHistory", null, workSheetVM);
        }

    }
}
