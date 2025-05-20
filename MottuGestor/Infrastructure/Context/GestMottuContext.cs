
using Microsoft.EntityFrameworkCore;
using MottuGestor.API.Domain.Entities;
using MottuGestor.API.Infrastructure.Mappings;

namespace MottuGestor.Infrastructure.Context
{
    public class GestMottuContext : DbContext
    {
        public GestMottuContext(DbContextOptions<GestMottuContext> options) : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
