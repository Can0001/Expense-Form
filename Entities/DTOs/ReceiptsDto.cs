using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReceiptsDto:IDto
    {
        public string DocumentDate { get; set; }
        public string ReceiptNo { get; set; }
        public string TheFirmThatCutsthePlug { get; set; }
        public string Description { get; set; }
        public string ReceiptTour { get; set; }
        public string VATRate { get; set; }
        public string TotalFisAmount { get; set; }
        public string VATAmount { get; set; }
        public string ReceiptImage { get; set; }
    }
}
