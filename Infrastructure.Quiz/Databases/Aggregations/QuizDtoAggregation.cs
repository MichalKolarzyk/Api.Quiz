﻿using Application.Quiz.Questions;
using Application.Quiz.Quizzes;
using Domain.Quiz.Accounts;
using Domain.Quiz.Questions;
using Domain.Quiz.Quizzes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases.Aggregations
{
    internal class QuizDtoAggregation : AggregationBase<QuizDto>
    {
        private readonly IMongoCollection<QuizAggregate> _mongoCollection;

        public QuizDtoAggregation(MongoClient mongoClient, IMongoRepositorySettings mongoRepositorySettings)
        {
            var database = mongoClient.GetDatabase(mongoRepositorySettings.MongoDatabase);
            _mongoCollection = database.GetCollection<QuizAggregate>(nameof(QuizAggregate));

        }

        protected override IAggregateFluent<QuizDto> GetAggregations()
        {
            return _mongoCollection
                .Aggregate()
                .Lookup<Account, QuizWithAuthor>(nameof(Account), nameof(QuizAggregate.AuthorId), nameof(Account.Id), nameof(QuizWithAuthor.Authors))
                .Project(q => new QuizDto
                {
                    Author = q.Authors[0].Login,
                    Name = q.Name,
                    QuestionIds = q.QuestionIds,
                    QuestionCount = q.QuestionIds.Count,
                });
        }

        private class QuizWithAuthor : QuizAggregate 
        {
            public List<Account> Authors { get; set; } = new List<Account>();
        }
    }
}
