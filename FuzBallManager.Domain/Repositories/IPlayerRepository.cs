using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.Base;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task <IEnumerable <Player>> GetPlayerByLastName (string lastName);
        //Task <List<Player>> GetAllPlayersAsync(GetAllPlayersQuery query, CancellationToken cancellationToken);
    }
}
