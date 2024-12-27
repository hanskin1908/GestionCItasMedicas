using AutoMapper;
using Citas.Application.DTOs;
using Citas.Domain.Entities;
using Citas.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Citas.Application.Queries
{
    public class GetCitaByIdQueryHandler : IRequestHandler<GetCitaByIdQuery, CitaDto>
    {
        private readonly ICitaRepository _repository;
        private readonly IMapper _mapper;

        public GetCitaByIdQueryHandler()
        {
        }

        public GetCitaByIdQueryHandler(ICitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CitaDto> Handle(GetCitaByIdQuery query, CancellationToken cancellationToken)
        {
            var cita = await _repository.GetByIdAsync(query.Id);
            return _mapper.Map<CitaDto>(cita);
        }
    }
}
