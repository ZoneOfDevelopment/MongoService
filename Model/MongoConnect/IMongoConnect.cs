namespace MongoService.Model.MongoConnect
{
    public interface IMongoConnect
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
