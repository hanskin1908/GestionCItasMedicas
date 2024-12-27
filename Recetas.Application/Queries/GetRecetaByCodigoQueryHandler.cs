using AutoMapper;
using MediatR;
using Recetas.Application.DTOs;
using Recetas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recetas.Application.Queries
{
    public class GetRecetaByCodigoQueryHandler : IRequestHandler<GetRecetaByCodigoQuery, RecetaDto>
    {
        private readonly IRecetaRepository _repository;
        private readonly IMapper _mapper;

        public GetRecetaByCodigoQueryHandler(IRecetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecetaDto> Handle(GetRecetaByCodigoQuery query, CancellationToken cancellationToken)
        {
            var receta = await _repository.GetByCodigoAsync(query.Codigo);
            return _mapper.Map<RecetaDto>(receta);
        }
    }
}
