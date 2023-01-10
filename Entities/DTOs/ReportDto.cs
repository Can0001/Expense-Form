using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReportDto:IDto
    {
        public string Daterange { get; set; }
        public string Person { get; set; }
        public string PlugType { get; set; }
    }
}
