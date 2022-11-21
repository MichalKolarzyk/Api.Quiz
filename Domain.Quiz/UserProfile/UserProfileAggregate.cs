﻿using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.UserProfile
{
    public class UserProfileAggregate : AggregateRoot
    {
        public Guid AccountId { get; set; }
        public string Image { get; set; } = string.Empty;
        public List<UserProfileWorkspace> UserProfileWorkspaces { get; set; } = new List<UserProfileWorkspace>();

        public UserProfileAggregate(Guid accountId)
        {
            AccountId = accountId;
            Id = Guid.NewGuid();
            AddDomainEvent(new CreateUserProfileDomainEvent { UserProfileId = Id});
        }

        public void AddWorkspace(UserProfileWorkspace userProfileWorkspace)
        {
            UserProfileWorkspaces.Add(userProfileWorkspace);
        }
    }
}
