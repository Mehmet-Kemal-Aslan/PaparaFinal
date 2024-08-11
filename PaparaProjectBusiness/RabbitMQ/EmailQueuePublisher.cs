using Microsoft.Extensions.Options;
using PaparaProjectSchema.Notification;
using RabbitMQ.Client;
using System.Text;

namespace PaparaProjectBussiness.RabbitMQ
{
    public class EmailQueuePublisher :IEmailQueuePublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public EmailQueuePublisher(IOptions<RabbitMqSettings> rabbitMqSettings)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(rabbitMqSettings.Value.Uri) };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _queueName = rabbitMqSettings.Value.QueueName;
            _channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
