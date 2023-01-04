using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeOperationClaimDal:MongoDB_RepositoryBase<EmployeeOperationClaim,MongoDB_Context<EmployeeOperationClaim,MongoDB_EmployeeOperationClaimsCollection>>,IEmployeeOperationClaimDal
    {
        public List<EmployeeOperationClaimsEvolved> GetAllClaims()
        {
            List<EmployeeOperationClaim> _employeeOperationClaims = new List<EmployeeOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<Employee> _employee = new List<Employee>();
            List<EmployeeOperationClaimsEvolved> _employeeOperationClaimsEvolveds = new List<EmployeeOperationClaimsEvolved>();

            using (var operationClaims = new MongoDB_Context<OperationClaim,MongoDB_OperationClaimsCollection>())
            {
                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }
            using (var employees = new MongoDB_Context<Employee,MongoDB_EmployeesCollection>())
            {
                _employee = employees.collection.Find<Employee>(document => true).ToList();
            }
            using (var employeeOperationClaims = new MongoDB_Context<EmployeeOperationClaim, MongoDB_EmployeeOperationClaimsCollection>())
            {
                _employeeOperationClaims = employeeOperationClaims.collection.Find<EmployeeOperationClaim>(document => true).ToList();
            }
            foreach (var employeeOperationClaim in _employeeOperationClaims)
            {
                var currentOperationClaim = _operationClaims.Where(o => o.Id == employeeOperationClaim.OperationClaimId).FirstOrDefault();
                var currentEmployee = _employee.Where(e => e.Id == employeeOperationClaim.EmployeeId).FirstOrDefault();

                if (currentEmployee != null && currentOperationClaim != null)
                {
                    EmployeeOperationClaimsEvolved _employeeOperationClaimsEvolved = new EmployeeOperationClaimsEvolved
                    {
                        Id = employeeOperationClaim.Id,
                        OperationClaim = currentOperationClaim.Name,
                        OperationClaimId = currentOperationClaim.Id,
                        Employee = currentEmployee.FirstName,
                        EmployeeId = currentEmployee.Id
                    };
                    _employeeOperationClaimsEvolveds.Add(_employeeOperationClaimsEvolved);
                }
            }
            return _employeeOperationClaimsEvolveds;
        }

        public List<EmployeeOperationClaimsEvolved> GetClaims()
        {
            throw new NotImplementedException();
        }
    }
}
