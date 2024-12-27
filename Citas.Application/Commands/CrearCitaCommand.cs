using Citas.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.Commands
{
    public class CrearCitaCommand : IRequest<Citas.Domain.Entities.Cita>
    {
        public DateTime FechaHora { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
    }
}
