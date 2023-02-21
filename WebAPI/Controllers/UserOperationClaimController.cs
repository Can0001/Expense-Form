using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result=_userOperationClaimService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaimDto userOperationClaimDto)
        {
            var _mapperUserOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimDto);
            var result =_userOperationClaimService.Add(_mapperUserOperationClaim);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
