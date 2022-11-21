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
        Task Dispach(AggregateRoot aggregateRoot);
    }

    public class DomainEventDispacher : IDomainEventDispacher
    {
        private readonly IMediator _mediator;
        private readonly HashSet<AggregateRoot> _aggregateRoots = new HashSet<AggregateRoot>();

        public DomainEventDispacher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispach(AggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.GetDomainEvents())
            {
                await _mediator.Publish(domainEvent);
            }
        }


    }
}
