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
        public int DocumentDate { get; set; }
        public int VocherAmount { get; set; }
        public string VocherStatement { get; set; }
        public string VocherImage { get; set; }
        public string VocherIssuingCompanyInformation { get; set; }
        public string CompanyName { get; set; }
        public string AuthorizedNameSurname { get; set; }
        public string Address { get; set; }

    }
}
