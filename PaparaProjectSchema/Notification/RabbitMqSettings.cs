using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectSchema.Notification
{
    public class RabbitMqSettings
    {
        public string Uri { get; set; }
        public string QueueName { get; set; }
    }
}
