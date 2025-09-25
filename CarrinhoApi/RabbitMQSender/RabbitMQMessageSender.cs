using MessageBuss;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace CarrinhoApi.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;
        public RabbitMQMessageSender(IConfiguration configuration)
        {
            //_hostname = configuration["RabbitMQ:Hostname"];
            _hostname = "localhost";
            //_password = configuration["RabbitMQ:Password"];
            _password = "r3n4t0321";
            //_password = configuration["RabbitMQ:Password"];
            _username = "renatoads1";
        }
        public void SendMessage(BaseMessage message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, null);
            byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

            throw new NotImplementedException();
        }
    }
}
