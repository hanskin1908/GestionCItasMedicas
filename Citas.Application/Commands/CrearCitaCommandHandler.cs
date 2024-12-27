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

namespace Citas.Application.Commands
{
    public class CreateCitaCommandHandler : IRequestHandler<CreateCitaCommand, CitaDto>
    {
        private readonly ICitaRepository _repository;
        private readonly IMapper _mapper;

        public CreateCitaCommandHandler()
        {
        }

        public CreateCitaCommandHandler(ICitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CitaDto> Handle(CreateCitaCommand command, CancellationToken cancellationToken)
        {
            var cita = _mapper.Map<Citas.Domain.Entities.Cita>(command);
            var createdCita = await _repository.AddAsync(cita);
            return _mapper.Map<CitaDto>(createdCita);
        }
    }
}
