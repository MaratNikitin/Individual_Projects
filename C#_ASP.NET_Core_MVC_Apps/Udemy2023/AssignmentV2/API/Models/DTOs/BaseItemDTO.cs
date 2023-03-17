using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
