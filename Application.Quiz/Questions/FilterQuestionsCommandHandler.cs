using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class FilterQuestionsCommandHandler : IRequestHandler<FilterQuestionsCommand, GetQuestionsResponse>
    {
        private readonly IRepository<Question> _questionRepository;

        public FilterQuestionsCommandHandler(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<GetQuestionsResponse> Handle(FilterQuestionsCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Question, bool>> predicate = q => q.IsPrivate == request.IsPrivate;

            var questions = await _questionRepository.GetListAsync(predicate, request.Take, request.Skip);
            var count = await _questionRepository.GetCount(predicate);

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
                }).ToList(),
                Count = count,
            };
        }
    }
}
