using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.DTOs
{
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Estado { get; set; }
    }
}
