using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class VoucherDto:IDto
    {
        public string DocumentDate { get; set; }
        public double VoucherAmount { get; set; }
        public string VoucherDescription { get; set; }
        public string VoucherImage { get; set; }
        public string VoucherIssuingCompanyInformation { get; set; }
        public string CompanyName { get; set; }
        public string AuthorizedNameSurname { get; set; }
        public string Address { get; set; }
    }
}
