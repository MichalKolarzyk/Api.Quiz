using Domain.Quiz.Abstracts;
using Domain.Quiz.Exceptions;
using Domain.Quiz.Questions;


namespace Domain.Quiz.Accounts
{
    public class Account : AggregateRoot
    {
        public string Login { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public Account(string login, string hashPassword)
        {
            Login = login;
            HashPassword = hashPassword;
            Id = Guid.NewGuid();
            Language = "Us-en";
        }
    }
}
