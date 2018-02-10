using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using TiElStats.Database;
using TiElStats.Models.EntityModels;
using TiElStats.Models.ViewModels;
using TiElStats.Models.ViewModels.DataSet;

namespace TiElStats.Controllers
{
    [Route("api/datasets")]
    public class DataSetsController : Controller
    {

        // GET api/datasets
        [HttpGet]
        public string Get()
        {
            var dataSetsCollection = DatabaseContext.DataSets();
            var filter = Builders<DataSet>.Filter.Empty;

            var result = new StringBuilder();

            foreach (var dataSet in dataSetsCollection.Find(filter).ToListAsync().Result)
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(dataSet, Formatting.Indented);
                result.Append(jsonString);
                result.Append("\n");
            }
            
            return result.ToString();
        }
    

        // GET api/datasets/"id"
        [Route("{id}")]
        [HttpGet]
        public string Get(string id)
        {
            var dataSetsCollection = DatabaseContext.DataSets();            
            var filter = Builders<DataSet>.Filter.Eq("_id", ObjectId.Parse(id));
            var dataset = dataSetsCollection.Find(filter).FirstOrDefault();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(dataset, Formatting.Indented);

            return jsonString;
        }

        // POST api/datasets/create
        [Route("create")]
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CreateDataSetViewModel createDataSetViewModel)
        {
            var dataSetsCollection = DatabaseContext.DataSets();
            var dataSetToInsert = new DataSet()
            {
                OwnerId = "5a6cebc882b8493a1cce363c",
                Name = createDataSetViewModel.Name,
                Description = createDataSetViewModel.Description,
                Source = createDataSetViewModel.Source,
                Unit = createDataSetViewModel.Unit,
                Data = createDataSetViewModel.Data,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
            };
            dataSetsCollection.InsertOne(dataSetToInsert);
        }

        // PUT api/datasets/edit/"id"
        [Route("edit/{id}")]
        [HttpPut]
        [Authorize]
        public void Edit(string id, [FromBody] EditDataSetViewModel editDataSetViewModel)
        {
            var dataSetsCollection = DatabaseContext.DataSets();
            var filter = Builders<DataSet>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataSet>.Update
                .Set(d => d.Name, editDataSetViewModel.Name)
                .Set(d => d.Description, editDataSetViewModel.Description)
                .Set(d => d.Source, editDataSetViewModel.Source)
                .Set(d => d.Unit, editDataSetViewModel.Unit)
                .Set(d => d.Data, editDataSetViewModel.Data)
                .Set(d => d.DateLastModified, DateTime.Now);
            dataSetsCollection.UpdateOne(filter, update);
        }

        // DELETE api/datasets/delete/"id"
        [Route("delete/{id}")]
        [HttpDelete]
        [Authorize]
        public void Delete(string id)
        {
            var dataSetsCollection = DatabaseContext.DataSets();
            var filter = Builders<DataSet>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataSet>.Update
                .Set(d => d.IsDeleted, true);
            dataSetsCollection.UpdateOne(filter, update);
        }
    }
}