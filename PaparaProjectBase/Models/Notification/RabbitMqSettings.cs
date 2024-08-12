using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectBase.Models.Notification
{
    public class RabbitMqSettings
    {
        public string Uri { get; set; }
        public string QueueName { get; set; }
    }
}
