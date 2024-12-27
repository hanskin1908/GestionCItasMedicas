using MediatR;
using Recetas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Application.Queries
{
    public class GetRecetaByCodigoQuery : IRequest<RecetaDto>
    {
        public string Codigo { get; set; }
    }
}
