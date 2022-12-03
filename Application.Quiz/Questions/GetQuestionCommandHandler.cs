using Application.Quiz.Database;
using Domain.Quiz.Questions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class GetQuestionCommandHandler : IRequestHandler<GetQuestionCommand, GetQuestionResponse>
    {
        private readonly IRepository<QuestionAggregate> _questionRepository;

        public GetQuestionCommandHandler(IRepository<QuestionAggregate> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<GetQuestionResponse> Handle(GetQuestionCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<QuestionAggregate> output = _questionRepository.Get(q => true);
            if (request.WorkspaceId != null)
                output = output.Where(q => q.WorkspaceId == request.WorkspaceId);

            return new GetQuestionResponse()
            {
                Questions = output.Select(q => new GetQuestionDto
                {
                    Answers = q.Answers,
                    CorrectAnswerIndex = q.CorrectAnswerIndex,
                    Description = q.Description,
                    Id = q.Id,
                    WorkspaceId = q.WorkspaceId,
                }).ToList(),
            };
        }
    }
}
