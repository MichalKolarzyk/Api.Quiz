using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    internal class PublishAppEventCommand : INotification
    {
        public string Payload { get; set; } = string.Empty;
    }
}
