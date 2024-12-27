
using Citas.Domain.Interfaces;
using Citas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cita.Infrastructure.Repositories
{
    //public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    //{
    //    public PacienteRepository(CitasDbContext context) : base(context)
    //    {
    //    }

    //    public async Task<Paciente> GetByIdAsync(int id)
    //    {
    //        return await DbSet.FindAsync(id);
    //    }

    //    public async Task<Paciente> GetByDocumentoAsync(TipoDocumento tipoDocumento, string numeroDocumento)
    //    {
    //        return await DbSet.FirstOrDefaultAsync(p => p.TipoDocumento == tipoDocumento && p.NumeroDocumento == numeroDocumento);
    //    }
    //}
}
