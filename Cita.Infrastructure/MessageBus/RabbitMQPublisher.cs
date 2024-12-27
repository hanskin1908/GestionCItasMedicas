using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.Entity.Infrastructure;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
namespace Cita.Infrastructure.MessageBus
{
    public class RabbitMQService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "citas_exchange";
        private const string RoutingKey = "cita.finalizada";
        private bool _disposed;

        public RabbitMQService(string hostName, string userName, string password)
        {
            var factory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };

            _connection = (IConnection)factory.CreateConnectionAsync();
            _channel = _connection.CreateModel();

            // Configurar exchange
            _channel.ExchangeDeclare(
                exchange: ExchangeName,
                type: ExchangeType.Direct,
                durable: true,
                autoDelete: false);
        }

        public void PublicarMensaje<T>(T mensaje)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(RabbitMQService));

            var json = JsonConvert.SerializeObject(mensaje);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
                exchange: ExchangeName,
                routingKey: RoutingKey,
                basicProperties: properties,
                body: body);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _channel?.Dispose();
                _connection?.Dispose();
            }

            _disposed = true;
        }

        ~RabbitMQService()
        {
            Dispose(false);
        }
    }
}
