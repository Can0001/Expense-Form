using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ReceiptDal : MongoDB_RepositoryBase<Receipt, MongoDB_Context<Receipt, MongoDB_ReceiptsCollection>>, IReceiptDal
    {
    }
}
