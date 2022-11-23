using BaseImplementationLib.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    public class Settings : IMqSettings
    {
        public string MqHostName { get; } = "localhost";
    }
}
