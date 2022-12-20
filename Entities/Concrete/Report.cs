using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Report:IEntity
    {
        public string Id { get; set; }
        public DateTime Daterange { get; set; }
        public string Person { get; set; }
        public string PlugType { get; set; }



    }
}
