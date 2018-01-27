using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TiElStats.Models.EntityModels;
using TiElStats.Models.ViewModels;

namespace TiElStats.Controllers
{
    [Route("api/datasets")]
    public class DataSetsController : Controller
    {

        // GET api/dataset
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "foo", "bar" };
        }

        // GET api/dataset/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "foo";
        }

        // POST api/datasets
        [HttpPost]
        public void Post([FromBody] DataSet dataSet)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TiElStats");
            var collection = database.GetCollection<DataSet>("dataSets");
            var dataSetToInsert = new DataSet()
            {
                Name = dataSet.Name,
                Description = dataSet.Description,
                Source = dataSet.Source,
                Unit = dataSet.Unit,
                Data = dataSet.Data,
                IsDeleted = dataSet.IsDeleted,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
            };
            collection.InsertOne(dataSetToInsert);
        }

        // Put api/datasets/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] EditDataSetViewModel editDataSet)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TiElStats");
            var collection = database.GetCollection<DataSet>("dataSets");
            var filter = Builders<DataSet>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataSet>.Update
                .Set(d => d.Name, editDataSet.Name)
                .Set(d => d.Description, editDataSet.Description)
                .Set(d => d.Source, editDataSet.Source)
                .Set(d => d.Unit, editDataSet.Unit)
                .Set(d => d.Data, editDataSet.Data)
                .Set(d => d.DateLastModified, DateTime.Now);
            collection.UpdateOne(filter, update);
        }

        // DELETE api/datasets/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TiElStats");
            var collection = database.GetCollection<DataSet>("dataSets");
            var filter = Builders<DataSet>.Filter
                .Eq("_id", ObjectId.Parse(id));
            var update = Builders<DataSet>.Update
                .Set(d => d.IsDeleted, true);
            collection.UpdateOne(filter, update);
        }
    }
}