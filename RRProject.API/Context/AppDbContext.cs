using Microsoft.EntityFrameworkCore;
using RRProject.API.Entities;

namespace RRProject.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Candidata> Candidatas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 1,
                Nome = "Rayane Furtado",
                Clube = "Paysandu",
                ImagemUrl = "/Imagens/Candidatas/Paysandu.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 2,
                Nome = "Giovanna Cristinne Silva Picanço",
                Clube = "Grêmio Literário e Recreativo Português",
                ImagemUrl = "/Imagens/Candidatas/Grêmio Literário e Recreativo Português.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 3,
                Nome = "Isadora Andrade Rêgo",
                Clube = "Assembleia Paraense",
                ImagemUrl = "/Imagens/Candidatas/Assembléia Paraense.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 4,
                Nome = "Érica Venise da Silva Pinto",
                Clube = "Bancrévea",
                ImagemUrl = "/Imagens/Candidatas/Bancrévea.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 5,
                Nome = "Aline Carla Rodrigues Wanderley",
                Clube = "Guará Acqua Park",
                ImagemUrl = "/Imagens/Candidatas/Guará Acqua Park.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 6,
                Nome = "Ádria Mayara Pantoja Nogueira",
                Clube = "ASALP",
                ImagemUrl = "/Imagens/Candidatas/ASALP.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 7,
                Nome = "Janaína Pontes Ferreira",
                Clube = "Tuna Luso Brasileira ",
                ImagemUrl = "/Imagens/Candidatas/Tuna Luso Brasileira.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 8,
                Nome = "Ana de Nazaré Martins Barbosa",
                Clube = "Tênis Clube do Pará",
                ImagemUrl = "/Imagens/Candidatas/Tênis Clube.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 9,
                Nome = "Adriana dos Santos Pinheiro",
                Clube = "Clube do Remo",
                ImagemUrl = "/Imagens/Candidatas/Clube do Remo.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 10,
                Nome = "Monã Rita Vianna de Oliveira",
                Clube = "Iate Clube de Santarém",
                ImagemUrl = "/Imagens/Candidatas/Iate Clube de Santarém.png"
            });
        }
    }
}

