using Citas.Application.DTOs;
using Citas.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.Queries
{
    public class GetCitaByIdQuery : IRequest<CitaDto>
    {
        public int Id { get; set; }
    }
}
