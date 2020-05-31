using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSAspNetCoreWeb.Models
{
    public class PipelineService
    {
        IMongoCollection<Pipeline> Pipelines; // коллекция в базе данных
        public PipelineService()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017/ProjectstoreDb";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // обращаемся к коллекции
            Pipelines = database.GetCollection<Pipeline>("Pipelines");
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
