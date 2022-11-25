using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    public class JobWithAction : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Func<Task> action = GetTask(context);
            await action();
        }

        public Func<Task> GetTask(IJobExecutionContext context)
        {
            var containsAction = context.JobDetail.JobDataMap.TryGetValue("Action", out var actionObject);
            if (containsAction == true && actionObject is Func<Task> action)
                return action;
            return null ;
        }
    }
}
