using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using TiElStats.Database;
using TiElStats.Models.EntityModels;
using TiElStats.Models.ViewModels.DataChart;

namespace TiElStats.Controllers
{
    [Route("api/actions")]
    public class EventsController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var eventsCollection = DatabaseContext.Events();       
            var filter = Builders<Event>.Filter.Empty;

            var result = new StringBuilder();

            foreach (var dataChart in eventsCollection.Find(filter).ToListAsync().Result)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(dataChart, Formatting.Indented);
                result.Append(jsonString);
                result.Append("\n");
            }
            return result.ToString();
        }

        // GET api/datacharts/"id"

        [Route("{id}")]
        [HttpGet]
        public string Get(string id)
        {
            var dataChartsCollection = DatabaseContext.DataCharts();            
            var filter = Builders<DataChart>.Filter.Eq("_id", ObjectId.Parse(id));
            var dataChart = dataChartsCollection.Find(filter).FirstOrDefault();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(dataChart, Formatting.Indented);

            return jsonString;
        }

        // POST api/datacharts/create

        [Route("create")]
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CreateDataChartViewModel createDataChartViewModel)
        {
            var dataChartsCollection = DatabaseContext.DataCharts();
            var dataChartToInsert = new DataChart()
            {
                OwnerId = "5a6cebc882b8493a1cce363c",
                Name = createDataChartViewModel.Name,
                Description = createDataChartViewModel.Description,
                DataSets = createDataChartViewModel.DataSets,
                Events = createDataChartViewModel.Events,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
            };
            dataChartsCollection.InsertOne(dataChartToInsert);
        }

        // PUT api/datacharts/edit/"id"

        [Route("edit/{id}")]
        [HttpPut]
        [Authorize]
        public void Edit(string id, [FromBody] EditDataChartViewModel editdataChartViewModel)
        {
            var dataChartsCollection = DatabaseContext.DataCharts();
            var filter = Builders<DataChart>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataChart>.Update
                .Set(d => d.Name, editdataChartViewModel.Name)
                .Set(d => d.Description, editdataChartViewModel.Description)
                .Set(d => d.DataSets, editdataChartViewModel.DataSets)
                .Set(d => d.Events, editdataChartViewModel.Events)
                .Set(d => d.DateLastModified, DateTime.Now);
            dataChartsCollection.UpdateOne(filter, update);
        }

        // DELETE api/datacharts/delete/"id"

        [Route("delete/{id}")]
        [HttpDelete]
        [Authorize]
        public void Delete(string id)
        {
            var dataChartsCollection = DatabaseContext.DataCharts();
            var filter = Builders<DataChart>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataChart>.Update
                .Set(d => d.IsDeleted, true);
            dataChartsCollection.UpdateOne(filter, update);
        }
    }
}