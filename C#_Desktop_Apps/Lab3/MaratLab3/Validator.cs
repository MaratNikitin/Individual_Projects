using System;

/*
 * This app is created for doing CRUD operations with the 'Products' table of the 'TechSupport' database.
 * This file contains all the data validation methods used in this project.
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

namespace MaratLab3
{
    public static class Validator
	{
        public static string LineEnd { get; set; } = "\n"; // it's a way of inserting line end symbol

        /// <summary>
        /// This validation method checks if data is entered inside a control
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user about missing required data </returns>
        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks if data entered inside a control can be converted into a decimal number
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user reminding that a decimal number is needed </returns>
        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a valid decimal value." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks if data entered inside a control can be converted into a DateTime value
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <returns> A message string for a user reminding that a DateTime value is needed </returns>
        public static string IsValidDate(string value, string name)
        {
            string msg = "";
            if (!DateTime.TryParse(value, out _))
            {
                msg += name + " must be a valid date." + LineEnd;
            }
            return msg;
        }

        /// <summary>
        /// This validation method checks that data entered inside a control doesn't exceed the maximum number of characters allowed for its database column
        /// </summary>
        /// <param name="value"> Value from a control to be validated </param>
        /// <param name="name"> Tag name of the control </param>
        /// <param name="maxAllowedNumberOfCharacters"> Maximum allowed number of characters for the database's column </param>
        /// <returns> A message string for a user reminding that number of characters for the DB column is limited </returns>
        public static string IsWithinAllowedRangeOfCharacters(string value, string name, int maxAllowedNumberOfCharacters)
        {
            string msg = "";
            if (value.Length > maxAllowedNumberOfCharacters)
            {
                msg += name + " can not have more than " + maxAllowedNumberOfCharacters + 
                    " characters because of the database's column design restriction." + LineEnd;
            }
            return msg;
        }

    }
}
