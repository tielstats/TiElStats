using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using TiElStats.Models.EntityModels;

namespace TiElStats.Models.ViewModels.DataSet
{
    public class CreateDataSetViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Unit { get; set; }
        public List<StatisticalData> Data { get; set; }
    }
}
