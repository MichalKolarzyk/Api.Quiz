using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quiz.Quizzes.GetQuiz
{
    public class GetQuizRequest : IRequest<GetQuizResponse>
    {
        public Guid Id { get; set; }

        public GetQuizRequest(Guid id)
        {
            Id = id;
        }
    }
}
