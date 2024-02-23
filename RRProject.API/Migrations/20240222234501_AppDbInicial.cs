using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RRProject.API.Migrations
{
    /// <inheritdoc />
    public partial class AppDbInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidataIdenti = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdenti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaBeleza = table.Column<int>(type: "int", nullable: false),
                    NotaFantasia = table.Column<int>(type: "int", nullable: false),
                    NotaApresentacao = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemUrlclube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemUrlcandidata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidatas",
                columns: new[] { "Id", "Clube", "ImagemUrlcandidata", "ImagemUrlclube", "Nome" },
                values: new object[,]
                {
                    { 1, "Assembleia Paraense", "/Imagens/Candidatas/assembleia.png", "/Imagens/Clubes/assembleia.png", "Fernanda Costa" },
                    { 2, "Bancrévea", "/Imagens/Candidatas/bancrevea.png", "/Imagens/Clubes/bancrevea.png", "Vitorya Carolyne" },
                    { 3, "Casota", "/Imagens/Candidatas/casota.png", "/Imagens/Clubes/casota.png", "Letícia Moraes" },
                    { 4, "Cassazum", "/Imagens/Candidatas/cassazum.png", "/Imagens/Clubes/cassazum.png", "Natália Leão" },
                    { 5, "Clube de Engenharia", "/Imagens/Candidatas/engenharia.png", "/Imagens/Clubes/engenharia.png", "Heloysa Rodrigues" },
                    { 6, "Clube do Remo", "/Imagens/Candidatas/remo.png", "/Imagens/Clubes/remo.png", "Gabrielle Costa" },
                    { 7, "Clube dos Advogado", "/Imagens/Candidatas/oab.png", "/Imagens/Clubes/oab.png", "Lídia Negrão" },
                    { 8, "Grêmio Português ", "/Imagens/Candidatas/gremio.png", "/Imagens/Clubes/gremio.png", "Ana Karina" },
                    { 9, "Acqua Park", "/Imagens/Candidatas/guara.png", "/Imagens/Clubes/guara.png", "Giselly Geise" },
                    { 10, "Pará Clube", "/Imagens/Candidatas/clubepara.png", "/Imagens/Clubes/clubepara.png", "Evelyn Moreira" },
                    { 11, "Paysandu", "/Imagens/Candidatas/paysandu.png", "/Imagens/Clubes/paysandu.png", "Tais Malato" },
                    { 12, "Tênis Clube", "/Imagens/Candidatas/tenis.png", "/Imagens/Clubes/tenis.png", "Ana Maria Marques" },
                    { 13, "Tuna Luso", "/Imagens/Candidatas/tuna.png", "/Imagens/Clubes/tuna.png", "Ingrid Kácia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Candidatas");
        }
    }
}
