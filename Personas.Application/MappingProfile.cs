using AutoMapper;
using Personas.Dominio.DTOs;
using Personas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<CreatePersonaCommand, Persona>();
        }
    }
}
