using GestMottu.API.Domain.Entities;

namespace MottuGestor.Infrasctructure.Persistence.Repositories
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