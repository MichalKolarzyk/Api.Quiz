using Infrastructure.Quiz.Databases;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositoryFactory(this IServiceCollection serviceCollection, string mongoConnectionstring, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(mongoConnectionstring);

            serviceCollection.AddSingleton(mongoClient);
            serviceCollection.AddSingleton(typeof(IRepositoryFactory), new RepositoryFactory(mongoClient, databaseName));
        }

    }
}
