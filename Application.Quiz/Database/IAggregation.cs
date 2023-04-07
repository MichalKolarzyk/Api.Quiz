using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Database
{
    public interface IAggregation<T>
        where T : IAggregationModel
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, int take = 10, int skip = 0);
        Task<long> GetCount(Expression<Func<T, bool>> expression);
    }
}
