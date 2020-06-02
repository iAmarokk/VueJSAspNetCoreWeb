using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJSAspNetCoreWeb.Services;

namespace VueJSAspNetCoreWeb.Models
{
    public class UserService
    {
        private readonly IMongoCollection<User> Users; 
        public UserService(IProjectstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get()
        {
            return Users.Find(user => true).ToList();
        }

        public User Get(string id) =>
            Users.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefault();

        // добавление
        public async Task Create(User u)
        {
            await Users.InsertOneAsync(u);
        }
        // удаление
        public async Task Remove(string id)
        {
            await Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }


}
