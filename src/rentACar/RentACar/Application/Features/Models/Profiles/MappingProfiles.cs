using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Pagination;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(destinationMember: m => m.BrandName, memberOptions: opt => opt.MapFrom(m => m.Brand.Name))
                .ForMember(destinationMember: m => m.FuelName, memberOptions: opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(destinationMember: m => m.TransmissionName, memberOptions: opt => opt.MapFrom(m => m.Transmission.Name))
                .ReverseMap();

            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: m => m.BrandName, memberOptions: opt => opt.MapFrom(m => m.Brand.Name))
                .ForMember(destinationMember: m => m.FuelName, memberOptions: opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(destinationMember: m => m.TransmissionName, memberOptions: opt => opt.MapFrom(m => m.Transmission.Name))
                .ReverseMap();

            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
        }
    }
}

