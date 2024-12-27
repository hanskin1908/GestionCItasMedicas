using Recetas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.Domain.Interfaces
{
    public interface IRecetaRepository
    {
        Task<Receta> GetByIdAsync(int id);
        Task<Receta> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Receta>> GetByPacienteIdAsync(int pacienteId);
        Task<Receta> AddAsync(Receta receta);
        Task UpdateAsync(Receta receta);
        Task DeleteAsync(int id);
    }
}
