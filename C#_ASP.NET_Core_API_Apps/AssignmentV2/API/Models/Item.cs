using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public partial class Item
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(100)]
    public string ItemName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal ItemValue { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Items")]
    public virtual Category Category { get; set; } = null!;
}
