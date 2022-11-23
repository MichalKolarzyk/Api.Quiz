using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseImplementationLib.RabbitMq
{
    public interface IMqSettings
    {
        string MqHostName { get; }
    }
}
