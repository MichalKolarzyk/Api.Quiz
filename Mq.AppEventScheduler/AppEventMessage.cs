using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.AppEventScheduler
{
    public class AppEventMessage
    {
        public DateTime Start { get; set; }
        public int EventsAmount { get; set; } = 1;
        public int RepeatAfterSecounts { get; set; }
        public string Payload { get; set; } = string.Empty;
    }
}
