﻿using ApiClient;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class TeamClient : BaseClient
{
    private static Url GetTeamClient() => GetClient().AppendPathSegment("Team");

    public static async Task<List<Team>> GetAllTeams()
    {
        return await GetTeamClient().GetJsonAsync<List<Team>>();
    }

}