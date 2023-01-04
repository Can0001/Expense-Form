using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : Controller
    {
        IAuthEmployeeService _authService;
        public EmployeeAuthController(IAuthEmployeeService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(EmployeeForLoginDto employeeForLoginDto)
        {
            var employeeToLogin = _authService.Login(employeeForLoginDto);
            if (!employeeToLogin.Success)
            {
                return BadRequest(employeeToLogin.Message);
            }
            var result = _authService.CreateAccessToken(employeeToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public ActionResult Register(EmployeeForRegisterDto employeeForRegisterDto)
        {
            var employeeExist = _authService.EmployeeExists(employeeForRegisterDto.EMail);
            if (!employeeExist.Success)
            {
                return BadRequest(employeeExist.Message);
            }

            var registerResult = _authService.Register(employeeForRegisterDto, employeeForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
