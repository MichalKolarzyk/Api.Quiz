using Domain.Quiz.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quiz.Databases
{
    public interface IDomainEventDispacher
    {
        void AddAggregate(AggregateRoot aggregateRoot);
        Task Dispach();
    }

    public class DomainEventDispacher : IDomainEventDispacher
    {
        private readonly IMediator _mediator;
        private readonly HashSet<AggregateRoot> _aggregateRoots = new HashSet<AggregateRoot>();

        public DomainEventDispacher(IMediator mediator)
        {
            _mediator = mediator;
        }


        public void AddAggregate(AggregateRoot aggregateRoot)
        {
            _aggregateRoots.Add(aggregateRoot);
        }

        public async Task Dispach()
        {
            var domainEvents = _aggregateRoots.SelectMany(a => a.GetDomainEvents());
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }


    }
}
