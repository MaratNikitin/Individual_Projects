using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * This class (in a separate class library) represents customers and their electricity usage data
 * Author: Marat Nikitin
 * Attempted to make names of constants and variables self-explanatory to improve clarity of logic
 * SAIT, OOSD program
 * When: December 2021
 */

namespace CustomerDataClassLibrary
{

    /// <summary>
    /// Represents customers and their electricity usage data
    /// </summary>
    public class Customer
    {
        const decimal ADMINISTRATIVE_CHARGE = 12m; // this constant represents the administrative charge
        const decimal PRICE_PER_KWH = 0.07m; // this constant represents price per kWh used

        private int accountNo; // represents account number for a customer
        private string firstName; // represents first name of a customer
        private string lastName; // represents last name of a customer
        private decimal numberKWHUsed; // represents number of kWh used by a customer
        private decimal billAmount; // represents bill amount for a customer (calculated in a method below)

        /// <summary>
        /// Constructor method with parameters and default values
        /// </summary>
        /// <param name="accountNo">Account Number (Auto-Generated) </param>
        /// <param name="firstName"> Customer's First Name</param>
        /// <param name="lastName">Customer's Last Name</param>
        /// <param name="numberKWHUsed">Number of kWh Used</param>
        /// <param name="billAmount"> Bill Amount, $</param>
        public Customer (int accountNo = 0, string firstName = "Unknown", string lastName = "Unknown", decimal numberKWHUsed = 0m, decimal billAmount = 0m)
        {
            this.accountNo = accountNo;
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberKWHUsed = numberKWHUsed;
            this.billAmount = billAmount;
        }

        // public properties - controlled access to the private data
        public int AccountNo { get; set; } // auto-implemented property (unnamed private variable is automatically created)
        public string FirstName { get; set; } // auto-implemented property (unnamed private variable is automatically created)
        public string LastName { get; set; } // auto-implemented property (unnamed private variable is automatically created)
        public decimal NumberKWHUsed { get; set; } // auto-implemented property (unnamed private variable is automatically created)
        public decimal BillAmount { get; set; } // auto-implemented property (unnamed private variable is automatically created)
        public string Name { get; set; } // auto-implemented property (unnamed private variable is automatically created)

        /// <summary>
        /// This method calculates billAmount value based on the number of kWh used input value
        /// </summary>
        /// <param name="numberKWHUsed"> number of kWh used value as a decimal number </param>
        /// <returns> billAmount value </returns>
        public decimal CalculateCharge(decimal numberKWHUsed)
        {
            decimal billAmount = ADMINISTRATIVE_CHARGE + PRICE_PER_KWH * numberKWHUsed;
            return billAmount;
        }

        /// <summary>
        /// It's the redefined (overridden) ToString() method to display Customer class objects meaningfully
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{accountNo}, {firstName} {lastName}, {numberKWHUsed}kWh, " +
                $"bill: {billAmount.ToString("c")}";
        }
    }
}
