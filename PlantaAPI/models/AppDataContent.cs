using API.Models;
using Microsoft.EntityFrameworkCore;

namespace PlantaAPI.Models
{
    public class AppDataContext : DbContext
    {
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Origem> Origens { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planta>()
                .HasOne(p => p.Origem)
                .WithMany(o => o.Plantas)
                .HasForeignKey(p => p.OrigemId);

            modelBuilder.Entity<Planta>()
                .HasOne(p => p.Tipo)
                .WithMany(t => t.Plantas)
                .HasForeignKey(p => p.TipoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
