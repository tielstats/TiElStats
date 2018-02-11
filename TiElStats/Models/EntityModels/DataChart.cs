using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class DataChart
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("ownerId")]
        public string OwnerId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("dataSets")]
        public List<string> DataSets { get; set; }
        [BsonElement("events")]
        public List<string> Events { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }
        [BsonElement("dateLastModified")]
        public DateTime DateLastModified { get; set; }
    }
}
