using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ServiceA.Business.Data.Entities;
using ServiceA.Business.Data.Interface;
using ServiceA.Business.Services.Interface;

namespace ServiceA.Business.Services
{
    public class AService : IAService
    {
        private readonly IARepository _iaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AService(IARepository iaRepository, IMapper mapper, ILogger<AService> logger)
        {
            _iaRepository = iaRepository ?? throw new ArgumentNullException(nameof(iaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<AEntity>> GetAll()
        {
            return await _iaRepository.GetAll();
        }

        public async Task<AEntity> GetById(long id)
        {
            return await _iaRepository.GetById(id);
        }

        public async Task<long> Create(AEntity a)
        {
            var result = await _iaRepository.Create(a);
            return result.Entity.Id;
        }

        public async Task<bool> Update(AEntity a)
        {
            return await _iaRepository.Update(a);
        }

        public async Task<bool> RemoveById(long id)
        {
            return await _iaRepository.RemoveById(id);
        }
    }
}
