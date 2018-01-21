using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models
{
    public class Data
    {
        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}
