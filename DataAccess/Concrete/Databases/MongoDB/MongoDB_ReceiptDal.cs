using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ReceiptDal : MongoDB_RepositoryBase<Receipt, MongoDB_Context<Receipt, MongoDB_ReceiptCollection>>, IReceiptDal
    {

    }
}
