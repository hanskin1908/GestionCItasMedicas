using AutoMapper;
using MediatR;
using Recetas.Application.DTOs;
using Recetas.Domain.Entities;
using Recetas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recetas.Application.Commands
{
    public class CreateRecetaCommandHandler : IRequestHandler<CreateRecetaCommand, RecetaDto>
    {
        private readonly IRecetaRepository _repository;
        private readonly IMapper _mapper;

        public CreateRecetaCommandHandler(IRecetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecetaDto> Handle(CreateRecetaCommand command, CancellationToken cancellationToken)
        {
            var receta = _mapper.Map<Receta>(command);
            receta.FechaCreacion = DateTime.UtcNow;

            var createdReceta = await _repository.AddAsync(receta);
            return _mapper.Map<RecetaDto>(createdReceta);
        }
    }
}
