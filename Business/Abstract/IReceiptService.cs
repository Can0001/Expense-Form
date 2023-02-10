using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IReceiptService
    {
        IResult Add(Receipt receipt);
        IResult Delete(string id);
        IResult Update(Receipt receipt);
        IDataResult<List<Receipt>> GetAll();
        IDataResult<List<Receipt>> GetByDate(string min, string max);
        IDataResult<Receipt> GetById(string id);
        IDataResult<List<Receipt>> GetByReceiptId(string receiptNoId);




    }
}
