using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;


namespace Recetas.Infrastructure.MessageBus
{
    public class RabbitMQListener
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "recetas_queue";

        public void Listen()
        {
            var factory = new ConnectionFactory { HostName = _hostName };
            var connection = (IConnection)factory.CreateConnectionAsync();
            var channel = (IChannel)connection.CreateChannelAsync();

            channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);

                var citaData = JsonConvert.DeserializeObject<dynamic>(message);
                Console.WriteLine($"Recibido: {JsonConvert.SerializeObject(citaData)}");
                // Aquí se implementaría la creación de la receta en base a los datos de la cita.
            };

            channel.BasicConsumeAsync(queue: _queueName, autoAck: true, consumer: consumer);
        }
    }
}
