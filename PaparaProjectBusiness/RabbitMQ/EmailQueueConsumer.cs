using Microsoft.Extensions.Options;
using PaparaProjectBase.Models.Notification;
using PaparaProjectBussiness.Notifications;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PaparaProjectBussiness.RabbitMQ
{
    public class EmailQueueConsumer : IEmailQueueConsumer
    {
        private readonly INotificationService _notificationService;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public EmailQueueConsumer(INotificationService notificationService, IOptions<RabbitMqSettings> rabbitMqSettings)
        {
            _notificationService = notificationService;
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

        public void Start()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailMessage = JsonSerializer.Deserialize<EmailMessage>(message);

                _notificationService.SendEmail(emailMessage.Subject, emailMessage.Email, emailMessage.Content);
            };

            _channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
