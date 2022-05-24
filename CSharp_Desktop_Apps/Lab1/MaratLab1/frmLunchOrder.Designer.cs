
namespace MaratLab1
{
    partial class frmLunchOrder
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
            this.groupBoxMainCourse = new System.Windows.Forms.GroupBox();
            this.radioButtonSalad = new System.Windows.Forms.RadioButton();
            this.radioButtonPizza = new System.Windows.Forms.RadioButton();
            this.radioButtonHamburger = new System.Windows.Forms.RadioButton();
            this.groupBoxAddOnHamburger = new System.Windows.Forms.GroupBox();
            this.checkBoxFrenchFries = new System.Windows.Forms.CheckBox();
            this.groupBoxAddOnSalad = new System.Windows.Forms.GroupBox();
            this.groupBoxAddOnPizza = new System.Windows.Forms.GroupBox();
            this.checkBoxOlives = new System.Windows.Forms.CheckBox();
            this.checkBoxSausage = new System.Windows.Forms.CheckBox();
            this.checkBoxPepperoni = new System.Windows.Forms.CheckBox();
            this.checkBoxBreadSticks = new System.Windows.Forms.CheckBox();
            this.checkBoxBaconBits = new System.Windows.Forms.CheckBox();
            this.checkBoxCroutons = new System.Windows.Forms.CheckBox();
            this.checkBoxKetchup = new System.Windows.Forms.CheckBox();
            this.checkBoxLettuce = new System.Windows.Forms.CheckBox();
            this.groupBoxOrderTotal = new System.Windows.Forms.GroupBox();
            this.textBoxOrderTotal = new System.Windows.Forms.TextBox();
            this.textBoxTax = new System.Windows.Forms.TextBox();
            this.textBoxSubtotal = new System.Windows.Forms.TextBox();
            this.labelOrderTotal = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxMainCourse.SuspendLayout();
            this.groupBoxAddOnHamburger.SuspendLayout();
            this.groupBoxAddOnSalad.SuspendLayout();
            this.groupBoxAddOnPizza.SuspendLayout();
            this.groupBoxOrderTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMainCourse
            // 
            this.groupBoxMainCourse.Controls.Add(this.radioButtonSalad);
            this.groupBoxMainCourse.Controls.Add(this.radioButtonPizza);
            this.groupBoxMainCourse.Controls.Add(this.radioButtonHamburger);
            this.groupBoxMainCourse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxMainCourse.Location = new System.Drawing.Point(50, 43);
            this.groupBoxMainCourse.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMainCourse.Name = "groupBoxMainCourse";
            this.groupBoxMainCourse.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMainCourse.Size = new System.Drawing.Size(257, 140);
            this.groupBoxMainCourse.TabIndex = 0;
            this.groupBoxMainCourse.TabStop = false;
            this.groupBoxMainCourse.Text = "Main Course";
            // 
            // radioButtonSalad
            // 
            this.radioButtonSalad.AutoSize = true;
            this.radioButtonSalad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonSalad.Location = new System.Drawing.Point(7, 91);
            this.radioButtonSalad.Name = "radioButtonSalad";
            this.radioButtonSalad.Size = new System.Drawing.Size(66, 25);
            this.radioButtonSalad.TabIndex = 2;
            this.radioButtonSalad.TabStop = true;
            this.radioButtonSalad.Text = "Salad";
            this.radioButtonSalad.UseVisualStyleBackColor = true;
            this.radioButtonSalad.CheckedChanged += new System.EventHandler(this.radioButtonSalad_CheckedChanged);
            // 
            // radioButtonPizza
            // 
            this.radioButtonPizza.AutoSize = true;
            this.radioButtonPizza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPizza.Location = new System.Drawing.Point(7, 60);
            this.radioButtonPizza.Name = "radioButtonPizza";
            this.radioButtonPizza.Size = new System.Drawing.Size(63, 25);
            this.radioButtonPizza.TabIndex = 1;
            this.radioButtonPizza.TabStop = true;
            this.radioButtonPizza.Text = "Pizza";
            this.radioButtonPizza.UseVisualStyleBackColor = true;
            this.radioButtonPizza.CheckedChanged += new System.EventHandler(this.radioButtonPizza_CheckedChanged);
            // 
            // radioButtonHamburger
            // 
            this.radioButtonHamburger.AutoSize = true;
            this.radioButtonHamburger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonHamburger.Location = new System.Drawing.Point(7, 29);
            this.radioButtonHamburger.Name = "radioButtonHamburger";
            this.radioButtonHamburger.Size = new System.Drawing.Size(108, 25);
            this.radioButtonHamburger.TabIndex = 0;
            this.radioButtonHamburger.TabStop = true;
            this.radioButtonHamburger.Text = "Hamburger";
            this.radioButtonHamburger.UseVisualStyleBackColor = true;
            this.radioButtonHamburger.CheckedChanged += new System.EventHandler(this.radioButtonHamburger_CheckedChanged);
            // 
            // groupBoxAddOnHamburger
            // 
            this.groupBoxAddOnHamburger.Controls.Add(this.checkBoxFrenchFries);
            this.groupBoxAddOnHamburger.Controls.Add(this.checkBoxKetchup);
            this.groupBoxAddOnHamburger.Controls.Add(this.checkBoxLettuce);
            this.groupBoxAddOnHamburger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAddOnHamburger.Location = new System.Drawing.Point(336, 43);
            this.groupBoxAddOnHamburger.Name = "groupBoxAddOnHamburger";
            this.groupBoxAddOnHamburger.Size = new System.Drawing.Size(364, 140);
            this.groupBoxAddOnHamburger.TabIndex = 1;
            this.groupBoxAddOnHamburger.TabStop = false;
            this.groupBoxAddOnHamburger.Text = "Add-On Items (Hamburger)";
            // 
            // checkBoxFrenchFries
            // 
            this.checkBoxFrenchFries.AutoSize = true;
            this.checkBoxFrenchFries.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFrenchFries.Location = new System.Drawing.Point(6, 92);
            this.checkBoxFrenchFries.Name = "checkBoxFrenchFries";
            this.checkBoxFrenchFries.Size = new System.Drawing.Size(113, 25);
            this.checkBoxFrenchFries.TabIndex = 3;
            this.checkBoxFrenchFries.Text = "French Fries";
            this.checkBoxFrenchFries.UseVisualStyleBackColor = true;
            // 
            // groupBoxAddOnSalad
            // 
            this.groupBoxAddOnSalad.Controls.Add(this.checkBoxBreadSticks);
            this.groupBoxAddOnSalad.Controls.Add(this.checkBoxBaconBits);
            this.groupBoxAddOnSalad.Controls.Add(this.checkBoxCroutons);
            this.groupBoxAddOnSalad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAddOnSalad.Location = new System.Drawing.Point(336, 43);
            this.groupBoxAddOnSalad.Name = "groupBoxAddOnSalad";
            this.groupBoxAddOnSalad.Size = new System.Drawing.Size(364, 140);
            this.groupBoxAddOnSalad.TabIndex = 7;
            this.groupBoxAddOnSalad.TabStop = false;
            this.groupBoxAddOnSalad.Text = "Add-On Items (Salad)";
            // 
            // groupBoxAddOnPizza
            // 
            this.groupBoxAddOnPizza.Controls.Add(this.checkBoxOlives);
            this.groupBoxAddOnPizza.Controls.Add(this.checkBoxSausage);
            this.groupBoxAddOnPizza.Controls.Add(this.checkBoxPepperoni);
            this.groupBoxAddOnPizza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAddOnPizza.Location = new System.Drawing.Point(330, 43);
            this.groupBoxAddOnPizza.Name = "groupBoxAddOnPizza";
            this.groupBoxAddOnPizza.Size = new System.Drawing.Size(370, 140);
            this.groupBoxAddOnPizza.TabIndex = 6;
            this.groupBoxAddOnPizza.TabStop = false;
            this.groupBoxAddOnPizza.Text = "Add-On Items (Pizza)";
            // 
            // checkBoxOlives
            // 
            this.checkBoxOlives.AutoSize = true;
            this.checkBoxOlives.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxOlives.Location = new System.Drawing.Point(6, 92);
            this.checkBoxOlives.Name = "checkBoxOlives";
            this.checkBoxOlives.Size = new System.Drawing.Size(72, 25);
            this.checkBoxOlives.TabIndex = 3;
            this.checkBoxOlives.Text = "Olives";
            this.checkBoxOlives.UseVisualStyleBackColor = true;
            // 
            // checkBoxSausage
            // 
            this.checkBoxSausage.AutoSize = true;
            this.checkBoxSausage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxSausage.Location = new System.Drawing.Point(7, 61);
            this.checkBoxSausage.Name = "checkBoxSausage";
            this.checkBoxSausage.Size = new System.Drawing.Size(87, 25);
            this.checkBoxSausage.TabIndex = 2;
            this.checkBoxSausage.Text = "Sausage";
            this.checkBoxSausage.UseVisualStyleBackColor = true;
            // 
            // checkBoxPepperoni
            // 
            this.checkBoxPepperoni.AutoSize = true;
            this.checkBoxPepperoni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPepperoni.Location = new System.Drawing.Point(7, 29);
            this.checkBoxPepperoni.Name = "checkBoxPepperoni";
            this.checkBoxPepperoni.Size = new System.Drawing.Size(99, 25);
            this.checkBoxPepperoni.TabIndex = 0;
            this.checkBoxPepperoni.Text = "Pepperoni";
            this.checkBoxPepperoni.UseVisualStyleBackColor = true;
            // 
            // checkBoxBreadSticks
            // 
            this.checkBoxBreadSticks.AutoSize = true;
            this.checkBoxBreadSticks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxBreadSticks.Location = new System.Drawing.Point(6, 92);
            this.checkBoxBreadSticks.Name = "checkBoxBreadSticks";
            this.checkBoxBreadSticks.Size = new System.Drawing.Size(112, 25);
            this.checkBoxBreadSticks.TabIndex = 3;
            this.checkBoxBreadSticks.Text = "Bread Sticks";
            this.checkBoxBreadSticks.UseVisualStyleBackColor = true;
            // 
            // checkBoxBaconBits
            // 
            this.checkBoxBaconBits.AutoSize = true;
            this.checkBoxBaconBits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxBaconBits.Location = new System.Drawing.Point(7, 61);
            this.checkBoxBaconBits.Name = "checkBoxBaconBits";
            this.checkBoxBaconBits.Size = new System.Drawing.Size(100, 25);
            this.checkBoxBaconBits.TabIndex = 2;
            this.checkBoxBaconBits.Text = "Bacon Bits";
            this.checkBoxBaconBits.UseVisualStyleBackColor = true;
            // 
            // checkBoxCroutons
            // 
            this.checkBoxCroutons.AutoSize = true;
            this.checkBoxCroutons.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxCroutons.Location = new System.Drawing.Point(7, 29);
            this.checkBoxCroutons.Name = "checkBoxCroutons";
            this.checkBoxCroutons.Size = new System.Drawing.Size(93, 25);
            this.checkBoxCroutons.TabIndex = 0;
            this.checkBoxCroutons.Text = "Croutons";
            this.checkBoxCroutons.UseVisualStyleBackColor = true;
            // 
            // checkBoxKetchup
            // 
            this.checkBoxKetchup.AutoSize = true;
            this.checkBoxKetchup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxKetchup.Location = new System.Drawing.Point(7, 61);
            this.checkBoxKetchup.Name = "checkBoxKetchup";
            this.checkBoxKetchup.Size = new System.Drawing.Size(223, 25);
            this.checkBoxKetchup.TabIndex = 2;
            this.checkBoxKetchup.Text = "Ketchup, mustard and mayo";
            this.checkBoxKetchup.UseVisualStyleBackColor = true;
            // 
            // checkBoxLettuce
            // 
            this.checkBoxLettuce.AutoSize = true;
            this.checkBoxLettuce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxLettuce.Location = new System.Drawing.Point(7, 29);
            this.checkBoxLettuce.Name = "checkBoxLettuce";
            this.checkBoxLettuce.Size = new System.Drawing.Size(217, 25);
            this.checkBoxLettuce.TabIndex = 0;
            this.checkBoxLettuce.Text = "Lettuce, tomato and onions";
            this.checkBoxLettuce.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrderTotal
            // 
            this.groupBoxOrderTotal.Controls.Add(this.textBoxOrderTotal);
            this.groupBoxOrderTotal.Controls.Add(this.textBoxTax);
            this.groupBoxOrderTotal.Controls.Add(this.textBoxSubtotal);
            this.groupBoxOrderTotal.Controls.Add(this.labelOrderTotal);
            this.groupBoxOrderTotal.Controls.Add(this.labelTax);
            this.groupBoxOrderTotal.Controls.Add(this.labelSubtotal);
            this.groupBoxOrderTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOrderTotal.Location = new System.Drawing.Point(50, 278);
            this.groupBoxOrderTotal.Name = "groupBoxOrderTotal";
            this.groupBoxOrderTotal.Size = new System.Drawing.Size(366, 268);
            this.groupBoxOrderTotal.TabIndex = 2;
            this.groupBoxOrderTotal.TabStop = false;
            this.groupBoxOrderTotal.Text = "Order Total";
            // 
            // textBoxOrderTotal
            // 
            this.textBoxOrderTotal.Location = new System.Drawing.Point(151, 209);
            this.textBoxOrderTotal.Name = "textBoxOrderTotal";
            this.textBoxOrderTotal.ReadOnly = true;
            this.textBoxOrderTotal.Size = new System.Drawing.Size(168, 29);
            this.textBoxOrderTotal.TabIndex = 5;
            // 
            // textBoxTax
            // 
            this.textBoxTax.Location = new System.Drawing.Point(151, 152);
            this.textBoxTax.Name = "textBoxTax";
            this.textBoxTax.ReadOnly = true;
            this.textBoxTax.Size = new System.Drawing.Size(168, 29);
            this.textBoxTax.TabIndex = 4;
            // 
            // textBoxSubtotal
            // 
            this.textBoxSubtotal.Location = new System.Drawing.Point(151, 92);
            this.textBoxSubtotal.Name = "textBoxSubtotal";
            this.textBoxSubtotal.ReadOnly = true;
            this.textBoxSubtotal.Size = new System.Drawing.Size(168, 29);
            this.textBoxSubtotal.TabIndex = 3;
            // 
            // labelOrderTotal
            // 
            this.labelOrderTotal.AutoSize = true;
            this.labelOrderTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelOrderTotal.Location = new System.Drawing.Point(35, 212);
            this.labelOrderTotal.Name = "labelOrderTotal";
            this.labelOrderTotal.Size = new System.Drawing.Size(99, 21);
            this.labelOrderTotal.TabIndex = 2;
            this.labelOrderTotal.Text = "Order Total:";
            this.labelOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTax
            // 
            this.labelTax.AutoSize = true;
            this.labelTax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTax.Location = new System.Drawing.Point(35, 155);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(36, 21);
            this.labelTax.TabIndex = 1;
            this.labelTax.Text = "Tax";
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.AutoSize = true;
            this.labelSubtotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSubtotal.Location = new System.Drawing.Point(35, 95);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(79, 21);
            this.labelSubtotal.TabIndex = 0;
            this.labelSubtotal.Text = "Subtotal:";
            this.labelSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPlaceOrder.Location = new System.Drawing.Point(515, 318);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(185, 43);
            this.buttonPlaceOrder.TabIndex = 3;
            this.buttonPlaceOrder.Text = "&Place Order";
            this.buttonPlaceOrder.UseVisualStyleBackColor = false;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.buttonPlaceOrder_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.Location = new System.Drawing.Point(515, 411);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(185, 43);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(515, 503);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(185, 43);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // frmLunchOrder
            // 
            this.AcceptButton = this.buttonPlaceOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.BackgroundImage = global::MaratLab1.Properties.Resources.MyBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.buttonReset;
            this.ClientSize = new System.Drawing.Size(778, 595);
            this.Controls.Add(this.groupBoxAddOnPizza);
            this.Controls.Add(this.groupBoxAddOnSalad);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxAddOnHamburger);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.groupBoxOrderTotal);
            this.Controls.Add(this.groupBoxMainCourse);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLunchOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lunch Order";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLunchOrder_Load);
            this.groupBoxMainCourse.ResumeLayout(false);
            this.groupBoxMainCourse.PerformLayout();
            this.groupBoxAddOnHamburger.ResumeLayout(false);
            this.groupBoxAddOnHamburger.PerformLayout();
            this.groupBoxAddOnSalad.ResumeLayout(false);
            this.groupBoxAddOnSalad.PerformLayout();
            this.groupBoxAddOnPizza.ResumeLayout(false);
            this.groupBoxAddOnPizza.PerformLayout();
            this.groupBoxOrderTotal.ResumeLayout(false);
            this.groupBoxOrderTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMainCourse;
        private System.Windows.Forms.RadioButton radioButtonHamburger;
        private System.Windows.Forms.RadioButton radioButtonSalad;
        private System.Windows.Forms.RadioButton radioButtonPizza;
        private System.Windows.Forms.GroupBox groupBoxAddOnHamburger;
        private System.Windows.Forms.CheckBox checkBoxFrenchFries;
        private System.Windows.Forms.CheckBox checkBoxKetchup;
        private System.Windows.Forms.CheckBox checkBoxLettuce;
        private System.Windows.Forms.GroupBox groupBoxOrderTotal;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Label labelOrderTotal;
        private System.Windows.Forms.TextBox textBoxOrderTotal;
        private System.Windows.Forms.TextBox textBoxTax;
        private System.Windows.Forms.TextBox textBoxSubtotal;
        private System.Windows.Forms.Button buttonPlaceOrder;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxAddOnPizza;
        private System.Windows.Forms.CheckBox checkBoxOlives;
        private System.Windows.Forms.CheckBox checkBoxSausage;
        private System.Windows.Forms.CheckBox checkBoxPepperoni;
        private System.Windows.Forms.GroupBox groupBoxAddOnSalad;
        private System.Windows.Forms.CheckBox checkBoxBreadSticks;
        private System.Windows.Forms.CheckBox checkBoxBaconBits;
        private System.Windows.Forms.CheckBox checkBoxCroutons;
    }
}

