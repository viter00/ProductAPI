using AutoMapper;
using Core.Models.Data;
using Core.Models.DTO;
using Core.Models.Endpoints.Insert;
using Core.Models.Endpoints.Update;
using System;
using System.Xml.Serialization;

namespace Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Core.Models.Endpoints.Update.RequestUpdate, ProductDto>()
            .ForMember(dest => dest.Status, opt =>
            {
                opt.MapFrom((src, dest) =>
                {
                    if (src.Activated != null)
                         return (bool)src.Activated ? "Ativo" : "Inativo";
                    return dest.Status;
                });
            })
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) =>
            {
                if (srcMember is DateTime srcDateTime && srcDateTime == DateTime.MinValue)
                    return false;
                if (srcMember is int srcInt && srcInt <= 0)
                    return false;
                return srcMember != null;
            }));
            CreateMap<ProductDto, RequestUpdate>();
            CreateMap<RequestInsert, Product>()
            .ForMember(dest => dest.Status, opt =>
            {
                opt.MapFrom(src => src.Activated ? "Ativo" : "Inativo");
            });
            CreateMap<RequestUpdate, Product>();
        }
    }
}
