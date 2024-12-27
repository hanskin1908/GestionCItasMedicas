using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Dominio.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoPersona { get; set; } // Médico o Paciente
        public string Especialidad { get; set; } // Solo para médicos
        public bool Activo { get; set; }
    }
}
