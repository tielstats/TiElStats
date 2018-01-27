using MongoDB.Driver;
using TiElStats.Models.EntityModels;
using TiElStats.Utilities;

namespace TiElStats.Database
{
    public static class DatabaseContext
    {
        private static readonly IMongoClient Client = new MongoClient(SystemConstants.DatabaseConnectionString);

        private static readonly IMongoDatabase Database = Client.GetDatabase(SystemConstants.DatabaseName);

        public static IMongoCollection<User> Users()
        {
            return Database.GetCollection<User>("users");
        }

        public static IMongoCollection<DataSet> DataSets()
        {
            return Database.GetCollection<DataSet>("dataSets");
        }
    }
}