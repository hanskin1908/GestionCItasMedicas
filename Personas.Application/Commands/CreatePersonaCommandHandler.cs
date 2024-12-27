using AutoMapper;
using MediatR;
using Personas.Dominio.DTOs;
using Personas.Dominio.Entities;
using Personas.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Personas.Application.Commands
{
    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, PersonaDto>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonaCommandHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonaDto> Handle(CreatePersonaCommand command, CancellationToken cancellationToken)
        {
            var persona = _mapper.Map<Persona>(command);
            persona.Activo = true;

            var result = await _repository.AddAsync(persona);
            return _mapper.Map<PersonaDto>(result);
        }
    }
}
