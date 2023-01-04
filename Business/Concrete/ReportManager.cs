using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reportDaL;
        public ReportManager(IReportDal reportDaL)
        {
            _reportDaL = reportDaL;
        }

        public IResult Add(Report report)
        {
            _reportDaL.Add(report);
            return new SuccessResult(Messages.ReportAdded);
        }

        public IResult Delete(string id)
        {
            var report = _reportDaL.Get(r=>r.Id== id);
            _reportDaL.Delete(report);
            return new SuccessResult(Messages.ReportDeleted);
        }

        public IDataResult<List<Report>> GetAll()
        {
            return new SuccessDataResult<List<Report>>(_reportDaL.GetAll(),Messages.ReportListed);
        }

        public IDataResult<List<Report>> GetByDateRange(string min, string max)
        {
            return new SuccessDataResult<List<Report>>(_reportDaL.GetAll(r => Convert.ToDateTime(r.Daterange) > Convert.ToDateTime(min) && Convert.ToDateTime(r.Daterange) < Convert.ToDateTime(max)), Messages.ReportListed);
        }

        public IDataResult<Report> GetById(string id)
        {
            return new SuccessDataResult<Report>(_reportDaL.Get(r=>r.Id== id), Messages.ReportListed);
        }

        public IDataResult<List<Report>> GetByPerson(string person)
        {
            return new SuccessDataResult<List<Report>>(_reportDaL.GetAll(r=>r.Person== person), Messages.ReportListed);
        }

        public IDataResult<List<Report>> GetByPlugType(string plugType)
        {
            return new SuccessDataResult<List<Report>>(_reportDaL.GetAll(r=>r.PlugType== plugType), Messages.ReportListed);
        }

        public IResult Update(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
