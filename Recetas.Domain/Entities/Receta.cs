using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Domain.Entities
{
    public class Receta
    {
        public int Id { get; set; }
        public string Codigo { get; set; } // Código único de la receta
        public int PacienteId { get; set; } // ID del paciente asociado
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } // Activa, Vencida, Entregada
        public string Descripcion { get; set; } // Descripción o contenido de la receta
    }
}
