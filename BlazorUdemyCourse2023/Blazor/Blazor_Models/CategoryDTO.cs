using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The category name is required...")]
        public string Name { get; set; }
    }
}
