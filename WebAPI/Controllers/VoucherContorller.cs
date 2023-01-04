using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherContorller : ControllerBase
    {
        private readonly IVoucherService _voucherServie;
        private readonly IMapper _mapper;
        public VoucherContorller(IVoucherService voucherServie, IMapper mapper)
        {
            _voucherServie = voucherServie;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(VoucherDto voucher)
        {
            var _mappedVoucher = _mapper.Map<Voucher>(voucher);
            var result = _voucherServie.Add(_mappedVoucher);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(string id)
        {
            var result = _voucherServie.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Voucher voucher)
        {
            var result = _voucherServie.Update(voucher);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _voucherServie.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _voucherServie.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydate")]
        public IActionResult GetByDate(string min, string max)
        {
            var result = _voucherServie.GetByDate(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getauthorizednamesurname")]
        public IActionResult GetAuthorizedNameSurname(string name)
        {
            var result = _voucherServie.GetAuthorizedNameSurname(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getadress")]
        public IActionResult GetAdress(string adress)
        {
            var result = _voucherServie.GetAdress(adress);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcompanyname")]
        public IActionResult GetCompanyName(string companyName)
        {
            var result=_voucherServie.GetCompanyName(companyName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
