using Domain.Quiz.Abstracts;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class ValidationDomainException : DomainException
    {
        public ValidationResult ValidationResult { get; set; }

        public ValidationDomainException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
