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
        public DbSet<AvaliacaoUsuario> Avaliacao { get; set; }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 1,
                Nome = "Fernanda Costa",
                Clube = "Assembleia Paraense",
                ImagemUrlclube = "/Imagens/Clubes/assembleia.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/assembleia.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 2,
                Nome = "Vitorya Carolyne",
                Clube = "Bancrévea",
                ImagemUrlclube = "/Imagens/Clubes/bancrevea.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/bancrevea.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 3,
                Nome = "Letícia Moraes",
                Clube = "Casota",
                ImagemUrlclube = "/Imagens/Clubes/casota.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/casota.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 4,
                Nome = "Natália Leão",
                Clube = "Cassazum",
                ImagemUrlclube = "/Imagens/Clubes/cassazum.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/cassazum.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 5,
                Nome = "Heloysa Rodrigues",
                Clube = "Clube de Engenharia",
                ImagemUrlclube = "/Imagens/Clubes/engenharia.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/engenharia.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 6,
                Nome = "Gabrielle Costa",
                Clube = "Clube do Remo",
                ImagemUrlclube = "/Imagens/Clubes/remo.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/remo.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 7,
                Nome = "Lídia Negrão",
                Clube = "Clube dos Advogado",
                ImagemUrlclube = "/Imagens/Clubes/oab.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/oab.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 8,
                Nome = "Ana Karina",
                Clube = "Grêmio Português ",
                ImagemUrlclube = "/Imagens/Clubes/gremio.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/gremio.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 9,
                Nome = "Giselly Geise",
                Clube = "Acqua Park",
                ImagemUrlclube = "/Imagens/Clubes/guara.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/guara.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 10,
                Nome = "Evelyn Moreira",
                Clube = "Pará Clube",
                ImagemUrlclube = "/Imagens/Clubes/clubepara.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/clubepara.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 11,
                Nome = "Tais Malato",
                Clube = "Paysandu",
                ImagemUrlclube = "/Imagens/Clubes/paysandu.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/paysandu.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 12,
                Nome = "Ana Maria Marques",
                Clube = "Tênis Clube",
                ImagemUrlclube = "/Imagens/Clubes/tenis.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/tenis.png"
            });
            modelBuilder.Entity<Candidata>().HasData(new Candidata
            {
                Id = 13,
                Nome = "Ingrid Kácia",
                Clube = "Tuna Luso",
                ImagemUrlclube = "/Imagens/Clubes/tuna.png",
                ImagemUrlcandidata = "/Imagens/Candidatas/tuna.png"
            });
        }
    }
}

