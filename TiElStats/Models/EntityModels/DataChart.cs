using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class DataChart
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("dataSets")]
        public List<DataSet> DataSets { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }
        [BsonElement("dateLastModified")]
        public DateTime DateLastModified { get; set; }
    }
}
