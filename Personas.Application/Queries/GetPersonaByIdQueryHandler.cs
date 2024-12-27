using AutoMapper;
using MediatR;
using Personas.Dominio.DTOs;
using Personas.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Personas.Application.Queries
{
    public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, PersonaDto>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonaByIdQueryHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonaDto> Handle(GetPersonaByIdQuery query, CancellationToken cancellationToken)
        {
            var persona = await _repository.GetByIdAsync(query.Id);
            return _mapper.Map<PersonaDto>(persona);
        }
    }
}
