using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_VoucherDal : MongoDB_RepositoryBase<Voucher, MongoDB_Context<Voucher, MongoDB_VoucherCollection>>, IVoucherDal
    {
    }
}
