using Application.Commands;
using Application.Responses;
using Domain.Entities;
using AutoMapper;

namespace Application.Mappers
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Player, PlayerResponse>().ReverseMap();
            CreateMap<Player, CreatePlayerCommand>().ReverseMap();
        }
    }
}
