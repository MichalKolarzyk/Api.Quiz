using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    internal static class ServicesCollectionExtensions
    {
        public static async Task AddQuartz(this IServiceCollection services)
        {
            IScheduler scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.Start();
            services.AddSingleton(scheduler);
        }
    }
}
