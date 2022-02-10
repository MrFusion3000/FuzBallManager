using Domain.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers.QueryHandlers
{
    public class GetManagerHandler : IRequestHandler<GetManagerQuery, List<Manager>>
    {
        private readonly IManagerRepository _managerRepository;
        public GetManagerHandler(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public async Task<List<Manager>> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            return (List<Manager>) await _managerRepository.GetAllAsync();
        }
    }
}
