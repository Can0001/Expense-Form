using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal= employeeDal;
        }
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.StaffAdded);
        }

        public IResult Delete(string id)
        {
            var employee=_employeeDal.Get(e=>e.Id==id);
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.StaffDeleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(),Messages.StaffListed);
        }

        public IDataResult<Employee> GetByDepartment(string depart)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e=>e.Department==depart),Messages.StaffListed);
        }

        public IDataResult<Employee> GetById(string id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e=>e.Id==id),Messages.StaffListed);
        }

        public IDataResult<Employee> GetByMail(string mail)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e=>e.Email==mail),Messages.StaffListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(Employee employee)
        {
            return new SuccessDataResult<List<OperationClaim>>(_employeeDal.GetClaims(employee));
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.StaffUpdated);
        }

        public IResult UpdatePassword(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.StaffUpdated);
        }
    }
}
