using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required] // validating input data:
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }

        [Required] // validating input data
        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Expense Amount, $")]
        [Range(0, 1000000000, ErrorMessage = "Expense amount must be positive")] // validating input data
        public decimal ExpenseAmount { get; set; }
    }
}
