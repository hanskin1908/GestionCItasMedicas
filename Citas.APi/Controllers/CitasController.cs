using AutoMapper;
using Cita.Infrastructure.MessageBus;
using Citas.Application.Commands;
using Citas.Application.DTOs;
using Citas.Application.Queries;
using MediatR;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Citas.APi.Controllers
{
 
 
        [RoutePrefix("api/citas")]
        public class CitasController : ApiController
        {
            private readonly IMediator _mediator;
            private readonly IRabbitMQPublisher _messageBus;

            public CitasController(IMediator mediator, IRabbitMQPublisher messageBus)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
                _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
            }

            // Obtener cita por ID
            [HttpGet]
            [Route("{id:int}")]
            public async Task<IHttpActionResult> GetById(int id)
            {
                var query = new GetCitaByIdQuery { Id = id };
                var result = await _mediator.Send(query);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            // Crear cita
            [HttpPost]
            [Route("")]
            public async Task<IHttpActionResult> Create([FromBody] CreateCitaCommand command)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _mediator.Send(command);
                return Created($"api/citas/{result.Id}", result);
            }

            // Finalizar cita y notificar receta
            [HttpPut]
            [Route("{id:int}/finalizar")]
            public async Task<IHttpActionResult> Finalize(int id)
            {
                try
                {
                    // Simulación de finalización de cita
                    var query = new GetCitaByIdQuery { Id = id };
                    var cita = await _mediator.Send(query);

                    if (cita == null)
                        return NotFound();

                    cita.Estado = "Finalizada";
                var mensaje = new
                {
                    IdCita = cita.Id,
                    PacienteId = cita.PacienteId,
                    MedicoId = cita.MedicoId,
                    Estado = cita.Estado,
                    FechaFinalizacion = DateTime.UtcNow
                };
                // Publicar mensaje en RabbitMQ
                _messageBus.PublicarMensaje(mensaje, "cita.finalizada");

                return Ok($"Cita con ID {id} finalizada y notificada.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // Eliminar cita
            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IHttpActionResult> Delete(int id)
            {
                try
                {
                    // Aquí se implementaría la eliminación de la cita.
                    return Ok($"Cita con ID {id} eliminada correctamente.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }
