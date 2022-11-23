using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    public class MqQueue
    {
        public string Name { get; set; } = string.Empty;
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }
}
