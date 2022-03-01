﻿using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers
{
    public class CreateManagerHandler : IRequestHandler<CreateManagerCommand, ManagerResponse>
    {
        private readonly IManagerRepository _managerRepo;
        public CreateManagerHandler(IManagerRepository managerRepository)
        {
            _managerRepo = managerRepository;
        }
        public async Task<ManagerResponse> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            //var managerEntity = ManagerMapper.Mapper.Map<Manager>(request);
            var managerEntity = request.Adapt<Manager>();

            //if (managerEntity is null)
            //{
            //    throw new ApplicationException("issue with mapper");
            //}

            ArgumentNullException.ThrowIfNull(managerEntity);

            var newManager = await _managerRepo.AddAsync(managerEntity);
            //var managerResponse = ManagerMapper.Mapper.Map<ManagerResponse>(newManager);
            var managerResponse = request.Adapt<ManagerResponse>();


            return managerResponse;
        }
    }
}
