using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Domain.Entities
{
    public class Medico : Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
    }
}
