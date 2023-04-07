using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Questions.GetQuestion
{
    public class GetQuestionRequest : IRequest<GetQuestionResponse>
    {
        public Guid Id { get; set; }

        public GetQuestionRequest(Guid id)
        {
            Id = id;
        }
    }
}
