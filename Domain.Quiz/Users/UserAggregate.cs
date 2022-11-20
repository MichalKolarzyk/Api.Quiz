using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Users
{
    public class UserAggregate : AggregateRoot
    {
        public string Login { get; set; } = string.Empty;

        public string HashPassword { get; set; } = string.Empty;

        public UserAggregate(string login, string hashPassword)
        {
            Login = login;
            HashPassword = hashPassword;
            Id = Guid.NewGuid();

            AddDomainEvent(new CreateNewUserDomainEvent(Id));
        }
    }
}
