namespace MongoService.Model.MongoConnect
{
    public class MongoConnect : IMongoConnect
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
