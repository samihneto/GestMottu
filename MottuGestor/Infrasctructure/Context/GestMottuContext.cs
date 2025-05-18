using GestMottu.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MottuGestor.Infrasctructure.Context
{
    public class GestMottuContext : DbContext
    {
        public GestMottuContext(DbContextOptions<GestMottuContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
    }
}
