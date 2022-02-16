using Application.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class FixtureMappingProfile : Profile
    {
        public FixtureMappingProfile()
        {
            CreateMap<Fixture, FixtureResponse>().ReverseMap();
            CreateMap<Fixture, CreateFixtureCommand>().ReverseMap();
        }
    }
}
