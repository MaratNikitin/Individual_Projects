using API.Models;
using API.Models.DTOs;
using AutoMapper;
using System.Diagnostics.Metrics;

/*
 * This ASP.NET7 Web API app allows sharing items coming from a SQL Server database 
    using Entity Framework Core; full range of CRUD operations for Items is enabled.
 *  This file sets mapping rules of the AutoMapper.
 * Author: Marat Nikitin
 * Assignment
 * When: March 2023
 */

namespace API.Configurations
{
    public class AutoMapperConfigurations : Profile
    {
        /// <summary>
        /// AutoMapper configurations (rules) are set in this constructor method
        /// </summary>
        public AutoMapperConfigurations()
        {
            CreateMap<Item, GetItemDTO>().ReverseMap();
            CreateMap<Item, CreateItemDTO>().ReverseMap();
            CreateMap<Item, UpdateItemDTO>().ReverseMap();
        }
    }
}
