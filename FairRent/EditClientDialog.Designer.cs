
namespace FairRent
{
    partial class EditClientDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlEditClient = new System.Windows.Forms.TabControl();
            this.tabPageCarDetails = new System.Windows.Forms.TabPage();
            this.checkBoxIsHungarian = new System.Windows.Forms.CheckBox();
            this.checkBoxFiltered = new System.Windows.Forms.CheckBox();
            this.textBoxKw = new System.Windows.Forms.TextBox();
            this.labelKwPrompt = new System.Windows.Forms.Label();
            this.textBoxEngineNumber = new System.Windows.Forms.TextBox();
            this.labelEngineNumberPrompt = new System.Windows.Forms.Label();
            this.textBoxIdentificationNumber = new System.Windows.Forms.TextBox();
            this.labelIdentificationNumberPrompt = new System.Windows.Forms.Label();
            this.comboBoxFuel = new System.Windows.Forms.ComboBox();
            this.labelFuelPrompt = new System.Windows.Forms.Label();
            this.textBoxPlateNumber = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.labelYearPrompt = new System.Windows.Forms.Label();
            this.dateTimePickerInspectionDate = new System.Windows.Forms.DateTimePicker();
            this.labelInspectionDatePrompt = new System.Windows.Forms.Label();
            this.textBoxCubicCentimetre = new System.Windows.Forms.TextBox();
            this.labelCubicCentimetrePrompt = new System.Windows.Forms.Label();
            this.comboBoxCarType = new System.Windows.Forms.ComboBox();
            this.comboBoxCarManufacturer = new System.Windows.Forms.ComboBox();
            this.labelCarTypePrompt = new System.Windows.Forms.Label();
            this.labelCarManufacturerPrompt = new System.Windows.Forms.Label();
            this.labelPlateNumberPrompt = new System.Windows.Forms.Label();
            this.tabPageClientDetails = new System.Windows.Forms.TabPage();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.comboBoxPostalCode = new System.Windows.Forms.ComboBox();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.labelDiscountPrompt = new System.Windows.Forms.Label();
            this.textBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.labelEmailAddressPrompt = new System.Windows.Forms.Label();
            this.textBoxPhone2 = new System.Windows.Forms.TextBox();
            this.labelPhone2Prompt = new System.Windows.Forms.Label();
            this.textBoxPhone1 = new System.Windows.Forms.TextBox();
            this.labelPhone1Prompt = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddressPrompt = new System.Windows.Forms.Label();
            this.labelCityPrompt = new System.Windows.Forms.Label();
            this.labelPostalCodePrompt = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.labelNamePrompt = new System.Windows.Forms.Label();
            this.tabPageInsurance = new System.Windows.Forms.TabPage();
            this.textBoxCascoDeduction = new System.Windows.Forms.TextBox();
            this.labelCascoDeductionPrompt = new System.Windows.Forms.Label();
            this.textBoxCascoType = new System.Windows.Forms.TextBox();
            this.labelCascoTypePrompt = new System.Windows.Forms.Label();
            this.comboBoxCascoName = new System.Windows.Forms.ComboBox();
            this.labelCascoNamePrompt = new System.Windows.Forms.Label();
            this.textBoxInsuranceFee = new System.Windows.Forms.TextBox();
            this.labelInsuranceFeePrompt = new System.Windows.Forms.Label();
            this.comboBoxInsuranceName = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInsuranceDate = new System.Windows.Forms.DateTimePicker();
            this.labelInsuranceDatePrompt = new System.Windows.Forms.Label();
            this.labelInsuranceNamePrompt = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.errorProviderClient = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControlEditClient.SuspendLayout();
            this.tabPageCarDetails.SuspendLayout();
            this.tabPageClientDetails.SuspendLayout();
            this.tabPageInsurance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlEditClient
            // 
            this.tabControlEditClient.Controls.Add(this.tabPageCarDetails);
            this.tabControlEditClient.Controls.Add(this.tabPageClientDetails);
            this.tabControlEditClient.Controls.Add(this.tabPageInsurance);
            this.tabControlEditClient.Location = new System.Drawing.Point(6, 0);
            this.tabControlEditClient.Name = "tabControlEditClient";
            this.tabControlEditClient.SelectedIndex = 0;
            this.tabControlEditClient.Size = new System.Drawing.Size(436, 344);
            this.tabControlEditClient.TabIndex = 0;
            this.tabControlEditClient.SelectedIndexChanged += new System.EventHandler(this.tabControlEditClient_SelectedIndexChanged);
            this.tabControlEditClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControlEditClient_KeyDown);
            // 
            // tabPageCarDetails
            // 
            this.tabPageCarDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCarDetails.Controls.Add(this.checkBoxIsHungarian);
            this.tabPageCarDetails.Controls.Add(this.checkBoxFiltered);
            this.tabPageCarDetails.Controls.Add(this.textBoxKw);
            this.tabPageCarDetails.Controls.Add(this.labelKwPrompt);
            this.tabPageCarDetails.Controls.Add(this.textBoxEngineNumber);
            this.tabPageCarDetails.Controls.Add(this.labelEngineNumberPrompt);
            this.tabPageCarDetails.Controls.Add(this.textBoxIdentificationNumber);
            this.tabPageCarDetails.Controls.Add(this.labelIdentificationNumberPrompt);
            this.tabPageCarDetails.Controls.Add(this.comboBoxFuel);
            this.tabPageCarDetails.Controls.Add(this.labelFuelPrompt);
            this.tabPageCarDetails.Controls.Add(this.textBoxPlateNumber);
            this.tabPageCarDetails.Controls.Add(this.textBoxYear);
            this.tabPageCarDetails.Controls.Add(this.labelYearPrompt);
            this.tabPageCarDetails.Controls.Add(this.dateTimePickerInspectionDate);
            this.tabPageCarDetails.Controls.Add(this.labelInspectionDatePrompt);
            this.tabPageCarDetails.Controls.Add(this.textBoxCubicCentimetre);
            this.tabPageCarDetails.Controls.Add(this.labelCubicCentimetrePrompt);
            this.tabPageCarDetails.Controls.Add(this.comboBoxCarType);
            this.tabPageCarDetails.Controls.Add(this.comboBoxCarManufacturer);
            this.tabPageCarDetails.Controls.Add(this.labelCarTypePrompt);
            this.tabPageCarDetails.Controls.Add(this.labelCarManufacturerPrompt);
            this.tabPageCarDetails.Controls.Add(this.labelPlateNumberPrompt);
            this.tabPageCarDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageCarDetails.Name = "tabPageCarDetails";
            this.tabPageCarDetails.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageCarDetails.Size = new System.Drawing.Size(428, 318);
            this.tabPageCarDetails.TabIndex = 0;
            this.tabPageCarDetails.Text = "Vehicle Data";
            // 
            // checkBoxIsHungarian
            // 
            this.checkBoxIsHungarian.AutoSize = true;
            this.checkBoxIsHungarian.Location = new System.Drawing.Point(225, 18);
            this.checkBoxIsHungarian.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxIsHungarian.Name = "checkBoxIsHungarian";
            this.checkBoxIsHungarian.Size = new System.Drawing.Size(167, 17);
            this.checkBoxIsHungarian.TabIndex = 2;
            this.checkBoxIsHungarian.TabStop = false;
            this.checkBoxIsHungarian.Text = "&Hungarian Plate Nr [AAA-000]";
            this.checkBoxIsHungarian.UseVisualStyleBackColor = true;
            // 
            // checkBoxFiltered
            // 
            this.checkBoxFiltered.AutoSize = true;
            this.checkBoxFiltered.Location = new System.Drawing.Point(100, 281);
            this.checkBoxFiltered.Name = "checkBoxFiltered";
            this.checkBoxFiltered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxFiltered.Size = new System.Drawing.Size(158, 17);
            this.checkBoxFiltered.TabIndex = 21;
            this.checkBoxFiltered.Text = "Filterable to Inspection &Date";
            this.checkBoxFiltered.UseVisualStyleBackColor = true;
            // 
            // textBoxKw
            // 
            this.textBoxKw.Location = new System.Drawing.Point(100, 252);
            this.textBoxKw.MaxLength = 6;
            this.textBoxKw.Name = "textBoxKw";
            this.textBoxKw.Size = new System.Drawing.Size(100, 20);
            this.textBoxKw.TabIndex = 20;
            // 
            // labelKwPrompt
            // 
            this.labelKwPrompt.AutoSize = true;
            this.labelKwPrompt.Location = new System.Drawing.Point(14, 255);
            this.labelKwPrompt.Name = "labelKwPrompt";
            this.labelKwPrompt.Size = new System.Drawing.Size(25, 13);
            this.labelKwPrompt.TabIndex = 19;
            this.labelKwPrompt.Text = "K&w:";
            // 
            // textBoxEngineNumber
            // 
            this.textBoxEngineNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEngineNumber.Location = new System.Drawing.Point(100, 226);
            this.textBoxEngineNumber.MaxLength = 40;
            this.textBoxEngineNumber.Name = "textBoxEngineNumber";
            this.textBoxEngineNumber.Size = new System.Drawing.Size(179, 20);
            this.textBoxEngineNumber.TabIndex = 18;
            // 
            // labelEngineNumberPrompt
            // 
            this.labelEngineNumberPrompt.AutoSize = true;
            this.labelEngineNumberPrompt.Location = new System.Drawing.Point(14, 229);
            this.labelEngineNumberPrompt.Name = "labelEngineNumberPrompt";
            this.labelEngineNumberPrompt.Size = new System.Drawing.Size(83, 13);
            this.labelEngineNumberPrompt.TabIndex = 17;
            this.labelEngineNumberPrompt.Text = "&Engine Number:";
            // 
            // textBoxIdentificationNumber
            // 
            this.textBoxIdentificationNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxIdentificationNumber.Location = new System.Drawing.Point(100, 200);
            this.textBoxIdentificationNumber.MaxLength = 40;
            this.textBoxIdentificationNumber.Name = "textBoxIdentificationNumber";
            this.textBoxIdentificationNumber.Size = new System.Drawing.Size(179, 20);
            this.textBoxIdentificationNumber.TabIndex = 16;
            // 
            // labelIdentificationNumberPrompt
            // 
            this.labelIdentificationNumberPrompt.AutoSize = true;
            this.labelIdentificationNumberPrompt.Location = new System.Drawing.Point(14, 203);
            this.labelIdentificationNumberPrompt.Name = "labelIdentificationNumberPrompt";
            this.labelIdentificationNumberPrompt.Size = new System.Drawing.Size(86, 13);
            this.labelIdentificationNumberPrompt.TabIndex = 15;
            this.labelIdentificationNumberPrompt.Text = "&Chassis Number:";
            // 
            // comboBoxFuel
            // 
            this.comboBoxFuel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxFuel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFuel.FormattingEnabled = true;
            this.comboBoxFuel.Location = new System.Drawing.Point(100, 173);
            this.comboBoxFuel.MaxLength = 30;
            this.comboBoxFuel.Name = "comboBoxFuel";
            this.comboBoxFuel.Size = new System.Drawing.Size(100, 21);
            this.comboBoxFuel.TabIndex = 14;
            // 
            // labelFuelPrompt
            // 
            this.labelFuelPrompt.AutoSize = true;
            this.labelFuelPrompt.Location = new System.Drawing.Point(14, 176);
            this.labelFuelPrompt.Name = "labelFuelPrompt";
            this.labelFuelPrompt.Size = new System.Drawing.Size(57, 13);
            this.labelFuelPrompt.TabIndex = 13;
            this.labelFuelPrompt.Text = "&Fuel Type:";
            // 
            // textBoxPlateNumber
            // 
            this.textBoxPlateNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPlateNumber.Location = new System.Drawing.Point(100, 16);
            this.textBoxPlateNumber.MaxLength = 20;
            this.textBoxPlateNumber.Name = "textBoxPlateNumber";
            this.textBoxPlateNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlateNumber.TabIndex = 1;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(100, 147);
            this.textBoxYear.MaxLength = 4;
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 20);
            this.textBoxYear.TabIndex = 12;
            // 
            // labelYearPrompt
            // 
            this.labelYearPrompt.AutoSize = true;
            this.labelYearPrompt.Location = new System.Drawing.Point(14, 150);
            this.labelYearPrompt.Name = "labelYearPrompt";
            this.labelYearPrompt.Size = new System.Drawing.Size(32, 13);
            this.labelYearPrompt.TabIndex = 11;
            this.labelYearPrompt.Text = "&Year:";
            // 
            // dateTimePickerInspectionDate
            // 
            this.dateTimePickerInspectionDate.CustomFormat = "";
            this.dateTimePickerInspectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerInspectionDate.Location = new System.Drawing.Point(100, 121);
            this.dateTimePickerInspectionDate.Name = "dateTimePickerInspectionDate";
            this.dateTimePickerInspectionDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerInspectionDate.TabIndex = 10;
            this.dateTimePickerInspectionDate.Value = new System.DateTime(2020, 12, 28, 19, 40, 50, 0);
            // 
            // labelInspectionDatePrompt
            // 
            this.labelInspectionDatePrompt.AutoSize = true;
            this.labelInspectionDatePrompt.Location = new System.Drawing.Point(14, 124);
            this.labelInspectionDatePrompt.Name = "labelInspectionDatePrompt";
            this.labelInspectionDatePrompt.Size = new System.Drawing.Size(85, 13);
            this.labelInspectionDatePrompt.TabIndex = 9;
            this.labelInspectionDatePrompt.Text = "&Inspection Date:";
            // 
            // textBoxCubicCentimetre
            // 
            this.textBoxCubicCentimetre.Location = new System.Drawing.Point(100, 95);
            this.textBoxCubicCentimetre.MaxLength = 6;
            this.textBoxCubicCentimetre.Name = "textBoxCubicCentimetre";
            this.textBoxCubicCentimetre.Size = new System.Drawing.Size(100, 20);
            this.textBoxCubicCentimetre.TabIndex = 8;
            // 
            // labelCubicCentimetrePrompt
            // 
            this.labelCubicCentimetrePrompt.AutoSize = true;
            this.labelCubicCentimetrePrompt.Location = new System.Drawing.Point(14, 98);
            this.labelCubicCentimetrePrompt.Name = "labelCubicCentimetrePrompt";
            this.labelCubicCentimetrePrompt.Size = new System.Drawing.Size(30, 13);
            this.labelCubicCentimetrePrompt.TabIndex = 7;
            this.labelCubicCentimetrePrompt.Text = "&cm3:";
            // 
            // comboBoxCarType
            // 
            this.comboBoxCarType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCarType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCarType.FormattingEnabled = true;
            this.comboBoxCarType.Location = new System.Drawing.Point(100, 68);
            this.comboBoxCarType.MaxLength = 60;
            this.comboBoxCarType.Name = "comboBoxCarType";
            this.comboBoxCarType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCarType.TabIndex = 6;
            // 
            // comboBoxCarManufacturer
            // 
            this.comboBoxCarManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCarManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCarManufacturer.FormattingEnabled = true;
            this.comboBoxCarManufacturer.Location = new System.Drawing.Point(100, 42);
            this.comboBoxCarManufacturer.MaxLength = 60;
            this.comboBoxCarManufacturer.Name = "comboBoxCarManufacturer";
            this.comboBoxCarManufacturer.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCarManufacturer.TabIndex = 4;
            // 
            // labelCarTypePrompt
            // 
            this.labelCarTypePrompt.AutoSize = true;
            this.labelCarTypePrompt.Location = new System.Drawing.Point(14, 71);
            this.labelCarTypePrompt.Name = "labelCarTypePrompt";
            this.labelCarTypePrompt.Size = new System.Drawing.Size(39, 13);
            this.labelCarTypePrompt.TabIndex = 5;
            this.labelCarTypePrompt.Text = "M&odel:";
            // 
            // labelCarManufacturerPrompt
            // 
            this.labelCarManufacturerPrompt.AutoSize = true;
            this.labelCarManufacturerPrompt.Location = new System.Drawing.Point(14, 45);
            this.labelCarManufacturerPrompt.Name = "labelCarManufacturerPrompt";
            this.labelCarManufacturerPrompt.Size = new System.Drawing.Size(37, 13);
            this.labelCarManufacturerPrompt.TabIndex = 3;
            this.labelCarManufacturerPrompt.Text = "&Make:";
            // 
            // labelPlateNumberPrompt
            // 
            this.labelPlateNumberPrompt.AutoSize = true;
            this.labelPlateNumberPrompt.Location = new System.Drawing.Point(14, 19);
            this.labelPlateNumberPrompt.Name = "labelPlateNumberPrompt";
            this.labelPlateNumberPrompt.Size = new System.Drawing.Size(48, 13);
            this.labelPlateNumberPrompt.TabIndex = 0;
            this.labelPlateNumberPrompt.Text = "&Plate Nr:";
            // 
            // tabPageClientDetails
            // 
            this.tabPageClientDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageClientDetails.Controls.Add(this.comboBoxCity);
            this.tabPageClientDetails.Controls.Add(this.comboBoxPostalCode);
            this.tabPageClientDetails.Controls.Add(this.textBoxDiscount);
            this.tabPageClientDetails.Controls.Add(this.labelDiscountPrompt);
            this.tabPageClientDetails.Controls.Add(this.textBoxEmailAddress);
            this.tabPageClientDetails.Controls.Add(this.labelEmailAddressPrompt);
            this.tabPageClientDetails.Controls.Add(this.textBoxPhone2);
            this.tabPageClientDetails.Controls.Add(this.labelPhone2Prompt);
            this.tabPageClientDetails.Controls.Add(this.textBoxPhone1);
            this.tabPageClientDetails.Controls.Add(this.labelPhone1Prompt);
            this.tabPageClientDetails.Controls.Add(this.textBoxAddress);
            this.tabPageClientDetails.Controls.Add(this.labelAddressPrompt);
            this.tabPageClientDetails.Controls.Add(this.labelCityPrompt);
            this.tabPageClientDetails.Controls.Add(this.labelPostalCodePrompt);
            this.tabPageClientDetails.Controls.Add(this.textBoxClientName);
            this.tabPageClientDetails.Controls.Add(this.labelNamePrompt);
            this.tabPageClientDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageClientDetails.Name = "tabPageClientDetails";
            this.tabPageClientDetails.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageClientDetails.Size = new System.Drawing.Size(428, 318);
            this.tabPageClientDetails.TabIndex = 1;
            this.tabPageClientDetails.Text = "Customer Data";
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(107, 69);
            this.comboBoxCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCity.MaxLength = 60;
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(110, 21);
            this.comboBoxCity.TabIndex = 5;
            // 
            // comboBoxPostalCode
            // 
            this.comboBoxPostalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPostalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPostalCode.FormattingEnabled = true;
            this.comboBoxPostalCode.Location = new System.Drawing.Point(107, 43);
            this.comboBoxPostalCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPostalCode.MaxLength = 10;
            this.comboBoxPostalCode.Name = "comboBoxPostalCode";
            this.comboBoxPostalCode.Size = new System.Drawing.Size(82, 21);
            this.comboBoxPostalCode.TabIndex = 3;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Location = new System.Drawing.Point(107, 198);
            this.textBoxDiscount.MaxLength = 5;
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(48, 20);
            this.textBoxDiscount.TabIndex = 15;
            // 
            // labelDiscountPrompt
            // 
            this.labelDiscountPrompt.AutoSize = true;
            this.labelDiscountPrompt.Location = new System.Drawing.Point(14, 201);
            this.labelDiscountPrompt.Name = "labelDiscountPrompt";
            this.labelDiscountPrompt.Size = new System.Drawing.Size(69, 13);
            this.labelDiscountPrompt.TabIndex = 14;
            this.labelDiscountPrompt.Text = "&Discount (%):";
            // 
            // textBoxEmailAddress
            // 
            this.textBoxEmailAddress.Location = new System.Drawing.Point(107, 172);
            this.textBoxEmailAddress.MaxLength = 60;
            this.textBoxEmailAddress.Name = "textBoxEmailAddress";
            this.textBoxEmailAddress.Size = new System.Drawing.Size(157, 20);
            this.textBoxEmailAddress.TabIndex = 13;
            // 
            // labelEmailAddressPrompt
            // 
            this.labelEmailAddressPrompt.AutoSize = true;
            this.labelEmailAddressPrompt.Location = new System.Drawing.Point(14, 175);
            this.labelEmailAddressPrompt.Name = "labelEmailAddressPrompt";
            this.labelEmailAddressPrompt.Size = new System.Drawing.Size(76, 13);
            this.labelEmailAddressPrompt.TabIndex = 12;
            this.labelEmailAddressPrompt.Text = "&Email Address:";
            // 
            // textBoxPhone2
            // 
            this.textBoxPhone2.Location = new System.Drawing.Point(107, 146);
            this.textBoxPhone2.MaxLength = 30;
            this.textBoxPhone2.Name = "textBoxPhone2";
            this.textBoxPhone2.Size = new System.Drawing.Size(110, 20);
            this.textBoxPhone2.TabIndex = 11;
            // 
            // labelPhone2Prompt
            // 
            this.labelPhone2Prompt.AutoSize = true;
            this.labelPhone2Prompt.Location = new System.Drawing.Point(14, 149);
            this.labelPhone2Prompt.Name = "labelPhone2Prompt";
            this.labelPhone2Prompt.Size = new System.Drawing.Size(47, 13);
            this.labelPhone2Prompt.TabIndex = 10;
            this.labelPhone2Prompt.Text = "Phone&2:";
            // 
            // textBoxPhone1
            // 
            this.textBoxPhone1.Location = new System.Drawing.Point(107, 120);
            this.textBoxPhone1.MaxLength = 30;
            this.textBoxPhone1.Name = "textBoxPhone1";
            this.textBoxPhone1.Size = new System.Drawing.Size(110, 20);
            this.textBoxPhone1.TabIndex = 9;
            // 
            // labelPhone1Prompt
            // 
            this.labelPhone1Prompt.AutoSize = true;
            this.labelPhone1Prompt.Location = new System.Drawing.Point(14, 123);
            this.labelPhone1Prompt.Name = "labelPhone1Prompt";
            this.labelPhone1Prompt.Size = new System.Drawing.Size(47, 13);
            this.labelPhone1Prompt.TabIndex = 8;
            this.labelPhone1Prompt.Text = "Phone&1:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(107, 94);
            this.textBoxAddress.MaxLength = 60;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(223, 20);
            this.textBoxAddress.TabIndex = 7;
            // 
            // labelAddressPrompt
            // 
            this.labelAddressPrompt.AutoSize = true;
            this.labelAddressPrompt.Location = new System.Drawing.Point(14, 97);
            this.labelAddressPrompt.Name = "labelAddressPrompt";
            this.labelAddressPrompt.Size = new System.Drawing.Size(48, 13);
            this.labelAddressPrompt.TabIndex = 6;
            this.labelAddressPrompt.Text = "&Address:";
            // 
            // labelCityPrompt
            // 
            this.labelCityPrompt.AutoSize = true;
            this.labelCityPrompt.Location = new System.Drawing.Point(14, 71);
            this.labelCityPrompt.Name = "labelCityPrompt";
            this.labelCityPrompt.Size = new System.Drawing.Size(27, 13);
            this.labelCityPrompt.TabIndex = 4;
            this.labelCityPrompt.Text = "&City:";
            // 
            // labelPostalCodePrompt
            // 
            this.labelPostalCodePrompt.AutoSize = true;
            this.labelPostalCodePrompt.Location = new System.Drawing.Point(14, 45);
            this.labelPostalCodePrompt.Name = "labelPostalCodePrompt";
            this.labelPostalCodePrompt.Size = new System.Drawing.Size(67, 13);
            this.labelPostalCodePrompt.TabIndex = 2;
            this.labelPostalCodePrompt.Text = "&Postal Code:";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(107, 16);
            this.textBoxClientName.MaxLength = 60;
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(157, 20);
            this.textBoxClientName.TabIndex = 1;
            // 
            // labelNamePrompt
            // 
            this.labelNamePrompt.AutoSize = true;
            this.labelNamePrompt.Location = new System.Drawing.Point(14, 19);
            this.labelNamePrompt.Name = "labelNamePrompt";
            this.labelNamePrompt.Size = new System.Drawing.Size(38, 13);
            this.labelNamePrompt.TabIndex = 0;
            this.labelNamePrompt.Text = "&Name:";
            // 
            // tabPageInsurance
            // 
            this.tabPageInsurance.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageInsurance.Controls.Add(this.textBoxCascoDeduction);
            this.tabPageInsurance.Controls.Add(this.labelCascoDeductionPrompt);
            this.tabPageInsurance.Controls.Add(this.textBoxCascoType);
            this.tabPageInsurance.Controls.Add(this.labelCascoTypePrompt);
            this.tabPageInsurance.Controls.Add(this.comboBoxCascoName);
            this.tabPageInsurance.Controls.Add(this.labelCascoNamePrompt);
            this.tabPageInsurance.Controls.Add(this.textBoxInsuranceFee);
            this.tabPageInsurance.Controls.Add(this.labelInsuranceFeePrompt);
            this.tabPageInsurance.Controls.Add(this.comboBoxInsuranceName);
            this.tabPageInsurance.Controls.Add(this.dateTimePickerInsuranceDate);
            this.tabPageInsurance.Controls.Add(this.labelInsuranceDatePrompt);
            this.tabPageInsurance.Controls.Add(this.labelInsuranceNamePrompt);
            this.tabPageInsurance.Location = new System.Drawing.Point(4, 22);
            this.tabPageInsurance.Name = "tabPageInsurance";
            this.tabPageInsurance.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageInsurance.Size = new System.Drawing.Size(428, 318);
            this.tabPageInsurance.TabIndex = 2;
            this.tabPageInsurance.Text = "Insurance Data";
            // 
            // textBoxCascoDeduction
            // 
            this.textBoxCascoDeduction.Location = new System.Drawing.Point(144, 165);
            this.textBoxCascoDeduction.MaxLength = 60;
            this.textBoxCascoDeduction.Name = "textBoxCascoDeduction";
            this.textBoxCascoDeduction.Size = new System.Drawing.Size(146, 20);
            this.textBoxCascoDeduction.TabIndex = 11;
            // 
            // labelCascoDeductionPrompt
            // 
            this.labelCascoDeductionPrompt.AutoSize = true;
            this.labelCascoDeductionPrompt.Location = new System.Drawing.Point(14, 168);
            this.labelCascoDeductionPrompt.Name = "labelCascoDeductionPrompt";
            this.labelCascoDeductionPrompt.Size = new System.Drawing.Size(61, 13);
            this.labelCascoDeductionPrompt.TabIndex = 10;
            this.labelCascoDeductionPrompt.Text = "Deductible:";
            // 
            // textBoxCascoType
            // 
            this.textBoxCascoType.Location = new System.Drawing.Point(144, 139);
            this.textBoxCascoType.MaxLength = 60;
            this.textBoxCascoType.Name = "textBoxCascoType";
            this.textBoxCascoType.Size = new System.Drawing.Size(146, 20);
            this.textBoxCascoType.TabIndex = 9;
            // 
            // labelCascoTypePrompt
            // 
            this.labelCascoTypePrompt.AutoSize = true;
            this.labelCascoTypePrompt.Location = new System.Drawing.Point(14, 142);
            this.labelCascoTypePrompt.Name = "labelCascoTypePrompt";
            this.labelCascoTypePrompt.Size = new System.Drawing.Size(126, 13);
            this.labelCascoTypePrompt.TabIndex = 8;
            this.labelCascoTypePrompt.Text = "Optional Insurance Type:";
            // 
            // comboBoxCascoName
            // 
            this.comboBoxCascoName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCascoName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCascoName.FormattingEnabled = true;
            this.comboBoxCascoName.Location = new System.Drawing.Point(144, 112);
            this.comboBoxCascoName.MaxLength = 60;
            this.comboBoxCascoName.Name = "comboBoxCascoName";
            this.comboBoxCascoName.Size = new System.Drawing.Size(146, 21);
            this.comboBoxCascoName.TabIndex = 7;
            // 
            // labelCascoNamePrompt
            // 
            this.labelCascoNamePrompt.AutoSize = true;
            this.labelCascoNamePrompt.Location = new System.Drawing.Point(14, 116);
            this.labelCascoNamePrompt.Name = "labelCascoNamePrompt";
            this.labelCascoNamePrompt.Size = new System.Drawing.Size(99, 13);
            this.labelCascoNamePrompt.TabIndex = 6;
            this.labelCascoNamePrompt.Text = "Optional Insurance:";
            // 
            // textBoxInsuranceFee
            // 
            this.textBoxInsuranceFee.Location = new System.Drawing.Point(144, 69);
            this.textBoxInsuranceFee.MaxLength = 10;
            this.textBoxInsuranceFee.Name = "textBoxInsuranceFee";
            this.textBoxInsuranceFee.Size = new System.Drawing.Size(146, 20);
            this.textBoxInsuranceFee.TabIndex = 5;
            // 
            // labelInsuranceFeePrompt
            // 
            this.labelInsuranceFeePrompt.AutoSize = true;
            this.labelInsuranceFeePrompt.Location = new System.Drawing.Point(14, 72);
            this.labelInsuranceFeePrompt.Name = "labelInsuranceFeePrompt";
            this.labelInsuranceFeePrompt.Size = new System.Drawing.Size(99, 13);
            this.labelInsuranceFeePrompt.TabIndex = 4;
            this.labelInsuranceFeePrompt.Text = "Insurance premium:";
            // 
            // comboBoxInsuranceName
            // 
            this.comboBoxInsuranceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInsuranceName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInsuranceName.FormattingEnabled = true;
            this.comboBoxInsuranceName.Location = new System.Drawing.Point(144, 15);
            this.comboBoxInsuranceName.MaxLength = 60;
            this.comboBoxInsuranceName.Name = "comboBoxInsuranceName";
            this.comboBoxInsuranceName.Size = new System.Drawing.Size(146, 21);
            this.comboBoxInsuranceName.TabIndex = 1;
            // 
            // dateTimePickerInsuranceDate
            // 
            this.dateTimePickerInsuranceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerInsuranceDate.Location = new System.Drawing.Point(144, 42);
            this.dateTimePickerInsuranceDate.Name = "dateTimePickerInsuranceDate";
            this.dateTimePickerInsuranceDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerInsuranceDate.TabIndex = 3;
            // 
            // labelInsuranceDatePrompt
            // 
            this.labelInsuranceDatePrompt.AutoSize = true;
            this.labelInsuranceDatePrompt.Location = new System.Drawing.Point(14, 45);
            this.labelInsuranceDatePrompt.Name = "labelInsuranceDatePrompt";
            this.labelInsuranceDatePrompt.Size = new System.Drawing.Size(84, 13);
            this.labelInsuranceDatePrompt.TabIndex = 2;
            this.labelInsuranceDatePrompt.Text = "Insurance Term:";
            // 
            // labelInsuranceNamePrompt
            // 
            this.labelInsuranceNamePrompt.AutoSize = true;
            this.labelInsuranceNamePrompt.Location = new System.Drawing.Point(14, 19);
            this.labelInsuranceNamePrompt.Name = "labelInsuranceNamePrompt";
            this.labelInsuranceNamePrompt.Size = new System.Drawing.Size(73, 13);
            this.labelInsuranceNamePrompt.TabIndex = 0;
            this.labelInsuranceNamePrompt.Text = "Insurance Co:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(363, 352);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Exit";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(283, 352);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "&Save";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // errorProviderClient
            // 
            this.errorProviderClient.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderClient.ContainerControl = this;
            this.errorProviderClient.RightToLeft = true;
            // 
            // EditClientDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(446, 387);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlEditClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditClientDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.EditClientDialog_Load);
            this.tabControlEditClient.ResumeLayout(false);
            this.tabPageCarDetails.ResumeLayout(false);
            this.tabPageCarDetails.PerformLayout();
            this.tabPageClientDetails.ResumeLayout(false);
            this.tabPageClientDetails.PerformLayout();
            this.tabPageInsurance.ResumeLayout(false);
            this.tabPageInsurance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEditClient;
        private System.Windows.Forms.TabPage tabPageCarDetails;
        private System.Windows.Forms.TabPage tabPageClientDetails;
        private System.Windows.Forms.TabPage tabPageInsurance;
        private System.Windows.Forms.Label labelPlateNumberPrompt;
        private System.Windows.Forms.Label labelCarManufacturerPrompt;
        private System.Windows.Forms.Label labelCarTypePrompt;
        private System.Windows.Forms.ComboBox comboBoxCarManufacturer;
        private System.Windows.Forms.TextBox textBoxCubicCentimetre;
        private System.Windows.Forms.Label labelCubicCentimetrePrompt;
        private System.Windows.Forms.ComboBox comboBoxCarType;
        private System.Windows.Forms.Label labelInspectionDatePrompt;
        private System.Windows.Forms.DateTimePicker dateTimePickerInspectionDate;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label labelYearPrompt;
        private System.Windows.Forms.TextBox textBoxIdentificationNumber;
        private System.Windows.Forms.Label labelIdentificationNumberPrompt;
        private System.Windows.Forms.ComboBox comboBoxFuel;
        private System.Windows.Forms.Label labelFuelPrompt;
        private System.Windows.Forms.TextBox textBoxPlateNumber;
        private System.Windows.Forms.TextBox textBoxEngineNumber;
        private System.Windows.Forms.Label labelEngineNumberPrompt;
        private System.Windows.Forms.TextBox textBoxKw;
        private System.Windows.Forms.Label labelKwPrompt;
        private System.Windows.Forms.CheckBox checkBoxFiltered;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Label labelNamePrompt;
        private System.Windows.Forms.Label labelPostalCodePrompt;
        private System.Windows.Forms.Label labelCityPrompt;
        private System.Windows.Forms.TextBox textBoxPhone1;
        private System.Windows.Forms.Label labelPhone1Prompt;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddressPrompt;
        private System.Windows.Forms.TextBox textBoxPhone2;
        private System.Windows.Forms.Label labelPhone2Prompt;
        private System.Windows.Forms.TextBox textBoxEmailAddress;
        private System.Windows.Forms.Label labelEmailAddressPrompt;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label labelDiscountPrompt;
        private System.Windows.Forms.Label labelInsuranceNamePrompt;
        private System.Windows.Forms.Label labelInsuranceDatePrompt;
        private System.Windows.Forms.DateTimePicker dateTimePickerInsuranceDate;
        private System.Windows.Forms.TextBox textBoxInsuranceFee;
        private System.Windows.Forms.Label labelInsuranceFeePrompt;
        private System.Windows.Forms.ComboBox comboBoxInsuranceName;
        private System.Windows.Forms.ComboBox comboBoxCascoName;
        private System.Windows.Forms.Label labelCascoNamePrompt;
        private System.Windows.Forms.TextBox textBoxCascoDeduction;
        private System.Windows.Forms.Label labelCascoDeductionPrompt;
        private System.Windows.Forms.TextBox textBoxCascoType;
        private System.Windows.Forms.Label labelCascoTypePrompt;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.ComboBox comboBoxPostalCode;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxIsHungarian;
        private System.Windows.Forms.ErrorProvider errorProviderClient;
    }
}