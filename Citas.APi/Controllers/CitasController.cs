using AutoMapper;
using Cita.Infrastructure.MessageBus;
using Cita.Infrastructure.Repositories;
using Citas.Application;
using Citas.Application.Commands;
using Citas.Application.DTOs;
using Citas.Application.Queries;
using Citas.Domain.Interfaces;
using Citas.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly RabbitMQPublisher _messageBus;

        public CitasController(IMediator @object)
        {
            var services = new ServiceCollection();

            // Configuración de AutoMapper
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Registro de dependencias core
            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<CitasDbContext>();

            // Registro de handlers de MediatR
            services.AddTransient<IRequestHandler<CreateCitaCommand, CitaDto>, CreateCitaCommandHandler>();

            // Registro de MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(
                    typeof(CreateCitaCommand).Assembly
                );
            });

            // Configuración de RabbitMQ
            var hostname = "localhost";
            var username = "guest";
            var password = "guest";
            _messageBus = new RabbitMQPublisher(hostname, username, password);

            // Construcción del contenedor
            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
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
                _messageBus.PublicarMensaje( "cita.finalizada");

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
                // Aquí se implementaría la lógica para eliminar la cita
                return Ok($"Cita con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
    
