using Application.Quiz.Quizzes.Models;
using Domain.Quiz.Accounts;
using Domain.Quiz.Quizzes;
using MongoDB.Driver;

namespace Infrastructure.Quiz.Databases.Aggregations
{
    internal class QuizDetailAggregation : AggregationBase<QuizDetailAggregationModel>
    {
        private readonly IMongoCollection<QuizAggregate> _mongoCollection;

        public QuizDetailAggregation(MongoClient mongoClient, IMongoRepositorySettings mongoRepositorySettings)
        {
            var database = mongoClient.GetDatabase(mongoRepositorySettings.MongoDatabase);
            _mongoCollection = database.GetCollection<QuizAggregate>(nameof(QuizAggregate));

        }

        protected override IAggregateFluent<QuizDetailAggregationModel> GetAggregations()
        {
            return _mongoCollection
                .Aggregate()
                .Lookup<Account, QuizWithAuthor>(nameof(Account), nameof(QuizAggregate.AuthorId), nameof(Account.Id), nameof(QuizWithAuthor.Authors))
                .Project(q => new QuizDetailAggregationModel
                {
                    Author = q.Authors[0].Login,
                    Name = q.Name,
                    QuestionIds = q.QuestionIds,
                });
        }

        private class QuizWithAuthor : QuizAggregate 
        {
            public List<Account> Authors { get; set; } = new List<Account>();
        }
    }
}
