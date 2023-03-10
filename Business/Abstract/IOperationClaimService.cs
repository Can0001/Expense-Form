using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<OperationClaim>> GetAll();

        IDataResult<OperationClaim> GetByClaimName(string claimName);

        IResult Add(OperationClaim claim);
        IResult Delete(string id);
        IResult Update(OperationClaim claim);
    }
}
