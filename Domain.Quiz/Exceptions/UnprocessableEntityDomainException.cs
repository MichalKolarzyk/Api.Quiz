using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class UnprocessableEntityDomainException : DomainException
    {
        public string ErrorMessage { get; }
        public string Key { get; set; }

        public UnprocessableEntityDomainException(string errorMessage, string key = null)
        {
            ErrorMessage = errorMessage;
            Key = key;
        }
    }
}
