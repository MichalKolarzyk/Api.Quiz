using BaseImplementationLib.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    internal class Settings : IMqSettings
    {
        public string MqHostName { get; } = Environment.GetEnvironmentVariable("RABBITMQ_HOST_NAME") ?? "localhost";
    }
}
