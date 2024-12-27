
using Citas.Domain.Interfaces;
using Citas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cita.Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly CitasDbContext _context;

        public CitaRepository(CitasDbContext context)
        {
            _context = context;
        }

        public async Task<Citas.Domain.Entities.Cita> GetByIdAsync(int id) => await _context.Citas.FindAsync(id);

        public async Task<IEnumerable<Citas.Domain.Entities.Cita>> GetAllAsync() => await _context.Citas.ToListAsync();

        public async Task<Citas.Domain.Entities.Cita> AddAsync(Citas.Domain.Entities.Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task UpdateAsync(Citas.Domain.Entities.Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
            }
        }
    }
}
