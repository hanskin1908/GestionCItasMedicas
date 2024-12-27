using Personas.Dominio.Entities;
using Personas.Dominio.Interfaces;
using Personas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasDbContext _context;

        public PersonaRepository(PersonasDbContext context)
        {
            _context = context;
        }

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<IEnumerable<Persona>> GetByTipoAsync(string tipo)
        {
            return await _context.Personas
                .Where(p => p.TipoPersona == tipo)
                .ToListAsync();
        }

        public async Task<Persona> AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}
