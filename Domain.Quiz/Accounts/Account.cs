using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
