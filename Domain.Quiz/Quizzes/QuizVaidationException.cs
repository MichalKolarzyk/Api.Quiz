using Domain.Quiz.Abstracts;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Quizzes
{
    public class QuizVaidationException : DomainException
    {
        public ValidationResult ValidationResult { get; set; }

        public QuizVaidationException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
