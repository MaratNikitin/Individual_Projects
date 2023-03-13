using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Data.DTOs;

namespace HotelListingAPI.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        /// <summary>
        /// AutoMapper configuration (rules) are set in this constructor method
        /// </summary>
        public AutoMapperConfiguration()
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountriesDTO>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<Hotel, GetHotelsDTO>().ReverseMap();
        }
    }
}
