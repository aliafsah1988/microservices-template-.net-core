using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceA.Data.Interface;
using ServiceA.Data.Entities;

namespace ServiceA.Data.Repositories
{
    public class SomeRepository : ISomeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<SomeEntity> _aEntity;
        public SomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _aEntity = _dbContext.Set<SomeEntity>();
        }
        public Task<EntityEntry<SomeEntity>> Create(SomeEntity someEntity)
        {
            var result = _aEntity.AddAsync(someEntity);
            _dbContext.SaveChanges();
            return result;
        }

        public Task<bool> Update(SomeEntity someEntity)
        {
            var existedA = _aEntity.FirstOrDefault(c => c.Id == someEntity.Id);
            if (existedA == null) return Task.FromResult(false);
            existedA.AppId = someEntity.AppId;
            existedA.Email = someEntity.Email;
            existedA.FirstName = someEntity.FirstName;
            existedA.FullName = someEntity.FullName;
            existedA.LastName = someEntity.LastName;
            existedA.MiddleName = someEntity.MiddleName;
            existedA.Output = someEntity.Output;
            if (_dbContext.SaveChanges() > 0) return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<List<SomeEntity>> GetAll()
        {
            return _aEntity.ToListAsync();
        }

        public Task<List<SomeEntity>> GetByAppId(Guid appId)
        {
            return _aEntity.Where(c => c.AppId == appId).ToListAsync();
        }

        public Task<SomeEntity> GetById(long id)
        {
            return _aEntity.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<bool> RemoveById(long id)
        {
            var existedA = _aEntity.FirstOrDefault(c => c.Id == id);
            if (existedA == null) return Task.FromResult(false);
            _aEntity.Remove(existedA);
            if (_dbContext.SaveChanges() > 0) return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}
