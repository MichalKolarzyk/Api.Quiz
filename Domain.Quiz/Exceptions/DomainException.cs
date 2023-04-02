using MediatR;

namespace Domain.Quiz.Abstracts
{
    public class DomainException : Exception
    {
        public int StatusCode { get; set; }
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
