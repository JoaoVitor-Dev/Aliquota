using Aliquota.Entity;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Entity.Fundo> Fundos { get; set; }
        public DbSet<Entity.Cliente> Clientes { get; set; }
        public DbSet<Entity.Aplicacao> Aplicacoes { get; set; }
        public DbSet<Entity.Resgate> Resgates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacao>()
                .HasOne(a => a.Fundo)
                .WithMany(x => x.Aplicacoes)
                .HasForeignKey(x => x.FundoId);

            modelBuilder.Entity<Aplicacao>()
                .HasOne(a => a.Cliente)
                .WithMany(x => x.Aplicacoes)
                .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<Resgate>()
                 .HasOne(a => a.Fundo)
                 .WithMany(x => x.Resgates)
                 .HasForeignKey(x => x.FundoId);

            modelBuilder.Entity<Resgate>()
                 .HasOne(a => a.Cliente)
                 .WithMany(x => x.Resgates)
                 .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<Fundo>().HasData(
                new Fundo("Fundo de Investimento A") { Id = 1 },
                new Fundo("Fundo de Investimento B") { Id = 2 },
                new Fundo("Fundo de Investimento C") { Id = 3 }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente(1, "João"),
                new Cliente(2, "Maria"),
                new Cliente(3, "José")
            );
        }
    }
}
