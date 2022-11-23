using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes
{
    public class GetQuizesCommand : IRequest<GetQuizesResponse>
    {
        public Guid WorkspaceId { get; set; }
    }

    public class GetQuizesCommandValidator : AbstractValidator<GetQuizesCommand>
    {
        public GetQuizesCommandValidator()
        {
            RuleFor(x => x.WorkspaceId).NotEmpty();
        }
    }
}
