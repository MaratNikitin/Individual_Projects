using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This file contains the Customer class representing the Customer table of the InlandMarina database
 * Author: Marat Nikitin (created class library and this class and then copy-pasted Jolanta's code)
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
	public class Customer
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Please enter first name")]
		[StringLength(30)]
		[Display(Name = "First Name")] //this quoted name is displayed in a column header 
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter last name")]
		[StringLength(30)]
		[Display(Name = "Last Name")] //this quoted name is displayed in a column header 
		public string LastName { get; set; }

		[Required]
		[StringLength(15)]
		[RegularExpression(@"\d{3}-\d{3}-\d{4}",
		 ErrorMessage = "Please enter phone number in XXX-XXX-XXXX format")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter city")]
		[StringLength(30)]
		public string City { get; set; }

		[Required(ErrorMessage = "Please enter username")]
		[StringLength(30)]
		public string Username { get; set; }

		[Required(ErrorMessage = "Please enter password")]
		[Compare("ConfirmPassword")]
		[StringLength(30)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please confirm your password.")]
		[Display(Name = "Confirm Password")]
		[NotMapped] // excluding from DB tracking
		public string ConfirmPassword { get; set; }

		// navigation property
		public virtual ICollection<Lease> Leases { get; set; }
	}
}
