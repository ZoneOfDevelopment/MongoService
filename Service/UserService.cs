using MongoDB.Driver;
using MongoService.Model.Entities;
using MongoService.Model.MongoConnect;
using System.Collections.Generic;

namespace MongoService.Service
{
    public class UserService
    {
        // definition of User collection 
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoConnect settings)
        {
            // definition MongoDB client
            var client = new MongoClient(settings.ConnectionString);
            // get MongoDB database
            var database = client.GetDatabase(settings.DatabaseName);
            // feed the collection
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> GetAllUsers() =>
            _users.Find(user => true).ToList();

        public User GetUserById(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void UpdateUser(string id, User userInput) =>
            _users.ReplaceOne(user => user.Id == id, userInput);

        public void RemoveUser(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
