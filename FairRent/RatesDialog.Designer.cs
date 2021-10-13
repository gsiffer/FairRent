
namespace FairRent
{
    partial class RatesDialog
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
            this.labelTaxPrompt = new System.Windows.Forms.Label();
            this.labelDiscountPrompt = new System.Windows.Forms.Label();
            this.labelWagePrompt = new System.Windows.Forms.Label();
            this.textBoxTax = new System.Windows.Forms.TextBox();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.textBoxWage = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProviderRates = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRates)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTaxPrompt
            // 
            this.labelTaxPrompt.AutoSize = true;
            this.labelTaxPrompt.Location = new System.Drawing.Point(50, 65);
            this.labelTaxPrompt.Name = "labelTaxPrompt";
            this.labelTaxPrompt.Size = new System.Drawing.Size(115, 20);
            this.labelTaxPrompt.TabIndex = 0;
            this.labelTaxPrompt.Text = "Á&fa értéke (%):";
            // 
            // labelDiscountPrompt
            // 
            this.labelDiscountPrompt.AutoSize = true;
            this.labelDiscountPrompt.Location = new System.Drawing.Point(51, 109);
            this.labelDiscountPrompt.Name = "labelDiscountPrompt";
            this.labelDiscountPrompt.Size = new System.Drawing.Size(131, 20);
            this.labelDiscountPrompt.TabIndex = 2;
            this.labelDiscountPrompt.Text = "K&edvezmény (%):";
            // 
            // labelWagePrompt
            // 
            this.labelWagePrompt.AutoSize = true;
            this.labelWagePrompt.Location = new System.Drawing.Point(51, 153);
            this.labelWagePrompt.Name = "labelWagePrompt";
            this.labelWagePrompt.Size = new System.Drawing.Size(132, 20);
            this.labelWagePrompt.TabIndex = 4;
            this.labelWagePrompt.Text = "&Munkadíj (Ft/óra):";
            // 
            // textBoxTax
            // 
            this.textBoxTax.Location = new System.Drawing.Point(199, 65);
            this.textBoxTax.Name = "textBoxTax";
            this.textBoxTax.Size = new System.Drawing.Size(152, 26);
            this.textBoxTax.TabIndex = 1;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Location = new System.Drawing.Point(199, 107);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(152, 26);
            this.textBoxDiscount.TabIndex = 3;
            // 
            // textBoxWage
            // 
            this.textBoxWage.Location = new System.Drawing.Point(199, 149);
            this.textBoxWage.Name = "textBoxWage";
            this.textBoxWage.Size = new System.Drawing.Size(152, 26);
            this.textBoxWage.TabIndex = 5;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(199, 241);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(112, 35);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "&Mentés";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(317, 241);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "&Kilép";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProviderRates
            // 
            this.errorProviderRates.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderRates.ContainerControl = this;
            this.errorProviderRates.RightToLeft = true;
            // 
            // RatesDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(441, 288);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxWage);
            this.Controls.Add(this.textBoxDiscount);
            this.Controls.Add(this.textBoxTax);
            this.Controls.Add(this.labelWagePrompt);
            this.Controls.Add(this.labelDiscountPrompt);
            this.Controls.Add(this.labelTaxPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RatesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Beállítások";
            this.Load += new System.EventHandler(this.SettingDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTaxPrompt;
        private System.Windows.Forms.Label labelDiscountPrompt;
        private System.Windows.Forms.Label labelWagePrompt;
        private System.Windows.Forms.TextBox textBoxTax;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.TextBox textBoxWage;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProviderRates;
    }
}