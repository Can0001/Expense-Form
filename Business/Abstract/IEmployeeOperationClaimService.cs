using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeOperationClaimService
    {
        IDataResult<EmployeeOperationClaim> GetById(string id);
        IDataResult<List<EmployeeOperationClaimsEvolved>> GetAllClaims();
        IDataResult<List<EmployeeOperationClaim>> GetAll();
        IResult Add(EmployeeOperationClaim employeeOperationClaim);
        IResult Delete(EmployeeOperationClaim employeeOperationClaim);
        IResult Update(EmployeeOperationClaim employeeOperationClaim);
    }
}
