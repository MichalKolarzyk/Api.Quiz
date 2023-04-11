using Application.Quiz.Aggregations;
using Application.Quiz.Database;
using Application.Quiz.Extensions;
using Application.Quiz.Services;
using MediatR;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Application.Quiz.Questions.GetQuestions
{
    public class GetQuestionsCommandHandler : IRequestHandler<GetQuestionsCommand, GetQuestionsResponse>
    {
        private readonly IAggregation<QuestionAggregationModel> _questionDtoAggregation;
        private readonly ICurrentIdentity _currentIdentity;

        public GetQuestionsCommandHandler(IAggregation<QuestionAggregationModel> questionDtoAggregation, ICurrentIdentity currentIdentity)
        {
            _questionDtoAggregation = questionDtoAggregation;
            _currentIdentity = currentIdentity;
        }

        public async Task<GetQuestionsResponse> Handle(GetQuestionsCommand request, CancellationToken cancellationToken)
        {

            Expression<Func<QuestionAggregationModel, bool>> predicate = q => true;

            if (request.IsPrivate != null)
                predicate = predicate.AndAlso(q => q.IsPrivate == request.IsPrivate && q.AuthorId == _currentIdentity.AccountId);

            if (request.Author != null)
                predicate = predicate.AndAlso(q => q.Author == request.Author);

            if (request.Category != null)
                predicate = predicate.AndAlso(q => q.Category == request.Category);

            var questionsDto = await _questionDtoAggregation.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _questionDtoAggregation.GetCount(predicate);

            return new GetQuestionsResponse()
            {
                Questions = questionsDto.Select(q => new GetQuestionsResponse.Question
                {
                    Author = q.Author,
                    Category = q.Category,
                    DefaultLanugage = q.DefaultLanugage,
                    Description = q.Description,
                    Id = q.Id,
                    IsPrivate = q.IsPrivate,
                }).ToList(),
                Count = count,
            };
        }
    }
}