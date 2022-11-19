using MongoDB.Driver;
using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Application.Quiz.Database;

namespace Infrastructure.Quiz.Databases
{
    public class RepositoryMongoDB<T> : IRepository<T>
        where T : Entity
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public RepositoryMongoDB(IMongoCollection<T> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<T> InsertOne(T item)
        {
            await _mongoCollection.InsertOneAsync(item);
            return item;
        }

        public async Task ReplaceOne(T item)
        {
            await _mongoCollection.ReplaceOneAsync<T>((itemToReplace) => itemToReplace.Id == item.Id, item);
        }

        public async Task<T> GetOne(Expression<Func<T,bool>> expression)
        {
            return await _mongoCollection.Find<T>(expression).FirstAsync();
        }
    }
}
