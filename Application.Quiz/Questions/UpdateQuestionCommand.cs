using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class UpdateQuestionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid WorkspaceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new();
        public int CorrectAnswerIndex { get; set; }
    }

    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(x => x.CorrectAnswerIndex)
                .LessThan(x => x.Answers.Count);
        }
    }
}
