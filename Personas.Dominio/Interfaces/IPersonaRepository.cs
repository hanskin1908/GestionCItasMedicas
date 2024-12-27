using Personas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Dominio.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Persona> GetByIdAsync(int id);
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<IEnumerable<Persona>> GetByTipoAsync(string tipo);
        Task<Persona> AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}
