using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Users
{
    public class CreateNewUserDomainEvent : DomainEvent
    {
        public Guid UserId { get; set; }

        public CreateNewUserDomainEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
