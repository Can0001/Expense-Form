using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class VoucherManager : IVoucherService
    {
        IVoucherDal _voucherDal;
        public VoucherManager(IVoucherDal voucherDal)
        {
            _voucherDal = voucherDal;
        }

        public IResult Add(Voucher voucher)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Voucher voucher)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Voucher>> GetAdress(string adress)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Voucher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Voucher>> GetAuthorizedNameSurname(string name)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Voucher>> GetByDate(string min, string max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Voucher> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Voucher>> GetCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Voucher voucher)
        {
            throw new NotImplementedException();
        }


    }
}
