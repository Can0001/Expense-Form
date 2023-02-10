using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReportService
    {
        IResult Add(Report report);
        IResult Delete(string id);
        IResult Update(Report report);
        IDataResult<List<Report>> GetAll();
        IDataResult<Report> GetById(string id);
        IDataResult<List<Report>> GetByDateRange(string min, string max);
        IDataResult<List<Report>> GetByPerson(string person);

    }
}
