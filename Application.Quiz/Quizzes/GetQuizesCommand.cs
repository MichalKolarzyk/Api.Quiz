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
        public Guid AuthorId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
