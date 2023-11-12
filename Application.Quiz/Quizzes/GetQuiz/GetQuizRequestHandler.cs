using Application.Quiz.Database;
using Application.Aggregations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.GetQuiz
{
    internal class GetQuizRequestHandler : IRequestHandler<GetQuizRequest, GetQuizResponse>
    {
        private readonly IAggregation<QuizAggregationModel> _quizAggregation;

        public GetQuizRequestHandler(IAggregation<QuizAggregationModel> quizAggregation)
        {
            _quizAggregation = quizAggregation;
        }

        public async Task<GetQuizResponse> Handle(GetQuizRequest request, CancellationToken cancellationToken)
        {
            var quizAggregation = await _quizAggregation.GetAsync(q => q.Id == request.Id);

            return new GetQuizResponse
            {
                Author = quizAggregation.Author,
                Name = quizAggregation.Name,
                Questions = quizAggregation.Questions.Select(q => new GetQuizResponse.Question
                {
                    Id= q.Id,
                    Category= q.Category,
                    Author = "",
                    DefaultLanugage=q.DefaultLanugage,
                    Description = q.Description,
                }).ToList(),
            };
        }
    }
}
