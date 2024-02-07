using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RRProject.API.Migrations
{
    /// <inheritdoc />
    public partial class DB_CandidataImgURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Clube = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Beleza = table.Column<int>(type: "int", nullable: false),
                    Fantasia = table.Column<int>(type: "int", nullable: false),
                    Apresentacao = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidatas",
                columns: new[] { "Id", "Apresentacao", "Beleza", "Clube", "Comentario", "Fantasia", "ImagemUrl", "Nome", "Total" },
                values: new object[,]
                {
                    { 1, 0, 0, "Paysandu", null, 0, "/Imagens/Candidatas/Paysandu.png", "Rayane Furtado", 0 },
                    { 2, 0, 0, "Grêmio Literário e Recreativo Português", null, 0, "/Imagens/Candidatas/Grêmio Literário e Recreativo Português.png", "Giovanna Cristinne Silva Picanço", 0 },
                    { 3, 0, 0, "Assembleia Paraense", null, 0, "/Imagens/Candidatas/Assembléia Paraense.png", "Isadora Andrade Rêgo", 0 },
                    { 4, 0, 0, "Bancrévea", null, 0, "/Imagens/Candidatas/Bancrévea.png", "Érica Venise da Silva Pinto", 0 },
                    { 5, 0, 0, "Guará Acqua Park", null, 0, "/Imagens/Candidatas/Guará Acqua Park.png", "Aline Carla Rodrigues Wanderley", 0 },
                    { 6, 0, 0, "ASALP", null, 0, "/Imagens/Candidatas/ASALP.png", "Ádria Mayara Pantoja Nogueira", 0 },
                    { 7, 0, 0, "Tuna Luso Brasileira ", null, 0, "/Imagens/Candidatas/Tuna Luso Brasileira.png", "Janaína Pontes Ferreira", 0 },
                    { 8, 0, 0, "Tênis Clube do Pará", null, 0, "/Imagens/Candidatas/Tênis Clube.png", "Ana de Nazaré Martins Barbosa", 0 },
                    { 9, 0, 0, "Clube do Remo", null, 0, "/Imagens/Candidatas/Clube do Remo.png", "Adriana dos Santos Pinheiro", 0 },
                    { 10, 0, 0, "Iate Clube de Santarém", null, 0, "/Imagens/Candidatas/Iate Clube de Santarém.png", "Monã Rita Vianna de Oliveira", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
