using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceA.Business.Data.Entities;
using ServiceA.Business.Data.Interface;

namespace ServiceA.Business.Data.Repositories
{
    public class ARepository : IARepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<AEntity> _aEntity;
        public ARepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _aEntity = _dbContext.Set<AEntity>();
        }
        public Task<EntityEntry<AEntity>> Create(AEntity aEntity)
        {
            var result = _aEntity.AddAsync(aEntity);
            aEntity.CreatedDate = new DateTime();
            //TODO aEntity.CreatedBy
            _dbContext.SaveChanges();
            return result;
        }

        public Task<bool> Update(AEntity aEntity)
        {
            var existedA = _aEntity.FirstOrDefault(c => c.Id == aEntity.Id);
            if (existedA == null) return Task.FromResult(false);
            existedA.AppId = aEntity.AppId;
            existedA.Email = aEntity.Email;
            existedA.FirstName = aEntity.FirstName;
            existedA.FullName = aEntity.FullName;
            existedA.LastName = aEntity.LastName;
            existedA.MiddleName = aEntity.MiddleName;
            existedA.Output = aEntity.Output;
            existedA.UpdatedDate = new DateTime();
            //TODO  existedA.UpdatedBy
            if (_dbContext.SaveChanges() > 0) return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<List<AEntity>> GetAll()
        {
            return _aEntity.ToListAsync();
        }

        public Task<List<AEntity>> GetByAppId(Guid appId)
        {
            return _aEntity.Where(c => c.AppId == appId).ToListAsync();
        }

        public Task<AEntity> GetById(long id)
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
