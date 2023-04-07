using Application.Quiz.Database;
using Application.Quiz.Quizzes.Models;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.GetQuizzes
{
    public class GetQuizesCommandHandler : IRequestHandler<GetQuizesCommand, GetQuizesResponse>
    {
        private readonly IAggregation<QuizDetailAggregationModel> _quizAggregation;

        public GetQuizesCommandHandler(IAggregation<QuizDetailAggregationModel> quizAggregation)
        {
            _quizAggregation = quizAggregation;
        }

        public async Task<GetQuizesResponse> Handle(GetQuizesCommand request, CancellationToken cancellationToken)
        {
            var quizzesAggregation = await _quizAggregation.GetListAsync(q => true, request.Take, request.Skip);
            var count = await _quizAggregation.GetCount(q => true);
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

        public List<string> GetCategory(QuizDetailAggregationModel quiz)
        {
            var groupedList = quiz.Questions.GroupBy(q => q.Category);
            return groupedList.Select(g => g.Key).Where(k => !string.IsNullOrEmpty(k)).ToList();
        }
    }
}
