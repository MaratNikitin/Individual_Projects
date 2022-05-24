using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * This class is a repository of user input validation methods used in this Windows Forms project
 * Author: Marat Nikitin, although this file is based on examples of Jolanta Warpechowska-Gruca
 * SAIT, OOSD program
 * When: December 2021
 */

namespace MaratLabAssignment2
{
    /// <summary>
    /// This class is a repository of user input validation methods for Windows Forms projects
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// This method validates if text box is not empty
        /// </summary>
        /// <param name="tb"> text box to validate</param>
        /// <returns> true if not empty and false if empty </returns>
        public static bool IsPresent(TextBox tb)
        {
            bool isValid = true; // not guilty until proven otherwise
            if(tb.Text == "") // it means that the textbox is empty
            {
                isValid = false; // it's a fail
                MessageBox.Show(tb.Tag + " is required", "Missing Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning); // helpful message for a user
                tb.Focus(); // assisting a user in finding the problematic text box by focusing on it
            }
            return isValid;
        }       

        /// <summary>
        /// This method validates if a text box contains non-negative decimal value
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox tb)
        {
            bool isValid = true; // not guilty until proven otherwise
            decimal result; // for TryParse
            if (!Decimal.TryParse(tb.Text, out result)) // TryParse returned false
            {
                isValid = false; // it's a fail
                MessageBox.Show(tb.Tag + " must be a number", "Unacceptable Number", MessageBoxButtons.OK, MessageBoxIcon.Warning); // helpful message for a user
                tb.SelectAll(); // select all content for replacement
                tb.Focus(); // assisting a user in finding the problematic text box by focusing on it
            }
            else // it's decimal value, but could be negative
            {
                if (result < 0) // it means we have a negative value
                {
                    isValid = false; // it's a fail
                    MessageBox.Show(tb.Tag + " must be positive or zero", "Unacceptable Number", MessageBoxButtons.OK, MessageBoxIcon.Warning); // helpful message for a user
                    tb.SelectAll(); // select all content for replacement
                    tb.Focus(); // assisting a user in finding the problematic text box by focusing on it
                }
            }
            return isValid;
        }        
    }
}
