using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetTeamByTeamName(string teamName, CancellationToken cancellationToken);
    }
}
