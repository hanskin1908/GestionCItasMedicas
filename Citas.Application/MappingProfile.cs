using AutoMapper;
using Citas.Application.Commands;
using Citas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCitaCommand, Citas.Domain.Entities.Cita>();
            CreateMap<Citas.Domain.Entities.Cita, CitaDto>();
        }
    }
}
