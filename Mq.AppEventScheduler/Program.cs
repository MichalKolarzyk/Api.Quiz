using BaseImplementationLib;
using BaseImplementationLib.RabbitMq;
using MediatR;
using Microsoft.Extensions.Hosting;
using Mq.AppEventScheduler;

var settings = new Settings();

IHost host = Host.CreateDefaultBuilder().ConfigureServices(async services =>
{
    services.ReqisterMessageQueue(settings);
    services.RegisterMqConsumer<AppEventMessageConsumer>() ;
    services.RegisterMqQueue(new MqQueue { Name = "AppEventListener" });
    services.RegisterMqQueue(new MqQueue { Name = "TestListener" });
    services.RegisterMqExchange(new MqExchange { Name = "AppEventExchange" });
    services.RegisterMqQueueBinding(new MqQueueBind { ExchangeName = "AppEventExchange", QueueName = "TestListener" });
    services.AddMediatR(typeof(Settings).Assembly);
    await services.AddQuartz();
}).Build();

host.UseMq();
host.Run();
