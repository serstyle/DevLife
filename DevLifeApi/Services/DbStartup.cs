using DevLifeApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLifeApi.Services
{
    public class DbStartup
    {
        IMongoDatabase _database;
        public DbStartup(IDevLifeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _database = database;
        }

        public IMongoDatabase GetMongo()
        {
            return _database;
        }
    }
}
