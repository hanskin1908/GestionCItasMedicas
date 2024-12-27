using MediatR;
using Personas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application.Queries
{
    public class GetPersonaByIdQuery : IRequest<PersonaDto>
    {
        public int Id { get; set; }
    }
}
