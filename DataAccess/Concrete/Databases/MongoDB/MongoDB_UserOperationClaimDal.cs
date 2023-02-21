using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.DTOs;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_UserOperationClaimDal : MongoDB_RepositoryBase<UserOperationClaim, MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimsCollection>>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetAllClaims()
        {
            List<UserOperationClaim> _userOperationClaims = new List<UserOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<User> _users = new List<User>();
            List<UserOperationClaimDto> _userOperationClaimsDto = new List<UserOperationClaimDto>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimsCollection>())
            {
                _operationClaims=operationClaims.collection.Find<OperationClaim>(document=>true).ToList();
            }

            using (var users=new MongoDB_Context<User, MongoDB_UsersCollection>())
            {
                _users=users.collection.Find<User>(document=>true).ToList();
            }

            using (var operationClaims=new MongoDB_Context<UserOperationClaim, MongoDB_UserOperationClaimsCollection>())
            {
                _userOperationClaims=operationClaims.collection.Find<UserOperationClaim>(document=>true).ToList() ;
            }
            foreach (var userOperationClaim in _userOperationClaims)
            {
                var currentOperationClaim=_operationClaims.Where(o=>o.Id==userOperationClaim.OperationClaimId).FirstOrDefault();
                var currentUser=_users.Where(u=>u.Id==userOperationClaim.UserId).FirstOrDefault();

                if (currentUser !=null && currentOperationClaim != null)
                {
                    UserOperationClaimDto userOperationClaimDto = new UserOperationClaimDto
                    {
                        UserId = userOperationClaim.UserId,
                        OperationClaimId = userOperationClaim.OperationClaimId,
                        
                    };
                    _userOperationClaimsDto.Add(userOperationClaimDto);
                }

            }
                return _userOperationClaimsDto;
        }
    }
}
