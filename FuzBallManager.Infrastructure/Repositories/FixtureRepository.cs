using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class FixtureRepository : Repository<Fixture>, IFixtureRepository
    {
        public FixtureRepository(FBMContext FBMContext) : base(FBMContext) { }

        public async Task<Fixture> GetNextFixture(Fixture request, CancellationToken cancellationToken)
        {
            var fixture = await _FBMContext.Fixtures
                .FirstOrDefaultAsync(f => f.Played == false, cancellationToken: cancellationToken);

            var fixtureResponse = fixture.Adapt<Fixture>();
            return fixture;
        }

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

        public async Task<Guid> Delete(Fixture command, CancellationToken cancellationToken)
        {
            var fixtureToDelete = _FBMContext.Fixtures.Where(a => a.FixtureID == command.FixtureID).FirstOrDefault();

            if (fixtureToDelete.FixtureID == Guid.Empty) return (default);
            _FBMContext.Fixtures.Remove(fixtureToDelete);

            await _FBMContext.SaveChangesAsync(cancellationToken);
            return command.FixtureID;
        }
    }
}