using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ibge = table.Column<int>(nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(maxLength: 80, nullable: false),
                    Longitude = table.Column<string>(maxLength: 25, nullable: false),
                    Latitude = table.Column<string>(maxLength: 25, nullable: false),
                    Regiao = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_Ibge",
                table: "cities",
                column: "Ibge",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_Uf_Cidade",
                table: "cities",
                columns: new[] { "Uf", "Cidade" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
