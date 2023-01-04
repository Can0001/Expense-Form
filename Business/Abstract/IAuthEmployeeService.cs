using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthEmployeeService
    {
        IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto, string password);
        IDataResult<Employee> Login(EmployeeForLoginDto employeeForLoginDto);
        IResult EmployeeExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Employee employee);
    }
}
