using System.Collections.Generic;
using TiElStats.Models.EntityModels;

namespace TiElStats.Models.ViewModels.DataSet
{
    public class EditDataSetViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Unit { get; set; }
        public List<StatisticalData> Data { get; set; }
    }
}
