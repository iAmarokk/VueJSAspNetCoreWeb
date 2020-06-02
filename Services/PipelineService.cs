using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJSAspNetCoreWeb.Services;

namespace VueJSAspNetCoreWeb.Models
{
    public class PipelineService
    {
        private readonly IMongoCollection<Pipeline> Pipelines;

        public PipelineService(IProjectstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Pipelines = database.GetCollection<Pipeline>(settings.PipelinesCollectionName);
        }

        public List<Pipeline> Get()
        {
            return Pipelines.Find(project => true).ToList();
        }

        public Pipeline Get(string id) =>
            Pipelines.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefault();
        // добавление
        public async Task Create(Pipeline p)
        {
            await Pipelines.InsertOneAsync(p);
        }
        // удаление
        public async Task Remove(string id)
        {
            await Pipelines.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
