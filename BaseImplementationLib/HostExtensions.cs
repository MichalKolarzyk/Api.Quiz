using BaseImplementationLib.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace BaseImplementationLib
{
    public static class HostExtensions
    {
        public static void UseMq(this IHost host)
        {
            host.UseMqQueues();
            host.UseMqExchanges();
            host.UseMqExchangeBinds();
            host.UseMqQueueBinds();
            host.UseMqConsumers();
        }
    }
}
