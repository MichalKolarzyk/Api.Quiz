using Application.Quiz.Database;
using Application.Quiz.Questions;
using Domain.Quiz.Accounts;
using Domain.Quiz.Questions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases.Aggregations
{
    internal class QuestionDtoAggregation : AggregationBase<QuestionDto>
    {
        private readonly IMongoCollection<Question> _mongoCollection;

        public QuestionDtoAggregation(MongoClient mongoClient, IMongoRepositorySettings mongoRepositorySettings)
        {
            var database = mongoClient.GetDatabase(mongoRepositorySettings.MongoDatabase);
            _mongoCollection = database.GetCollection<Question>(typeof(Question).Name);

        }

        protected override IAggregateFluent<QuestionDto> GetAggregations()
        {
            return _mongoCollection
                .Aggregate()
                .Lookup<Account, QuestionWithAuthor>(nameof(Account), nameof(Question.AuthorId), nameof(Account.Id), nameof(QuestionWithAuthor.Authors))
                .Project(q => new QuestionDto
                {
                    Answers = q.Answers,
                    Author = q.Authors[0].Login,
                    Category = q.Category,
                    CorrectAnswerIndex = q.CorrectAnswerIndex,
                    DefaultLanugage = q.DefaultLanugage,
                    Description = q.Description,
                    Id = q.Id,
                    IsPrivate = q.IsPrivate
                });
        }

        private class QuestionWithAuthor : Question
        {
            public List<Account> Authors = new List<Account>();
        }
    }
}
