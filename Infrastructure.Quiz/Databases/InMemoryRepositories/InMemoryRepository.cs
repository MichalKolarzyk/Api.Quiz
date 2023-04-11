using Application.Quiz.Database;
using Domain.Quiz.Abstracts;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases.InMemoryRepositories
{
    public abstract class InMemoryRepository<T> : IRepository<T>
        where T : AggregateRoot
    {
        protected abstract List<T> GetListItems();

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return Task.Run(() => GetListItems().FirstOrDefault(expression.Compile()));
        }

        public Task<long> GetCount(Expression<Func<T, bool>> expression)
        {
            var count = GetListItems().Where(expression.Compile()).Count();
            return Task.Run(() => (long)count);
        }

        public Task<List<T>> GetListAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return Task.Run(() => GetListItems().Where(expression.Compile()).ToList());
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, int take = 10, int skip = 0)
        {
            return Task.Run(() => GetListItems().Where(expression.Compile()).Take(take).Skip(skip).ToList());
        }

        public Task<T> InsertAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
