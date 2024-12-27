using MediatR;
using Recetas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Application.Commands
{
    public class CreateRecetaCommand : IRequest<RecetaDto>
    {
        public string Codigo { get; set; } // Código único de la receta
        public int PacienteId { get; set; } // ID del paciente
        public string Descripcion { get; set; } // Detalles de la receta
        public string Estado { get; set; } = "Activa"; // Estado inicial
        public DateTime FechaCreacion {get;set;}
    }
}
