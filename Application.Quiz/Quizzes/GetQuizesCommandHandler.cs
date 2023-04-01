using Application.Quiz.Database;
using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes
{
    public class GetQuizesCommandHandler : IRequestHandler<GetQuizesCommand, GetQuizesResponse>
    {
        private readonly IRepository<QuizAggregate> _repository;

        public GetQuizesCommandHandler(IRepository<QuizAggregate> repository)
        {
            _repository = repository;
        }

        public async Task<GetQuizesResponse> Handle(GetQuizesCommand request, CancellationToken cancellationToken)
        {
            var quizes = await _repository.GetListAsync(q => q.WorkspaceId == request.WorkspaceId);

            return new GetQuizesResponse
            {
                Quizes = quizes,
            };
        }
    }
}
