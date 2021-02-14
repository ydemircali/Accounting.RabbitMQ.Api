using System.Text;
using Accounting.RabbitMQ.Api.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Accounting.RabbitMQ.Api.Services
{
    public class RabbitMQService
    {
        public FisModel data;
        public RabbitMQService(FisModel _data)
        {
            this.data = _data;
        }
        public string Post()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "AccTransactions",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var fisModel = JsonConvert.SerializeObject(data);
                var body = Encoding.UTF8.GetBytes(fisModel);

                channel.BasicPublish(exchange: "",
                                     routingKey: "AccTransactions",
                                     basicProperties: null,
                                     body: body);
                return "TransactionObjectId:" + data.TransactionObjectId+ " added queue.";
            }
        }
    }
}