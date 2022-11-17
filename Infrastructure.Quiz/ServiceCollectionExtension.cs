using Infrastructure.Quiz.Databases;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure.Quiz
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositoryFactory(this IServiceCollection serviceCollection, string mongoConnectionstring, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(mongoConnectionstring);
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            serviceCollection.AddSingleton(mongoClient);
            serviceCollection.AddSingleton(typeof(IRepositoryFactory), new RepositoryFactory(mongoClient, databaseName));
        }

    }
}
