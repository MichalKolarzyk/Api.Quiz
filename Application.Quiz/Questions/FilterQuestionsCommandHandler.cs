using Application.Quiz.Database;
using Domain.Quiz.Accounts;
using Domain.Quiz.Questions;
using MediatR;
using System.Linq.Expressions;

namespace Application.Quiz.Questions
{
    public class FilterQuestionsCommandHandler : IRequestHandler<FilterQuestionsCommand, GetQuestionsResponse>
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Account> _accountRepository;

        public FilterQuestionsCommandHandler(IRepository<Question> questionRepository, IRepository<Account> accountRepository)
        {
            _questionRepository = questionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetQuestionsResponse> Handle(FilterQuestionsCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Question, bool>> predicate = q => q.IsPrivate == request.IsPrivate;

            var questions = await _questionRepository.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _questionRepository.GetCount(predicate);

            var authorsIds = questions.Select(q => q.AuthorId).Distinct().ToList();
            var authors = await _accountRepository.GetListAsync(authorsIds);

            return new GetQuestionsResponse()
            {
                Questions = questions.Select(q => new QuestionDto
                {
                    Answers = q.Answers,
                    CorrectAnswerIndex = q.CorrectAnswerIndex,
                    Description = q.Description,
                    Category = q.Category,
                    DefaultLanugage = q.DefaultLanugage,
                    IsPrivate = q.IsPrivate,
                    Id = q.Id,
                    Author = authors.FirstOrDefault(a => a.Id == q.AuthorId)?.Login ?? "",
                }).ToList(),
                Count = count,
            };
        }
    }
}
