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
        where T : AggregateRoot
    {
        private readonly IMongoCollection<T> _mongoCollection;
        private readonly IDomainEventDispacher _domainEventDispacher;

        public RepositoryMongoDB(MongoClient mongoClient, IMongoRepositorySettings mongoRepositorySettings, IDomainEventDispacher domainEventDispacher)
        {
            var database = mongoClient.GetDatabase(mongoRepositorySettings.MongoDatabase);
            _mongoCollection = database.GetCollection<T>(typeof(T).Name);
            _domainEventDispacher = domainEventDispacher;
        }

        public async Task<T> InsertAsync(T item)
        {
            await _mongoCollection.InsertOneAsync(item);
            await _domainEventDispacher.Dispach(item);
            return item;
        }

        public async Task UpdateAsync(T item)
        {
            await _mongoCollection.ReplaceOneAsync<T>((itemToReplace) => itemToReplace.Id == item.Id, item);
            await _domainEventDispacher.Dispach(item);
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>> expression)
        {
            return await _mongoCollection.Find<T>(expression).FirstOrDefaultAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _mongoCollection.Find<T>(expression).ToEnumerable();
        }
    }
}
