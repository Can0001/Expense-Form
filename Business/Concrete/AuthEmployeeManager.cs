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
        private ITokenHelper<Employee> _tokenHelper;
        public AuthEmployeeManager(IEmployeeService employeeService, ITokenHelper<Employee> tokenHelper)
        {
            _tokenHelper= tokenHelper;
            _employeeService = employeeService;
        }

        public IDataResult<AccessToken> CreateAccessToken(Employee employee)
        {
            var claims = _employeeService.GetClaims(employee);
            var accessToken = _tokenHelper.CreateToken(employee, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken);
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
            var employeeToCheck = _employeeService.GetByMail(employeeForLoginDto.Email);
            if (employeeToCheck == null)
            {
                return new ErrorDataResult<Employee>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(employeeForLoginDto.Password,employeeToCheck.Data.PasswordHash, employeeToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Employee>(Messages.PasswordError);
            }
            return new SuccessDataResult<Employee>(employeeToCheck.Data);
        }

        public IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var employee = new Employee()
            {
                Email = employeeForRegisterDto.Email,
                FirstName = employeeForRegisterDto.FirstName,
                LastName = employeeForRegisterDto.LastName,
                PasswordHash = passwordHash,
                Status = true,
                PasswordSalt = passwordSalt
            };
            _employeeService.Add(employee);
            return new SuccessDataResult<Employee>(employee,Messages.StaffAdded);
        }
    }
}
