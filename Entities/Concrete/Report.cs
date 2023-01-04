using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.Concrete
{
    public class Report : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Daterange { get; set; }
        public string Person { get; set; }
        public string PlugType { get; set; }



    }
}
