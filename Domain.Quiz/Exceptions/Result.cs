using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Exceptions
{
    public class Result
    {
        private List<Error> _errors = new List<Error>();
        public bool HasErrors => _errors.Any();

        public void AddError(Error error)
        {
            _errors.Add(error);
        }

        public DomainException ToException()
        {
            if (!HasErrors)
            {
                throw new Exception("Result does not contain errors");
            }

            return new DomainException
            {
                StatusCode = _errors.First().Code,
                Errors = _errors.ToDictionary(e => e.Field, e => e.Message),
            };
        }

        public static DomainException DomainException(Error error)
        {
            return new DomainException
            {
                StatusCode = error.Code,
                Errors = new Dictionary<string, string>()
                {
                    { error.Field, error.Message },
                },
            };
        }
    }
}
