using Business.Abstract;
using Business.Constants;
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
    public class EmployeeOperationClaimManager : IEmployeeOperationClaimService
    {
        private readonly IEmployeeOperationClaimDal _employeeOperationClaimDal;
        public EmployeeOperationClaimManager(IEmployeeOperationClaimDal employeeOperationClaimDal)
        {
            _employeeOperationClaimDal = employeeOperationClaimDal;
        }

        public IResult Add(EmployeeOperationClaim employeeOperationClaim)
        {
            _employeeOperationClaimDal.Add(employeeOperationClaim);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(EmployeeOperationClaim employeeOperationClaim)
        {
            _employeeOperationClaimDal.Delete(employeeOperationClaim);
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<List<EmployeeOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeOperationClaim>>(_employeeOperationClaimDal.GetAll(),Messages.Successful);
        }

        public IDataResult<List<EmployeeOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<EmployeeOperationClaimsEvolved>>(_employeeOperationClaimDal.GetClaims(), Messages.Successful);
        }

        public IDataResult<EmployeeOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<EmployeeOperationClaim>(_employeeOperationClaimDal.Get(e => e.Id == id), Messages.Successful);
        }

        public IResult Update(EmployeeOperationClaim employeeOperationClaim)
        {
            _employeeOperationClaimDal.Update(employeeOperationClaim);
            return new SuccessResult();
        }
    }
}
