using APIDepartamento.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIDepartamento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
            modelBuilder.Entity<Pais>()
                .HasMany(p => p.Departamentos)
                .WithOne(d => d.Pais)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
