using Application.Aggregations;
using Application.Quiz.Questions;
using Application.Quiz.Quizzes;
using Domain.Quiz.Accounts;
using Domain.Quiz.Questions;
using Domain.Quiz.Quizzes;
using MongoDB.Driver;

namespace Infrastructure.Quiz.Databases.Aggregations
{
    internal class QuizAggregation : AggregationBase<QuizAggregationModel>
    {
        private readonly IMongoCollection<QuizAggregate> _mongoCollection;

        public QuizAggregation(MongoClient mongoClient, IMongoRepositorySettings mongoRepositorySettings)
        {
            var database = mongoClient.GetDatabase(mongoRepositorySettings.MongoDatabase);
            _mongoCollection = database.GetCollection<QuizAggregate>(nameof(QuizAggregate));
        }

        protected override IAggregateFluent<QuizAggregationModel> GetAggregations()
        {
            return _mongoCollection
                .Aggregate()
                .Lookup<Account, QuizWithAuthor>(nameof(Account), nameof(QuizAggregate.AuthorId), nameof(Account.Id), nameof(QuizWithAuthor.Authors))
                .Lookup<QuizWithAuthor, QuizWithAuthor>(nameof(Question), nameof(QuizAggregate.QuestionIds), nameof(Question.Id), nameof(QuizWithAuthor.Questions))
                .Project(q => new QuizAggregationModel
                {
                    Id= q.Id,
                    Author = q.Authors[0].Login,
                    Name = q.Name,
                    Questions = q.Questions,
                });
        }

        private class QuizWithAuthor : QuizAggregate
        {
            public List<Account> Authors = new List<Account>();
            public List<Question> Questions { get; set; } = new List<Question>();
        }
    }
}
