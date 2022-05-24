 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * This app creates a form for accepting a lunch order while giving a customer a variety of options
 * One main course only can be selected, and various add-ons are offered for each main course
 * Author: Marat Nikitin
 * Attempted to make names of constants and variables self-explanatory to improve clarity of logic
 * SAIT, OOSD course
 * When: December 2021
 */

namespace MaratLab1
{
    public partial class frmLunchOrder : Form
    {
        /* Names of the constants below are self-explanatory */
        const decimal HAMBURGER_PRICE = 6.95m; // price value in dollars
        const decimal PIZZA_PRICE = 5.95m; // price value in dollars
        const decimal SALAD_PRICE = 4.95m; // price value in dollars
        const decimal HAMBURGER_ADD_ONS_PRICE = 0.75m; // price value in dollars
        const decimal PIZZA_ADD_ONS_PRICE = 0.50m; // price value in dollars
        const decimal SALAD_ADD_ONS_PRICE = 0.25m; // price value in dollars
        const decimal TAX_RATE = 5m; /* The tax value is entered in percents, i.e. the tax rate is 5% here. It was taken into 
                                      * consideration in calculations where this constant is used*/

        int mainCourseChosen; /* This value will be 1 for Hamburger, 2 for Pizza or 3 for Salad. 
                               * It's introduced to distinguish which main course was chosen. */
        int numberOfAddOns = 0;  /* This parameter is introduced as a counter for add-on options chosen. 
                             It allows to calculate the number of checked add-ons. */

        /* I tried to delete this block of code below and regretted it immediately after as my 
          form window simply disappeared. It was a great learning experience though. :) */
        public frmLunchOrder()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // The application is closed when the "Exit" button is pressed
        }

        /* When the Hamburger radio button option is chosen, this block of code below is activated */
        private void radioButtonHamburger_CheckedChanged(object sender, EventArgs e)
        {
            // add on options for hamburger become visible once hamburger is chosen
            // the other irrelevant add-on options are hidden
            groupBoxAddOnHamburger.Visible = true;
            groupBoxAddOnPizza.Visible = false;
            groupBoxAddOnSalad.Visible = false;
            mainCourseChosen = 1; // It's a code number for hamburger
            /* All the irrelevant add-on checkboxes of the other main course meals are forcefully unchecked below. This block is needed
             * to avoid incorrect price display in cases when customer chooses a main course, then some add-ons for it, and then changes
             his/her mind amout the main course */
            checkBoxPepperoni.Checked = false;
            checkBoxSausage.Checked = false;
            checkBoxOlives.Checked = false;
            checkBoxCroutons.Checked = false;
            checkBoxBaconBits.Checked = false;
            checkBoxBreadSticks.Checked = false;
        }

        /* When the Pizza radio button option is chosen, this block of code below is activated */
        private void radioButtonPizza_CheckedChanged(object sender, EventArgs e)
        {
            // add on options for pizza become visible once pizza is chosen
            // the other irrelevant add-on options are hidden
            groupBoxAddOnHamburger.Visible = false;
            groupBoxAddOnPizza.Visible = true;
            groupBoxAddOnSalad.Visible = false;
            mainCourseChosen = 2; // It's a code number for pizza 
            /* All the irrelevant add-on checkboxes of the other main course meals are forcefully unchecked below. This block is needed
             * to avoid incorrect price display in cases when customer chooses a main course, then some add-ons for it, and then changes
             his/her mind amout the main course */
            checkBoxLettuce.Checked = false;
            checkBoxKetchup.Checked = false;
            checkBoxFrenchFries.Checked = false;
            checkBoxCroutons.Checked = false;
            checkBoxBaconBits.Checked = false;
            checkBoxBreadSticks.Checked = false;
        }

        /* When the Salad radio button option is chosen, this block of code below is activated */
        private void radioButtonSalad_CheckedChanged(object sender, EventArgs e)
        {
            // add on options for salad become visible once salad is chosen
            // the other irrelevant add-on options are hidden
            groupBoxAddOnHamburger.Visible = false;
            groupBoxAddOnPizza.Visible = false;
            groupBoxAddOnSalad.Visible = true;
            mainCourseChosen = 3; // It's a code number for salad 

            /* All the irrelevant add-on checkboxes of the other main course meals are forcefully unchecked below. This block is needed
             * to avoid incorrect price display in cases when customer chooses a main course, then some add-ons for it, and then changes
             his/her mind amout the main course */
            checkBoxLettuce.Checked = false;
            checkBoxKetchup.Checked = false;
            checkBoxFrenchFries.Checked = false;
            checkBoxPepperoni.Checked = false;
            checkBoxSausage.Checked = false;
            checkBoxOlives.Checked = false;
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            decimal subtotalValue = 0m; // this parameter is used to calculate the Subtotal value
            decimal taxValue = 0m; // this parameter is used to calculate the Tax value
            decimal orderTotalValue = 0m; // // this parameter is used to calculate the Order Total value (i.e. the sum to be paid by a customer)
            numberOfAddOns = 0; // It allows to reset the counter each time when the Place Order button is pressed
            // below we find out how many add-ons were chosen by counting each checked add-on checkbox of each main course
            if (checkBoxLettuce.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++; // the counter is incremented by one
            }
            if (checkBoxKetchup.CheckState == CheckState.Checked)
            {
                numberOfAddOns++;
            }
            if (checkBoxFrenchFries.CheckState == CheckState.Checked)
            {
                numberOfAddOns++;
            }
            if (checkBoxPepperoni.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }
            if (checkBoxSausage.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }
            if (checkBoxOlives.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }
            if (checkBoxCroutons.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }
            if (checkBoxBaconBits.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }
            if (checkBoxBreadSticks.CheckState == CheckState.Checked) 
            {
                numberOfAddOns++;
            }

            /* Below we calculate the Subtotal value based on customer's choices */
            if (mainCourseChosen == 1) // if it's true, it means that hamburger was chosen
            {
                subtotalValue = HAMBURGER_PRICE + numberOfAddOns * HAMBURGER_ADD_ONS_PRICE;
            }
            if (mainCourseChosen == 2) // if it's true, it means that pizza was chosen
            {
                subtotalValue = PIZZA_PRICE + numberOfAddOns * PIZZA_ADD_ONS_PRICE;
            }
            if (mainCourseChosen == 3) // if it's true, it means that salad was chosen
            {
                subtotalValue = SALAD_PRICE + numberOfAddOns * SALAD_ADD_ONS_PRICE;
            }

            textBoxSubtotal.Text = subtotalValue.ToString("c"); // Subtotal value is entered in it's text area in the form in the cyrrency format

            CalculateTaxAmountAndTotal(subtotalValue, out taxValue, out orderTotalValue); // the method with two out parameters is used here

            textBoxTax.Text = taxValue.ToString("c"); // Tax value is entered in it's text area of the form in the currency format

            // orderTotalValue = subtotalValue + taxValue; // the Order Total value was calculated here originally, before using a method
            
            textBoxOrderTotal.Text = orderTotalValue.ToString("c"); // Order Total value is entered in it's text area
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            /* When the Reset button is pressed, the main course is set to the default hamburger option, 
             all the calculated values are cleared and all check-boxes are unchecked */
            radioButtonHamburger.Checked = true; // this radio button is checked by default when resetting the form
            checkBoxLettuce.Checked = false;
            checkBoxKetchup.Checked = false;
            checkBoxFrenchFries.Checked = false;
            checkBoxPepperoni.Checked = false;
            checkBoxSausage.Checked = false;
            checkBoxOlives.Checked = false;
            checkBoxCroutons.Checked = false;
            checkBoxBaconBits.Checked = false;
            checkBoxBreadSticks.Checked = false;
            textBoxSubtotal.Text = ""; // empty string value is inserted instead of the previous value
            textBoxTax.Text = ""; // empty string value is inserted instead of the previous value
            textBoxOrderTotal.Text = ""; // empty string value is inserted instead of the previous value
        }

        // As the application starts:
        private void frmLunchOrder_Load(object sender, EventArgs e)
        {
            /* In the 6 lines of code below I make sure that actual prices taken from the constant values
             * are displayed, i.e. these values are not hard-coded. When we update the constants' values,
             * these prices in the form display are updated automatically */
            groupBoxAddOnHamburger.Text = $"Add-On Items (Hamburger) ({HAMBURGER_ADD_ONS_PRICE.ToString("c")}/each)";
            groupBoxAddOnPizza.Text = $"Add-On Items (Pizza) ({PIZZA_ADD_ONS_PRICE.ToString("c")}/each)";
            groupBoxAddOnSalad.Text = $"Add-On Items (Salad) ({SALAD_ADD_ONS_PRICE.ToString("c")}/each)";
            radioButtonHamburger.Text = $"Hamburger - {HAMBURGER_PRICE.ToString("c")}";
            radioButtonPizza.Text = $"Pizza - {PIZZA_PRICE.ToString("c")}";
            radioButtonSalad.Text = $"Salad - {SALAD_PRICE.ToString("c")}";
        }

        /* The method below was created for returning the amount of tax and the order total value as out parameters */
        private void CalculateTaxAmountAndTotal(decimal subtotalValue, out decimal taxValue, out decimal orderTotalValue)
        {
            taxValue = subtotalValue * TAX_RATE / 100; /* tax value is calculated here, division by 100 is used
                                                                * because the TAX_RATE is in percents */
            orderTotalValue = subtotalValue * (1 + TAX_RATE / 100); // Order Total Value is calculated here
        }
    }
}
