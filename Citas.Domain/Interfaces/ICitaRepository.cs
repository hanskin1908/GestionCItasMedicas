using Citas.Domain.Entities;
using Citas.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citas.Domain.Interfaces
{
    public interface ICitaRepository
    {
        Task<Cita> GetByIdAsync(int id);
        Task<IEnumerable<Cita>> GetAllAsync();
        Task<Cita> AddAsync(Cita cita);
        Task UpdateAsync(Cita cita);
        Task DeleteAsync(int id);
    }
}
