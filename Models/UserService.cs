using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSAspNetCoreWeb.Models
{
    public class UserService
    {
        IMongoCollection<User> Users; // коллекция в базе данных
        public UserService()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017/ProjectstoreDb";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            // обращаемся к коллекции
            Users = database.GetCollection<User>("Users");
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
