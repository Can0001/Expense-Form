using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeDal : MongoDB_RepositoryBase<EmployeeEvolved, MongoDB_Context<EmployeeEvolved, MongoDB_EmployeesCollection>>, IEmployeeDal
    {
        public List<OperationClaim> GetClaims(Employee employee)
        {
            List<OperationClaim> _opeartionClaims= new List<OperationClaim>();
            List<EmployeeOperationClaim> _employeeOperationClaim=new List<EmployeeOperationClaim>();
            List<OperationClaim> _currentUserOperationClaims=new List<OperationClaim>();

            using (var operationClaims =  new MongoDB_Context<OperationClaim,MongoDB_OperationClaimsCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _opeartionClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }
            using (var operationClaims=new MongoDB_Context<EmployeeOperationClaim,MongoDB_EmployeeOperationClaimsCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _employeeOperationClaim=operationClaims.collection.Find<EmployeeOperationClaim>(document => true).ToList();
            }

            var employeeOperationClaims=_employeeOperationClaim.Where(e=>e.EmployeeId==employee.Id).ToList();
            foreach (var userOperationClaim in employeeOperationClaims)
            {
                _currentUserOperationClaims.Add(_opeartionClaims.Where(oc => oc.Id == userOperationClaim.OperationClaimId).FirstOrDefault());
            }
            return _currentUserOperationClaims;
        }

        public void DeleteClaims(Employee employee)
        {
            List<OperationClaim> _operationClaims=new List<OperationClaim>();
            using (var operationClaims=new MongoDB_Context<EmployeeOperationClaim,MongoDB_EmployeeOperationClaimsCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(d=>d.EmployeeId==employee.Id);
            }
        }

        public List<EmployeeEvolved> GetAllWithClaims()
        {
            List<EmployeeEvolved> _employeeEvlolved=new List<EmployeeEvolved>();
            List<Employee> _employees= new List<Employee>();
            using (var employees=new MongoDB_Context<Employee,MongoDB_EmployeesCollection>())
            {
                employees.GetMongoDBCollection();
                _employees = employees.collection.Find<Employee>(document => true).ToList();
            }

            foreach (var employee in _employees)
            {
                EmployeeEvolved employeeEvolved= new EmployeeEvolved 
                { 
                    Id=employee.Id,
                    EMail=employee.EMail,
                    FirstName=employee.FirstName,
                    LastName=employee.LastName,
                    Department=employee.Department,
                    OperationClaims=GetClaims(employee),
                };
                _employeeEvlolved.Add(employeeEvolved);

            }
            return _employeeEvlolved;
        }


    }
}
