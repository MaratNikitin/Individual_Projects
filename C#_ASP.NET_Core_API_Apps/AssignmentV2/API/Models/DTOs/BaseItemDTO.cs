using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/*
 * This ASP.NET7 Web API app allows sharing items coming from a SQL Server database 
    using Entity Framework Core; full range of CRUD operations for Items is enabled.
 *  This is the base class of other DTOs - it has properties shared by all its child class DTOs.
 * Author: Marat Nikitin
 * Assignment
 * When: March 2023
 */

namespace API.Models.DTOs
{
    public class BaseItemDTO
    {

        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal ItemValue { get; set; }

    }
}
