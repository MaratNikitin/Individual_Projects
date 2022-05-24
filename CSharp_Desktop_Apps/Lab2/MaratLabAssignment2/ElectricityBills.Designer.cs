
namespace MaratLabAssignment2
{
    partial class ElectricityBills
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelEnterCustomer = new System.Windows.Forms.Label();
            this.labelAccountNumber = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelkWhUsed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAccountNumber = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfKWHUsed = new System.Windows.Forms.TextBox();
            this.textBoxBillAmount = new System.Windows.Forms.TextBox();
            this.buttonEnterCustomerData = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelListOfCustomers = new System.Windows.Forms.Label();
            this.labelNumberOfCustomersProcessed = new System.Windows.Forms.Label();
            this.textBoxNumberOfCustomers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotalNumberOfkWhUsed = new System.Windows.Forms.Label();
            this.textBoxTotalKWHUsed = new System.Windows.Forms.TextBox();
            this.labelAverageBillAmount = new System.Windows.Forms.Label();
            this.textBoxAverageBillAmount = new System.Windows.Forms.TextBox();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.CustomerInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEnterCustomer
            // 
            this.labelEnterCustomer.AutoSize = true;
            this.labelEnterCustomer.BackColor = System.Drawing.Color.Transparent;
            this.labelEnterCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEnterCustomer.Location = new System.Drawing.Point(266, 23);
            this.labelEnterCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEnterCustomer.Name = "labelEnterCustomer";
            this.labelEnterCustomer.Size = new System.Drawing.Size(259, 25);
            this.labelEnterCustomer.TabIndex = 0;
            this.labelEnterCustomer.Text = "Enter New Customer\'s Data:";
            // 
            // labelAccountNumber
            // 
            this.labelAccountNumber.AutoSize = true;
            this.labelAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.labelAccountNumber.Location = new System.Drawing.Point(15, 320);
            this.labelAccountNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccountNumber.Name = "labelAccountNumber";
            this.labelAccountNumber.Size = new System.Drawing.Size(350, 21);
            this.labelAccountNumber.TabIndex = 1;
            this.labelAccountNumber.Text = "Last Customer\'s Account # (Auto-Generated):";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstName.Location = new System.Drawing.Point(15, 67);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(184, 21);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "Customer\'s First Name:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.BackColor = System.Drawing.Color.Transparent;
            this.labelLastName.Location = new System.Drawing.Point(15, 111);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(182, 21);
            this.labelLastName.TabIndex = 3;
            this.labelLastName.Text = "Customer\'s Last Name:";
            // 
            // labelkWhUsed
            // 
            this.labelkWhUsed.AutoSize = true;
            this.labelkWhUsed.BackColor = System.Drawing.Color.Transparent;
            this.labelkWhUsed.Location = new System.Drawing.Point(15, 157);
            this.labelkWhUsed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelkWhUsed.Name = "labelkWhUsed";
            this.labelkWhUsed.Size = new System.Drawing.Size(178, 21);
            this.labelkWhUsed.TabIndex = 4;
            this.labelkWhUsed.Text = "Number of kWh Used:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 275);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Last Customer\'s Bill Amount (Auto Calculated):";
            // 
            // textBoxAccountNumber
            // 
            this.textBoxAccountNumber.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxAccountNumber.Location = new System.Drawing.Point(378, 317);
            this.textBoxAccountNumber.Name = "textBoxAccountNumber";
            this.textBoxAccountNumber.ReadOnly = true;
            this.textBoxAccountNumber.Size = new System.Drawing.Size(324, 29);
            this.textBoxAccountNumber.TabIndex = 6;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.BackColor = System.Drawing.Color.White;
            this.textBoxFirstName.Location = new System.Drawing.Point(226, 64);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(476, 29);
            this.textBoxFirstName.TabIndex = 7;
            this.textBoxFirstName.Tag = "Customer\'s First Name ";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.BackColor = System.Drawing.Color.White;
            this.textBoxLastName.Location = new System.Drawing.Point(226, 103);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(476, 29);
            this.textBoxLastName.TabIndex = 8;
            this.textBoxLastName.Tag = "Customer\'s Last Name";
            // 
            // textBoxNumberOfKWHUsed
            // 
            this.textBoxNumberOfKWHUsed.BackColor = System.Drawing.Color.White;
            this.textBoxNumberOfKWHUsed.Location = new System.Drawing.Point(226, 149);
            this.textBoxNumberOfKWHUsed.Name = "textBoxNumberOfKWHUsed";
            this.textBoxNumberOfKWHUsed.Size = new System.Drawing.Size(476, 29);
            this.textBoxNumberOfKWHUsed.TabIndex = 9;
            this.textBoxNumberOfKWHUsed.Tag = "Number of kWh used value ";
            // 
            // textBoxBillAmount
            // 
            this.textBoxBillAmount.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxBillAmount.Location = new System.Drawing.Point(378, 272);
            this.textBoxBillAmount.Name = "textBoxBillAmount";
            this.textBoxBillAmount.ReadOnly = true;
            this.textBoxBillAmount.Size = new System.Drawing.Size(324, 29);
            this.textBoxBillAmount.TabIndex = 10;
            // 
            // buttonEnterCustomerData
            // 
            this.buttonEnterCustomerData.BackColor = System.Drawing.Color.Peru;
            this.buttonEnterCustomerData.Location = new System.Drawing.Point(226, 207);
            this.buttonEnterCustomerData.Name = "buttonEnterCustomerData";
            this.buttonEnterCustomerData.Size = new System.Drawing.Size(117, 40);
            this.buttonEnterCustomerData.TabIndex = 11;
            this.buttonEnterCustomerData.Text = "&Submit Data";
            this.buttonEnterCustomerData.UseVisualStyleBackColor = false;
            this.buttonEnterCustomerData.Click += new System.EventHandler(this.buttonEnterCustomerData_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Peru;
            this.buttonReset.Location = new System.Drawing.Point(585, 207);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(117, 40);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Peru;
            this.buttonExit.Location = new System.Drawing.Point(585, 571);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(117, 40);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelListOfCustomers
            // 
            this.labelListOfCustomers.AutoSize = true;
            this.labelListOfCustomers.BackColor = System.Drawing.Color.Transparent;
            this.labelListOfCustomers.Location = new System.Drawing.Point(15, 371);
            this.labelListOfCustomers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelListOfCustomers.Name = "labelListOfCustomers";
            this.labelListOfCustomers.Size = new System.Drawing.Size(164, 21);
            this.labelListOfCustomers.TabIndex = 14;
            this.labelListOfCustomers.Text = "All Customers\' Data:";
            // 
            // labelNumberOfCustomersProcessed
            // 
            this.labelNumberOfCustomersProcessed.AutoSize = true;
            this.labelNumberOfCustomersProcessed.BackColor = System.Drawing.Color.Transparent;
            this.labelNumberOfCustomersProcessed.Location = new System.Drawing.Point(15, 496);
            this.labelNumberOfCustomersProcessed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumberOfCustomersProcessed.Name = "labelNumberOfCustomersProcessed";
            this.labelNumberOfCustomersProcessed.Size = new System.Drawing.Size(207, 21);
            this.labelNumberOfCustomersProcessed.TabIndex = 17;
            this.labelNumberOfCustomersProcessed.Text = "# of Customers Processed:";
            // 
            // textBoxNumberOfCustomers
            // 
            this.textBoxNumberOfCustomers.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxNumberOfCustomers.Location = new System.Drawing.Point(266, 493);
            this.textBoxNumberOfCustomers.Name = "textBoxNumberOfCustomers";
            this.textBoxNumberOfCustomers.ReadOnly = true;
            this.textBoxNumberOfCustomers.Size = new System.Drawing.Size(197, 29);
            this.textBoxNumberOfCustomers.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(72, 450);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Statistics ↓";
            // 
            // labelTotalNumberOfkWhUsed
            // 
            this.labelTotalNumberOfkWhUsed.AutoSize = true;
            this.labelTotalNumberOfkWhUsed.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalNumberOfkWhUsed.Location = new System.Drawing.Point(15, 537);
            this.labelTotalNumberOfkWhUsed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalNumberOfkWhUsed.Name = "labelTotalNumberOfkWhUsed";
            this.labelTotalNumberOfkWhUsed.Size = new System.Drawing.Size(226, 21);
            this.labelTotalNumberOfkWhUsed.TabIndex = 20;
            this.labelTotalNumberOfkWhUsed.Text = "Total Number Of kWh Used: ";
            // 
            // textBoxTotalKWHUsed
            // 
            this.textBoxTotalKWHUsed.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxTotalKWHUsed.Location = new System.Drawing.Point(266, 537);
            this.textBoxTotalKWHUsed.Name = "textBoxTotalKWHUsed";
            this.textBoxTotalKWHUsed.ReadOnly = true;
            this.textBoxTotalKWHUsed.Size = new System.Drawing.Size(197, 29);
            this.textBoxTotalKWHUsed.TabIndex = 21;
            // 
            // labelAverageBillAmount
            // 
            this.labelAverageBillAmount.AutoSize = true;
            this.labelAverageBillAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelAverageBillAmount.Location = new System.Drawing.Point(15, 578);
            this.labelAverageBillAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAverageBillAmount.Name = "labelAverageBillAmount";
            this.labelAverageBillAmount.Size = new System.Drawing.Size(172, 21);
            this.labelAverageBillAmount.TabIndex = 22;
            this.labelAverageBillAmount.Text = "Average Bill Amount:";
            // 
            // textBoxAverageBillAmount
            // 
            this.textBoxAverageBillAmount.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxAverageBillAmount.Location = new System.Drawing.Point(266, 578);
            this.textBoxAverageBillAmount.Name = "textBoxAverageBillAmount";
            this.textBoxAverageBillAmount.ReadOnly = true;
            this.textBoxAverageBillAmount.Size = new System.Drawing.Size(197, 29);
            this.textBoxAverageBillAmount.TabIndex = 23;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCustomers.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridViewCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerInfo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCustomers.EnableHeadersVisualStyles = false;
            this.dataGridViewCustomers.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(226, 371);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PapayaWhip;
            this.dataGridViewCustomers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCustomers.RowTemplate.Height = 25;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(476, 104);
            this.dataGridViewCustomers.TabIndex = 24;
            // 
            // CustomerInfo
            // 
            this.CustomerInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerInfo.HeaderText = "Customers\' Information:";
            this.CustomerInfo.Name = "CustomerInfo";
            this.CustomerInfo.ReadOnly = true;
            // 
            // ElectricityBills
            // 
            this.AcceptButton = this.buttonEnterCustomerData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImage = global::MaratLabAssignment2.Properties.Resources.MyBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonReset;
            this.ClientSize = new System.Drawing.Size(728, 637);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.textBoxAverageBillAmount);
            this.Controls.Add(this.labelAverageBillAmount);
            this.Controls.Add(this.textBoxTotalKWHUsed);
            this.Controls.Add(this.labelTotalNumberOfkWhUsed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumberOfCustomers);
            this.Controls.Add(this.labelNumberOfCustomersProcessed);
            this.Controls.Add(this.labelListOfCustomers);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonEnterCustomerData);
            this.Controls.Add(this.textBoxBillAmount);
            this.Controls.Add(this.textBoxNumberOfKWHUsed);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxAccountNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelkWhUsed);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.labelAccountNumber);
            this.Controls.Add(this.labelEnterCustomer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ElectricityBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Electricity Usage & Billing Data";
            this.Load += new System.EventHandler(this.ElectricityBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnterCustomer;
        private System.Windows.Forms.Label labelAccountNumber;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelkWhUsed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAccountNumber;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxNumberOfKWHUsed;
        private System.Windows.Forms.TextBox textBoxBillAmount;
        private System.Windows.Forms.Button buttonEnterCustomerData;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelListOfCustomers;
        private System.Windows.Forms.Label labelNumberOfCustomersProcessed;
        private System.Windows.Forms.TextBox textBoxNumberOfCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalNumberOfkWhUsed;
        private System.Windows.Forms.TextBox textBoxTotalKWHUsed;
        private System.Windows.Forms.Label labelAverageBillAmount;
        private System.Windows.Forms.TextBox textBoxAverageBillAmount;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerInfo;
    }
}

