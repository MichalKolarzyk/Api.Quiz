using BaseImplementationLib.RabbitMq;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    internal class PublishAppEventCommandHandler : INotificationHandler<PublishAppEventCommand>
    {
        private readonly ProducerBase<string> _producer;

        public PublishAppEventCommandHandler(ProducerBase<string> producer)
        {
            _producer = producer;
        }

        public Task Handle(PublishAppEventCommand notification, CancellationToken cancellationToken)
        {
            _producer.SendMessage(notification.Payload, "AppEventExchange");
            return Unit.Task;
        }
    }
}
