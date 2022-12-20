using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_UserDal : MongoDB_RepositoryBase<User, MongoDB_Context<User, MongoDB_UsersCollection>>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
           User _user=new User();
           List<UserOperationClaim> _userOperationClaims= new List<UserOperationClaim>();
           List<OperationClaim> _operationClaims= new List<OperationClaim>();
            using (var context=new MongoDB_Context<User,MongoDB_UsersCollection>())
            {
                _user=context.collection.Find(u=>u.Id==user.Id).First();
            }
            using (var context = new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimsCollection>())
            {
                _userOperationClaims=context.collection.Find(u=>u.UserId==user.Id).ToList();
            }
            using (var contex = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimsCollection>())
            {
                foreach (var userOperationCliam in _userOperationClaims)
                {
                    _operationClaims.Add(contex.collection.Find(u => u.Id == userOperationCliam.OperationClaimId).First());
                }
            }
            return _operationClaims;
        }
    }
}
