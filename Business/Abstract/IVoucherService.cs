using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVoucherService
    {
        IResult Add(Voucher voucher);
        IResult Delete(string id);
        IResult Update(Voucher voucher);
        IDataResult<List<Voucher>> GetAll();
        IDataResult<Voucher> GetById(string id);
        IDataResult<List<Voucher>> GetByDate(string min, string max);
        IDataResult<List<Voucher>> GetAuthorizedNameSurname(string name);
        IDataResult<List<Voucher>>GetAdress(string adress);
        IDataResult<List<Voucher>>GetCompanyName(string companyName);


    }
}
