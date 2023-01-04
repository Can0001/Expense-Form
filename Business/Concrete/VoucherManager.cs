using Business.Abstract;
using Business.Constants;
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
            _voucherDal.Add(voucher);
            return new SuccessResult(Messages.VoucherAdded);
        }

        public IResult Delete(string id)
        {
            var voucher= _voucherDal.Get(v=>v.Id==id);
            _voucherDal.Delete(voucher);
            return new SuccessResult(Messages.VoucherDeleted);
        }

        public IDataResult<List<Voucher>> GetAdress(string adress)
        {
            return new SuccessDataResult<List<Voucher>>(_voucherDal.GetAll(v => v.Address == adress), Messages.VoucherListed);
        }

        public IDataResult<List<Voucher>> GetAll()
        {
            return new SuccessDataResult<List<Voucher>>(_voucherDal.GetAll(), Messages.VoucherListed);
        }

        public IDataResult<List<Voucher>> GetAuthorizedNameSurname(string name)
        {
            return new SuccessDataResult<List<Voucher>>(_voucherDal.GetAll(v => v.AuthorizedNameSurname == name), Messages.VoucherListed);
        }

        public IDataResult<List<Voucher>> GetByDate(string min, string max)
        {
            return new SuccessDataResult<List<Voucher>>(_voucherDal.GetAll(r => Convert.ToDateTime(r.DocumentDate) > Convert.ToDateTime(min) && Convert.ToDateTime(r.DocumentDate) < Convert.ToDateTime(max)), Messages.VoucherListed);
        }

        public IDataResult<Voucher> GetById(string id)
        {
            return new SuccessDataResult<Voucher>(_voucherDal.Get(v => v.Id == id), Messages.VoucherListed);
        }

        public IDataResult<List<Voucher>> GetCompanyName(string companyName)
        {
            return new SuccessDataResult<List<Voucher>>(_voucherDal.GetAll(v => v.CompanyName == companyName), Messages.VoucherListed);
        }

        public IResult Update(Voucher voucher)
        {
            _voucherDal.Update(voucher);
            return new SuccessResult(Messages.VoucherUpdated);
        }


    }
}
