using MottuGestor.Infrastructure.Context;
using GestMottu.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MottuGestor.Infrasctructure.Persistence.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly GestMottuContext _context;

        public MotoRepository(GestMottuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moto>> GetAllAsync() =>
            await _context.Motos.ToListAsync();

        public async Task<Moto?> GetByIdAsync(int id) =>
            await _context.Motos.FindAsync(id);

        public async Task<IEnumerable<Moto>> GetByModeloAsync(string modelo) =>
            await _context.Motos
                .Where(m => m.Modelo.Contains(modelo))
                .ToListAsync();

        public async Task AddAsync(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Moto moto)
        {
            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is not null)
            {
                _context.Motos.Remove(moto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
