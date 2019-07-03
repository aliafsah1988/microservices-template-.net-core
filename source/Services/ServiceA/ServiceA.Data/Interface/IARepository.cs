using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceA.Data.Entities;

namespace ServiceA.Data.Interface
{
    public interface IARepository
    {
        Task<EntityEntry<AEntity>> Create(AEntity aEntity);
        Task<bool> Update(AEntity aEntity);
        Task<List<AEntity>> GetAll();
        Task<List<AEntity>> GetByAppId(Guid appId);
        Task<AEntity> GetById(long id);
        Task<bool> RemoveById(long id);
    }
}
