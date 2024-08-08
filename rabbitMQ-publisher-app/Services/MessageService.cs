using RabbitMQ.Client;
using System.Text;

namespace rabbitMQ_publisher_app.Services
{
    public static class MessageService
    {
        public static async Task PublishMessageAsync()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "test", durable: false, exclusive: false,
                    autoDelete: false, arguments: null);

                var body = Encoding.UTF8.GetBytes("Teste mensagem");

                channel.BasicPublish(exchange: string.Empty,
                    routingKey: "test", basicProperties: null, body: body);
            }
        }
    }
}
