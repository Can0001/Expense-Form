using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeDal : MongoDB_RepositoryBase<Employee, MongoDB_Context<Employee, MongoDB_EmployeesCollection>>, IEmployeeDal
    {
    }
}
