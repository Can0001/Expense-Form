using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEmailExist(user.Email));
            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(string id)
        {
           var user=_userDal.Get(u=>u.Id== id);
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListerd);
        }

        public IDataResult<User> GetByGender(string gender)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Gender == gender), Messages.UserListerd);
        }

        public IDataResult<User> GetById(string id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserListerd);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == mail), Messages.UserListerd);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
        private IResult CheckIfEmailExist(string email)
        {
            var result = _userDal.GetAll(p => p.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailExist);
            }
            return new SuccessResult();
        }
    }
}
