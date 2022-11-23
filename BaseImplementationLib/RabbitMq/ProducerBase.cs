using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    public class ProducerBase<T>
    {
        public IModel _channel;

        public ProducerBase(IModel channel)
        {
            _channel = channel;
        }

        public void SendMessage(T message, string exchangeName)
        {
            var bodyAsString = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(bodyAsString);
            _channel.BasicPublish(exchange: exchangeName, "", basicProperties: null, body: body);
        }
    }
}
