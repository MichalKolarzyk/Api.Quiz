using BaseImplementationLib.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib
{
    public static class ServiceCollectionExtensions
    {
        public static void ReqisterMessageQueue(this IServiceCollection services, IMqSettings mqSettings)
        {
            var factory = new ConnectionFactory() { HostName = mqSettings.MqHostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            services.AddSingleton<IMqSettings>(mqSettings);
            services.AddSingleton(channel);
            services.AddSingleton(typeof(ProducerBase<>));
        }

        public static void RegisterMqConsumer<TConsumer>(this IServiceCollection services)
            where TConsumer : class, IMqConsumer
        {
            services.AddScoped<IMqConsumer, TConsumer>();
        }

        public static void RegisterMqQueue(this IServiceCollection services, MqQueue queue)
        {
            services.AddSingleton<MqQueue>(queue);
        }

        public static void RegisterMqExchange(this IServiceCollection services, MqExchange mqExchange)
        {
            services.AddSingleton<MqExchange>(mqExchange);
        }

        public static void RegisterMqExchangeBinding(this IServiceCollection services, MqExchangeBind mqExchangeBind)
        {
            services.AddSingleton<MqExchangeBind>(mqExchangeBind);
        }

        public static void RegisterMqQueueBinding(this IServiceCollection services, MqQueueBind mqQueueBind)
        {
            services.AddSingleton<MqQueueBind>(mqQueueBind);
        }
    }
}
