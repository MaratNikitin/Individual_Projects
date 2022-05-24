using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This class (entity) was automatically generated from the "Incidents" table of the DB 
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
    public partial class Incidents
    {
        [Key]
        [Column("IncidentID")]
        public int IncidentId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Column("TechID")]
        public int? TechId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOpened { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateClosed { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Incidents))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(ProductCode))]
        [InverseProperty(nameof(Products.Incidents))]
        public virtual Products ProductCodeNavigation { get; set; }
        [ForeignKey(nameof(TechId))]
        [InverseProperty(nameof(Technicians.Incidents))]
        public virtual Technicians Tech { get; set; }
    }
}
