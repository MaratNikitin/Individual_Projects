using System;
using System.Windows.Forms;
using MaratLab3.Models;

/*
 * This app is created for doing CRUD operations with the 'Products' table of the 'TechSupport' database.
 * This is the second (modal) form of the application allowing adding or modifying rows of the 'Products' 
 *  table of the database
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

namespace MaratLab3
{
    public partial class frmSecond : Form
    {
        public Products Product { get; set; } // represents an instance of a Products class, used for transferring data from the Main form to the Second form
        public bool AddProduct { get; set; } // this parameter saves the "true" value when the "Add" button is pressed in the
                                             // Main form; saves the "false" value when the "Modify" button was pressed there

        public frmSecond()
        {
            InitializeComponent();  // initializing the form's content
        }

        // when the Second (modal) form loads (which happens after clicking "Add" or "Modify" button of the main form)
        private void frmSecond_Load(object sender, EventArgs e)
        {
            if (this.AddProduct == true) // it means that the "Add" button of the main form was clicked
            {
                this.Text = "Add Product"; // that text is displayed at the top of the Second form
            }
            else // it means that the "Modify" button of the main form was clicked
            {
                this.Text = "Modify Product"; // that text is displayed at the top of the Second form
                DisplaySelectedProduct(); // contents of a row selected in the ListBox before pressing
                                               //  the "Modify" button are displayed in the second form
                textBoxProductCode.Enabled = false; // making sure that the ID column can not be changed by a user
            }
        }

        // when the "Ok" button was clicked
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IsValidData()) // it means that all the data validation criteria are met
            {
                if (this.AddProduct == true) // It means that the "Add" option was chosen
                {
                    this.Product = new Products(); // a new instance of the Products class is created
                }
                LoadProductData(); // it's a custom-made function described below
                this.DialogResult = DialogResult.OK; // it's used in the Main form
            }
        }

        // when the cancel button is clicked
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // the Second (modal) form closes
        }

        /// <summary>
        /// Custom-made method saving data from the textboxes inside the 'Product' instance of a 'Products' class
        /// </summary>
        private void LoadProductData()
        {
            Product.ProductCode = textBoxProductCode.Text; // 'ProductCode' value is retrieved using data entered in the appropriate textbox
            Product.Name = textBoxName.Text; // 'Name' value is retrieved using data entered in the appropriate textbox
            Product.Version = Convert.ToDecimal(textBoxVersion.Text); // 'Version' value is retrieved using data entered in the appropriate textbox
            Product.ReleaseDate = Convert.ToDateTime(textBoxReleaseDate.Text); // 'ReleaseDate' value is retrieved using data entered in the appropriate textbox
        }

        /// <summary>
        /// This custom-made method validates data entered in the textboxes of the Second (modal) form
        /// </summary>
        /// <returns>List of validation error messages</returns>
        private bool IsValidData()
        {
            bool success = true; // not guilty until proven otherwise - this parameter stays true when validation is successful
            string errorMessage = ""; // beginning from a blank slate

            // checking if all the textboxes contain at least some data:
            errorMessage += Validator.IsPresent(textBoxProductCode.Text, textBoxProductCode.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxName.Text, textBoxName.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxVersion.Text, textBoxVersion.Tag.ToString());
            errorMessage += Validator.IsPresent(textBoxReleaseDate.Text, textBoxReleaseDate.Tag.ToString());

            // checking if the textbox for "Version" contains a decimal number:
            errorMessage += Validator.IsDecimal(textBoxVersion.Text, textBoxVersion.Tag.ToString());

            // checking if the textbox for "ReleaseDate" contains a valid date:
            errorMessage += Validator.IsValidDate(textBoxReleaseDate.Text, textBoxReleaseDate.Tag.ToString());

            // checking if the numbers of characters in the textboxes do not exceed the maximum allowed values set in the database
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(textBoxProductCode.Text, textBoxProductCode.Tag.ToString(), 10);
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(textBoxName.Name, textBoxName.Tag.ToString(), 50);
            errorMessage += Validator.IsWithinAllowedRangeOfCharacters(textBoxVersion.Text, textBoxVersion.Tag.ToString(), 18);

            if (errorMessage != "") // it means that at least one validation criterion was not met
            {
                success = false; // it's a fail
                MessageBox.Show(errorMessage, "Entry Error"); // precious feedback to a user listing all the validation failures
            }
            return success; // "true" value of the "success" if validation passed and "false" if validation failed
        }        

        /// <summary>
        /// Custom-made method populating textboxes of the Second form for their further update
        /// </summary>
        private void DisplaySelectedProduct()
        {
            textBoxProductCode.Text = Product.ProductCode; // selected row's 'ProductCode' value is displayed in the appropriate text box of the Second form
            textBoxName.Text = Product.Name; // selected row's 'Name' value is displayed in the appropriate text box of the Second form
            textBoxVersion.Text = Product.Version.ToString(); // selected row's 'Version' value is displayed in the appropriate text box of the Second form 
            textBoxReleaseDate.Text = Product.ReleaseDate.ToShortDateString(); // selected row's 'ReleaseDate' value is displayed in the appropriate text box of the Second form
        }
    }
}
