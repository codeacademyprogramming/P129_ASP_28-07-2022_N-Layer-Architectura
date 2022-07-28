using AutoMapper;
using P129NLayerArchitectura.Core.Entities;
using P129NLayerArchitectura.Service.DTOS.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryPostDto, Category>()
                .ForMember(des=>des.CreatedAt,src=>src.MapFrom(s=>DateTime.UtcNow.AddHours(4)));
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryGetDto>();

        }
    }
}
