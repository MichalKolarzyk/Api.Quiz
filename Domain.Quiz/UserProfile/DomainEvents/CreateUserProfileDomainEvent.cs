using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.UserProfile
{
    public class CreateUserProfileDomainEvent : DomainEvent
    {
        public Guid UserProfileId { get; set; }
    }
}
