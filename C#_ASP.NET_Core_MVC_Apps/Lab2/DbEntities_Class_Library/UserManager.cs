using System.Collections.Generic;
using System.Linq;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file is used for authenticating a user. 
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
    public class UserManager
    {
        private readonly static List<Customer> _customers; // making it available at the class level

        static UserManager()  // initializes static list of users
        {
            //InlandMarinaContext db = new InlandMarinaContext();
            //_customers = db.Customers.ToList();
        }


        /// <summary>
        /// User (a customer) is authenticated based on credentials and a user returned if exists or null if not.
        /// </summary>
        /// <param name="username">Username as string</param>
        /// <param name="password">Password as string</param>
        /// <returns>A Customer class object or null.</returns>
        /// <remarks>
        /// 
        /// </remarks>
        public static Customer Authenticate(string username, string password)
        {
            InlandMarinaContext db = new InlandMarinaContext();
            var user = db.Customers.SingleOrDefault(usr => usr.Username == username
                                                    && usr.Password == password);
            return user; //this will either be null or an object
        }
    }
    
}
