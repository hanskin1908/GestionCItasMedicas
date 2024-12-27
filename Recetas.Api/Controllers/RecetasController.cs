using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Recetas.Application;
using Recetas.Application.Commands;
using Recetas.Application.DTOs;
using Recetas.Application.Queries;
using Recetas.Domain.Entities;
using Recetas.Domain.Interfaces;
using Recetas.Infrastructure.Data;
using Recetas.Infrastructure.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Recetas.Api.Controllers
{
    [RoutePrefix("api/recetas")]
    public class RecetasController : ApiController
    {
        private readonly RecetasDbContext _dbContext;
        private readonly RecetaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RecetasController()
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
            services.AddTransient<IRecetaRepository, RecetaRepository>();
            services.AddTransient<RecetasDbContext>();

            // Registro de handlers de MediatR
            services.AddTransient<IRequestHandler<CreateRecetaCommand, RecetaDto>, CreateRecetaCommandHandler>();
            var context = new RecetasDbContext();
            _repository = new RecetaRepository(context);
            // Registro de MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(
                    typeof(CreateRecetaCommand).Assembly
                );
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
           


            // Construcción del contenedor
            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
            _mapper = config.CreateMapper();
        }

        // Obtener receta por código
        [HttpGet]
        [Route("codigo/{codigo}")]
        public async Task<IHttpActionResult> GetByCodigo(string codigo)
        {
            try
            {
                var receta = await _repository.GetByCodigoAsync(codigo);
                if (receta == null)
                    return NotFound();

                var recetaDto = _mapper.Map<RecetaDto>(receta);
                return Ok(recetaDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Crear receta
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] CreateRecetaCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
          
                var receta = _mapper.Map<Receta>(command);
                await _repository.AddAsync(receta);

                var recetaDto = _mapper.Map<RecetaDto>(receta);
                return Created($"api/recetas/{recetaDto.Codigo}", recetaDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Actualizar receta
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] RecetaDto recetaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var receta = await _repository.GetByIdAsync(id);
                if (receta == null)
                    return NotFound();

                receta = _mapper.Map(recetaDto, receta);
                await _repository.UpdateAsync(receta);

                var updatedDto = _mapper.Map<RecetaDto>(receta);
                return Ok(updatedDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Eliminar receta
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                // Aquí se implementaría la lógica para eliminar la receta.
                return Ok($"Receta con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

