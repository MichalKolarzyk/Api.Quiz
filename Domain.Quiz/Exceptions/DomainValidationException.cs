using Domain.Quiz.Abstracts;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class DomainValidationException : DomainException
    {
        public ValidationResult ValidationResult { get; set; }

        public DomainValidationException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
