﻿using AutoMapper;

namespace API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>().ReverseMap();

            CreateMap<Models.Domain.Walk, Models.DTO.AddWalkRequest>().ReverseMap();

            CreateMap<Models.Domain.Walk, Models.DTO.UpdateWalkRequest>().ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>().ReverseMap();
        }
    }
}
