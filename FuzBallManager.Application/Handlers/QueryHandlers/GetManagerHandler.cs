using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetManagerHandler : IRequestHandler<GetManagerQuery, Manager>
    {
        private readonly IManagerRepository _managerRepository;
        public GetManagerHandler(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public async Task<Manager> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            var lastname = request.LastName;

            //var manager = await _managerRepository.GetManagerByLastName(lastname, cancellationToken);
            //var managerResponse = manager.Adapt<Manager>();

            //return manager;
            return (Manager)await _managerRepository.GetManagerByLastName(lastname, cancellationToken);
        }
    }
}
