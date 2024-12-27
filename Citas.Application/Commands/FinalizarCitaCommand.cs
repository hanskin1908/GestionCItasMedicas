﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Application.Commands
{
    public class FinalizarCitaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
