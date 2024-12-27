using Citas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.Commands
{
    public class CreateCitaCommand : IRequest<CitaDto>
    {
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; } // ID del paciente
        public int MedicoId { get; set; }   // ID del médico
        public string Estado { get; set; } = "Pendiente"; // Estado inicial
    }
}
