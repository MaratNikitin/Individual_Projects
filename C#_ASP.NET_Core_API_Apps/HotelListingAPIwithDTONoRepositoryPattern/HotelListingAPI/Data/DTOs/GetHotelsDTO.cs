﻿namespace HotelListingAPI.Data.DTOs
{
    public class GetHotelsDTO
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }
}
