using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file contains a class describing display parameters of leases (used on MySlips page) and includes data 
    from several tables of the DB
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */


namespace DbEntities_Class_Library
{
    public class LeaseSlipViewModel
    {
        [Display(Name = "Lease ID")] //this quoted name is displayed in a column header 
        public int LeaseID { get; set; }

        [Display(Name = "Slip ID")]
        public int SlipID { get; set; }
                
        public int Width { get; set; }
        public int Length { get; set; }

        [Display(Name = "Dock Name")]
        public string DockName { get; set; }

        [Display(Name = "Water Service")]
        public bool WaterService { get; set; }
        
        [Display(Name = "Electrical Service")]
        public bool ElectricalService { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone #")]
        public string Phone { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }
    }
}
