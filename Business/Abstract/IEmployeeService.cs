using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(EmployeeEvolved employee);
        IResult Delete(EmployeeEvolved employee);
        IResult Update(EmployeeEvolved employee);
        IDataResult<List<EmployeeEvolved>> GetAll();
        IDataResult<EmployeeEvolved> GetById(string id);
        IDataResult<EmployeeEvolved> GetByDepartment(string depart);
        IDataResult<EmployeeEvolved> GetByMail(string mail);
        IDataResult<List<OperationClaim>> GetClaims(Employee employee);

    }
}
