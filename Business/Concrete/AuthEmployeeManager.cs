using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthEmployeeManager : IAuthEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeTokenHelper _employeeTokenHelper;

        public AuthEmployeeManager(IEmployeeService employeeService, IEmployeeTokenHelper employeeTokenHelper)
        {
            _employeeService = employeeService;
            _employeeTokenHelper = employeeTokenHelper;
        }

        public IDataResult<EmployeeAccessToken> CreateAccessToken(Employee employee)
        {
            var claims = _employeeService.GetClaims(employee);
            var accessToken = _employeeTokenHelper.EmployeeCreateToken(employee, claims.Data);
            return new SuccessDataResult<EmployeeAccessToken>(accessToken);
        }

        public IResult EmployeeExists(string email)
        {
            var result = _employeeService.GetByMail(email);
            if (result.Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<Employee> Login(EmployeeForLoginDto employeeForLoginDto)
        {
            //var employeeToCheck=_employeeService.GetByMail(employeeForLoginDto.EMail);
            //if (employeeToCheck==null)
            //{
            //    return new SuccessDataResult<Employee>(Messages.UserNotFound);
            //}
            //if (!HashingHelper.VerifyPasswordHash(employeeForLoginDto.Password,employeeToCheck.Data.PasswordSalt)
            //{

            //}
            throw new NotImplementedException();
        }

        public IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }
    }
}
