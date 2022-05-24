using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This class (entity) was automatically generated from the "Products" table of the DB 
 * using Entity Framework Core Database First. Then ToString() method was overrridden in the bottom of this file
 * to allow appropriate display of information from the "Products" table inside the Listbox control of the Main form
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MaratLab3.Models
{
    public partial class Products
    {
        public Products()
        {
            Incidents = new HashSet<Incidents>();
            Registrations = new HashSet<Registrations>();
        }

        [Key]
        [StringLength(10)]
        public string ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 1)")]
        public decimal Version { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }

        [InverseProperty("ProductCodeNavigation")]
        public virtual ICollection<Incidents> Incidents { get; set; }
        [InverseProperty("ProductCodeNavigation")]
        public virtual ICollection<Registrations> Registrations { get; set; }

        /// <summary>
        /// Overriding ToString() method allows meaningful display of data from the "Products" table of the TechSupport database
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ProductCode.PadRight(15) + this.Name.PadRight(34) + this.Version.ToString().PadRight(10) + this.ReleaseDate.ToString("MMM.dd, yyyy").PadRight(20);
        }
    }
}
