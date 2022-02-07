using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllPlayersQuery : IRequest<List<Player>>
    {
        //public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, List<Player>>
        //{
        //    public IPlayerRepository PlayerRepository { get; }
        //    public GetAllPlayersQueryHandler(IPlayerRepository playerRepository)
        //    {
        //        PlayerRepository = playerRepository;
        //    }

        //    public async Task<List<Player>> Handle(GetAllPlayersQuery query, CancellationToken cancellationToken)
        //    {
        //        return  await PlayerRepository.GetAllPlayersAsync(query, cancellationToken);
        //    }
        //}
    }
}
