using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal= operationClaimDal;
        }

        public IResult Add(OperationClaim claim)
        {
            _operationClaimDal.Add(claim);
            return new SuccessResult();
        }

        public IResult Delete(string id)
        {
            var claim = _operationClaimDal.Get(o => o.Id == id);
            _operationClaimDal.Delete(claim);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.Successful);
        }

        public IDataResult<OperationClaim> GetByClaimName(string claimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o=>o.Name==claimName),Messages.Successful);
        }

        public IResult Update(OperationClaim claim)
        {
            _operationClaimDal.Update(claim);
            return new SuccessResult();
        }
    }
}
