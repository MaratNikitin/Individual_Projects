using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file contains the Slip class representing the Slip table of the InlandMarina database
 * Author: Marat Nikitin (created class library and this class and then copy-pasted Jolanta's code)
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
    [Table("Slip")]
    public class Slip
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int DockID { get; set; }

        // navigation properties
        public virtual Dock Dock { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}
