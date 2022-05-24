using CustomerDataClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This is a repository of tests for the CalculateCharge() method in the Customer class 
 * Author: Marat Nikitin
 * SAIT, OOSD program
 * When: December 2021
 */

namespace UnitTest
{
    [TestClass()]
    public class CustomerTests
    {
        /// <summary>
        /// Testing if the calculated bill amount is correct for 100 kWh used
        /// </summary>
        [TestMethod()]
        public void CalculatedBillValueIsCorrectAt100Test()
        {
            // arrange
            Customer cust1 = new Customer(1, "John", "Doe", 100, 19);
            // this class object above is initiated only to activate the CalculateCharge() method
            decimal numberOfKWHUsed = 100m; // represents number of kWh used by a customer
            decimal expectedBillAmount = 19m; // represents the expected bill amount 
            decimal actualBillAmount; // represents the calculated bill amount, i.e. using CalculateCharge() method

            // act
            actualBillAmount = cust1.CalculateCharge(numberOfKWHUsed); // calculating bill amount using the method
            
            // assert
            Assert.AreEqual(expectedBillAmount, actualBillAmount); // comparing the expected and calculated value
        }

        /// <summary>
        /// Testing if the calculated bill is correct for 0 kWh used
        /// </summary>
        [TestMethod()]
        public void CalculatedBillValueIsCorrectAtZeroTest()
        {
            // arrange
            Customer cust1 = new Customer(1, "John", "Doe", 100, 19);
            // this class object above is initiated only to activate the CalculateCharge() method
            decimal numberOfKWHUsed = 0m; // represents number of kWh used by a customer
            decimal expectedBillAmount = 12m; // represents the expected bill amount 
            decimal actualBillAmount; // represents the calculated bill amount, i.e. using CalculateCharge() method

            // act
            actualBillAmount = cust1.CalculateCharge(numberOfKWHUsed); // calculating bill amount using the method

            // assert
            Assert.AreEqual(expectedBillAmount, actualBillAmount); // comparing the expected and calculated value
        }

        /// <summary>
        /// Testing if the calculated bill amount is correct for 300 kWh used
        /// </summary>
        [TestMethod()]
        public void CalculatedBillValueIsCorrectAt300Test()
        {
            // arrange
            Customer cust1 = new Customer(1, "John", "Doe", 100, 19);
            // this class object above is initiated only to activate the CalculateCharge() method
            decimal numberOfKWHUsed = 300m; // represents number of kWh used by a customer
            decimal expectedBillAmount = 33m; // represents the expected bill amount 
            decimal actualBillAmount; // represents the calculated bill amount, i.e. using CalculateCharge() method

            // act
            actualBillAmount = cust1.CalculateCharge(numberOfKWHUsed); // calculating bill amount using the method

            // assert
            Assert.AreEqual(expectedBillAmount, actualBillAmount); // comparing the expected and calculated value
        }
    }
}