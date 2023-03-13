using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Data.DTOs
{
    public abstract class BaseCountryDTO
    {
        [Required]
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
    }
}
