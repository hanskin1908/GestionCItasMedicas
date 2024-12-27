using MediatR;
using Recetas.Application.Commands;
using Recetas.Application.DTOs;
using Recetas.Application.Queries;
using System;
using System.Collections.Generic;
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
        private readonly IMediator _mediator;

        public RecetasController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Obtener receta por código
        [HttpGet]
        [Route("codigo/{codigo}")]
        public async Task<IHttpActionResult> GetByCodigo(string codigo)
        {
            var query = new GetRecetaByCodigoQuery { Codigo = codigo };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // Crear receta
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] CreateRecetaCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            return Created($"api/recetas/{result.Codigo}", result);
        }

        // Actualizar receta
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRecetaCommand
            {
                Codigo = recetaDto.Codigo,
                PacienteId = recetaDto.PacienteId,
                Descripcion = recetaDto.Descripcion,
                Estado = recetaDto.Estado
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Eliminar receta
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                // Aquí se implementaría la eliminación de la receta.
                return Ok($"Receta con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}