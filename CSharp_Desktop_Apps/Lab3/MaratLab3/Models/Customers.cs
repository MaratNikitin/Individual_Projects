using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This class (entity) was automatically generated from the "Customers" table of the DB 
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
    public partial class Customers
    {
        public Customers()
        {
            Incidents = new HashSet<Incidents>();
            Registrations = new HashSet<Registrations>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [StringLength(9)]
        public string ZipCode { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [ForeignKey(nameof(State))]
        [InverseProperty(nameof(States.Customers))]
        public virtual States StateNavigation { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Incidents> Incidents { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Registrations> Registrations { get; set; }
    }
}
