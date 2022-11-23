using BaseImplementationLib;
using BaseImplementationLib.RabbitMq;
using Microsoft.Extensions.Hosting;
using Mq.AppEventScheduler;

var settings = new Settings();

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.ReqisterMessageQueue(settings);
    services.RegisterMqConsumer(new TestMessageConsumer() { QueueName = "Queue" });
    services.RegisterMqQueue(new MqQueue { Name = "Queue" });
    services.RegisterMqExchange(new MqExchange { Name = "ExchangeTest" });
    services.RegisterMqQueueBinding(new MqQueueBind { QueueName = "Queue", ExchangeName = "ExchangeTest" });

}).Build();

host.UseMq();
host.Run();
