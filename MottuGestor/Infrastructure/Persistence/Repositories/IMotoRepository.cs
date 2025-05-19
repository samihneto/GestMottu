using MottuGestor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MottuGestor.Infrastructure.Persistence.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(int id);
        Task<IEnumerable<Moto>> GetByModeloAsync(string modelo);
        Task AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(int id);
    }
}