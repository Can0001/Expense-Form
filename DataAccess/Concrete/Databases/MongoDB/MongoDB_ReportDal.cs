using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
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
    public class MongoDB_ReportDal : MongoDB_RepositoryBase<Report, MongoDB_Context<Report,MongoDB_ReportsCollection>>, IReportDal
    {
    }
}
