using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ServiceA.Business.Services.Interface;
using ServiceA.Data.Entities;
using ServiceA.Data.Interface;

namespace ServiceA.Business.Services
{
    public class SomeService : ISomeService
    {
        private readonly ISomeRepository _iaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SomeService(ISomeRepository iaRepository, IMapper mapper, ILogger<SomeService> logger)
        {
            _iaRepository = iaRepository ?? throw new ArgumentNullException(nameof(iaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<SomeEntity>> GetAll()
        {
            return await _iaRepository.GetAll();
        }

        public async Task<SomeEntity> GetById(long id)
        {
            return await _iaRepository.GetById(id);
        }

        public async Task<long> Create(SomeEntity some)
        {
            some.CreatedDate = new DateTime();
            var result = await _iaRepository.Create(some);
            return result.Entity.Id;
        }

        public async Task<bool> Update(SomeEntity some)
        {
            some.UpdatedDate = new DateTime();
            return await _iaRepository.Update(some);
        }

        public async Task<bool> RemoveById(long id)
        {
            return await _iaRepository.RemoveById(id);
        }
    }
}
