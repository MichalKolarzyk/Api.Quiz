using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases
{
    public class RepositoryMongoDB<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public RepositoryMongoDB(IMongoCollection<T> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task InsertOne(T item)
        {
            await _mongoCollection.InsertOneAsync(item);
        }
    }
}
