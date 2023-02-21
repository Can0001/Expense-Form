using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.DTOs;
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


        public List<UserDto> GetAllWithClaims()
        {
            List<UserDto> _userDto = new List<UserDto>();
            List<User> _users = new List<User>();
            using (var users = new MongoDB_Context<User, MongoDB_UsersCollection>())
            {
                users.GetMongoDBCollection();
                _users = users.collection.Find<User>(documnet => true).ToList();
            }
            foreach (var user in _users)
            {
                UserDto userDto = new UserDto {
                    Id= user.Id,
                    Email= user.Email,
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    Gender= user.Gender,
                    OperationClaims=GetClaims(user),
                    Status=user.Status,
                };
                _userDto.Add(userDto);
            }
            return _userDto;
        }

        public UserDto GetWithClaims(string id)
        {
            User user = new User();
            using(var users = new MongoDB_Context<User, MongoDB_UsersCollection>())
            {
                users.GetMongoDBCollection();
                user=users.collection.Find<User>(documenet=> documenet.Id==id).FirstOrDefault();
            }

            UserDto userDto = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                OperationClaims = GetClaims(user),
                Status = user.Status,
            };
            return userDto;
        }

        public void DeleteClaims(User user)
        {
            List<OperationClaim> _operationClaims=new List<OperationClaim>();

            using(var operationClaims=new MongoDB_Context<UserOperationClaim,MongoDB_UserOperationClaimsCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(o => o.UserId == user.Id);
            }
        }
    }
}
