using MongoDB.Driver;
using Domain.Quiz.Abstracts;
using System.Linq.Expressions;
using Application.Quiz.Database;
using Domain.Quiz.Questions;
using Application.Quiz.Questions;
using Domain.Quiz.Accounts;

namespace Infrastructure.Quiz.Databases
{
    public class RepositoryMongoDB<T> : IRepository<T>
        where T : AggregateRoot
    {
        protected readonly IDomainEventDispacher _domainEventDispacher;
        protected readonly IMongoCollection<T> _mongoCollection;

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
            await _mongoCollection.ReplaceOneAsync((itemToReplace) => itemToReplace.Id == item.Id, item);
            await _domainEventDispacher.Dispach(item);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _mongoCollection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, int take = 10, int skip = 0)
        {
            return await _mongoCollection.Find(expression).Limit(take).Skip(skip).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _mongoCollection.Find(expression).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(List<Guid> ids)
        {
            var filterDef = new FilterDefinitionBuilder<T>();
            var filter = filterDef.In(x => x.Id, ids);
            return await _mongoCollection.Find(filter).ToListAsync();

            //return await _mongoCollection.Find(a => ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<long> GetCount(Expression<Func<T, bool>> expression)
        {
            return await _mongoCollection.Find(expression).CountDocumentsAsync();
        }
    }
}
