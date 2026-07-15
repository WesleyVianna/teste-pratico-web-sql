using Microsoft.EntityFrameworkCore;
using PontoTuristicoApp.Models;

namespace PontoTuristicoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<PontoTuristico> PontosTuristicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cria índices para acelerar as buscas na listagem
            modelBuilder.Entity<PontoTuristico>()
                .HasIndex(p => p.Nome);

            modelBuilder.Entity<PontoTuristico>()
                .HasIndex(p => p.Cidade);
        }
    }
}