﻿using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> GetPlayerByLastName(string lastName, CancellationToken cancellationToken);
        //Task<Player> GetPlayerByFirstNameLastName(string firstName, string lastName, CancellationToken cancellationToken);
        Task<List<Player>> GetPlayersByTeamName(string teamName, CancellationToken cancellationToken);
    }
}
