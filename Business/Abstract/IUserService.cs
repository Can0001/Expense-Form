﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(string id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(string id);
        IDataResult<User> GetByMail(string mail);
        IDataResult<User> GetByGender(string gender);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
