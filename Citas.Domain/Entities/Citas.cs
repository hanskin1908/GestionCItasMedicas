using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Domain.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; } // ID de la persona paciente
        public int MedicoId { get; set; }   // ID de la persona médico
        public string Estado { get; set; } // Pendiente, En proceso, Finalizada
    }
}
