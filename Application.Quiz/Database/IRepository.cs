
using Domain.Quiz.Abstracts;
using System.Linq.Expressions;

namespace Application.Quiz.Database
{
    public interface IRepository<T> 
        where T : AggregateRoot
    {
        Task<T> InsertAsync(T item);
        Task UpdateAsync(T item);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
    }
}