using System.Threading.Tasks;
using AutoMapper;
using Identity.Business.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Business.Services.Interface;
using ServiceA.Data.Entities;

namespace ServiceA.WebApi.Controllers
{
    [Route("api/A")]
    [ApiController]
    public class AController : ControllerBase
    {
        private readonly IAService _aService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AController(IAService aService, IIdentityService identityService, IMapper mapper)
        {
            _aService = aService;
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntities = await _aService.GetAll();
            return Ok(aEntities);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] long id)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = await _aService.GetById(id);
            return Ok(aEntity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Business.Domain.A a)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = _mapper.Map<AEntity>(a);
            aEntity.CreatedBy = identity.Id.ToString();
            var result = await _aService.Create(aEntity);
            return Created(string.Empty, result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Business.Domain.A a)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = _mapper.Map<AEntity>(a);
            aEntity.UpdatedBy = identity.Id.ToString();
            var result = await _aService.Update(aEntity);
            return Ok(result);
        }

        [HttpGet("removeById")]
        public async Task<IActionResult> RemoveById([FromQuery(Name = "id")] long id)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var result = await _aService.RemoveById(id);
            return Ok(result);
        }
    }
}