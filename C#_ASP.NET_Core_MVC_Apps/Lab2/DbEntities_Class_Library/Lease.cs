using System.ComponentModel.DataAnnotations.Schema;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file contains the Lease class representing the Lease table of the InlandMarina database
 * Author: Marat Nikitin (created class library and this class and then copy-pasted Jolanta's code)
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
    [Table("Lease")]
    public class Lease
    {
        public int ID { get; set; }
        public int SlipID { get; set; }
        public int CustomerID { get; set; }

        //navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Slip Slip { get; set; }
    }
}
