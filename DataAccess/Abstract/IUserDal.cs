using Core.DataAccess.Databases;
using Core.Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

        List<OperationClaim> GetClaims(User user);
        UserDto GetWithClaims(string id);

        List<UserDto> GetAllWithClaims();
        void DeleteClaims(User user);
    }
}
