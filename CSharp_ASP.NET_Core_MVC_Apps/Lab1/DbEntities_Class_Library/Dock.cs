using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
 * see contact information, see available slips with the option of selecting them by dock
 * This file contains the Dock class representing the Dock table of the InlandMarina database
 * Author: Marat Nikitin (created class library and this class and then copy-pasted Jolanta's code)
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
 */

namespace DbEntities_Class_Library
{
    [Table("Dock")]
    public class Dock
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public bool WaterService { get; set; }
        public bool ElectricalService { get; set; }

        // navigation property
        public virtual ICollection<Slip> Slips { get; set; }
    }
}
