using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;


namespace Infrastructure.Repositories
{
    public class FixtureRepository : Repository<Fixture>, IFixtureRepository
    {
        public FixtureRepository(FBMContext FBMContext) : base(FBMContext) { }

        //public async Task<Manager> GetManagerByLastName(string lastname, CancellationToken cancellationToken)
        //{
        //    var manager = await _FBMContext.Managers
        //        .FirstOrDefaultAsync(m => m.LastName == lastname, cancellationToken);

        //    if (manager == null) return default;

        //    var managerResponse = manager.Adapt<Manager>();

        //    return managerResponse;
        //}


        public async Task<Guid> Update(Fixture command, CancellationToken cancellationToken)
        {
            var fixture = _FBMContext.Fixtures.Where(a => a.FixtureID == command.FixtureID).FirstOrDefault();

            if (fixture == null)
            {
                return default;
            }
            else
            {
                fixture.FixtureID = command.FixtureID;
                fixture.HomeTeamId = command.HomeTeamId;
                fixture.AwayTeamId = command.AwayTeamId;
                fixture.HomeTeamScore = command.HomeTeamScore;
                fixture.AwayTeamScore = command.AwayTeamScore;
                fixture.Attendance = command.Attendance;
                fixture.FixtureDate = command.FixtureDate;
                fixture.Played = command.Played;

                await _FBMContext.SaveChangesAsync(cancellationToken);
                return fixture.FixtureID;
            }
        }

        public async Task<Guid> DeleteAsync(Guid fixtureID, CancellationToken cancellationToken)
        {
            if (fixtureID == Guid.Empty) return (default);

            await _FBMContext.SaveChangesAsync(cancellationToken);
            return fixtureID;
        }
    }
}