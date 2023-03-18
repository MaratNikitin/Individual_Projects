using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Data.DTOs
{
    public class GetCountriesDTO : BaseCountryDTO
    {
        public int CountryId { get; set; }
    }
}
