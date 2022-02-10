using Application.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class ManagerMappingProfile : Profile
    {
        public ManagerMappingProfile()
        {
            CreateMap<Manager, ManagerResponse>().ReverseMap();
            CreateMap<Manager, CreateManagerCommand>().ReverseMap();
        }
    }
}
