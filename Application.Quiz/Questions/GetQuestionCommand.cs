using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions
{
    public class GetQuestionCommand : IRequest<GetQuestionResponse>
    {
        public Guid? WorkspaceId { get; set; }
    }
}
