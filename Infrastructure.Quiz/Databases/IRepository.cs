
namespace Infrastructure.Quiz.Databases
{
    public interface IRepository<T>
    {
        Task InsertOne(T item);
    }
}