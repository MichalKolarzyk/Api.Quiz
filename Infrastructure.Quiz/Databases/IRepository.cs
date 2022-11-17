
namespace Infrastructure.Quiz.Databases
{
    public interface IRepository<T>
    {
        Task<T> InsertOne(T item);
    }
}