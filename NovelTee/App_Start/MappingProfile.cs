using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NovelTee.Dtos;
using NovelTee.Models;

namespace NovelTee.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            Mapper.CreateMap<TeeVariant, TeeVariantDto>();
            Mapper.CreateMap<Color, ColorDto>();
            Mapper.CreateMap<Size, SizeDto>();
            Mapper.CreateMap<Gender, GenderDto>();


        }
    }
}