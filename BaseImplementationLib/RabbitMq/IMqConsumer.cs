using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    public interface IMqConsumer<T> : IMqConsumer
    {
        void Consume(T message);
    }

    public interface IMqConsumer
    {
        EventingBasicConsumer Subscribe(IModel channel);
        string QueueName { get; set; }
    }

    public abstract class MqConsumer<T> : IMqConsumer<T>
    {
        public string QueueName { get; set; } = string.Empty;

        public abstract void Consume(T message);
        
        public EventingBasicConsumer Subscribe(IModel channel)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var item = JsonConvert.DeserializeObject<T>(message);
                Consume(item ?? throw new Exception("CannotSerialize"));
            };
            return consumer;
        }
    }
}
