using Application.Quiz.Database;
using Application.Quiz.Services;
using Domain.Quiz.Accounts;
using Domain.Quiz.Questions;
using MediatR;
using System.Linq.Expressions;

namespace Application.Quiz.Questions
{
    public class FilterQuestionsCommandHandler : IRequestHandler<FilterQuestionsCommand, GetQuestionsResponse>
    {
        private readonly IAggregation<QuestionDto> _questionDtoAggregation;
        private readonly CurrentAccount _currentAccount;

        public FilterQuestionsCommandHandler(IAggregation<QuestionDto> questionDtoAggregation, CurrentAccount currentAccount)
        {
            _questionDtoAggregation = questionDtoAggregation;
            _currentAccount = currentAccount;
        }

        public async Task<GetQuestionsResponse> Handle(FilterQuestionsCommand request, CancellationToken cancellationToken)
        {
            var user = await _currentAccount.GetCurrentAccount();

            Expression<Func<QuestionDto, bool>> predicate = q => q.IsPrivate == request.IsPrivate
                && q.Author.Contains(request.Author);

            var questionsDto = await _questionDtoAggregation.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _questionDtoAggregation.GetCount(predicate);

            return new GetQuestionsResponse()
            {
                Questions = questionsDto,
                Count = count,
            };
        }
    }
}
