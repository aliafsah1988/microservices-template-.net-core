using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceA.Business.Data.Entities;

namespace ServiceA.Business.Services.Interface
{
    public interface IAService
    {
        Task<List<AEntity>> GetAll();
        Task<AEntity> GetById(long id);
        Task<long> Create(AEntity a);
        Task<bool> Update(AEntity a);
        Task<bool> RemoveById(long id);
    }
}
