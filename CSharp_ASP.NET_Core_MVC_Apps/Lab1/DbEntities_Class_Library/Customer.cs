using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
 * see contact information, see available slips with the option of selecting them by dock
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

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[StringLength(15)]
		public string Phone { get; set; }

		[Required]
		[StringLength(30)]
		public string City { get; set; }

		// navigation property
		public virtual ICollection<Lease> Leases { get; set; }
	}
}
