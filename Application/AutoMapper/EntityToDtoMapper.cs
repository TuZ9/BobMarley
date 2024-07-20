using AutoMapper;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Entities;

namespace BobMarley.Application.AutoMapper
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper() 
        {
            CreateMap<Flower, FlowerDto>();
        }
    }
}
