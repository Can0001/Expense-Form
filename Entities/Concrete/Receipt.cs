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
        public int DocumentDate { get; set; }
        public int ReceiptNo { get; set; }
        public string TheFirmThatCutsthePlug { get; set; }
        public string Description { get; set; }
        public string PlugTour { get; set; }
        public int VATRate { get; set; }
        public int TotalFisAmount { get; set; }
        public int VATAmount { get; set; }
        public string ReceiptImage { get; set; }
    }
}
