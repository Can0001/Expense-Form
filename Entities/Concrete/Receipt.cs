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
        public string ReceiptTour { get; set; }
        public double VATRate { get; set; }
        public double TotalFisAmount { get; set; }
        public double VATAmount { get; set; }
        public string ReceiptImage { get; set; }
    }
}
