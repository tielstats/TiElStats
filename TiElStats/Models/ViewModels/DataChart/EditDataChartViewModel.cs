using System;
using System.Collections.Generic;
using TiElStats.Models.EntityModels;

namespace TiElStats.Models.ViewModels.DataChart
{
    public class EditDataChartViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> DataSets { get; set; }
        public List<string> Events { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
    }
}