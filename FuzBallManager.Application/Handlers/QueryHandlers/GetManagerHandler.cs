using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetManagerHandler : IRequestHandler<GetManagerQuery, Manager>
    {
        private readonly IManagerRepository _managerRepo;
        public GetManagerHandler(IManagerRepository managerRepo)
        {
            _managerRepo = managerRepo;
        }
        public async Task<Manager> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            var name = request.Name;

            return (Manager)await _managerRepo.GetManagerByName(name, cancellationToken);
        }
    }
}
