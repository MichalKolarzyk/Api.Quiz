using Domain.Quiz.Quizzes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quiz
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand>
    {
        public Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
