using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerDataClassLibrary; // this allows using classes from the CustomerDataClassLibrary

/*
 * This project creates a form for accepting data on electricity usage by customers, displays the list & number of customers,
 *   displays electricity usage statistics while interacting with other projects in the solution.
 * Author: Marat Nikitin
 * Attempted to make names of constants and variables self-explanatory to improve clarity of logic
 * SAIT, OOSD course
 * When: December 2021
 */

namespace MaratLabAssignment2
{
    public partial class ElectricityBills : Form
    {
       decimal billAmount = 0m; // represents calculated bill amount 
       decimal numberKWHUsed = 0m; // represents number of kWh used by a customer
       int counterForAccountNo = 1; // represents Customer Account Number (auto-generated value) & number of customers processed
       decimal totalKWHUsed = 0m; // represents the sum of kWh used by all entered customers
       decimal averageBillValue = 0m; // represents the average bill value for all entered customers
       decimal totalOfBillValues = 0m; // represents sum of bill value for all entered customers
       List<Customer> listOfCustomers = new List<Customer>(); // empty list for Customer class objects is defined   
        
        public ElectricityBills()
        {
            InitializeComponent();
        }
            
        // when the form (app) loads:
        private void ElectricityBills_Load(object sender, EventArgs e)
        {
            // Default initial statistics values are displayed when the form is loaded
            textBoxAverageBillAmount.Text = "N/A";
            textBoxNumberOfCustomers.Text = "0";
            textBoxTotalKWHUsed.Text = "0";

            /* when the app starts, there is no customer data submitted yet, so appropriate 
                * information about it is displayed:*/
            textBoxAccountNumber.Text = "N/A";
            textBoxBillAmount.Text = "N/A";

            textBoxFirstName.Focus(); /* focus is attempted to be set on the uppermost text box for new data entry - 
                                       * for some reason, it doesn't work, so the next code line was tried */
            textBoxFirstName.Text = ""; /* focus is attempted to be set on the uppermost text box for new data entry - 
                                       * for some reason, it doesn't work, so the next code line was tried */
            this.ActiveControl = textBoxFirstName; // finally, this way it worked! :)
        }

        // when the "Submit Data" button is pushed (most of the magic happens here)
        private void buttonEnterCustomerData_Click(object sender, EventArgs e)
        {            
            if // data validations are done first, before anything else happens
            (
                Validator.IsPresent(textBoxFirstName) && // validating that first name is entered
                Validator.IsPresent(textBoxLastName) && // validating that last name is entered
                Validator.IsPresent(textBoxNumberOfKWHUsed) && // validating that last name is entered
                Validator.IsNonNegativeDecimal(textBoxNumberOfKWHUsed) // validating that non-negative decimal value of kWh is entered
            )
            { // all of these operations in the block below happen only if data validation passes successfully          
                Customer newCustomerToRunCalculateChargeMethod = new Customer (88, "noname", "noname", 88m, 88m);
                // this new Customer class object above is instantiated only to run the CalculateCaherge() method below
            
                numberKWHUsed = Convert.ToDecimal(textBoxNumberOfKWHUsed.Text); // value taken from the textbox
            
                billAmount = newCustomerToRunCalculateChargeMethod.CalculateCharge(numberKWHUsed); /* this value is generated using
                    a method where the name for newCustomerToRunCalculateChargeMethod speaks for itself. Since billAmount is a calculated 
                    value, it was critical to be calculated before before creating the newCustomer object (see it below) */
            
                Customer newCustomer = new Customer(counterForAccountNo, textBoxFirstName.Text, textBoxLastName.Text, 
                    Convert.ToDecimal(textBoxNumberOfKWHUsed.Text), billAmount); 
                    // this newCustomer object above is created representing each new customer to be added to a list
            
                listOfCustomers.Add(newCustomer); // the new customer information is added to the listOfCustomers list
            
                dataGridViewCustomers.Rows.Add(newCustomer); // a new line with the newly entered customer's data is displayed
            
                textBoxAccountNumber.Text = counterForAccountNo.ToString() + " (" +
                    textBoxFirstName.Text + " " + textBoxLastName.Text + ")";
                // account number for the new customer is displayed with customer's name to avoid misinterpretation

                textBoxBillAmount.Text = billAmount.ToString("c") + " (" +
                    textBoxFirstName.Text + " " + textBoxLastName.Text + ")"; 
                // calculated bill amount for the latest entered customer is displayed with customer's name to avoid misinterpretation
            
                textBoxNumberOfCustomers.Text = counterForAccountNo.ToString(); // number of customers processed is displayed
            
                totalKWHUsed += numberKWHUsed; // total of kWh used by all customers us updated
            
                textBoxTotalKWHUsed.Text = totalKWHUsed.ToString(); // total of kWh used by all customers us displayed
            
                totalOfBillValues += billAmount; // this value is needed for counting average bill value

                averageBillValue = totalOfBillValues / counterForAccountNo; // average bill amount is calculated

                textBoxAverageBillAmount.Text = averageBillValue.ToString("c"); // average bill amount is displayed            

                /* these three lines below ensure that duplicating customer's data is not entered by mistake;
                 * e.g. duplicating can happen after entering valid data and pressing "Enter" key or "Submit Data" button twice */
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                textBoxNumberOfKWHUsed.Text = "";

                textBoxFirstName.Focus(); // focus is set on the uppermost cleared text box for new data entry

                counterForAccountNo++; // customer account number is incremented only after all parameters are calculated
            }
        }

        // when the "Exit" button is pushed
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // the application is closed
        }

        // when the "Reset" button is pushed
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // all textboxs with data for the latest customer are emptied below
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxNumberOfKWHUsed.Text = "";

            // textBoxBillAmount.Text = ""; //not sure if this line of code should be used (user's opinion is needed)
            // textBoxAccountNumber.Text = ""; //not sure if this line of code should be used (user's opinion is needed)

            textBoxFirstName.Focus(); // focus is set on the uppermost text box for data entry 
        }        
    }
}
