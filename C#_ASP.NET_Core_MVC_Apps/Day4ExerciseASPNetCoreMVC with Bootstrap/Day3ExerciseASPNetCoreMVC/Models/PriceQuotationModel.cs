using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Day3ExerciseASPNetCoreMVC.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter the Subtotal value.")]
        [Range(0.000001, Double.MaxValue, ErrorMessage =
               "Subtotal value must be greater than 0")]
        public decimal? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter the Discount Percent value.")]
        [Range(0, 100, ErrorMessage =
               "Discount percent value must be 0-100")]
        public decimal? DiscountPct { get; set; }


        public decimal? DiscountAmt { get; set; }


        public decimal? Total { get; set; }


        public decimal? CalculateDiscountAmount()
        {
            decimal? discountValue = Subtotal * DiscountPct / 100;
            return discountValue;
        }

        public decimal? CalculateTotal()
        {
            decimal? totalValue = Subtotal * (1 - DiscountPct / 100);
            return totalValue;
        }
    }
}
