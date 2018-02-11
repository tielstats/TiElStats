using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class Event
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("ownerId")]
        public string OwnerId { get; set; }
        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set;  }
        [BsonElement("dateLastModified")]
        public DateTime DateLastModified { get; set; }
    }
}
