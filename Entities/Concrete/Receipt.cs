using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{
    public class Receipt : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DocumentDate { get; set; }
        public string ReceiptNo { get; set; }
        public string TheFirmThatCutsthePlug { get; set; }
        public string Description { get; set; }
        public string VATRate { get; set; }
        public string TotalFisAmount { get; set; }
        public string VATAmount { get; set; }
        public string ReceiptImage { get; set; }
    }
}
