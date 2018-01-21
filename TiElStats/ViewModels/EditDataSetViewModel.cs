using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using TiElStats.Models;

namespace TiElStats.ViewModels
{
    public class EditDataSetViewModel
    {
        // [BsonElement("name")]
        public string Name { get; set; }
        // [BsonElement("description")]
        public string Description { get; set; }
        // [BsonElement("source")]
        public string Source { get; set; }
        // [BsonElement("unit")]
        public string Unit { get; set; }
        // [BsonElement("data")]
        public List<Data> Data { get; set; }
    }
}
