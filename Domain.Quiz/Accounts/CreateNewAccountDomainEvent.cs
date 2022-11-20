﻿using Domain.Quiz.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Account
{
    public class CreateNewAccountDomainEvent : DomainEvent
    {
        public Guid AccountId { get; set; }

        public CreateNewAccountDomainEvent(Guid userId)
        {
            AccountId = userId;
        }
    }
}
