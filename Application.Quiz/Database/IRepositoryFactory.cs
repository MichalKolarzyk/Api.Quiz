using Domain.Quiz.Abstracts;

namespace Application.Quiz.Database
{
    public interface IRepositoryFactory
    {
        IRepository<T> Create<T>()
            where T : Entity;
    }
}
