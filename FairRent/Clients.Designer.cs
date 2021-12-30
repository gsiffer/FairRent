
namespace FairRent
{
    partial class Clients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients));
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.labelFilterPlateNumPrompt = new System.Windows.Forms.Label();
            this.textBoxFilterPlateNum = new System.Windows.Forms.TextBox();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.labelNamePrompt = new System.Windows.Forms.Label();
            this.buttonNewClient = new System.Windows.Forms.Button();
            this.buttonEditClient = new System.Windows.Forms.Button();
            this.buttonNewWorksheet = new System.Windows.Forms.Button();
            this.buttonEditWorksheet = new System.Windows.Forms.Button();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.checkBoxConfirmDeletion = new System.Windows.Forms.CheckBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.labelPromptIdentificationNumber = new System.Windows.Forms.Label();
            this.textBoxFilterIdentificationNumber = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.checkBoxFilterTechnicalExamination = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTechnicalExamination = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTechnicalExamination = new System.Windows.Forms.GroupBox();
            this.labelPromptRowsCount = new System.Windows.Forms.Label();
            this.labelRowsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.groupBoxTechnicalExamination.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(1042, 432);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(126, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClients.ColumnHeadersHeight = 25;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewClients.Location = new System.Drawing.Point(4, 62);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.RowHeadersWidth = 25;
            this.dataGridViewClients.Size = new System.Drawing.Size(525, 268);
            this.dataGridViewClients.StandardTab = true;
            this.dataGridViewClients.TabIndex = 0;
            this.dataGridViewClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCustomers_CellDoubleClick);
            this.dataGridViewClients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewClients_KeyDown);
            // 
            // labelFilterPlateNumPrompt
            // 
            this.labelFilterPlateNumPrompt.AutoSize = true;
            this.labelFilterPlateNumPrompt.Location = new System.Drawing.Point(26, 12);
            this.labelFilterPlateNumPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilterPlateNumPrompt.Name = "labelFilterPlateNumPrompt";
            this.labelFilterPlateNumPrompt.Size = new System.Drawing.Size(73, 13);
            this.labelFilterPlateNumPrompt.TabIndex = 8;
            this.labelFilterPlateNumPrompt.Text = "&Plate Nr Filter:";
            // 
            // textBoxFilterPlateNum
            // 
            this.textBoxFilterPlateNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFilterPlateNum.Location = new System.Drawing.Point(29, 31);
            this.textBoxFilterPlateNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilterPlateNum.Name = "textBoxFilterPlateNum";
            this.textBoxFilterPlateNum.Size = new System.Drawing.Size(68, 20);
            this.textBoxFilterPlateNum.TabIndex = 9;
            this.textBoxFilterPlateNum.TextChanged += new System.EventHandler(this.textBoxFilterPlateNum_TextChanged);
            // 
            // textBoxFilterName
            // 
            this.textBoxFilterName.Location = new System.Drawing.Point(104, 31);
            this.textBoxFilterName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(153, 20);
            this.textBoxFilterName.TabIndex = 11;
            this.textBoxFilterName.TextChanged += new System.EventHandler(this.textBoxFilterName_TextChanged);
            // 
            // labelNamePrompt
            // 
            this.labelNamePrompt.AutoSize = true;
            this.labelNamePrompt.Location = new System.Drawing.Point(101, 12);
            this.labelNamePrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNamePrompt.Name = "labelNamePrompt";
            this.labelNamePrompt.Size = new System.Drawing.Size(63, 13);
            this.labelNamePrompt.TabIndex = 10;
            this.labelNamePrompt.Text = "N&ame Filter:";
            // 
            // buttonNewClient
            // 
            this.buttonNewClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewClient.Location = new System.Drawing.Point(1042, 62);
            this.buttonNewClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewClient.Name = "buttonNewClient";
            this.buttonNewClient.Size = new System.Drawing.Size(126, 23);
            this.buttonNewClient.TabIndex = 1;
            this.buttonNewClient.Text = "&New Customer";
            this.buttonNewClient.UseVisualStyleBackColor = true;
            this.buttonNewClient.Click += new System.EventHandler(this.buttonNewClient_Click);
            // 
            // buttonEditClient
            // 
            this.buttonEditClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditClient.Location = new System.Drawing.Point(1042, 89);
            this.buttonEditClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEditClient.Name = "buttonEditClient";
            this.buttonEditClient.Size = new System.Drawing.Size(126, 23);
            this.buttonEditClient.TabIndex = 2;
            this.buttonEditClient.Text = "&Modify Customer";
            this.buttonEditClient.UseVisualStyleBackColor = true;
            this.buttonEditClient.Click += new System.EventHandler(this.buttonEditClient_Click);
            // 
            // buttonNewWorksheet
            // 
            this.buttonNewWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewWorksheet.Location = new System.Drawing.Point(1042, 163);
            this.buttonNewWorksheet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewWorksheet.Name = "buttonNewWorksheet";
            this.buttonNewWorksheet.Size = new System.Drawing.Size(126, 23);
            this.buttonNewWorksheet.TabIndex = 4;
            this.buttonNewWorksheet.Text = "New &Worksheet";
            this.buttonNewWorksheet.UseVisualStyleBackColor = true;
            this.buttonNewWorksheet.Click += new System.EventHandler(this.buttonNewWorksheet_Click);
            // 
            // buttonEditWorksheet
            // 
            this.buttonEditWorksheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditWorksheet.Location = new System.Drawing.Point(1042, 190);
            this.buttonEditWorksheet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEditWorksheet.Name = "buttonEditWorksheet";
            this.buttonEditWorksheet.Size = new System.Drawing.Size(126, 23);
            this.buttonEditWorksheet.TabIndex = 5;
            this.buttonEditWorksheet.Text = "M&odify Worksheet";
            this.buttonEditWorksheet.UseVisualStyleBackColor = true;
            this.buttonEditWorksheet.Click += new System.EventHandler(this.buttonEditWorksheet_Click);
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteClient.Location = new System.Drawing.Point(1042, 116);
            this.buttonDeleteClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(126, 23);
            this.buttonDeleteClient.TabIndex = 3;
            this.buttonDeleteClient.Text = "&Delete Customer";
            this.buttonDeleteClient.UseVisualStyleBackColor = true;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // checkBoxConfirmDeletion
            // 
            this.checkBoxConfirmDeletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxConfirmDeletion.AutoSize = true;
            this.checkBoxConfirmDeletion.Checked = true;
            this.checkBoxConfirmDeletion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConfirmDeletion.Location = new System.Drawing.Point(1027, 236);
            this.checkBoxConfirmDeletion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxConfirmDeletion.Name = "checkBoxConfirmDeletion";
            this.checkBoxConfirmDeletion.Size = new System.Drawing.Size(120, 17);
            this.checkBoxConfirmDeletion.TabIndex = 6;
            this.checkBoxConfirmDeletion.Text = "Ask &Before Deletion";
            this.checkBoxConfirmDeletion.UseVisualStyleBackColor = true;
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(427, 29);
            this.buttonClearFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(102, 23);
            this.buttonClearFilter.TabIndex = 14;
            this.buttonClearFilter.Text = "Delete Filter&s";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // labelPromptIdentificationNumber
            // 
            this.labelPromptIdentificationNumber.AutoSize = true;
            this.labelPromptIdentificationNumber.Location = new System.Drawing.Point(261, 12);
            this.labelPromptIdentificationNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPromptIdentificationNumber.Name = "labelPromptIdentificationNumber";
            this.labelPromptIdentificationNumber.Size = new System.Drawing.Size(111, 13);
            this.labelPromptIdentificationNumber.TabIndex = 12;
            this.labelPromptIdentificationNumber.Text = "&Chassis Number Filter:";
            // 
            // textBoxFilterIdentificationNumber
            // 
            this.textBoxFilterIdentificationNumber.Location = new System.Drawing.Point(264, 31);
            this.textBoxFilterIdentificationNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilterIdentificationNumber.Name = "textBoxFilterIdentificationNumber";
            this.textBoxFilterIdentificationNumber.Size = new System.Drawing.Size(153, 20);
            this.textBoxFilterIdentificationNumber.TabIndex = 13;
            this.textBoxFilterIdentificationNumber.TextChanged += new System.EventHandler(this.textBoxFilterIdentificationNumber_TextChanged);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Enabled = false;
            this.buttonPrint.Location = new System.Drawing.Point(171, 16);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(88, 23);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "&Export to Excel";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // checkBoxFilterTechnicalExamination
            // 
            this.checkBoxFilterTechnicalExamination.AutoSize = true;
            this.checkBoxFilterTechnicalExamination.Location = new System.Drawing.Point(8, 19);
            this.checkBoxFilterTechnicalExamination.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxFilterTechnicalExamination.Name = "checkBoxFilterTechnicalExamination";
            this.checkBoxFilterTechnicalExamination.Size = new System.Drawing.Size(48, 17);
            this.checkBoxFilterTechnicalExamination.TabIndex = 0;
            this.checkBoxFilterTechnicalExamination.Text = "&Filter";
            this.checkBoxFilterTechnicalExamination.UseVisualStyleBackColor = true;
            this.checkBoxFilterTechnicalExamination.CheckedChanged += new System.EventHandler(this.checkBoxFilterTechnicalExamination_CheckedChanged);
            // 
            // dateTimePickerTechnicalExamination
            // 
            this.dateTimePickerTechnicalExamination.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTechnicalExamination.Location = new System.Drawing.Point(69, 18);
            this.dateTimePickerTechnicalExamination.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerTechnicalExamination.Name = "dateTimePickerTechnicalExamination";
            this.dateTimePickerTechnicalExamination.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerTechnicalExamination.TabIndex = 1;
            this.dateTimePickerTechnicalExamination.ValueChanged += new System.EventHandler(this.dateTimePickerTechnicalExamination_ValueChanged);
            // 
            // groupBoxTechnicalExamination
            // 
            this.groupBoxTechnicalExamination.Controls.Add(this.checkBoxFilterTechnicalExamination);
            this.groupBoxTechnicalExamination.Controls.Add(this.buttonPrint);
            this.groupBoxTechnicalExamination.Controls.Add(this.dateTimePickerTechnicalExamination);
            this.groupBoxTechnicalExamination.Location = new System.Drawing.Point(563, 12);
            this.groupBoxTechnicalExamination.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxTechnicalExamination.Name = "groupBoxTechnicalExamination";
            this.groupBoxTechnicalExamination.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxTechnicalExamination.Size = new System.Drawing.Size(265, 47);
            this.groupBoxTechnicalExamination.TabIndex = 15;
            this.groupBoxTechnicalExamination.TabStop = false;
            this.groupBoxTechnicalExamination.Text = "&Inspection Date Filter to";
            // 
            // labelPromptRowsCount
            // 
            this.labelPromptRowsCount.AutoSize = true;
            this.labelPromptRowsCount.Location = new System.Drawing.Point(849, 34);
            this.labelPromptRowsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPromptRowsCount.Name = "labelPromptRowsCount";
            this.labelPromptRowsCount.Size = new System.Drawing.Size(62, 13);
            this.labelPromptRowsCount.TabIndex = 18;
            this.labelPromptRowsCount.Text = "Row count:";
            // 
            // labelRowsCount
            // 
            this.labelRowsCount.AutoSize = true;
            this.labelRowsCount.Location = new System.Drawing.Point(917, 34);
            this.labelRowsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRowsCount.Name = "labelRowsCount";
            this.labelRowsCount.Size = new System.Drawing.Size(59, 13);
            this.labelRowsCount.TabIndex = 19;
            this.labelRowsCount.Text = "<<Count>>";
            // 
            // Clients
            // 
            this.AcceptButton = this.buttonEditClient;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(1179, 543);
            this.Controls.Add(this.labelRowsCount);
            this.Controls.Add(this.labelPromptRowsCount);
            this.Controls.Add(this.groupBoxTechnicalExamination);
            this.Controls.Add(this.textBoxFilterIdentificationNumber);
            this.Controls.Add(this.labelPromptIdentificationNumber);
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.checkBoxConfirmDeletion);
            this.Controls.Add(this.buttonDeleteClient);
            this.Controls.Add(this.buttonEditWorksheet);
            this.Controls.Add(this.buttonNewWorksheet);
            this.Controls.Add(this.buttonEditClient);
            this.Controls.Add(this.buttonNewClient);
            this.Controls.Add(this.textBoxFilterName);
            this.Controls.Add(this.labelNamePrompt);
            this.Controls.Add(this.textBoxFilterPlateNum);
            this.Controls.Add(this.labelFilterPlateNumPrompt);
            this.Controls.Add(this.dataGridViewClients);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customers_FormClosing);
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.groupBoxTechnicalExamination.ResumeLayout(false);
            this.groupBoxTechnicalExamination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Label labelFilterPlateNumPrompt;
        private System.Windows.Forms.TextBox textBoxFilterPlateNum;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.Label labelNamePrompt;
        private System.Windows.Forms.Button buttonNewClient;
        private System.Windows.Forms.Button buttonEditClient;
        private System.Windows.Forms.Button buttonNewWorksheet;
        private System.Windows.Forms.Button buttonEditWorksheet;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.CheckBox checkBoxConfirmDeletion;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Label labelPromptIdentificationNumber;
        private System.Windows.Forms.TextBox textBoxFilterIdentificationNumber;
        private System.Windows.Forms.Button buttonPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.CheckBox checkBoxFilterTechnicalExamination;
        private System.Windows.Forms.DateTimePicker dateTimePickerTechnicalExamination;
        private System.Windows.Forms.GroupBox groupBoxTechnicalExamination;
        private System.Windows.Forms.Label labelPromptRowsCount;
        private System.Windows.Forms.Label labelRowsCount;
    }
}