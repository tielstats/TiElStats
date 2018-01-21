using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TiElStats.Models
{
    public class DataSet
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("source")]
        public string Source { get; set; }
        [BsonElement("unit")]
        public string Unit { get; set; }
        [BsonElement("data")]
        public List<Data> Data { get; set; }
        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("date_created")]
        public DateTime DateCreated { get; set;  }
        [BsonElement("date_last_modified")]
        public DateTime DateLastModified { get; set; }   
    }
}