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
        public IResult Add(EmployeeEvolved employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.StaffAdded);
        }

        public IResult Delete(EmployeeEvolved employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.StaffDeleted);
        }

        public IDataResult<List<EmployeeEvolved>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeEvolved>>(_employeeDal.GetAll(),Messages.StaffListed);
        }

        public IDataResult<EmployeeEvolved> GetByDepartment(string depart)
        {
            return new SuccessDataResult<EmployeeEvolved>(_employeeDal.Get(e=>e.Department==depart),Messages.StaffListed);
        }

        public IDataResult<EmployeeEvolved> GetById(string id)
        {
            return new SuccessDataResult<EmployeeEvolved>(_employeeDal.Get(e=>e.Id==id),Messages.StaffListed);
        }

        public IDataResult<EmployeeEvolved> GetByMail(string mail)
        {
            return new SuccessDataResult<EmployeeEvolved>(_employeeDal.Get(e=>e.EMail==mail),Messages.StaffListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(Employee employee)
        {
            return new SuccessDataResult<List<OperationClaim>>(_employeeDal.GetClaims(employee));
        }

        public IResult Update(EmployeeEvolved employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.StaffUpdated);
        }
    }
}
