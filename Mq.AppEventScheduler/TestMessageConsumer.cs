using BaseImplementationLib.RabbitMq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    public class TestMessageConsumer : MqConsumer<Customer>
    {
        public override void Consume(Customer message)
        {
            Console.WriteLine(message.Name);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
