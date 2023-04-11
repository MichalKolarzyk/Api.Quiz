using Application.Quiz.Database;
using Application.Aggregations;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Application.Quiz.Extensions;

namespace Application.Quiz.Quizzes.GetQuizzes
{
    public class GetQuizesCommandHandler : IRequestHandler<GetQuizesCommand, GetQuizesResponse>
    {
        private readonly IAggregation<QuizAggregationModel> _quizAggregation;

        public GetQuizesCommandHandler(IAggregation<QuizAggregationModel> quizAggregation)
        {
            _quizAggregation = quizAggregation;
        }

        public async Task<GetQuizesResponse> Handle(GetQuizesCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<QuizAggregationModel, bool>> predicate = q => true;

            if(request.Author != null)
                predicate.AndAlso(q => q.Author.StartsWith(request.Author));

            var quizzesAggregation = await _quizAggregation.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _quizAggregation.GetCount(predicate);
            var quizzes = quizzesAggregation.Select(a => new GetQuizesResponse.Quiz
            {
                Id = a.Id,
                Author = a.Author,
                Name = a.Name,
                QuestionCount = a.Questions.Count,
                Category = GetCategory(a),
            }).ToList();

            return new GetQuizesResponse
            {
                Quizes = quizzes,
                Count = count,
            };
        }

        public List<string> GetCategory(QuizAggregationModel quiz)
        {
            var groupedList = quiz.Questions.GroupBy(q => q.Category);
            return groupedList.Select(g => g.Key).Where(k => !string.IsNullOrEmpty(k)).ToList();
        }
    }
}
