using BaseImplementationLib.RabbitMq;
using MediatR;
using Quartz;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    public class AppEventMessageConsumer : MqConsumer<AppEventMessage>
    {
        IMediator _mediator;
        IScheduler _scheduler;

        public AppEventMessageConsumer(IMediator mediator, IScheduler scheduler)
        {
            _mediator = mediator;
            _scheduler = scheduler;
            QueueName = "AppEventListener";
        }

        public override void Consume(AppEventMessage message)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object> { { "Action", async () => await _mediator.Publish(new PublishAppEventCommand { Payload = message.Payload }) } };
            var jobDataMap = new JobDataMap(keyValuePairs as IDictionary<string, object>);
            var job = JobBuilder.Create<JobWithAction>().UsingJobData(jobDataMap).Build();

            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(message.RepeatAfterSecounts)
                    .WithRepeatCount(message.EventsAmount))
                .Build();

            _scheduler.ScheduleJob(job, trigger);
        }
    }
}
