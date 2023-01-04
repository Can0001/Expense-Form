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
        IResult Add(Employee employee);
        IResult Delete(string id);
        IResult Update(Employee employee);
        IResult UpdatePassword(Employee employee);
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(string id);
        IDataResult<Employee> GetByDepartment(string depart);
        IDataResult<Employee> GetByMail(string mail);
        IDataResult<List<OperationClaim>> GetClaims(Employee employee);

    }
}
