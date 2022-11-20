using Application.Quiz.Database;
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
        public static void AddMongoRepository(this IServiceCollection serviceCollection, IMongoRepositorySettings mongoRepositorySettings)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            serviceCollection.AddScoped<MongoClient>(provider => new MongoClient(mongoRepositorySettings.MongoConnectionString));
            serviceCollection.AddSingleton<IMongoRepositorySettings>(mongoRepositorySettings);
            serviceCollection.AddTransient<IDomainEventDispacher, DomainEventDispacher>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositoryMongoDB<>));
        }
    }
}
