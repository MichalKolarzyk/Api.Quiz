using Application.Quiz.Aggregations;
using Application.Quiz.Database;
using Application.Quiz.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions.GetQuestion
{
    public class GetQuestionRequestHandler : IRequestHandler<GetQuestionRequest, GetQuestionResponse>
    {
        private readonly IAggregation<QuestionAggregationModel> _questionAggregation;
        private readonly ICurrentIdentity _currentIdentity;

        public GetQuestionRequestHandler(IAggregation<QuestionAggregationModel> questionAggregation, ICurrentIdentity currentIdentity)
        {
            _questionAggregation = questionAggregation;
            _currentIdentity = currentIdentity;
        }

        async Task<GetQuestionResponse> IRequestHandler<GetQuestionRequest, GetQuestionResponse>.Handle(GetQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionAggregation.GetAsync(q => q.Id == request.Id);
            return new GetQuestionResponse()
            {
                Id = question.Id,
                Answers = question.Answers,
                Author = question.Author,
                Category = question.Category,
                CorrectAnswerIndex = question.CorrectAnswerIndex,
                DefaultLanugage = question.DefaultLanugage,
                Description = question.Description,
                IsPrivate = question.IsPrivate,
                CanUserEdit = _currentIdentity.AccountId == question.AuthorId
            };
        }
    }
}
