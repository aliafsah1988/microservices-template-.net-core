using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceA.Data.Entities;

namespace ServiceA.Business.Services.Interface
{
    public interface ISomeService
    {
        Task<List<SomeEntity>> GetAll();
        Task<SomeEntity> GetById(long id);
        Task<long> Create(SomeEntity some);
        Task<bool> Update(SomeEntity some);
        Task<bool> RemoveById(long id);
    }
}
