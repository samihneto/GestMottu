using Microsoft.EntityFrameworkCore;
using MottuGestor.Domain.Entities;
using MottuGestor.Infrastructure.Mappings;

namespace MottuGestor.Infrastructure.Context
{
    public class GestMottuContext : DbContext
    {
        public GestMottuContext(DbContextOptions<GestMottuContext> options)
            : base(options) { }

        public DbSet<Moto> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MotoMapping());
        }
    }
}
