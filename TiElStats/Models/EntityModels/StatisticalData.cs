using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class StatisticalData
    {
        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
        [BsonElement("value")]
        public decimal Value { get; set; }
    }
}
