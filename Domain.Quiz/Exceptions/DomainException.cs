using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Abstracts
{
    public class DomainException : Exception, IRequest<ErrorMessage>
    {
    }
}
