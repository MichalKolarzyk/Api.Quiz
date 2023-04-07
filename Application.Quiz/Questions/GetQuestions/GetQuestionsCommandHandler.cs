using Application.Quiz.Aggregations;
using Application.Quiz.Database;
using Application.Quiz.Services;
using MediatR;
using System.Linq.Expressions;

namespace Application.Quiz.Questions.GetQuestions
{
    public class GetQuestionsCommandHandler : IRequestHandler<GetQuestionsCommand, GetQuestionsResponse>
    {
        private readonly IAggregation<QuestionAggregationModel> _questionDtoAggregation;
        private readonly CurrentAccount _currentAccount;

        public GetQuestionsCommandHandler(IAggregation<QuestionAggregationModel> questionDtoAggregation, CurrentAccount currentAccount)
        {
            _questionDtoAggregation = questionDtoAggregation;
            _currentAccount = currentAccount;
        }

        public async Task<GetQuestionsResponse> Handle(GetQuestionsCommand request, CancellationToken cancellationToken)
        {
            var user = await _currentAccount.GetCurrentAccount();

            Expression<Func<QuestionAggregationModel, bool>> predicate = q => q.IsPrivate == request.IsPrivate
                && q.Author.Contains(request.Author);

            var questionsDto = await _questionDtoAggregation.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _questionDtoAggregation.GetCount(predicate);

            return new GetQuestionsResponse()
            {
                Questions = questionsDto.Select(q => new GetQuestionsResponse.Question
                {
                    Author= q.Author,
                    Category= q.Category,
                    DefaultLanugage= q.DefaultLanugage,
                    Description= q.Description,
                    Id= q.Id,
                    IsPrivate = q.IsPrivate,
                }).ToList(),
                Count = count,
            };
        }
    }
}
