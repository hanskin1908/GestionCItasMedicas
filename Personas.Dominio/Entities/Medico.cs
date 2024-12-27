using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Dominio.Entities
{
    public class Medico : Persona
    {
        public string Especialidad { get; set; }

        public bool PuedeAtenderCitas()
        {
            return Activo && !string.IsNullOrEmpty(Especialidad);
        }
    }
}
