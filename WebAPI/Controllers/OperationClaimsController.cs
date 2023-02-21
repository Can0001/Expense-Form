using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;

        public OperationClaimsController(IOperationClaimService operationClaimService, IMapper mapper)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _operationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(OperationClaimsDto operationClaim)
        {
            var _mappedClaim = _mapper.Map<OperationClaim>(operationClaim);
            var result = _operationClaimService.Add(_mappedClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}
