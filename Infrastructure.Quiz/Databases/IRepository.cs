
using Domain.Quiz.Abstracts;
using System.Linq.Expressions;

namespace Infrastructure.Quiz.Databases
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<T> InsertOne(T item);
        Task ReplaceOne(T item);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
    }
}