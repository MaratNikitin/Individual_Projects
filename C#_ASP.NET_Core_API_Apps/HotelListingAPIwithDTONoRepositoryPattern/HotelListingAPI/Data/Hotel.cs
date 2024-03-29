﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListingAPI.Data
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
