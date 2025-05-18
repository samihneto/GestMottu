using GestMottu.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MottuGestor.Infrastructure.Context
{
    public class GestMottuContext : DbContext
    {
        public GestMottuContext(DbContextOptions<GestMottuContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
    }
}
