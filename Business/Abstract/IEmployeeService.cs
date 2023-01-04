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
        IResult Delete(Employee employee);
        IResult Update(Employee employee);
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(string id);
        IDataResult<Employee> GetByDepartment(string depart);
        IDataResult<Employee> GetByMail(string mail);
        IDataResult<List<OperationClaim>> GetClaims(Employee employee);

    }
}
