using System.ComponentModel.DataAnnotations;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file contains a class describing display parameters of slips
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace ASP_NET_Core_MVC_Lab1.Models
{
    public class SlipDockLeaseViewModel
    {
        [Display(Name = "Slip ID")] //this quoted name is displayed in a column header 
        public int SlipID { get; set; }

        [Display(Name = "Width, ft")] //this quoted name is displayed in a column header
        public int Width { get; set; }

        [Display(Name = "Length, ft")] //this quoted name is displayed in a column header
        public int Length { get; set; }

        [Display(Name = "Dock Name")] //this quoted name is displayed in a column header
        public string DockName { get; set; }

        [Display(Name = "Water Service")] //this quoted name is displayed in a column header
        public bool WaterService { get; set; }

        [Display(Name = "Electrical Service")] //this quoted name is displayed in a column header
        public bool ElectricalService { get; set; }
    }

    
}
