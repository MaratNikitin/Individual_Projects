using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class UpdateItemDTO : BaseItemDTO
    {
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
    }
}
