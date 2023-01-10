using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IReceiptDal : IEntityRepository<Receipt>
    {
    }
}
