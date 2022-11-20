
using Domain.Quiz.Abstracts;
using System.Linq.Expressions;

namespace Application.Quiz.Database
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task<T> InsertOne(T item);
        Task ReplaceOne(T item);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task Save();
    }
}