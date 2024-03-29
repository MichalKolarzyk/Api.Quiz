﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.Abstracts
{
    public abstract class AggregateRoot : Entity
    {
        private List<DomainEvent> _domainEvents = new List<DomainEvent>();

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            if(_domainEvents == null)
                _domainEvents = new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public List<DomainEvent> GetDomainEvents()
        {
            if (_domainEvents == null)
                return new List<DomainEvent>();
            return _domainEvents;
        }
    }
}
