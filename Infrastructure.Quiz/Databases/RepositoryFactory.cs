using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases
{
    public interface IRepositoryFactory
    {
        IRepository<T> Create<T>();
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IMongoDatabase _database;

        public RepositoryFactory(MongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IRepository<T> Create<T>()
        {
            var colleciton = _database.GetCollection<T>(typeof(T).Name);
            return new RepositoryMongoDB<T>(colleciton);
        }

    }
}
