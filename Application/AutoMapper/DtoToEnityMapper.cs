using AutoMapper;
using BobMarley.Domain.Dto;
using BobMarley.Domain.Entities;

namespace BobMarley.Application.AutoMapper
{
    public class DtoToEnityMapper : Profile
    {
        public DtoToEnityMapper() 
        {
            CreateMap<FlowerDto, Flower>();
        }
    }
}
