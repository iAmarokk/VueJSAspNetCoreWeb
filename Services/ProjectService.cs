using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJSAspNetCoreWeb.Services;

namespace VueJSAspNetCoreWeb.Models
{
    public class ProjectService
    {
        private readonly IMongoCollection<Project> Projects; 
        public ProjectService(IProjectstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Projects = database.GetCollection<Project>(settings.ProjectsCollectionName);
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
