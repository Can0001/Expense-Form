﻿using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_OperationClaimDal : MongoDB_RepositoryBase<OperationClaim, MongoDB_Context<OperationClaim, MongoDB_OperationClaimsCollection>>, IOperationClaimDal
    {

    }
}
