﻿using MediatR;
using Personas.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application
{
    public class CreatePersonaCommand : IRequest<PersonaDto>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoPersona { get; set; }
        public string Especialidad { get; set; }
    
    }
}
