using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class Event
    {
        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}
