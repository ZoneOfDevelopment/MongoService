using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoService.Model.Entities
{
    public class User
    {
        // With BsonId we define this property as primary key
        [BsonId]
        // With BsonRepresentation we will save this property as ObjectId
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        // With BsonIgnore this property will not save in the Mongo document
        [BsonIgnore]
        public bool Test { get; set; }
    }
}
