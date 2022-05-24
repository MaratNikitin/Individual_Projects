using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This class (entity) was automatically generated from the "Registrations" table of the DB 
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
    public partial class Registrations
    {
        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Key]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Registrations))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(ProductCode))]
        [InverseProperty(nameof(Products.Registrations))]
        public virtual Products ProductCodeNavigation { get; set; }
    }
}
