namespace HotelListingAPI.Data.DTOs
{
    public class GetCountryDetailsDTO : BaseCountryDTO
    {
        public int CountryId { get; set; }
        public List<GetHotelsDTO> Hotels { get; set; }
    }
}
