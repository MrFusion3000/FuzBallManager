using Domain.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers.QueryHandlers
{
    public class GetAllManagersHandler : IRequestHandler<GetAllManagersQuery, List<Manager>>
    {
        private readonly IManagerRepository _managerRepository;
        public GetAllManagersHandler(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public async Task<List<Manager>> Handle(GetAllManagersQuery request, CancellationToken cancellationToken)
        {
            return (List<Manager>) await _managerRepository.GetAllAsync();
        }
    }
}
