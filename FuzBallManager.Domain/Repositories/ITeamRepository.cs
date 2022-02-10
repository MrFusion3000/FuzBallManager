using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<IEnumerable<Team>> GetTeamByTeamName(string teamName);
    }
}
