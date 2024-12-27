using Cita.Infrastructure.MessageBus;
using Citas.Domain.Enum;
using Citas.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Citas.Application.Commands
{
    //public class FinalizarCitaCommandHandler : IRequestHandler<FinalizarCitaCommand>
    //{
    //    //private readonly ICitaRepository _citaRepository;
    //    //private readonly IRabbitMQPublisher _rabbitMQPublisher;

    //    //public FinalizarCitaCommandHandler(
    //    //    ICitaRepository citaRepository,
    //    //    IRabbitMQPublisher rabbitMQPublisher)
    //    //{
    //    //    _citaRepository = citaRepository;
    //    //    _rabbitMQPublisher = rabbitMQPublisher;
    //    //}

    //    //public async Task<Unit> Handle(FinalizarCitaCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    var cita = await _citaRepository.GetByIdAsync(request.Id);
    //    //    cita.Estado = CitaEstado.Finalizada;
    //    //    await _citaRepository.UpdateAsync(cita);

    //    //    // Publicar evento de cita finalizada en RabbitMQ
    //    //    await _rabbitMQPublisher.PublishCitaFinalizadaEvent(cita);

    //    //    return Unit.Value;
    //    //}

    //    //Task IRequestHandler<FinalizarCitaCommand>.Handle(FinalizarCitaCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
}
