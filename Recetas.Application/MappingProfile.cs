using Recetas.Application.Commands;
using Recetas.Application.DTOs;
using Recetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Recetas.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRecetaCommand, Receta>();
            CreateMap<Receta, RecetaDto>();
        }
    }
}
