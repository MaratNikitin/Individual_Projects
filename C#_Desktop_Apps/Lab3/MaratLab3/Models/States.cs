using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This class (entity) was automatically generated from the "States" table of the DB 
 * using Entity Framework Core Database First - this class is not used in the project
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MaratLab3.Models
{
    public partial class States
    {
        public States()
        {
            Customers = new HashSet<Customers>();
        }

        [Key]
        [StringLength(2)]
        public string StateCode { get; set; }
        [Required]
        [StringLength(20)]
        public string StateName { get; set; }
        public int FirstZipCode { get; set; }
        public int LastZipCode { get; set; }

        [InverseProperty("StateNavigation")]
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
