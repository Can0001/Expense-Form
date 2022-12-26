using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Voucher : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
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
