using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class NotFoundDomainException : DomainException
    {
        public string ErrorMessage { get; }

        public NotFoundDomainException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
