﻿using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(FBMContext FBMContext) : base(FBMContext) { }

        public async Task<Manager> GetManagerByName(string name, CancellationToken cancellationToken)
        {
            var manager = await _FBMContext.Managers
                .FirstOrDefaultAsync(m => m.Name == name, cancellationToken);

            if (manager == null) return default;

            //var managerResponse = manager.Adapt<Manager>();

            return manager;
        }

        //TODO Place methods from UIConsole here
    }
}
