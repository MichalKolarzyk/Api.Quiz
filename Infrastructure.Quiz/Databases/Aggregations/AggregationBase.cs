using Application.Quiz.Database;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases.Aggregations
{
    internal abstract class AggregationBase<T> : IAggregation<T>
        where T : IAggregationModel
    {
        protected abstract IAggregateFluent<T> GetAggregations();

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await GetAggregations().Match(expression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, int take = 10, int skip = 0)
        {
            return await GetAggregations().Match(expression).Skip(skip).Limit(take).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await GetAggregations().Match(expression).ToListAsync();
        }

        public async Task<long> GetCount(Expression<Func<T, bool>> expression)
        {
            var result = await GetAggregations().Match(expression).Count().FirstOrDefaultAsync();
            return result?.Count ?? 0;
        }
    }
}
