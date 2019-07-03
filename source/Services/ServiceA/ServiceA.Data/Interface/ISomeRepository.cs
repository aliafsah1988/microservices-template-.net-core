using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceA.Data.Entities;

namespace ServiceA.Data.Interface
{
    public interface ISomeRepository
    {
        Task<EntityEntry<SomeEntity>> Create(SomeEntity someEntity);
        Task<bool> Update(SomeEntity someEntity);
        Task<List<SomeEntity>> GetAll();
        Task<List<SomeEntity>> GetByAppId(Guid appId);
        Task<SomeEntity> GetById(long id);
        Task<bool> RemoveById(long id);
    }
}
