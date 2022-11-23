using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    internal static class HostExtensionRabbitMq
    {
        internal static void UseMqConsumers(this IHost host)
        {
            var messageConsumers = host.Services.GetServices<IMqConsumer>();
            var channel = host.Services.GetService<IModel>();

            foreach (var consumer in messageConsumers)
            {
                var basicConsumer = consumer.Subscribe(channel);
                channel.BasicConsume(queue: consumer.QueueName,
                     autoAck: true,
                     consumer: basicConsumer);
            }
        }

        internal static void UseMqQueues(this IHost host)
        {
            var messageConsumers = host.Services.GetServices<MqQueue>();
            var channel = host.Services.GetService<IModel>();

            foreach (var consumer in messageConsumers)
            {
                channel.QueueDeclare(consumer.Name, consumer.Durable, consumer.Exclusive, consumer.AutoDelete, consumer.Properties);
            }
        }

        internal static void UseMqExchanges(this IHost host)
        {
            var mqExchanes = host.Services.GetServices<MqExchange>();
            var channel = host.Services.GetService<IModel>();

            foreach (var mqExchane in mqExchanes)
            {
                channel.ExchangeDeclare(mqExchane.Name, mqExchane.Type, mqExchane.Durable, mqExchane.AutoDelete, mqExchane.Arguments);
            }
        }

        internal static void UseMqExchangeBinds(this IHost host)
        {
            var mqExchanes = host.Services.GetServices<MqExchangeBind>();
            var channel = host.Services.GetService<IModel>();

            foreach (var mqExchane in mqExchanes)
            {
                channel.ExchangeBind(mqExchane.Destination, mqExchane.Source, mqExchane.RoutingKey, mqExchane.Arguments);
            }
        }

        internal static void UseMqQueueBinds(this IHost host)
        {
            var mqQueueBinds = host.Services.GetServices<MqQueueBind>();
            var channel = host.Services.GetService<IModel>();

            foreach (var mqQueueBind in mqQueueBinds)
            {
                channel.QueueBind(mqQueueBind.QueueName, mqQueueBind.ExchangeName, mqQueueBind.RoutingKey);
            }
        }
    }
}
