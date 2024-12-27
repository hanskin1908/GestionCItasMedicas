using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Application.DTOs
{
    public class RecetaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int PacienteId { get; set; }
      
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
