
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
        Task<List<T>> GetListAsync(List<Guid> ids);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, int take = 10, int skip = 0);
        Task<long> GetCount(Expression<Func<T, bool>> expression);
    }
}