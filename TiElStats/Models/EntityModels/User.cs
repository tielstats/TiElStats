using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiElStats.Models.EntityModels
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set;  }
        [BsonElement("dateLastModified")]
        public DateTime DateLastModified { get; set; }   
    }
}
