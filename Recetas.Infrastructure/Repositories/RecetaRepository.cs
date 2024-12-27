using Recetas.Domain.Entities;
using Recetas.Domain.Interfaces;
using Recetas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Infrastructure.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasDbContext _context;

        public RecetaRepository(RecetasDbContext context)
        {
            _context = context;
        }

        public async Task<Receta> GetByIdAsync(int id) => await _context.Recetas.FindAsync(id);

        public async Task<Receta> GetByCodigoAsync(string codigo) =>
            await _context.Recetas.FirstOrDefaultAsync(r => r.Codigo == codigo);

        public async Task<IEnumerable<Receta>> GetByPacienteIdAsync(int pacienteId) =>
            await _context.Recetas.Where(r => r.PacienteId == pacienteId).ToListAsync();

        public async Task<Receta> AddAsync(Receta receta)
        {
            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();
            return receta;
        }

        public async Task UpdateAsync(Receta receta)
        {
            _context.Entry(receta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta != null)
            {
                _context.Recetas.Remove(receta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
