using System.Threading.Tasks;
using AutoMapper;
using Identity.Business.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Business.Services.Interface;
using ServiceA.Data.Entities;

namespace ServiceA.WebApi.Controllers
{
    [Route("api/Some")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly ISomeService _someService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public SomeController(ISomeService someService, IIdentityService identityService, IMapper mapper)
        {
            _someService = someService;
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntities = await _someService.GetAll();
            return Ok(aEntities);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] long id)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = await _someService.GetById(id);
            return Ok(aEntity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Business.Domain.SomeModel someModel)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = _mapper.Map<SomeEntity>(someModel);
            aEntity.CreatedBy = identity.Id.ToString();
            var result = await _someService.Create(aEntity);
            return Created(string.Empty, result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Business.Domain.SomeModel someModel)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var aEntity = _mapper.Map<SomeEntity>(someModel);
            aEntity.UpdatedBy = identity.Id.ToString();
            var result = await _someService.Update(aEntity);
            return Ok(result);
        }

        [HttpGet("removeById")]
        public async Task<IActionResult> RemoveById([FromQuery(Name = "id")] long id)
        {
            var identity = _identityService.GetIdentity();
            if (identity == null) return Unauthorized();
            var result = await _someService.RemoveById(id);
            return Ok(result);
        }
    }
}