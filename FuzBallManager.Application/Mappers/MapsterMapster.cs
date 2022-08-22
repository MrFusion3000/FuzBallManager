using Application.Responses;
using Domain.Entities;
using Mapster;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public class MapsterMapster
{
    public static void MapsterSetter()
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = false;

        TypeAdapterConfig<Player, PlayerResponse>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<Manager, ManagerResponse>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<Team, TeamResponse>
            .NewConfig()
            .PreserveReference(true)
            .TwoWays();

        TypeAdapterConfig<Fixture, FixtureResponse>
            .NewConfig()
            .PreserveReference(true);

        //TypeAdapterConfig<Fixture, FixtureResponse>
        //    .NewConfig()
        //    .PreserveReference(true);


        //If ignore ID here but leave ID property in DTO then ID = 00000000-0000-0000-0000-000000000000
        //.Ignore("ID")

        TypeAdapterConfig.GlobalSettings.Compile();
    }
}