using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSAspNetCoreWeb.Models
{
    public class ProjectService
    {
        IMongoCollection<Project> Projects; // коллекция в базе данных
        public ProjectService()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017/ProjectstoreDb";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // обращаемся к коллекции
            Projects = database.GetCollection<Project>("Projects");
        }
        public List<Project> Get()
        {
            return Projects.Find(project => true).ToList();
        }

        public Project Get(string id) =>
            Projects.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefault();

        // добавление
        public async Task Create(Project t)
        {
            await Projects.InsertOneAsync(t);
        }
        // удаление
        public async Task Remove(string id)
        {
            await Projects.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }

    }
}
