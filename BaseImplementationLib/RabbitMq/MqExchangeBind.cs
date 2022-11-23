using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    public class MqExchangeBind
    {
        public string Destination { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
        public IDictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>();  
    }
}
