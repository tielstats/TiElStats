using System.Collections.Generic;
using TiElStats.Models.EntityModels;

namespace TiElStats.Models.ViewModels
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
        public List<StatisticalData> Data { get; set; }
    }
}
