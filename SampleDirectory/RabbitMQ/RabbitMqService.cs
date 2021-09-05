using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace RabbitMQ
{
    public class RabbitMqService:IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName;
        public static string RoutingReport;
        public static string QueueName;
        public RabbitMqService(IConfiguration configuration, ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            ExchangeName = configuration.GetSection(RabbitMqOptions.ExchangeName).Value;
            RoutingReport = configuration.GetSection(RabbitMqOptions.RoutingReport).Value;
            QueueName = configuration.GetSection(RabbitMqOptions.QueueName).Value;
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();

            if (_channel is {IsOpen:true})
            {
                return _channel;
            }

            _channel = _connection.CreateModel();

            return _channel;
        }


        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();

            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
