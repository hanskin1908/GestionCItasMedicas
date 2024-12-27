using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cita.Infrastructure.MessageBus
{
    public interface IRabbitMQPublisher
    {
        void PublicarMensaje(object mensaje, string v);
        Task PublishCitaFinalizadaEvent(Citas.Domain.Entities.Cita cita);
        Task PublishEventAsync<T>(T @event) where T : IDomainEvent;
    }
}
