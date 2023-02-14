using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ReceiptManager : IReceiptService
    {
        IReceiptDal _receiptDal;
        public ReceiptManager(IReceiptDal receiptDal)
        {
            _receiptDal = receiptDal;
        }

        
        public IResult Add(Receipt receipt)
        {
            //IResult result = BusinessRules.Run(CheckIdReceiptNoExists(receipt.ReceiptNo));
            //if (result != null)
            //{
            //    return result;
            //}
            _receiptDal.Add(receipt);
            return new SuccessResult(Messages.ReceiptAdded);
        }

        public IResult Delete(string id)
        {
            var receipt=_receiptDal.Get(r=>r.Id== id);
            _receiptDal.Delete(receipt);
            return new SuccessResult(Messages.ReceiptDeleted);
        }

        public IDataResult<List<Receipt>> GetAll()
        {
            return new SuccessDataResult<List<Receipt>>(_receiptDal.GetAll(),Messages.ReceiptListed);
        }

        public IDataResult<List<Receipt>> GetByDate(string min, string max)
        {
            return new SuccessDataResult<List<Receipt>>(_receiptDal.GetAll(r => Convert.ToDateTime(r.DocumentDate) > Convert.ToDateTime(min) && Convert.ToDateTime(r.DocumentDate) < Convert.ToDateTime(max)), Messages.ReceiptListed);
        }

        public IDataResult<Receipt> GetById(string id)
        {
            return new SuccessDataResult<Receipt>(_receiptDal.Get(r => r.Id == id), Messages.ReceiptListed);
        }

        public IDataResult<List<Receipt>> GetByReceiptId(string receiptNoId)
        {
            return new SuccessDataResult<List<Receipt>>(_receiptDal.GetAll(r => r.ReceiptNo == receiptNoId), Messages.ReceiptListed);
        }


        public IResult Update(Receipt receipt)
        {
            _receiptDal.Update(receipt);
            return new SuccessResult(Messages.ReceiptUpdated);
        }

        private IResult CheckIdReceiptNoExists(string receiptNoId)
        {
            var result = _receiptDal.GetAll(r => r.ReceiptNo == receiptNoId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ReceiptNoAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
